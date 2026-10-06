using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MongoDBIntroductionProject.Models
{
    public class Project
    {
        [BsonId]
        public string Id { get; set; }

        public  string ProjectId { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  DateTime Start_Date { get; set; }
    }
}
