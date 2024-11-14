using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
            
        }

        public ErrorResult(string Message) : base(Message, false)
        {
            
        }
    }
}
