using Domain.Entidades;

namespace Domain.Interfaces.Servicos
{
    public interface IServiceAtivo
    {
        Task<bool> SalvarLista(IEnumerable<Ativo> ativos);

        Task<IEnumerable<Ativo>> BuscaHistorico(string nomeAtivo, DateTime dataInicio, DateTime dataFinal);
    }
}