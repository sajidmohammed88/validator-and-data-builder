using System.Threading.Tasks;
using ValidatorWithDataBuilder.Domain.CustomerAggregate;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Abstractions;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Exceptions;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators;
using Xunit;

namespace ValidatorWithDataBuilder.Domain.Tests
{
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;
        public CustomerServiceTests()
        {
            _customerService = new CustomerService(new CustomerValidator());
        }

        [Fact]
        public async Task Should_return_badrequest_when_customer_is_not_valid()
        {
            // Arrange
            var customer = new Customer
            {
                FirstName = "",
                LastName = "Test"
            };

            //Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(async () => await _customerService.CreateCustomerAsync(customer));
            Assert.NotNull(exception);
            Assert.Equal(2, exception.GetErrors().Count);
        }
    }
}
