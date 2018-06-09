using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public class Response<T> : Response
    {
        public T Data { get; private set; }

        public Response(T data) : base(Result.Success)
        {
            this.Data = data;
        }

        public Response(Result result) : base(result)
        {
            this.Data = default(T);
        }

        public Response(Exception e) : base(e)
        {
            this.Data = default(T);
        }
    }
}
