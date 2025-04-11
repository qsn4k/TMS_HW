using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_12_1
{
    class WrongLoginExpection: Exception
    {
        public WrongLoginExpection() : base()
        {

        }

        public WrongLoginExpection(string? message) : base(message)
        {
        }
    }

    class WrongPasswordExpection : Exception
    {
        public WrongPasswordExpection() : base()
        {
        }

        public WrongPasswordExpection(string? message) : base(message)
        {
        }
    }
}
