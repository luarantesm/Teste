using Domain.Entidades;

namespace Domain.Interfaces.Repositorios
{
    public interface IRepositoryAtivo
    {
        Task<bool> SalvarLista(IEnumerable<Ativo> ativos);

        Task<IEnumerable<Ativo>> BuscaHistorico(string nomeAtivo, DateTime dataInicio, DateTime dataFinal);
    }
}