using Domain.Entidades;

namespace Application.Interfaces
{
    public interface IApplicationYahoo
    {
        Task<IEnumerable<Ativo>> BuscaAtivos(string ativo, DateTime dataInicio, DateTime dataFim);
    }
}