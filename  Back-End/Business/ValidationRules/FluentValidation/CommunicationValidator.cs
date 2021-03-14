using Entities.Concrute;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CommunicationValidator:AbstractValidator<Communication>
    {
        public CommunicationValidator()
        {
            RuleFor(c => c.CommunicationId).NotEmpty().WithMessage("CommunicationId Can Not Be Empty!");
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("CustomerId Can Not Be Empty!");
            RuleFor(c => c.Address).NotEmpty().WithMessage("Address Can Not Be Empty!");
            RuleFor(c => c.Country).NotEmpty().WithMessage("Country Can Not Be Empty!");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("PhoneNumber Can Not Be Empty!");
            RuleFor(c => c.Street).NotEmpty().WithMessage("Street Can Not Be Empty!");
            RuleFor(c => c.ZipCode).NotEmpty().WithMessage("ZipCode Can Not Be Empty!");
            RuleFor(c => c.PhoneNumber).MinimumLength(7);
            RuleFor(c => c.Address).MaximumLength(100);
            RuleFor(c => c.SaveEmail).EmailAddress();
        }
    }
}
