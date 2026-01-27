using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.MongooModels;
using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {
        var client = new MongoClient("mongodb://root:root@localhost:27017/");
        _database = client.GetDatabase("english_center");
    }

    public IMongoCollection<Newsfeed> Newsfeeds =>
        _database.GetCollection<Newsfeed>("newsfeeds");


}
