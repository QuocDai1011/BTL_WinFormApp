using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BaiTapLonWinForm.Models
{
    public class Newsfeed
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("user_id")]
        public int UserId { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("link_path_in_cloud")]
        public List<string> LinkPathInCloud { get; set; }

        [BsonElement("posting_at")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime PostingAt { get; set; }

        [BsonElement("update_at")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdateAt { get; set; }

        [BsonElement("class_id")]
        public int ClassId { get; set; }

        [BsonElement("contentHtml")]
        public string ContentHtml { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
        
        [BsonElement("is_published")]
        public bool IsPublished { get; set; }
    }
}