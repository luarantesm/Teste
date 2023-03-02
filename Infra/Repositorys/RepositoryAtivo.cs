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

        public void Add(Ativo ativo)
        {
            try
            {
                _ativoContexto.Set<Ativo>().Add(ativo);
                _ativoContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}