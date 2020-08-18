using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp
{
    class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (uid INTEGER PRIMARY KEY, " +
                    "first_Name NVARCHAR(50) NOT NULL, " +
                    "last_Name NVARCHAR(50) NOT NULL," +
                    "email NVARCHAR(50) NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputid, string inputfirst_Name, string inputlast_Name, string inputemail)
        {
            //string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Customers VALUES(@uid, @first_Name, @last_Name, @email);";
                insertCommand.Parameters.AddWithValue("@uid", inputid);
                insertCommand.Parameters.AddWithValue("@first_Name", inputfirst_Name);
                insertCommand.Parameters.AddWithValue("@last_Name", inputlast_Name);
                insertCommand.Parameters.AddWithValue("@email", inputemail);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            //string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand ("SELECT uid, first_Name, last_Name, email from Customers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }

                db.Close();
            }

            return entries;
        }
    }
}
