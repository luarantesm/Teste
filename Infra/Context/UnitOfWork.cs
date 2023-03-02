using Domain.Entitys;
using Domain.Interfaces;
using Infra.Contexto;
using System.Diagnostics;

namespace Infra.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextAtivo _contextAtivo;

        public UnitOfWork(ContextAtivo context)
        {
            _contextAtivo = context;
        }

        public CommandResponse Commit()
        {
            try
            {
                _contextAtivo.SaveChanges();
                return new CommandResponse(true);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
                return new CommandResponse();
            }
        }

        public void Dispose()
        {
            _contextAtivo?.Dispose();
        }
    }
}