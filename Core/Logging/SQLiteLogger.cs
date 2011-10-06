using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading;
using System.Data.SQLite;

namespace ENFORM.Core.Logging
{
    public class SQLiteLogger : ILogger
    {
        private const string databaseSQL =
            "CREATE TABLE [Log] (" +
            "[LogID] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
            "[SessionID] INTEGER  NULL," +
            "[Thread] TEXT  NULL," +
            "[Message] TEXT  NULL," +
            "[Time] TIMESTAMP DEFAULT 'datetime(''now'',''localtime'')' NULL" +
            ");" +
            "CREATE TABLE [Sessions] (" +
            "[SessionID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL," +
            "[Time] TIMESTAMP DEFAULT 'datetime(''now'',''localtime'')' NULL" +
            ");";

        private int sessionID = -1;
        private SQLiteDatabase database;


        public void StartLogger()
        {
            
            database = new SQLiteDatabase("log.sqlite");
            if (!File.Exists("log.sqlite"))
            {
                SQLiteConnection.CreateFile("log.sqlite");
                
                database.RunQueryNoResult(databaseSQL);
            }


            DataSet result = database.RunQuery(
                "INSERT INTO Sessions VALUES (NULL,datetime('now','localtime'));" + 
                "SELECT last_insert_rowid();");
            sessionID = Convert.ToInt32(result.Tables[0].Rows[0][0]);
           
            


            
        }

        public void Log(string message)
        {
            lock (database)
            {
                database.RunQueryNoResult("INSERT INTO Log VALUES (NULL,'" +
                    sessionID.ToString() + "','" +
                    Thread.CurrentThread.Name + "','" +
                    message + "',datetime('now','localtime'));");
            }
        }

        public void Log(string format, params object[] args)
        {
            Log(String.Format(format, args));
        }

        public void StopLogger()
        {
            
        }
    }
}
