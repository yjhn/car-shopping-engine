namespace DataTypes
{
    public class ServerConstants
    {
        public const string Host = "0.0.0.0";
        public const string HostForClients = "localhost";
        public const string Ip = "80.209.238.247";
        //public const string IpLocal = "127.0.0.1";
        public const int Port = 8888;
        public const string HttpVersion = "HTTP/1.1";
        public const string Scheme = "https";
        public const string HeaderSeparator = "\r\n";
        public const int MaxBufferSize = 5000000;
        public const int MaxAttempts = 5000;
        public const int ServerTimeout = 200; //should be excluded
        public const int ClientTimeout = 5000;
        // constants for SSL certificate should be removed
        public const string CertFileName = @"ssl-certificate.pfx";
        public const string CertFileNameLocal = @"..\..\..\ssl-certificate.pfx";

        public const string Password = "burbulometodas";

    }
}