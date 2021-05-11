using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
