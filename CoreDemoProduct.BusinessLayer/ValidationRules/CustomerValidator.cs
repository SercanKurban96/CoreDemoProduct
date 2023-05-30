using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.BusinessLayer.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri adı boş bırakılamaz.");
            RuleFor(x => x.CustomerCity).NotEmpty().WithMessage("Şehir bilgisi boş bırakılamaz.");
        }
    }
}
