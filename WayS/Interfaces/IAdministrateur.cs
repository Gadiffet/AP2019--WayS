namespace WayS.Interfaces
{
    interface IAdministrateur<T>
    {
        T FindByLogin(string login);
    }
}
