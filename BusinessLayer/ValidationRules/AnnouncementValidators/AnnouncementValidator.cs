using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidators
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Duyuru başlığını giriniz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Duyuru başlığı en az 5 karakter olmalıdır");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Duyuru başlığı en fazla 20 karakter olmalıdır");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru içeriğini giriniz");
            RuleFor(x => x.Content).MinimumLength(50).WithMessage("Duyuru içeriği en az 50 karakter olmalıdır");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Duyuru içeriği en fazla 500 karakter olmalıdır");


        }
    }
}
