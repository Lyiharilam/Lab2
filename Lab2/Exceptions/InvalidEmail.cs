using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exceptions
{
    internal class InvalidEmail : Exception
    {
        public InvalidEmail(string? message) : base(message)
        {

        }
    }
}
