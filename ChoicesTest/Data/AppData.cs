using Microsoft.Data.Sqlite;
using MongoDB.Driver;
using System;
using ChoicesTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoicesTest.Data
{
    public class AppData
    {
        public MongoClient client = new("mongodb+srv://hieule:plh0801@cluster0.n2h9d.mongodb.net/examsdb?retryWrites=true&w=majority");
        public IMongoDatabase examdb;
        public IMongoCollection<Account> accounts;
        public IMongoCollection<Record> history;
        public IMongoCollection<Exam> exams;
        public bool admin { get; set; } = false;
        public string user { get; set; } = string.Empty;
        public string account { get; set; } = string.Empty;
        public bool logged { get; set; } = false;
        //public SqliteConnection connection= new SqliteConnection("Data Source=exams.db");
        public bool inited = false;

        public async Task<Tuple<int, bool>> GetExamPrivacyAndTimeAsync(string ExamCode)
        {
            var exam = await exams.Find(s => s.code == ExamCode).FirstOrDefaultAsync();
            return new Tuple<int, bool>(exam.time, exam.privacy);
        }

        public Tuple<int, bool> GetExamPrivacyAndTime(string ExamCode)
        {
            var exam = exams.Find(s => s.code == ExamCode).FirstOrDefault();
            return new Tuple<int, bool>(exam.time, exam.privacy);
            //var task = connection.OpenAsync();
            //var cmd = connection.CreateCommand();
            //cmd.CommandText = $"SELECT time,privacy FROM exam_collection WHERE code = '{ExamCode}'";
            //await task;
            //using var rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    return new Tuple<int,bool>(rdr.GetInt16(0), rdr.GetInt16(1) == 1);
            //}
            //return new Tuple<int, bool>(0, false);
        }

        public List<Account> GetAccounts()
        {
            return accounts.Find(s => true).ToList();
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            var collection = accounts.Find(s => true);
            var res = await collection.ToListAsync();
            return res;
        }

        public List<Exam> GetExams()
        {
            return exams.Find(s => true).ToList();
        }

        public async Task<List<Exam>> GetExamsAsync()
        {
            var collection = exams.Find(s => true);
            var res = await collection.ToListAsync();
            return res;
        }

        public async Task CreateNewExam(string ExamCode)
        {
            await examdb.CreateCollectionAsync(ExamCode);
        }

        public void Initialize()
        {
            examdb = client.GetDatabase("examaccess");
            accounts = examdb.GetCollection<Account>("accounts");
            exams = examdb.GetCollection<Exam>("exams");
            history = examdb.GetCollection<Record>("history");
            //var task = connection.OpenAsync();
            //var myCmd = connection.CreateCommand();
            //var myCmd2 = connection.CreateCommand();
            //var myCmd3 = connection.CreateCommand();
            //myCmd2.CommandText = "CREATE TABLE IF NOT EXISTS accounts(username TEXT PRIMARY KEY, password TEXT, name TEXT, admin INTEGER);";
            //myCmd3.CommandText = "CREATE TABLE IF NOT EXISTS history(id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, exam TEXT, score REAL, time TEXT);";
            //myCmd.CommandText = "CREATE TABLE IF NOT EXISTS exam_collection(code TEXT PRIMARY KEY, name TEXT, time INTEGER, label TEXT, privacy INTEGER);";
            //await task;
            //myCmd.ExecuteNonQuery();
            //myCmd2.ExecuteNonQuery();
            //myCmd3.ExecuteNonQuery();
            inited = true;
        }
    }
}
