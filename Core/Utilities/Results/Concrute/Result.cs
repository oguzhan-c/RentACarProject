using Core.Utilities.Results.Abstruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrute
{
    //Void olan classları içerir
    public class Result : IResult
    {
        public bool Succcess { get; }

        public string Message { get; }

        //Getter readonly dir readonly ler constructorda set edilebilir.
        //Tekrarı önlemek adına this kullanarak birinci ctor çalışınca 
        //zaten 2. ctrordaki gibi succes de çalışacak 
        //bu yüzden 1.ctor un içinden succesi sildik ve this(succes) yaparak 
        //1.ctor çalışınca 2.ctorda çalışsın dedik 
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        //overloading
        public Result(bool success)
        {
            Succcess = success;
        }

        
    }
}
