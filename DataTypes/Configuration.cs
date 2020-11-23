namespace DataTypes
{
    public struct Config
    {
        public string Ip
        { get; private set; }
        public int Port
        { get; private set; }
        public string HttpVersion
        { get; private set; }
        public string Scheme
        { get; private set; }
        public int Timeout
        { get; private set; }
        public int MaxBufferSize
        { get; private set; }
        public int MaxAttempts
        { get; private set; }
        public string[] Extra
        { get; set; }

        public Config(string ip, int port, string httpVersion, string scheme, int maxBufferSize, int maxAttempts, int timeout)
        {
            Ip = ip;
            Port = port;
            HttpVersion = httpVersion;
            Scheme = scheme;
            MaxBufferSize = maxBufferSize;
            MaxAttempts = maxAttempts;
            Timeout = timeout;
            Extra = new string[0];
        }
    }
}