using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;

namespace Domain.Services
{
    public class ServiceAtivo : IServiceAtivo
    {
        private readonly IRepositoryAtivo _ativoRepositorio;

        public ServiceAtivo(IRepositoryAtivo ativoRepositorio)
        {
            _ativoRepositorio = ativoRepositorio;
        }

        public async Task<bool> SalvarLista(IEnumerable<Ativo> ativos)
        {
            return await _ativoRepositorio.SalvarLista(ativos);
        }

        public async Task<IEnumerable<Ativo>> BuscaHistorico(string nomeAtivo, DateTime dataInicio, DateTime dataFinal)
        {
            return await _ativoRepositorio.BuscaHistorico(nomeAtivo, dataInicio, dataFinal);
        }
    }
}