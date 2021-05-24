/*using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;

namespace WayS.ViewModels
{
    class QuestionViewModel : ViewModelBase
    {
        private Question question;
        private QuestionRepository questionRepository;

        public int IdQuestion
        {
            get => question.IdQuestion;
            set
            {
                question.IdQuestion = value;
                RaisePropertyChanged();
            }
        }

        public string QuestionText
        {
            get => question.QuestionText;
            set
            {
                question.QuestionText = value;
                RaisePropertyChanged();
            }
        }

        public List<Reponses> ReponsesQuestion
        {
            get => question.ReponsesQuestion;
            set
            {
                question.ReponsesQuestion = value;
                RaisePropertyChanged();
            }
        }

        public Question Question
        {
            get => question;
            set
            {
                question = value;
                if (question != null)
                {
                    RaisePropertyChanged("IdQuestion");
                    RaisePropertyChanged("QuestionText");
                    RaisePropertyChanged("ReponsesQuestion");
                }
            }
        }

        public ICommand AjoutQuestion { get; set; }
        public ICommand SuppQuestion { get; set; }
        public ICommand ModifQuestion { get; set; }
        public ICommand ModifOrdreQuestion { get; set; }
        public ICommand ListQuestion { get; set; }

        public ObservableCollection<Reponses> ReponseQuestion { get; set; }
        public ObservableCollection<Question> Questions { get; set; }

        public QuestionViewModel()
        {
            question = new Question();
            questionRepository = new QuestionRepository();
            Questions = new ObservableCollection<Question>(questionRepository.Listing());
            AjoutQuestion = new RelayCommand(AjouterQuestion);
            SuppQuestion = new RelayCommand(SupprimerQuestion);
        }

        private void AjouterQuestion()
        {
            questionRepository = new QuestionRepository();
            questionRepository.Create(question);
            if (Question.IdQuestion > 0)
            {
                Questions.Add(Question);
                Question = new Question();
            }
        }

        public void SupprimerQuestion()
        {
            questionRepository = new QuestionRepository();
            questionRepository.Delete(question);
            if (Question.IdQuestion > 0)
            {
                Questions.Remove(Question);
            }
        }

        public void ModifierQuestion()
        {
            questionRepository = new QuestionRepository();
            if (Question.IdQuestion > 0)
            {
                questionRepository.Update(Question);
            }
        }

        public Question ModifierOrdreQuestion(Question question)
        {
            return null;
        }

        public Question ListerQuestion(Question question)
        {
            return null;
        }
    }
}

*/