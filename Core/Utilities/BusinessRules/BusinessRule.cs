using Core.Entities;
using Core.Utilities.Results.Abstruct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRule
    {
        public static IResult Run(params IResult [] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Succcess)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
