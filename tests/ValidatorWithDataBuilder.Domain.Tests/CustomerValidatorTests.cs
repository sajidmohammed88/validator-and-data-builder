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
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = "name",
                Discount = 1,
                Address = "rue 24 numero 2 quartier Mohammed 5 casablanca maroc"
            };

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            result.ShouldHaveValidationErrorFor(_ => _.FirstName)
                  .WithErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Last Name' must not be empty.")]
        [InlineData("", "Last Name must not be empty")]
        public void Should_return_error_when_lastName_is_null_or_empty(string lastName, string errorMessage)
        {
            //Arrange
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer
            {
                FirstName = "Toto",
                LastName = lastName,
                Discount = 1,
                Address = "rue 24 numero 2 quartier Mohammed 5 casablanca maroc"
            };

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            result.ShouldHaveValidationErrorFor(_ => _.LastName)
                  .WithErrorMessage(errorMessage);
        }

        [Fact]
        public void Should_return_error_when_discount_equal_zero()
        {
            //Arrange
            CustomerValidator validator = new CustomerValidator();
            Customer customer = new Customer
            {
                FirstName = "Toto",
                LastName = "lastName",
                Discount = 0,
                Address = "rue 24 numero 2 quartier Mohammed 5 casablanca maroc"
            };

            //Act
            var result = validator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            result.ShouldHaveValidationErrorFor(_ => _.Discount)
                  .WithErrorMessage("Discount should not be zero");
        }

    }
}