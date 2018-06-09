using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
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

        public static Result ShouldNotBeNullorEmpty(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                return Result.Success;
            }

            return Result.Failure;
        }
    }
}
