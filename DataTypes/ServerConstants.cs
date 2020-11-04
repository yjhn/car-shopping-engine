namespace DataTypes
{
    public class ServerConstants
    {
        public const string Host = "0.0.0.0";
        public const string HostForClients = "localhost";
        public const int Port = 8888;
        public const string HttpVersion = "HTTP/1.1";
        public const string Scheme = "https";
        public const string HeaderSeparator = "\r\n";
        public const int MaxBufferSize = 5000;
        public const int MaxAttempts = 5000;
        public const int ServerTimeout = 200;
        public const int ClientTimeout = 5000;
        // constants for SSL certificate
        public const string CertFileName = @"..\..\..\ssl-certificate.pfx";
        public const string Password = "burbulometodas";

    }
}