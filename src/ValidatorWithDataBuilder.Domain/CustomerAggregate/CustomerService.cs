using ValidatorWithDataBuilder.Domain.CustomerAggregate.Abstractions;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Exceptions;
using ValidatorWithDataBuilder.Domain.CustomerAggregate.Validators;

namespace ValidatorWithDataBuilder.Domain.CustomerAggregate
{
    public class CustomerService : ICustomerService
    {
        private CustomerValidator _customerValidator;

        public CustomerService(CustomerValidator customerValidator)
        {
            _customerValidator = customerValidator ?? throw new ArgumentNullException(nameof(customerValidator));
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            var result = await _customerValidator.ValidateAsync(customer);
            if (!result.IsValid)
            {
                IDictionary<string, string[]> errors = result.Errors
                    .GroupBy(_ => _.PropertyName)
                    .ToDictionary(_ => _.Key, v => v.Select(e => e.ErrorMessage)
                    .ToArray());

                throw new BadRequestException(errors);
            }

        }
    }
}
