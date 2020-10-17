using System;
using System.Collections.Generic;
using System.Text;

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
