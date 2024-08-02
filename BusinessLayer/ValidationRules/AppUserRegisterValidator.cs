using DTOLayer.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    internal class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı boş bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("En az 5 karakterden oluşması gerekir");
            RuleFor(x => x.Username).MaximumLength(5).WithMessage("En fazla 20 karakterden oluşması gerekir");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifrenizi doğrulamanız gerekiyor");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreniz eşleşmiyor");
        }
    }
}
