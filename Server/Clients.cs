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
            bool success = true;
            do
            {
                int session = r.Next();
                if (!registeredClients.ContainsKey(username))
                {
                    registeredClients.Add(username, session);
                    clientTimes.Add(username, DateTime.UtcNow);
                }
                else
                {
                    registeredClients[username] = session;
                    clientTimes[username] = DateTime.UtcNow;
                }
                int sessionRepeated = 0;
                foreach (KeyValuePair<string, int> kvp in registeredClients)
                    if (session == kvp.Value)
                        sessionRepeated++;
                if (sessionRepeated > 1)
                    success = false;
            }
            while (!success);

            return registeredClients[username];
        }

        public static bool Verify(int session)
        {
            foreach (KeyValuePair<string, int> kvp in registeredClients)
                if (kvp.Value == session)
                {
                    TimeSpan interval = DateTime.UtcNow - clientTimes[kvp.Key];
                    if (interval.Hours > 0)
                        return false;
                    else
                        return true;
                }
            return false;
        }
    }
}