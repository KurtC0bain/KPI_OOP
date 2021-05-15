using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// Exception that processes an existing of a dish in current order
    /// </summary>
    /// <remarks>
    /// <para>Show a message of existence</para>
    /// <para>Inherited from <c>Exception</c> class</para>
    /// </remarks>
    public class AlreadyExistException : Exception
    {
        static string explain = "This dish already exists in your order\nJust select the amount";
        public AlreadyExistException() : base(explain)
        { }
    }
}
