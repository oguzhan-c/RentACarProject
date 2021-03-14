using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserEmail).EmailAddress();
            RuleFor(u => u.UserPassword).MinimumLength(10);
            RuleFor(u => u.UserPassword).NotEmpty().WithMessage("Password Can Not Be Empty");
        }
    }
}
