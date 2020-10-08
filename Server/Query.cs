using System;
namespace Server
{
    public class Query
    {
        public String Name
        { get; }
        public string Value
        { get; }
        public Query(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return Name + "=" + Value;
        }
    }
}