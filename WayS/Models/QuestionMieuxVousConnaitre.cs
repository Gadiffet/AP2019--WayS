namespace WayS.Models
{
    class QuestionMieuxVousConnaitre : Question
    {

        public QuestionMieuxVousConnaitre()
        {

        }

        protected QuestionMieuxVousConnaitre(string questionText, int position)
        {
            QuestionText = questionText;
            Position = position;
        }
    }
}