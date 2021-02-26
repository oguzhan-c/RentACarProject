using Core.Utilities.Results.Abstruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrute
{
    public class DataResult<Tip> : Result, IDataResult<Tip>
    {
        public Tip Data { get; }

        public DataResult(Tip data , bool success ,String message):base(success,message)
        {
            Data = data;
        }

        public DataResult(Tip data , bool success):base(success)
        {
            Data = data;
        }
    }
}
