using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoicesTest.Models
{
    public class Record : IComparable<Record>
    {
        [BsonId]
        private ObjectId Id;

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("examcode")]
        public string examCode { get; set; }

        [BsonElement("score")]
        public double score { get; set; }

        [BsonElement("time")]
        public string time { get; set; }

        public int CompareTo(Record other)
        {
            return score.CompareTo(other.score);
        }
    }
}
