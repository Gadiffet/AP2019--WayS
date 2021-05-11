using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayS.Models
{
    class Question
    {
        private int idQuestion;
        private string questionText;
        private List<Reponses> reponsesQuestion;

        public int IdQuestion { 
            get => idQuestion;
            set => idQuestion = value; 
        }

        public string QuestionText
        {
            get => questionText;
            set => questionText = value;
        }

        public List<Reponses> ReponsesQuestion
        {
            get => reponsesQuestion;
            set => reponsesQuestion = value;
        }

        public Question()
        {
            ReponsesQuestion = new List<Reponses>();
        }
    }
}
