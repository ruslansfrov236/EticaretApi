using ETicaretApi.App.ViewModels.Products;
using FluentValidation;


namespace ETicaretApi.App.Validators.Product
{
   public  class ProductCreateValidators:AbstractValidator<VM_ProductCreate>
    {
        public ProductCreateValidators()
        {
            RuleFor(c => c.Name)
                             .NotEmpty()
                             .NotNull()
                                 .WithMessage("Please do not enter blank information.")
                             .MaximumLength(150)
                             .MinimumLength(4)
                                 .WithMessage("Please enter information between 4 and 150 characters.");

            RuleFor(c => c.Stock)
                               .NotEmpty()
                               .NotNull()
                                     .WithMessage("Please enter information between 4 and 150 characters.")
                               .Must(s => s >= 0)
                                    .WithMessage("Please do not enter a negative value."); ;
            RuleFor(c => c.Price)
                       .NotEmpty()
                       .NotNull()
                             .WithMessage("Please do not enter the price information blank.")
                       .Must(s => s >= 0)
                            .WithMessage("Please do not enter a negative value.");

        }
    }
}
