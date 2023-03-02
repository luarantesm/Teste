using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Servicos;

namespace Application
{
    public class ApplicationAtivo : IApplicationAtivo
    {
        private readonly IMapper _mapper;
        private readonly IServiceAtivo _ativoService;
        private readonly IApplicationYahoo _applicationYahoo;

        public ApplicationAtivo(IMapper mapper, IServiceAtivo ativoService, IApplicationYahoo applicationYahoo)
        {
            _mapper = mapper;
            _ativoService = ativoService;
            _applicationYahoo = applicationYahoo;
        }

        public async Task<IEnumerable<AtivoDto>> BuscaDadosAtivo(string nomeAtivo)
        {
            DateTime dataFim = DateTime.Parse(DateTime.UtcNow.ToString("dd/MM/yyyy"));
            DateTime dataInicio = DateTime.Parse(dataFim.AddDays(-30).ToString("dd/MM/yyyy"));

            IEnumerable<Ativo> ativos = _ativoService.BuscaHistorico(nomeAtivo, dataInicio, dataFim);

            if (!ativos.Any())
            {
                ativos = await _applicationYahoo.BuscaAtivos(nomeAtivo, dataInicio, dataFim);

                if (ativos != null)
                {
                    var retorno = await _ativoService.SalvarLista(ativos);

                    if (!retorno)
                        return null;
                }
            }

            return MapearDto(ativos);
        }

        private IEnumerable<AtivoDto> MapearDto(IEnumerable<Ativo> ativos)
        {
            var listaAtivoDto = _mapper.Map<IEnumerable<Ativo>, IEnumerable<AtivoDto>>(ativos);

            return AplicaVariacao(listaAtivoDto);
        }

        private IEnumerable<AtivoDto> AplicaVariacao(IEnumerable<AtivoDto> ativoDtos)
        {
            var ativoPrimeiro = ativoDtos.OrderBy(a => a.Data).FirstOrDefault();

            return ativoDtos.Select(ativo =>
            {
                var ativoAnterior = ativoDtos.Where(a => a.Data < ativo.Data)
                                               .OrderByDescending(a => a.Data)
                                               .FirstOrDefault();

                ativo.DefinirVariacaoPrimeiraData(ativoPrimeiro?.Valor);
                ativo.DefinirVariacaoDiaAnterior(ativoAnterior?.Valor);

                return ativo;
            }).OrderBy(a => a.Data);
        }
    }
}