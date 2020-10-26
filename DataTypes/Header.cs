using System.Collections.Generic;

namespace DataTypes
{
    public class Header
    {
        public string Name
        { get; }
        public string Value
        { get; }
        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public static bool Contains(List<Header> headers, string hName)
        {
            bool contains = false;
            foreach (Header h in headers)
                if (hName == h.Name)
                    contains = true;
            return contains;
        }

        public static string GetValueByName(List<Header> headers, string hName)
        {
            string hValue = "";
            foreach (Header h in headers)
                if (h.Name == hName)
                    hValue = h.Value;
            return hValue;
        }

    }
}