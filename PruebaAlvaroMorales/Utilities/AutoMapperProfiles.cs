using AutoMapper;
using PruebaAlvaroMorales.Core.Entities;
using PruebaAlvaroMorales.Models;

namespace PruebaAlvaroMorales.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClientDb, Client>();
            CreateMap<BillDb, Bill>().ReverseMap();
        }
    }
}
