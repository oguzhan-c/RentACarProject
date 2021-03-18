using Entities.Concrute;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RentValidator : AbstractValidator<Rent>
    {
        public RentValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage("CarId Can Not Empty!");
            RuleFor(r => r.UserId).NotEmpty().WithMessage("CustomerId Can Not Empty!");
            RuleFor(r => r.DailyPrice).NotEmpty().WithMessage("DailyPrice Can Not Empty!");
            RuleFor(r => r.RentId).NotEmpty().WithMessage("RentId Can Not Empty!");
            RuleFor(r => r.RentDate).NotEmpty().WithMessage("RentDate Can Not Empty!");
            RuleFor(r => r.ReturnDate).NotEmpty().WithMessage("ReturnDate Can Not Empty!");
            RuleFor(r => r.DailyPrice).GreaterThan(0);
        }
    }
}
