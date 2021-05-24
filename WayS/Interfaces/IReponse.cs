using System.Collections.Generic;

namespace WayS.Interfaces
{
    interface IReponse<T>
    {
        void Create(T element);
        void Update(T element);
        void Delete(T element);
        List<T> Listing(int id);
        T FindById(int id);
    }
}
