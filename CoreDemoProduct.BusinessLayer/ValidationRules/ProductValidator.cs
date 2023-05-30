using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok sayısı boş bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş bırakılamaz.");
        }
    }
}
