using Entities.Concrute;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandDate).NotEmpty().WithMessage("BrandDate Can Not Be Empty!");
            RuleFor(c => c.CarName).NotEmpty().WithMessage("CarName Can Not Be Empty!");
            RuleFor(c => c.Color).NotEmpty().WithMessage("Color Can Not Be Empty!");
            RuleFor(c => c.Marque).NotEmpty().WithMessage("Marque Can Not Be Empty!");
            RuleFor(c => c.Plaque).NotEmpty().WithMessage("Plaque Can Not Be Empty!");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Price Can Not Be Empty!");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Description Can Not Be Empty!");
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.BrandDate).GreaterThan(2019);//Arabaların en az 2019 model olması sağlandı
            RuleFor(c => c.Plaque).Length(7);
            RuleFor(c => c.Plaque.Substring(0, 2)).Must(IsNumber).WithMessage("Türkiye Cumhuriyetine Ait Bir Plaka Girilmeli");
        }
        //Bu metot sayesinde plakanın ilk iki karakterinin rakam olup olmadığı kontrol edildi
        private bool IsNumber(string arg)
        {
            
            char[] IsPlaque = arg.ToCharArray();
            if (char.IsNumber(IsPlaque[0]) && char.IsNumber(IsPlaque[1]))
            {
                return true;
            }
            return false;
        }
    }
}
