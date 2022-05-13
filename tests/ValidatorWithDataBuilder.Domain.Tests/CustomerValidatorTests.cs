using FluentValidation.TestHelper;
using ValidatorWithDataBuilder.Domain.CustomerAggregate;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators;
using Xunit;

namespace ValidatorWithDataBuilder.Domain.Tests
{
    public class CustomerValidatorTests
    {
        private CustomerValidator _customervalidator;
        public CustomerValidatorTests()
        {
            _customervalidator = new CustomerValidator();
        }

        [Theory]
        [InlineData(null, "FirstName should not be null")]
        [InlineData("", "FirstName should not be empty")]
        public void Should_return_error_when_firstname_is_null_or_empty(string firstName, string errorMessage)
        {
            //Arrange
            
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = "name",
                Discount = 1,
                Address = "rue 24 numero 2 quartier Mohammed 5 casablanca maroc"
            };

            //Act
            var result = _customervalidator.TestValidate(customer);

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
            Customer customer = new Customer
            {
                FirstName = "Toto",
                LastName = lastName,
                Discount = 1,
                Address = "rue 24 numero 2 quartier Mohammed 5 casablanca maroc"
            };

            //Act
            var result = _customervalidator.TestValidate(customer);

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
            Customer customer = new Customer
            {
                FirstName = "Toto",
                LastName = "lastName",
                Discount = 0,
                Address = "rue 24 numero 2 quartier Mohammed 5 casablanca maroc"
            };

            //Act
            var result = _customervalidator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            result.ShouldHaveValidationErrorFor(_ => _.Discount)
                  .WithErrorMessage("Discount should not be zero");
        }

        [Theory]
        [InlineData(null, "Address should not be null")]
        [InlineData("", "Address should not be empty")]
        [InlineData("akka", "Address should be between 10 and 250")]
        public void Should_return_error_when_Address_is_not_valid(string address, string errorMessage)
        {
            //Arrange
            Customer customer = new Customer
            {
                FirstName = "Toto",
                LastName = "nait",
                Discount = 1,
                Address = address
            };

            //Act
            var result = _customervalidator.TestValidate(customer);

            //Assert
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            result.ShouldHaveValidationErrorFor(_ => _.Address)
                  .WithErrorMessage(errorMessage);
        }
    }
}