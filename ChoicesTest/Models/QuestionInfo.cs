using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoicesTest.Models
{
    public class QuestionInfo
    {
        [BsonId]
        public int id { get; set; }

        [BsonElement("question")]
        public string question { get; set; }

        [BsonElement("answerA")]
        public string answerA { get; set; }

        [BsonElement("answerB")]
        public string answerB { get; set; }

        [BsonElement("answerC")]
        public string answerC { get; set; }

        [BsonElement("answerD")]
        public string answerD { get; set; }

        [BsonElement("answer")]
        public string answer { get; set; }

        [BsonElement("color")]
        public string color { get; set; } = "none";

        [BsonElement("answerdisplay")]
        public string answerDisplay { get; set; } = "none";
    }
}
