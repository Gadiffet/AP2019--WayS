namespace WayS.Models
{
    class CompteMessagerie
    {
        private int id;
        private string adresseMail;
        private string message;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string AdresseMail
        {
            get => adresseMail;
            set => adresseMail = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }
    }
}
