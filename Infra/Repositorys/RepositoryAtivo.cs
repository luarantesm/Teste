using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;

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
                _ativoContexto.Set<Ativo>().AddRange(ativos);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Ativo>> BuscaHistorico(string nomeAtivo, DateTime dataInicio, DateTime dataFinal)
        {
            try
            { 
                var tete = await _ativoContexto.Ativo.Where(x => x.Nome == nomeAtivo && x.Data <= dataInicio && x.Data >= dataFinal).AsNoTracking().ToListAsync();
                return tete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}