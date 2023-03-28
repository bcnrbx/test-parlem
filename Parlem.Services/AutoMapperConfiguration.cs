using AutoMapper;
using Parlem.DAL.Entities;
using Parlem.Services.Customer;

namespace Parlem.Services
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CustomerEntity, CustomerDto>().ReverseMap();
            CreateMap<CustomerProductEntity, CustomerProductDto>().ReverseMap();
        }
    }
}
