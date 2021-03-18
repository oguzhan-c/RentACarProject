using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("Customer Id Can Not Empty!");
            RuleFor(c => c.UserId).NotEmpty().WithMessage("UserId Id Can Not Empty!");
            //RuleFor(c => c.CustomerName).NotEmpty().WithMessage("CustomerName Id Can Not Empty!");
            //RuleFor(c => c.CustomerLastname).NotEmpty().WithMessage("CustomerLastname Id Can Not Empty!");
            RuleFor(c => c.DateOfBorth).NotEmpty().WithMessage("DateOfBorth Id Can Not Empty!");
            RuleFor(c => c.Gender).NotEmpty().WithMessage("Gender Id Can Not Empty!");
            RuleFor(c => c.IdentityNumber).NotEmpty().WithMessage("IdentityNumber Id Can Not Empty!");
            //RuleFor(c => c.CustomerName).Must(IsChar).WithMessage("CustomerName Name Can Not Valid Number Or Special Characters !");
            //RuleFor(c => c.CustomerLastname).Must(IsChar).Must(IsSymbol).WithMessage("CustomerLastname Name Can Not Valid Number Or Special Characters !");
            RuleFor(c => c.IdentityNumber).Must(IsNumber).WithMessage("İdentity Number Must Be A Number!");
            RuleFor(c => c.Gender).Must(IsNumber).Must(IsSymbol).WithMessage("Gender Can Not Valid Number Or Symbol!");
            RuleFor(c => c.DateOfBorth).Must(IAgeBigEnough).WithMessage("Under 18s can't rent a car!");
        }

        private bool IAgeBigEnough(DateTime arg)
        {
            int nowYear = DateTime.Now.Year;
            int age = nowYear - arg.Year;

            if (age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool IsNumber(string arg)
        {
            char[] character = arg.ToCharArray();

            foreach (var suspect in character)
            {
                if (!char.IsNumber(suspect))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsChar(string arg)
        {
            char[] character = arg.ToCharArray();

            foreach (var suspect in character)
            {
                if (char.IsDigit(suspect))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSymbol(string arg)
        {
            char[] character = arg.ToCharArray();

            foreach (var suspect in character)
            {
                if (char.IsSymbol(suspect))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
