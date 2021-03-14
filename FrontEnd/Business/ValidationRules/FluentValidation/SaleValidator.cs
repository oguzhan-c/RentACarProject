using Entities.Concrute;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.CarId).NotEmpty().WithMessage("CarId Can Not Be Empty!");
            RuleFor(s => s.SaleId).NotEmpty().WithMessage("SaleId Can Not Be Empty!");
            RuleFor(s => s.SalePrice).NotEmpty().WithMessage("SalePrice Can Not Be Empty!");
            RuleFor(s => s.CustomerId).NotEmpty().WithMessage("CustomerId Can Not Be Empty!");
            RuleFor(s => s.BuyingDate).NotEmpty().WithMessage("SalePrice Can Not Be Empty!");
            RuleFor(s => s.SalePrice).GreaterThan(0);
        }
    }
}
