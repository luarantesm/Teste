using Domain.Entidades;
using Domain.EntitysExternal;

namespace Application.Interfaces
{
    public interface IApplicationYahoo
    {
        Task<Ativo> BuscaAtivos(string ativo);
    }
}