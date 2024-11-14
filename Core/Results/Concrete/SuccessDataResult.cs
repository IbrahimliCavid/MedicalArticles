using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T Data) : base(Data, true){}
        public SuccessDataResult(T Data, string Message) : base(Data, Message, true) { }
    }
}
