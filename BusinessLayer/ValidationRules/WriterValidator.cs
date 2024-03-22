using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{

    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Görsel Yolu boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Alanı boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterName).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapınız.");
        }
    }
}
