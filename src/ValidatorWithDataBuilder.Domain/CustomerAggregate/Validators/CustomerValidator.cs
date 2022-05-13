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
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");

            RuleFor(_ => _.Discount)
               .NotEqual(0)
               .When(x => x.Discount is not null)
               .WithMessage("{PropertyName} should not be zero");

            RuleFor(_ => _.Address)
               .Cascade(CascadeMode.Stop)
               .NotNull()
               .WithMessage("{PropertyName} should not be null")
               .NotEmpty()
               .WithMessage("{PropertyName} should not be empty")
               .Length(10, 250)
               .WithMessage("{PropertyName} should be between 10 and 250");
        }
    }
}
