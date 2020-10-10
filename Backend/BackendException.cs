using System;

namespace Backend
{
    class BackendException : Exception
    {
        public BackendException(string message, Exception cause) : base(message, cause) { }
    }
}
