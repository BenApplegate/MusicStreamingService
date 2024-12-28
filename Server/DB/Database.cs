using MongoDB.Bson;
using MongoDB.Driver;
using Server.Utility;

namespace Server.DB;

public class Database
{
    private static MongoClient? _client;
    private static IMongoDatabase? _database;

    internal static IMongoCollection<BsonDocument>? RatingsCollection;
    internal static IMongoCollection<BsonDocument>? PlaylistsCollection;
    internal static IMongoCollection<BsonDocument>? UsersCollection;
    internal static IMongoCollection<BsonDocument>? AlbumsCollection;
    internal static IMongoCollection<BsonDocument>? SongsCollection;

    public static void Connect()
    {
        string? connectionUri = ServerSettings.GetSetting("databaseURI");
        if (connectionUri is null)
        {
            Logger.Error("Could not connect to database, you need to specify the URI to the mongo server in server.settings");
            return;
        }

        _client = new MongoClient(connectionUri);
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

        RatingsCollection = _database.GetCollection<BsonDocument>("ratings");
        PlaylistsCollection = _database.GetCollection<BsonDocument>("playlists");
        UsersCollection = _database.GetCollection<BsonDocument>("users");
        AlbumsCollection = _database.GetCollection<BsonDocument>("albums");
        SongsCollection = _database.GetCollection<BsonDocument>("songs");
        
        Logger.Info("Database connection successful");
    }

    public static void Close()
    {
        _client.Dispose();
    }
}