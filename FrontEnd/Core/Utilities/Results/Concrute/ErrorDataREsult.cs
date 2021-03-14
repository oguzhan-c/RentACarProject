using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrute
{
    public class ErrorDataResult<Tip> : DataResult<Tip>
    {
        public  ErrorDataResult(Tip data, String message) : base(data,false,message)
        {
        }

        public ErrorDataResult(Tip data) : base(data,false)
        {

        }

        public ErrorDataResult(String message) : base(default, false, message)
        {
        }

        public ErrorDataResult() : base(default, false)
        {
        }



    }
}
