namespace WayS.Models
{
    class Question
    {
        private int idQuestion;
        private string questionText;
        private int position;

        public int IdQuestion
        {
            get => idQuestion;
            set => idQuestion = value;
        }

        public string QuestionText
        {
            get => questionText;
            set => questionText = value;
        }

        public int Position
        {
            get => position;
            set => position = value;
        }

        public Question()
        {

        }

        protected Question(string questionText, int position)
        {
            QuestionText = questionText;
            Position = position;
        }
    }
}
