using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class Result : IResult
    {
        public string Message { get; }
        public bool IsSuccess { get; }
            
        public Result(bool isSucces) 
        {
            this.IsSuccess = isSucces;
        }

        public Result(string Message, bool IsSucces) : this(IsSucces) 
        {
            this.Message = Message;
        }
    }
}
