using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.EntitysExternal;
using Domain.Interfaces.Servicos;
using Newtonsoft.Json;
using static Domain.EntitysExternal.AtivosReposta;

namespace Application
{
    public class ApplicationAtivo : IApplicationAtivo
    {
        private readonly IMapper _IMapper;
        private readonly IServiceAtivo _ativoService;
        private readonly IApplicationYahoo _applicationYahoo;

        public ApplicationAtivo(IServiceAtivo ativoService, IMapper IMapper, IApplicationYahoo applicationYahoo)
        {
            _ativoService = ativoService;
            _IMapper = IMapper;
            _applicationYahoo = applicationYahoo;
        }

        public async Task Add(AtivoDto ativoDto)
        {
            Ativo retorno = await _applicationYahoo.BuscaAtivos(ativoDto.Nome);

            var ativo = _IMapper.Map<Ativo>(ativoDto);

            //_ativoService.Add(ativo);
        }
    }
}