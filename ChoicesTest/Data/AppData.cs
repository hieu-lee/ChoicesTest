using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoicesTest.Data
{
    public class AppData
    {
        public bool admin { get; set; } = false;
        public string user { get; set; } = string.Empty;
        public string account { get; set; } = string.Empty;
        public bool logged { get; set; } = false;
        public SqliteConnection connection= new SqliteConnection("Data Source=exams.db");
        public bool inited = false;

        public async Task<bool> GetExamPrivacyAsync(string ExamCode)
        {
            var task = connection.OpenAsync();
            var cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT privacy FROM exam_collection WHERE code = '{ExamCode}'";
            await task;
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return (rdr.GetInt16(0) == 1);
            }
            return false;
        }

        public async Task InitializeAsync()
        {
            var task = connection.OpenAsync();
            var myCmd = connection.CreateCommand();
            var myCmd2 = connection.CreateCommand();
            var myCmd3 = connection.CreateCommand();
            myCmd2.CommandText = "CREATE TABLE IF NOT EXISTS accounts(username TEXT PRIMARY KEY, password TEXT, name TEXT, admin INTEGER);";
            myCmd3.CommandText = "CREATE TABLE IF NOT EXISTS history(id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, exam TEXT, score REAL, time TEXT);";
            myCmd.CommandText = "CREATE TABLE IF NOT EXISTS exam_collection(code TEXT PRIMARY KEY, name TEXT, time INTEGER, label TEXT, privacy INTEGER);";
            await task;
            myCmd.ExecuteNonQuery();
            myCmd2.ExecuteNonQuery();
            myCmd3.ExecuteNonQuery();
            inited = true;
        }
    }
}
