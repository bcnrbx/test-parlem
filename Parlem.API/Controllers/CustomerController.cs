using Microsoft.AspNetCore.Mvc;
using Parlem.Services.Customer;

namespace Parlem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService
            )
        {
            _customerService = customerService;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCustomer(string customerId)
        {
            try
            {
                return Ok(await _customerService.GetByCustomerIdAsync(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("customer/{customerId}/products")]
        public async Task<IActionResult> GetCustomerProducts(string customerId)
        {
            try
            {
                return Ok(await _customerService.GetCustomerProductsByCustomerId(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return Ok(await _customerService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
