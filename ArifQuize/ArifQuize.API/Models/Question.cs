using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Question
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Text { get; set; }
    public List<string> Options { get; set; }
    public int CorrectOption { get; set; }
    public string Explanation { get; set; }
}
