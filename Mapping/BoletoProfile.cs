using AutoMapper;
using BoletoApi.DTOs;
using BoletoApi.Entities;

namespace BoletoApi.Mapping
{
    public class BoletoProfile : Profile
    {
        public BoletoProfile()
        {
            CreateMap<BoletoRequestDTO, Boleto>();
            CreateMap<Boleto, BoletoResponseDTO>();
        }
    }
}