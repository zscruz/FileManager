namespace Utilities
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        public bool IsError { get; set; }

        public ErrorEventArgs ErrorArgs { get; set; }

        private Result()
        {
            this.IsSuccess = true;
            this.IsError = false;
            this.ErrorArgs = null;
        }

        private Result(string header, string message)
        {
            this.IsSuccess = false;
            this.IsError = true;
            this.ErrorArgs = new ErrorEventArgs
            {
                Header = header,
                Message = message,
            };
        }

        public static Result GetSuccessfulResult()
        {
            return new Result();
        }

        public static Result GetErrorResult(string errorHeaderMessage, string errorBodyMessage)
        {
            return new Result(errorHeaderMessage, errorBodyMessage);
        }
    }
}
