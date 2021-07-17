using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUsername).NotEmpty().WithMessage("Admin kullanıcı adını boş geçemezsiniz.");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre alanı boş olamaz.");
            RuleFor(x => x.AdminUsername).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Admin Rol seçiniz");
        }
    }
}
