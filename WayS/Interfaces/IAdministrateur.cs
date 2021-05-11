using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayS.Interfaces
{
    interface IAdministrateur<T>
    {
        T FindByLogin(string login);
    }
}
