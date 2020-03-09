using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebAppShop.Dtos;
using WebAppShop.Models;

namespace WebAppShop.MappingProfiles
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //Domain to Dto
            // Mapping domain entities to view entities
            CreateMap<Customer, CustomerDto>();
            // Mapping view entities to domain entities
            CreateMap<CustomerDto, Customer>();

            CreateMap<Movie, MovieDto>();

            //Dto to Domain
            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}