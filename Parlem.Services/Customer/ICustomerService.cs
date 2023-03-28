namespace Parlem.Services.Customer
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddAsync(CustomerDto customerDto);
        Task<CustomerProductDto> AddCustomerProductAsync(CustomerProductDto customerProductDto);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByCustomerIdAsync(string customerId);
        Task<IEnumerable<CustomerProductDto>> GetCustomerProductsByCustomerId(string customerId);

    }
}
