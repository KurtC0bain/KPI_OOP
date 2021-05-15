using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Exception that processes an reaching the max. amount of dishes in current order
    /// </summary>
    /// <remarks>
    /// <para>Show a message of reaching max.</para>
    /// <para>Inherited from <c>Exception</c> class</para>
    /// </remarks>
    public class LimitReachedException : Exception
    {
        static string explain = "Sorry, you can choose only 10 dishes for one bill";
        public LimitReachedException() : base(explain)
        { }
        

    }
}
