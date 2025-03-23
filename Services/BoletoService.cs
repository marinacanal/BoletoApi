using AutoMapper;
using BoletoApi.DTOs;
using BoletoApi.Entities;
using BoletoApi.Repositories;

namespace BoletoApi.Services
{
    public class BoletoService
    { 
        private readonly IMapper _mapper;
        private readonly BoletoRepository _boletoRepository;

        public BoletoService(IMapper mapper, BoletoRepository boletoRepository)
        {
            _mapper = mapper;
            _boletoRepository = boletoRepository;
        }

        public async Task<BoletoResponseDTO> CriarBoleto(BoletoRequestDTO boletoRequest)
        {
            var boleto = _mapper.Map<Boleto>(boletoRequest);
            boleto = await _boletoRepository.CreateAsync(boleto);
            return _mapper.Map<BoletoResponseDTO>(boleto);
        }

        public async Task<BoletoResponseDTO> BuscarBoletoPorId(Guid id)
        {
            var boleto = await _boletoRepository.GetByIdAsync(id);

            if(boleto == null)
                throw new KeyNotFoundException("Boleto não encontrado!");

            if(DateTime.Now > boleto.DataVencimento)
                boleto.Valor += boleto.Valor * (boleto.Banco.PercentualJuros / 100);

            return _mapper.Map<BoletoResponseDTO>(boleto);
        }
    }
}