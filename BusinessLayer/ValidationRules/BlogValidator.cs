using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {

        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Adı boş bırakılamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz");
            RuleFor(x => x.BlogCreateDate).NotEmpty().WithMessage("Oluşturma Tarihi boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel Yolu boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen en fazla 150 karakter girişi yapınız.");
        }
    }
}
