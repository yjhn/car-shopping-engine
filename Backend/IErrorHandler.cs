using System;

namespace Backend
{
    public interface IErrorHandler
    {
        public void Handle(Exception e)
        {
            ;
        }
    }
}
