﻿using EntityLayer.Concrete;
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
            RuleFor(x => x.WriterNickname).NotEmpty().WithMessage("Yazar kullanıcı adını boş geçemezsiniz.");
            RuleFor(x => x.WriterNickname).MinimumLength(5).WithMessage("Kullanıcı adınız en az 5 karakter olmalıdır.");
            RuleFor(x => x.WriterNickname).MaximumLength(100).WithMessage("Kullanıcı adınız en fazla 100 karakter olmalıdır.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanını boş geçemezsiniz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail alanını boş geçemezsiniz.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Doğru bir mail adresi giriniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında alanını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).MinimumLength(50).WithMessage("Lütfen hakkınızda en az 50 karakter girişi yapın.");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Lütfen hakkınızda en fazla 100 karakter girişi yapın.");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToLower().Contains("a")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");       
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Şifreniz en az 6 karakterden oluşmalıdır.");
        }
    }
}
