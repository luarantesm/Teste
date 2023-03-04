using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Infra.Contexto;

namespace Infra.Repositorio
{
    public class RepositoryAtivo : IRepositoryAtivo
    {
        private readonly ContextAtivo _ativoContexto;

        public RepositoryAtivo(ContextAtivo ativoContext)
        {
            _ativoContexto = ativoContext;
        }

        public async Task<bool> SalvarLista(IEnumerable<Ativo> ativos)
        {
            try
            {
                await _ativoContexto.AddRangeAsync(ativos);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Ativo> BuscaHistorico(string nomeAtivo, DateTime dataInicio, DateTime dataFinal)
        {
            try
            {
                return _ativoContexto.Ativo.Where(x => x.Nome == nomeAtivo && x.Data >= dataInicio && x.Data <= dataFinal).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}