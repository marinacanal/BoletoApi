using AutoMapper;
using BoletoApi.DTOs;
using BoletoApi.Entities;

namespace BoletoApi.Mapping
{
    public class BancoProfile : Profile
    {
        public BancoProfile()
        {
            CreateMap<BancoRequestDTO, Banco>();
            CreateMap<Banco, BancoResponseDTO>();
        }
    }
}