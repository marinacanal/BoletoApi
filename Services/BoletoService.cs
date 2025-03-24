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
        private readonly BancoRepository _bancoRepository;

        public BoletoService(IMapper mapper, BoletoRepository boletoRepository, BancoRepository bancoRepository)
        {
            _mapper = mapper;
            _boletoRepository = boletoRepository;
            _bancoRepository = bancoRepository;
        }

        public async Task<BoletoResponseDTO> CriarBoleto(BoletoRequestDTO boletoRequest)
        {
            var banco = await _bancoRepository.BuscarBancoPorId(boletoRequest.BancoId);

            if(banco == null)
                throw new KeyNotFoundException("Banco não existe!");

            var boleto = _mapper.Map<Boleto>(boletoRequest);

            boleto = await _boletoRepository.CriarBoleto(boleto);
            return _mapper.Map<BoletoResponseDTO>(boleto);
        }

        public async Task<BoletoResponseDTO> BuscarBoletoPorId(Guid id)
        {
            var boleto = await _boletoRepository.BuscarBoletoPorId(id);

            if(boleto == null)
                throw new KeyNotFoundException("Boleto não encontrado!");

            if(DateTime.Now > boleto.DataVencimento)
            {
                var banco = await _bancoRepository.BuscarBancoPorId(boleto.BancoId);
                boleto.Valor += boleto.Valor * (banco.PercentualJuros / 100);
            }
            
            return _mapper.Map<BoletoResponseDTO>(boleto);
        }
    }
}