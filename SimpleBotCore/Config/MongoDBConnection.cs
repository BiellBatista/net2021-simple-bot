namespace SimpleBotCore.Config
{
    public class MongoDBConnection
    {
        public string Database { get; set; } = "Chatbot";
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 27017;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Write { get; set; }
        public bool RetryWrites { get; set; } = true;
        public bool UseSSL { get; set; }
        public string AuthSource { get; set; }
        public string ReplicaSet { get; set; }

        public string GetConnectionDefault()
        {
            return $"mongodb://{Host}:{Port}/{Database}";
        }

        public string GetConnectionAtlas()
        {
            return $"mongodb://{Username}:{Password}@{Host}/{Database}?ssl={UseSSL}&replicaSet={ReplicaSet}&authSource={AuthSource}&retryWrites={RetryWrites}&w={Write}";
        }
    }
}