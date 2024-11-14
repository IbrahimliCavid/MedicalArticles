using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
            
        }

        public SuccessResult(string Message) : base(Message, true)
        {
            
        }
    }
}
