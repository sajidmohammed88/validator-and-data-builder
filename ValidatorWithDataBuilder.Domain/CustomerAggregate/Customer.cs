namespace ValidatorWithDataBuilder.Domain.CustomerAggregate;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal? Discount { get; set; }
    public string Address { get; set; }
}