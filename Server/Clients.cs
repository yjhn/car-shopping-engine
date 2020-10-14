using System;
using System.Collections.Generic;

namespace Server
{
    public static class Clients
    {
        private static Dictionary<string, int> registeredClients = new Dictionary<string, int>();
        private static Dictionary<string, DateTime> clientTimes = new Dictionary<string, DateTime>();
        public static int Register(string username)
        {
            var r = new Random();
            if (!registeredClients.ContainsKey(username))
            {
                registeredClients.Add(username, r.Next());
                clientTimes.Add(username, DateTime.UtcNow);
            }
            else
            {
                registeredClients[username] = r.Next();
                clientTimes[username] = DateTime.UtcNow;
            }
            return registeredClients[username];
        }

        public static bool Verify(string username, int id)
        {
            if (!registeredClients.ContainsKey(username))
                return false;
            if (registeredClients[username] != id)
                return false;
            TimeSpan interval = DateTime.UtcNow - clientTimes[username];
            if (interval.Hours > 0)
                return false;
            return true;
        }
    }
}