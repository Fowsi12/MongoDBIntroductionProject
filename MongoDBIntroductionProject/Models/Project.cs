using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBIntroductionProject.Models
{
    public class Project
    {
        [BsonId]
        public string Id { get; set; }

        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }

        public string Status { get; set; }
    }
}