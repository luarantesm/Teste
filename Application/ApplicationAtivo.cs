using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Servicos;

namespace Application
{
    public class ApplicationAtivo : IApplicationAtivo
    {
        private readonly IMapper _IMapper;
        private readonly IServiceAtivo _ativoService;
        private readonly IApplicationYahoo _applicationYahoo;

        public ApplicationAtivo(IMapper IMapper, IServiceAtivo ativoService, IApplicationYahoo applicationYahoo)
        {
            _IMapper = IMapper;
            _ativoService = ativoService;
            _applicationYahoo = applicationYahoo;
        }

        public async Task<IEnumerable<AtivoDto>> BuscaDadosAtivo(string nomeAtivo)
        {
            DateTime dataFim = DateTime.UtcNow;
            DateTime dataInicio = dataFim.AddDays(-30);

            IEnumerable<Ativo> ativos = await _ativoService.BuscaHistorico(nomeAtivo, dataInicio, dataFim);

            if (ativos != null)
            {
                ativos = await _applicationYahoo.BuscaAtivos(nomeAtivo, dataInicio, dataFim);

                if (ativos != null)
                {
                    var retorno = await _ativoService.SalvarLista(ativos);

                    if (!retorno)
                        return null;
                }
            }

            return _IMapper.Map<IEnumerable<Ativo>, IEnumerable<AtivoDto>>(ativos);
        }
    }
}