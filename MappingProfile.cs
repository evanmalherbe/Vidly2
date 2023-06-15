using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2
{
	public class MappingProfile : Profile
	{
			public MappingProfile()
			{
					Mapper.CreateMap<Customer, CustomerDto>();
					Mapper.CreateMap<CustomerDto, Customer>();
					Mapper.CreateMap<MovieDto, Movie>();
					Mapper.CreateMap<Movie, MovieDto>();
			}
	}
}
