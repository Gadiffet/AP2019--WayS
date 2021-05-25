using System.Collections.Generic;

namespace WayS.Interfaces
{
    interface IRepository<T>
    {
        T Create(T element);
        T Update(T element);
        T Delete(T element);
        List<T> Listing();
        T FindById(int id);
    }
}
