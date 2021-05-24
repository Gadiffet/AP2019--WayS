using System.Collections.Generic;

namespace WayS.Interfaces
{
    interface IAdministrateur<T>
    {
        List<T> FindByLogin(string login);
    }
}
