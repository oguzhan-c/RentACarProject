using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstruct
{
    //interface interface yi implemente ederse 
    //implemente edilen interfacenin içindekileri yazmaya gerek yok 
    //çünkü implemente edilen interface direk içi yazılmış gibi gelir
    public interface IDataResult<Tip> : IResult 
    {
        //car/cars
        Tip Data { get; }
    }
}
