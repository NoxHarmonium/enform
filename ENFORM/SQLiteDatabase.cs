using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using NeuronDotNet.Core;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ENFORM
{
    public class SQLiteDatabase
    {
        private SQLiteConnection connection;
        
        public SQLiteDatabase(string filename)
        {
            connection = new SQLiteConnection(
                "Data Source=" + filename
                );
        }

        private void Open()
        {
            connection.Open();
        }

        private void Close()
        {
            connection.Close();
        }

        public int RunQueryNoResult(string query)
        {
            
            SQLiteCommand command = new SQLiteCommand(query, connection);
            Open();
            int result = command.ExecuteNonQuery();
            Close();
            return result;
        }

        public DataSet RunQuery(string query)
        {
            
            DataSet result = new DataSet();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            Open();
            adapter.Fill(result);
            Close();
            return result;

        }

        private int insertBLOB(byte[] buffer)
        {
            int rowId = -1;
            SQLiteTransaction transaction = null;
            try
            {
                Open();
                transaction = connection.BeginTransaction();
             



                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO BLOBS VALUES (NULL,@image); ";
                command.Parameters.Add("@image", DbType.Binary).Value = buffer;
                command.Transaction = transaction;
                command.ExecuteNonQuery();


                command = new SQLiteCommand();
                command.CommandText = "SELECT last_insert_rowid();";
                command.Transaction = transaction;
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rowId = (int)(long)reader[0];
                }

                transaction.Commit();
            }

            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Close();
            }

            return rowId;


        }

        public int InsertBLOBNetwork(Network network)
        {

            MemoryStream stream = new MemoryStream();


            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, network);
            stream.Seek(0, SeekOrigin.Begin);
            Network test = (Network)formatter.Deserialize(stream);


           
            
            stream.Seek(0, SeekOrigin.Begin);
            byte[] data = new byte[stream.Length];
            int i = 0;
            int b;
            while ((b = stream.ReadByte()) != -1)
            {
                data[i++] = (byte)b;
            }
           
            stream.Close();

            return insertBLOB(data);
            
            

        }


        public int InsertBLOBImage(Bitmap image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);
               
            return insertBLOB(stream.GetBuffer());

        }

        private byte[] retrieveBLOB(int index)
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT BLOBData " +
                "FROM BLOBs " +
                "WHERE BLOBIndex='" +
                 index +
                 "';";

            Open();
            SQLiteDataReader reader = command.ExecuteReader();


            byte[] buffer = null; ;
            while (reader.Read())
            {
                buffer = GetBytes(reader);
            }
            Close();
            return buffer;
        }

        public Network RetrieveBLOBNetwork(int index)
        {
            byte[] buffer = retrieveBLOB(index);
            MemoryStream stream = new MemoryStream(buffer, false);            


            BinaryFormatter formatter = new BinaryFormatter();
            return (Network) formatter.Deserialize(stream);

        }

        public Bitmap RetrieveBLOBImage(int index)
        {

            byte[] buffer = retrieveBLOB(index);
            
            MemoryStream stream = new MemoryStream(buffer, false);
            Image image = Bitmap.FromStream(stream);    


            return (Bitmap)image;
        }


        /*http://stackoverflow.com/questions/625029/how-do-i-store-and-retrieve-a-blob-from-sqlite*/
        static byte[] GetBytes(SQLiteDataReader reader)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    byte[] actualRead = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, actualRead, 0, (int)bytesRead);
                    stream.Write(actualRead, 0, actualRead.Length);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }


    }
}
