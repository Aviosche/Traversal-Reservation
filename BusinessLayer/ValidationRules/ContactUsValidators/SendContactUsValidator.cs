using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidators
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli email adresi girmelisiniz");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu açıklaması en az 5 karakterden oluşmalıdır");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu açıklaması en fazla 100 karakterden oluşmalıdır");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");

            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.MessageBody).MinimumLength(20).WithMessage("İletmek istediğiniz mesaj en az 20 karakterden oluşmalıdır");
            RuleFor(x => x.MessageBody).MinimumLength(250).WithMessage("İletmek istediğiniz mesaj en fazla 250 karakterden oluşmalıdır");
        }
    }
}
