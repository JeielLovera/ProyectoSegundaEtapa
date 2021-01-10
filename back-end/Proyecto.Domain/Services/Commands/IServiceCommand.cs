using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Services.Commands
{
    public interface IServiceCommand<TRequest> where TRequest : class
    {
        Task<bool> Save(TRequest entity);

        Task<bool> Update(int id, TRequest entity);

        Task<bool> Delete(int id);
    }
}
