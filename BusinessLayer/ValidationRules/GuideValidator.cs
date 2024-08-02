using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {

        public GuideValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehberin adını giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber bilgisini giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen rehberin fotoğrafını ekleyiniz");
        }
    }
}
