namespace ValidatorWithDataBuilder.Domain.CustomerAggregate.Abstractions
{
    public interface ICustomerService
    {
        public Task CreateCustomerAsync(Customer customer);
    }
}
