namespace WayS.Models
{
    class Administrateur
    {
        private int id;
        private string login;
        private string mdp;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Login
        {
            get => login;
            set => login = value;
        }

        public string Mdp
        {
            get => mdp;
            set => mdp = value;
        }
    }
}
