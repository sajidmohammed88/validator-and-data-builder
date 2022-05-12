using FluentValidation;

namespace ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(_ => _.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("FirstName should not be null")
                .NotEmpty()
                .WithMessage("FirstName should not be empty");

            RuleFor(_ => _.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");

            RuleFor(_ => _.Discount)
               .NotEqual(0)
               .When(x => x.Discount is not null)
               .WithMessage("{PropertyName} should not be zero");
        }


    }
}
