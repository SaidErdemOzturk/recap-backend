using Entities.Concrete;
using Entities.Concrete.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCartValidator : AbstractValidator<CreditCart>
    {
        public CreditCartValidator()
        {
            RuleFor(c => c.CartNumber).NotEmpty().WithMessage("Kart numarası boş olamaz.");
            RuleFor(c => c.ExpirationDate).NotEmpty().WithMessage("Son kullanma tarihi boş olamaz.");
            RuleFor(c => c.Cvv).NotEmpty().WithMessage("Cvv boş olamaz.");
            RuleFor(c => c.CartNumber).Length(16);
            RuleFor(c => c.Cvv).Length(3);
        }
    }
}
