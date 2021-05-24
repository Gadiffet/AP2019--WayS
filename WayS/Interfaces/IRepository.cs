using System.Collections.Generic;

namespace WayS.Interfaces
{
    interface IRepository<T>
    {
        void Create(T element);
        void Update(T element);
        void Delete(T element);
        List<T> Listing();
        T FindById(int id);
    }
}
