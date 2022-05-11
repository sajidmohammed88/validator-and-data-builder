﻿using FluentValidation;

namespace ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .WithMessage("FirstName should not be empty");
            RuleFor(_ => _.FirstName)
                .NotNull()
                .WithMessage("FirstName should not be null");
            RuleFor(_ => _.LastName)
                .NotNull();
            RuleFor(_ => _.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty");
        }


    }
}