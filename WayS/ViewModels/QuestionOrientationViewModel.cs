/*using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;

namespace WayS.ViewModels
{
    class QuestionOrientationViewModel : ViewModelBase
    {
        private QuestionOrientation questionOrientation;
        private QuestionOrientationRepository questionOrientationRepository;

        public int IdQuestion
        {
            get => questionOrientation.IdQuestion;
            set
            {
                questionOrientation.IdQuestion = value;
                RaisePropertyChanged();
            }
        }

        public string QuestionText
        {
            get => questionOrientation.QuestionText;
            set
            {
                questionOrientation.QuestionText = value;
                RaisePropertyChanged();
            }
        }

        public string Bareme
        {
            get => questionOrientation.Bareme;
            set
            {
                questionOrientation.Bareme = value;
                RaisePropertyChanged();
            }
        }

        public List<Reponses> ReponsesQuestion
        {
            get => questionOrientation.ReponsesQuestion;
            set
            {
                questionOrientation.ReponsesQuestion = value;
                RaisePropertyChanged();
            }
        }

        public QuestionOrientation QuestionOrientation
        {
            get => questionOrientation;
            set
            {
                questionOrientation = value;
                if (questionOrientation != null)
                {
                    RaisePropertyChanged("IdQuestion");
                    RaisePropertyChanged("QuestionText");
                    RaisePropertyChanged("Bareme");
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
        public ObservableCollection<QuestionOrientation> QuestionsOrientations { get; set; }

        public QuestionOrientationViewModel()
        {
            questionOrientation = new QuestionOrientation();
            questionOrientationRepository = new QuestionOrientationRepository();
            QuestionsOrientations = new ObservableCollection<QuestionOrientation>(questionOrientationRepository.Listing());
            AjoutQuestion = new RelayCommand(AjouterQuestion);
            SuppQuestion = new RelayCommand(SupprimerQuestion);
        }

        private void AjouterQuestion()
        {
            questionOrientationRepository = new QuestionOrientationRepository();
            questionOrientationRepository.Create(questionOrientation);
            if (QuestionOrientation.IdQuestion > 0)
            {
                QuestionsOrientations.Add(QuestionOrientation);
                QuestionOrientation = new QuestionOrientation();
            }
        }

        public void SupprimerQuestion()
        {
            questionOrientationRepository = new QuestionOrientationRepository();
            questionOrientationRepository.Delete(questionOrientation);
            if (QuestionOrientation.IdQuestion > 0)
            {
                QuestionsOrientations.Remove(QuestionOrientation);
            }
        }
    }
}
*/