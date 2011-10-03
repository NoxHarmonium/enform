﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NeuronDotNet.Core;


namespace ENFORM
{
    public class DataAccess
    {

        SQLiteDatabase database;
        protected string filename;

        public DataAccess(string filename)
        {
            this.filename = filename;
            database = new SQLiteDatabase(filename);
            //Create database structure for new files
            if (!File.Exists(filename))
            {
                CreateNewRunFile(filename);
            }
        
           
            

        }

        public void ClearFile()
        {
            database.RunQueryNoResult("DELETE FROM InputGroups;");
            database.RunQueryNoResult("DELETE FROM Parameters;");
            database.RunQueryNoResult("DELETE FROM Sources;");
            database.RunQueryNoResult("DELETE FROM InputGroups;");
            database.RunQueryNoResult("DELETE FROM BLOBS WHERE EXISTS (SELECT ImageBLOBref FROM Sources)");
        }

        public void NewFile()
        {
            File.Delete(filename);
            CreateNewRunFile(filename);
        }

        public string GetParameter(string key)
        {
            string query = 
                "SELECT ParameterValue " +
                "FROM Parameters " +
                "WHERE ParameterName='" + key + "';";

            DataSet result = database.RunQuery(query);
            if (result.Tables[0].Rows.Count > 0)
            {
                return result.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

        }

        public void SetParameter(string key, string value)
        {
            string query =
                "REPLACE INTO Parameters " +
                "VALUES ('" + key + "','" + value + "');";

            database.RunQueryNoResult(query);
            
        }



        public Network GetNetwork(int BlobIndex)
        {
            return database.RetrieveBLOBNetwork(BlobIndex);

        }

        public void SaveResult(string jobUUID, INetwork finalNetwork, int iterations, float[] results, DateTime startTime, DateTime endTime)
        {

            /*
              CREATE TABLE [Runs] (
                [RunID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL,
                [StartTime] TIMESTAMP  NULL,
                [EndTime] TIMESTAMP  NULL,
                [Status] INTEGER  NULL,
                [BLOBindex] INTEGER  NULL,
                [JobUUID] TEXT NULL
                );            
             */
            int networkID = database.InsertBLOBNetwork(finalNetwork);
            int runid = 0;
           
            //string sStartTime = "strftime('%s','2004-01-01 02:34:56');"



            string query = "INSERT INTO RUNS\n" + 
                "VALUES (NULL," +
                 "'" + startTime.ToString("yyyy-MM-dd HH:mm:ss") +"'," +
                "'" + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "'0','" + 
                networkID.ToString() + "','" + 
                jobUUID +"');"+
                "SELECT last_insert_rowid();";

            DataSet result = database.RunQuery(query);
            runid = Convert.ToInt32(result.Tables[0].Rows[0][0]);

            /*
            StringBuilder s = new StringBuilder();
            //query = "BEGIN TRANSACTION;\n";

            for (int i = 0; i < iterations; i += 2)
            {
                s.AppendLine("INSERT INTO Results \n" +
                    "VALUES(NULL,'" + runid.ToString() + "','" + i / 2 + "','" + results[i + 1].ToString() + "','" + results[i].ToString() + "');");

            }


            //query += "COMMIT TRANSACTION;\n";

            database.RunQueryNoResult(s.ToString());
            */
            string[][] items = new string[iterations/2][];
            
            for (int i = 0; i < iterations; i += 2)
            {                
                items[i/2] = new string[] { runid.ToString(),Convert.ToString(i/2),results[i + 1].ToString(),results[i].ToString()};
            }

            database.BatchInsert("Results", items);

        }

        public Run[] GetRuns()
        {
            string query = "SELECT ru.RunId," +
                           "ru.StartTime," +
                            "ru.EndTime," +
                            "ru.Status," +
                            "ru.BLOBIndex," +
                            "ru.JobUUID," +
                            "re.Fitness " +
                            "FROM (" +
                            "SELECT *, MAX(Iteration) FROM " +
                            "Results " +
                            "GROUP BY RunID " +
                            ") as re inner join Runs as ru " +
                            "ON re.RunID = ru.RunID;";
            DataSet result = database.RunQuery(query);
            List<Run> list = new List<Run>();
            if (result.Tables.Count > 0)
            {
                
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    list.Add(new Run(
                        Convert.ToInt32(row[0]),
                        DateTime.Parse(row[1].ToString()),
                        DateTime.Parse(row[2].ToString()),
                        Convert.ToInt32(row[3]),
                        Convert.ToInt32(row[4]),
                        row[5].ToString(),
                        Convert.ToSingle(row[6])));

                }
                return list.ToArray();
            }
            else
            {
                return new Run[0];
            }


        }


        public SourceItem[] GetSourceItems()
        {
            string query =
                "SELECT * " +
                "FROM Sources; ";//+
                //"ORDER BY Index;";

            DataSet result = database.RunQuery(query);
            if (result.Tables.Count > 0)
            {

                SourceItem[] items = new SourceItem[result.Tables[0].Rows.Count];

                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    DataRow row = result.Tables[0].Rows[i];
                    SourceType sourceType = (SourceType)Convert.ToInt32(row["SourceType"]);
                    Image cachedImage = null;
                    SourceItem item;

                    if ((bool)row["Cached"])
                    {
                        int index = Convert.ToInt32(row["ImageBLOBRef"]);


                        cachedImage = database.RetrieveBLOBImage(index);
                        


                    }

                    if (sourceType == SourceType.FileSystem)
                    {
                        if (cachedImage == null)
                        {
                            item = new SourceItem(
                                row["Filename"].ToString(),
                                Convert.ToInt32(row["SampleType"]),
                                row["Name"].ToString());
                        }
                        else
                        {
                            item = new SourceItem(
                                row["Filename"].ToString(),
                                Convert.ToInt32(row["SampleType"]),
                                row["Name"].ToString(),
                                cachedImage);

                        }
                    }
                    else
                        if (sourceType == SourceType.Custom)
                        {
                            Size size = new Size(
                                Convert.ToInt32(row["Width"]),
                                Convert.ToInt32(row["Height"]));
                            item = new SourceItem(size, Convert.ToInt32(row["SampleType"]), row["Name"].ToString());
                            item.InternalImage = cachedImage;
                        }
                        else
                        {
                            throw new NotImplementedException("Source Type '" +
                                sourceType.ToString() +
                                " is not implemented yet");
                        }
                    //item.SourceType = (SourceType) Convert.ToInt32(row["SourceType"]);

                   
                    items[i] = item;
                }



                return items;
            }
            return new SourceItem[0];
        }

        public InputGroup[] GetInputGroups()
        {
            string query =
               "SELECT * " +
               "FROM InputGroups; ";// +
               //"ORDER BY Index;";

            DataSet result = database.RunQuery(query);
            

            if (result.Tables.Count > 0)
            {
                InputGroup[] inputGroups = new InputGroup[result.Tables[0].Rows.Count];
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    DataRow row = result.Tables[0].Rows[i];
                    InputGroup inputGroup = new InputGroup(
                        (InputGroupType)Convert.ToInt32(row["Type"]),
                        Convert.ToInt32(row["Segments"]));
                    inputGroups[i] = inputGroup;
                }
                return inputGroups;
            }
            return new InputGroup[0];
        }

        public void AddInputGroup(int index, InputGroup inputGroup)
        {
            string query =
               "REPLACE INTO InputGroups " +
               "VALUES ('" + 
               index + "','" +
               (int)inputGroup.InputGroupType + "','" + 
               inputGroup.Segments + "');";

            database.RunQueryNoResult(query);

        }

        public void AddSource(int index, SourceItem sourceItem)
        {
            int blobIndex = -1;
            if (sourceItem.Cached)
            {
                blobIndex = database.InsertBLOBImage((Bitmap)sourceItem.InternalImage);
            }
            
            string query =
               "REPLACE INTO Sources " +
               "VALUES ('" +
               index + "','" +
               sourceItem.Name + "','" +
               sourceItem.Filename + "','" +
               sourceItem.Size.Width + "','" +
               sourceItem.Size.Height + "','" +
               (int)sourceItem.SampleType + "','" +
               Convert.ToInt32(sourceItem.Cached) + "','" +
               blobIndex + "','" +
               (int)sourceItem.SourceType + "');";
                
               database.RunQueryNoResult(query);
        }

        private void CreateNewRunFile(string filename)
        {
            SQLiteConnection.CreateFile(filename);
            string query = Properties.Resources.templateDatabaseSQL;
            database.RunQueryNoResult(query);
           

        }


        



    }
}
