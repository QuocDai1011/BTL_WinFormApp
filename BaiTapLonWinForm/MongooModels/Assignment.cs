using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaiTapLonWinForm.MongooModels
{
    public class Assignment
    {
        // _id
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // assignment_id
        [BsonElement("newsfeed_id")]
        public string NewsfeedId { get; set; }

        // class_id
        [BsonElement("class_id")]
        public int ClassId { get; set; }

        // student_id
        [BsonElement("student_id")]
        public int StudentId { get; set; }

        // student_name
        [BsonElement("student_name")]
        public string StudentName { get; set; }

        // links
        [BsonElement("link")]
        public string Link { get; set; }

        // attempt
        [BsonElement("attempt")]
        public int Attempt { get; set; }

        // submitted_at
        [BsonElement("submitted_at")]
        public DateTime SubmittedAt { get; set; }

        // updated_at
        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // is_late
        [BsonElement("is_late")]
        public bool IsLate { get; set; }

        // score
        [BsonElement("score")]
        public double? Score { get; set; }

        // feedback
        [BsonElement("feedback")]
        public string? Feedback { get; set; }

        // graded_at
        [BsonElement("graded_at")]
        public DateTime? GradedAt { get; set; }

        // teacher_id
        [BsonElement("teacher_id")]
        public int? TeacherId { get; set; }

        // status
        [BsonElement("status")]
        public string Status { get; set; }

        // is_completed
        [BsonElement("is_completed")]
        public bool IsCompleted { get; set; }

        // completed_at
        [BsonElement("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [BsonElement("due_time")]
        public DateTime? DueTime { get; set; }
    }
}
