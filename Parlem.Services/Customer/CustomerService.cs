using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using Parlem.DAL;
using Parlem.DAL.Entities;

namespace Parlem.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ParlemDBContext _parlemDBContext;

        public CustomerService(
            ILogger logger,
            IMapper mapper,
            ParlemDBContext parlemDBContext
            )
        {
            _logger = logger;
            _mapper = mapper;
            _parlemDBContext = parlemDBContext;
        }

        public async Task<CustomerDto> AddAsync(CustomerDto customerDto)
        {
            _logger.Debug($"CustomerService > AddAsync");

            var customer = _mapper.Map<CustomerEntity>(customerDto);
            var customerResult = await _parlemDBContext.AddAsync(customer);
            await _parlemDBContext.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customerResult);
        }

        public async Task<CustomerProductDto> AddCustomerProductAsync(CustomerProductDto customerProductDto)
        {
            _logger.Debug($"CustomerService > AddCustomerProductAsync");

            var customerProduct = _mapper.Map<CustomerProductEntity>(customerProductDto);
            var customerProductResult = await _parlemDBContext.AddAsync(customerProduct);
            await _parlemDBContext.SaveChangesAsync();

            return _mapper.Map<CustomerProductDto>(customerProductResult);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            _logger.Debug($"CustomerService > GetAllAsync");

            var listCustomerDto = await _parlemDBContext.Customers.AsNoTracking()
                .Select(x => _mapper.Map<CustomerDto>(x))
                .ToListAsync();

            if (listCustomerDto is null)
            {
                _logger.Error($"Error getting all customers");
                throw new Exception($"Error getting all customers");
            }

            return listCustomerDto;
        }

        public async Task<CustomerDto> GetByCustomerIdAsync(string customerId)
        {
            _logger.Debug($"CustomerService > GetByCustomerIdAsnyc > CustomerId {customerId}");

            var customerDto = await _parlemDBContext.Customers.AsNoTracking()
                .Where(x => x.CustomerId.Equals(customerId, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => _mapper.Map<CustomerDto>(x))
                .FirstOrDefaultAsync();
            if (customerDto is null)
            {
                _logger.Error($"Error getting customer with customer id {customerId}");
                throw new Exception($"Error getting customer with customer id {customerId}");
            }

            return customerDto;
        }

        public async Task<IEnumerable<CustomerProductDto>> GetCustomerProductsByCustomerId(string customerId)
        {
            _logger.Debug($"CustomerService > GetCustomerProductsByCustomerId > CustomerId {customerId}");

            var listCustomerProductDo = await _parlemDBContext.CustomerProducts.AsNoTracking()
                .Where(x => x.CustomerId.Equals(customerId))
                .Select(x => _mapper.Map<CustomerProductDto>(x))
                .ToListAsync();
            if (listCustomerProductDo is null)
            {
                _logger.Error($"Error getting customer products with customer id {customerId}");
                throw new Exception($"Error getting customer products with customer id {customerId}");
            }

            return listCustomerProductDo;
        }
    }
}
