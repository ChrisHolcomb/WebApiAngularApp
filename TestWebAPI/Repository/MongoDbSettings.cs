namespace TestWebAPI.Repository;

public class MongoDbSettings
{
    public string Host { get; init; }
    public int Port { get; init; }
    // public string ConnectionString => $"mongodb://{Host}:{Port}";
    private string connectionString;

    public string ConnectionString
    {
        get => string.IsNullOrEmpty(connectionString) ? $"mongodb://{Host}:{Port}" : connectionString;
        init => connectionString = value;
    }
}