using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class AlreadyExistException : Exception
    {
        static string explain = "This dish already exists in your order\nJust select the amount";
        public AlreadyExistException() : base(explain)
        { }
    }
}
