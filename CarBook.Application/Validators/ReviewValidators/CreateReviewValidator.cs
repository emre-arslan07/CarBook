using CarBook.Application.Features.Commands.ReviewCommands;
using CarBook.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
	{
        public CreateReviewValidator()
        {
            RuleFor(x=>x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz");
            RuleFor(x=>x.CustomerName).MinimumLength(3).WithMessage("Lütfen müşteri adı için en az 3 karakter girişi yapınız");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
            RuleFor(x => x.CustomerComment).NotEmpty().WithMessage("Lütfen yorum kısmını boş geçmeyiniz");
            RuleFor(x => x.CustomerComment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter girişi yapınız");
            RuleFor(x => x.CustomerComment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter girişi yapınız");
        }
    }
}
