using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult( T Data, bool IsSuccess ) : base(IsSuccess)
        {
            this.Data = Data;
        }

        public DataResult(T Data, string Message, bool IsSuccess) : base(Message, IsSuccess ) 
        {
            this.Data = Data;
        }
    }
}
