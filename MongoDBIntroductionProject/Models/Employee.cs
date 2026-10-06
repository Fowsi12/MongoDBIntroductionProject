using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBIntroductionProject.Models
{
    public class Employee
    {
        [BsonId]
        public  int EmployeeId { get; set; }
        public  string Name { get; set; }
        public  string Email { get; set; }
        public  Department Department { get; set; }
        public  List<Project> Myprojects { get; set; } = new List<Project>();
    }
}
