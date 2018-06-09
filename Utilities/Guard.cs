using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Guard
    {
        public static void AgainstNull(object test, string parameterName)
        {
            if (test == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void AgainstNullAndEmpty(string test, string parameterName)
        {
            AgainstNull(test, parameterName);
            if (test == string.Empty)
            {
                throw new ArgumentException(parameterName);
            }
        }
    }
}
