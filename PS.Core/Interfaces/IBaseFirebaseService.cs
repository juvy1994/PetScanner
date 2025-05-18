using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Interfaces
{
    public interface IBaseFirebaseService<T>
    {
        Task<List<T>> GetAllAsync();
        Task SaveAsync(T entity);
        Task DeleteAsync(string id);
    }
}
