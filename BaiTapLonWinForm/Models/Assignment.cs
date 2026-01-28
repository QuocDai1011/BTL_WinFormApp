using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaiTapLonWinForm.Models
{
    public class Assignment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("newsfeed_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string NewsfeedId { get; set; }

        [BsonElement("class_id")]
        public int ClassId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("start_time")]
        public DateTime StartTime { get; set; }

        [BsonElement("due_time")]
        public DateTime DueTime { get; set; }

        [BsonElement("max_score")]
        public int MaxScore { get; set; }

        [BsonElement("allow_late_submission")]
        public bool AllowLateSubmission { get; set; }

        [BsonElement("late_penalty_percent")]
        public int LatePenaltyPercent { get; set; }

        [BsonElement("max_attempts")]
        public int MaxAttempts { get; set; }

        [BsonElement("allow_multiple_links")]
        public bool AllowMultipleLinks { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } // draft | published | closed

        [BsonElement("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
