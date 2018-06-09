using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public class Response
    {
        public string ErrorMessage { get; private set; }

        public Result Result { get; }

        public Response(Result result)
        {
            this.Result = result;
            this.ErrorMessage = string.Empty;
        }

        public Response(Exception e)
        {
            this.ErrorMessage = e.Message;
            this.Result = Result.Failure;
        }
    }
}
