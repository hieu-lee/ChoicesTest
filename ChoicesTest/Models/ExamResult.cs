using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoicesTest.Models
{
    public class ExamResult : IComparable<ExamResult>
    {
        [BsonId]
        private ObjectId Id;

        [BsonElement("examcode")]
        public string examCode { get; set; }

        [BsonElement("score")]
        public double score { get; set; }

        [BsonElement("time")]
        public string time { get; set; }

        public int CompareTo(ExamResult other)
        {
            return score.CompareTo(other.score);
        }
    }
}
