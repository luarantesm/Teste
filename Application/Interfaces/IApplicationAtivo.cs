using Application.Dtos;

namespace Application.Interfaces
{
    public interface IApplicationAtivo
    {
        Task<IEnumerable<AtivoDto>> BuscaDadosAtivo(string ativo);
    }
}