using FluentValidation.TestHelper;
using System.Linq;
using ValidatorWithDataBuilder.Domain.CustomerAggregate;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators;
using Xunit;

namespace ValidatorWithDataBuilder.Domain.Tests
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void Should_return_error_when_firstname_is_empty()
        {
            //Arrange
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer { FirstName = ""};

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            result.ShouldHaveValidationErrorFor(_ => _.FirstName)
                  .WithErrorMessage("FirstName should not be empty");
        }

        [Fact]
        public void Should_return_error_when_firstname_is_null()
        {
            //Arrange
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer { FirstName = null };

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            result.ShouldHaveValidationErrorFor(_ => _.FirstName)
                  .WithErrorMessage("FirstName should not be null");
        }
    }
}