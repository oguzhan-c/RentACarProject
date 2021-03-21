using Entities.Concrute;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class PurchaseValidator : AbstractValidator<Purchase>
    {
        public PurchaseValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("CarId Can Not Be Empty!");
            //RuleFor(p => p.CustomerId).NotEmpty().WithMessage("CustomerId Can Not Be Empty!");
            RuleFor(p => p.Id).NotEmpty().WithMessage("PurchaseId Can Not Be Empty!");
            RuleFor(p => p.PurchaseDate).NotEmpty().WithMessage("PurchaseDate Can Not Be Empty!");
            RuleFor(p => p.PurchasePrice).NotEmpty().WithMessage("PurchasePrice Can Not Be Empty!");
            RuleFor(p => p.PurchasePrice).GreaterThan(0);
        }
    }
}
