using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto.Domain.Services.Querys
{
    public interface IServiceQuery<TResponse> where TResponse : class
    {
        Task<IEnumerable<TResponse>> GetAll(string includeProperties = "");

        Task<TResponse> GetById(int id, string includeProperties = "");
    }
}
