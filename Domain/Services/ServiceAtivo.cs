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

        public void Add(Ativo ativo)
        {
            _ativoRepositorio.Add(ativo);
        }
    }
}