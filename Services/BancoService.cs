using AutoMapper;
using BoletoApi.DTOs;
using BoletoApi.Entities;
using BoletoApi.Repositories;

namespace BoletoApi.Services
{
    public class BancoService
    {   
        private readonly IMapper _mapper;
        private readonly BancoRepository _bancoRepository;

        public BancoService(IMapper mapper, BancoRepository bancoRepository)
        {
            _mapper = mapper;
            _bancoRepository = bancoRepository;
        }

        public async Task<BancoResponseDTO> CriarBanco(BancoRequestDTO bancoRequest)
        {
            var banco = _mapper.Map<Banco>(bancoRequest);
            banco = await _bancoRepository.CriarBanco(banco);
            return _mapper.Map<BancoResponseDTO>(banco);
        }

        public async Task<BancoResponseDTO> BuscarBancoPorId(Guid id)
        {
            var banco = await _bancoRepository.BuscarBancoPorId(id);

            if(banco == null)
                throw new KeyNotFoundException("Banco não encontrado!");

            return _mapper.Map<BancoResponseDTO>(banco);
        }

        public async Task<List<BancoResponseDTO>> BuscarTodosBancos()
        {
            var bancos = await _bancoRepository.BuscarTodosBancos();

            if(!bancos.Any())
                throw new NullReferenceException("Nenhum banco encontrado!");

            return _mapper.Map<List<BancoResponseDTO>>(bancos);
        }
    }
}