using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Data) : base(Data, false)
        {
            
        }

        public ErrorDataResult(T Data , string Message) : base(Data, Message, false)
        {
            
        }
    }
}
