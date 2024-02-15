using CarBook.Application.Features.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
	{
        public UpdateReviewValidator()
        {
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz");
			RuleFor(x => x.CustomerName).MinimumLength(3).WithMessage("Lütfen müşteri adı için en az 3 karakter girişi yapınız");
			RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
			RuleFor(x => x.CustomerComment).NotEmpty().WithMessage("Lütfen yorum kısmını boş geçmeyiniz");
			RuleFor(x => x.CustomerComment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter girişi yapınız");
			RuleFor(x => x.CustomerComment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter girişi yapınız");
			RuleFor(x=>x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görseli alanını boş geçmeyiniz").MinimumLength(10).WithMessage("Lütfen minimum 10 karakter uzunluğunda veri girişi yapınız").MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter uzunluğunda veri girişi yapınız");
		}
    }
}
