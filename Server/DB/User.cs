using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Server.DB;

public class User
{
    [BsonId]
    public ObjectId _id { get; set; }
    
    [BsonElement("username")]
    public string Username { get; set; }
    
    [BsonElement("passwordHash")]
    public string PasswordHash { get; set; }
    
    [BsonElement("salt")]
    public string Salt { get; set; }
    
    private static (string hash, string salt) HashPassword(string passwordText)
    {
        //Generate random salt
        using var random = RandomNumberGenerator.Create();
        byte[] saltBytes = new byte[16];
        random.GetBytes(saltBytes);
        string salt = Convert.ToBase64String(saltBytes);

        //Salt and hash password
        string saltedPassword = passwordText + salt;
        using var sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        string hash = Convert.ToBase64String(hashBytes);

        return (hash, salt);
    }

    private static bool CheckPassword(string passwordText, string userHash, string salt)
    {
        //Salt an and hash password
        string saltedPassword = passwordText + salt;
        using var sha256 = SHA256.Create();
        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
        string hash = Convert.ToBase64String(hashBytes);

        //Check password validity
        return hash == userHash;
    }
}