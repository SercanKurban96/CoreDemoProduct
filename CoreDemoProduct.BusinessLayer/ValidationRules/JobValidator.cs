using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.BusinessLayer.ValidationRules
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.JobName).NotEmpty().WithMessage("Meslek adı boş bırakılamaz.");
            RuleFor(x => x.JobName).MinimumLength(3).WithMessage("Meslek adı en az 3 karakter olmalıdır.");
            RuleFor(x => x.JobName).MaximumLength(50).WithMessage("Meslek adı en fazla 50 karakter olmalıdır.");
        }
    }
}
