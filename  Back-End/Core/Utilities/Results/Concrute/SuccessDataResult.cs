using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrute
{
    public class SuccessDataResult<Tip> : DataResult<Tip> 
    {
        public SuccessDataResult(Tip data , String message ):base(data,true,message)
        {
        }

        public SuccessDataResult(Tip data):base(data,true)
        {

        }

        public SuccessDataResult(String message):base(default,true,message)
        {
        }
         
        public SuccessDataResult():base(default,true)
        {
        }



    }
}
