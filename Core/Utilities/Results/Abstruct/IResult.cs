using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstruct
{
    //Void içeren class IREsult 
    public interface IResult
    {
        bool Succcess { get; }
        string Message { get; }
    }
}
