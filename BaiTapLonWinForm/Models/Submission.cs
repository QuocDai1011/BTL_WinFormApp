using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonWinForm.Models
{
    public class Submission
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("assignment_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AssignmentId { get; set; }

        [BsonElement("class_id")]
        public int ClassId { get; set; }

        [BsonElement("student_id")]
        public int StudentId { get; set; }

        [BsonElement("student_name")]
        public string StudentName { get; set; }

        [BsonElement("links")]
        public List<string> Links { get; set; } = new();

        [BsonElement("attempt")]
        public int Attempt { get; set; }

        [BsonElement("submitted_at")]
        public DateTime? SubmittedAt { get; set; }

        [BsonElement("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [BsonElement("is_late")]
        public bool IsLate { get; set; }

        [BsonElement("score")]
        public int? Score { get; set; }

        [BsonElement("feedback")]
        public string Feedback { get; set; }

        [BsonElement("graded_at")]
        public DateTime? GradedAt { get; set; }

        [BsonElement("teacher_id")]
        public int? TeacherId { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }
        // submitted | graded | completed

        [BsonElement("is_completed")]
        public bool IsCompleted { get; set; }

        [BsonElement("completed_at")]
        public DateTime? CompletedAt { get; set; }
    }
}
