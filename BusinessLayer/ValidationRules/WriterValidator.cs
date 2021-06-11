using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girişi yapın.");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soy adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında alanını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).MinimumLength(50).WithMessage("Lütfen hakkınızda en az 50 karakter girişi yapın.");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToLower().Contains("a")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");       
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Şifreniz en az 6 karakterden oluşmalıdır.");
        }
    }
}
