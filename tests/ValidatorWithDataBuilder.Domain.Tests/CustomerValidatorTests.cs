using FluentValidation.TestHelper;
using ValidatorWithDataBuilder.Domain.CustomerAggregate;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators;
using Xunit;

namespace ValidatorWithDataBuilder.Domain.Tests
{
    public class CustomerValidatorTests
    {

        [Theory]
        [InlineData(null, "FirstName should not be null")]
        [InlineData("", "FirstName should not be empty")]
        public void Should_return_error_when_firstname_is_null_or_empty(string firstName, string errorMessage)
        {
            //Arrange
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer { FirstName = firstName };

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            result.ShouldHaveValidationErrorFor(_ => _.FirstName)
                  .WithErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Last Name' must not be empty.")]
        [InlineData("", "Last Name must not be empty")]
        public void Should_return_error_when_lastName_is_null_or_empty(string lastName, string errorMessage)
        {
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer
            {
                FirstName = "Toto",
                LastName = lastName
            };

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            result.ShouldHaveValidationErrorFor(_ => _.LastName)
                  .WithErrorMessage(errorMessage);
        }


    }
}