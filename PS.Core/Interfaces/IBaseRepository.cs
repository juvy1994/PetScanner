using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(string id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
