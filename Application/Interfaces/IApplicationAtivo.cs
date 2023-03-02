using Application.Dtos;

namespace Application.Interfaces
{
    public interface IApplicationAtivo
    {
        Task Add(AtivoDto ativoDto);
    }
}