using System;
using System.Collections.Generic;

namespace Server
{
    public static class Clients
    {
        readonly private static Dictionary<string, int> _registeredClients = new Dictionary<string, int>();
        readonly private static Dictionary<string, DateTime> _clientTimes = new Dictionary<string, DateTime>();
        public static int Register(string username)
        {
            var r = new Random();
            bool success = true;
            do
            {
                int session = r.Next();
                if (!_registeredClients.ContainsKey(username))
                {
                    _registeredClients.Add(username, session);
                    _clientTimes.Add(username, DateTime.UtcNow);
                }
                else
                {
                    _registeredClients[username] = session;
                    _clientTimes[username] = DateTime.UtcNow;
                }
                int sessionRepeated = 0;
                foreach (KeyValuePair<string, int> kvp in _registeredClients)
                    if (session == kvp.Value)
                        sessionRepeated++;
                if (sessionRepeated > 1)
                    success = false;
            }
            while (!success);

            return _registeredClients[username];
        }

        public static bool Verify(int session)
        {
            foreach (KeyValuePair<string, int> kvp in _registeredClients)
                if (kvp.Value == session)
                {
                    TimeSpan interval = DateTime.UtcNow - _clientTimes[kvp.Key];
                    if (interval.Hours > 0)
                        return false;
                    else
                        return true;
                }
            return false;
        }
    }
}