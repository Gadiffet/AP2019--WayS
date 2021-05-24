namespace WayS.Models
{
    class Reponses
    {
        private int id;
        private int idQuestion;
        private string reponse;
        private int nbrPoints;
        private bool correct;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int IdQuestion
        {
            get => idQuestion;
            set => idQuestion = value;
        }

        public string Reponse
        {
            get => reponse;
            set => reponse = value;
        }

        public int NbrPoints
        {
            get => nbrPoints;
            set => nbrPoints = value;
        }

        public bool Correct
        {
            get => correct;
            set => correct = value;
        }
    }
}
