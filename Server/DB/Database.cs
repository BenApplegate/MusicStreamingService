using MongoDB.Bson;
using MongoDB.Driver;
using Server.Utility;

namespace Server.DB;

public class Database
{
    private static MongoClient? _client;
    private static IMongoDatabase? _database;

    internal static IMongoCollection<BsonDocument>? _ratingsCollection;
    internal static IMongoCollection<BsonDocument>? _playlistsCollection;
    internal static IMongoCollection<BsonDocument>? _usersCollection;
    internal static IMongoCollection<BsonDocument>? _albumsCollection;
    internal static IMongoCollection<BsonDocument>? _songsCollection;

    public static void Connect()
    {
        string? connectionURI = ServerSettings.GetSetting("databaseURI");
        if (connectionURI is null)
        {
            Logger.Error("Could not connect to database, you need to specify the URI to the mongo server in server.settings");
            return;
        }

        _client = new MongoClient(connectionURI);
        Logger.Info("Database connected, found following databases");
        foreach (var db in _client.ListDatabaseNames().ToList())
        {
            Logger.Info(db);
        }

        _database = _client.GetDatabase("music");
        Logger.Info("Database connected, found following collections");
        foreach (var db in _database.ListCollectionNames().ToList())
        {
            Logger.Info(db);
        }

        _ratingsCollection = _database.GetCollection<BsonDocument>("ratings");
        _playlistsCollection = _database.GetCollection<BsonDocument>("playlists");
        _usersCollection = _database.GetCollection<BsonDocument>("users");
        _albumsCollection = _database.GetCollection<BsonDocument>("albums");
        _songsCollection = _database.GetCollection<BsonDocument>("songs");
        
        Logger.Info("Database connection successful");
    }

    public static void Close()
    {
        _client.Dispose();
    }
}