using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class QuestionOrientationViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private QuestionOrientation questionOrientation;
        private Reponses reponseQuestion;
        private QuestionOrientationRepository questionOrientationRepository;
        private ReponsesRepository reponsesRepository;
        private List<QuestionOrientation> listQuestions;
        private List<Reponses> listReponses;

        private int idQuestion;
        private int maxQuestion;

        public List<QuestionOrientation> ListQuestions
        {
            get => listQuestions;
            set => listQuestions = value;
        }

        public QuestionOrientation QuestionOrientation
        {
            get => questionOrientation;
            set
            {
                questionOrientation = value;
                if (questionOrientation != null)
                {
                    RaisePropertyChanged("QuestionText");
                }
            }
        }
        public List<Reponses> ListReponses
        {
            get => listReponses;
            set => listReponses = value;
        }

        public Reponses Reponses
        {
            get => reponseQuestion;
            set
            {
                reponseQuestion = value;
                if (reponseQuestion != null)
                {
                    RaisePropertyChanged("QuestionText");
                }
            }
        }

        public ICommand AnswerQuestionCommand { get; set; }

        public QuestionOrientationViewModel(IFrameNavigationService navigationService)
        {
            AnswerQuestionCommand = new RelayCommand(ActionAnswer);

            _navigationService = navigationService;
            QuestionOrientation = new QuestionOrientation();
            questionOrientationRepository = new QuestionOrientationRepository();
            reponseQuestion = new Reponses();
            reponsesRepository = new ReponsesRepository();

            listQuestions = new List<QuestionOrientation>(questionOrientationRepository.Listing());
            questionOrientation = listQuestions[5];

            idQuestion = QuestionOrientation.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.ListingOrientation(idQuestion));
        }

        private void ActionAnswer()
        {
            maxQuestion = listQuestions.Count;
            idQuestion = QuestionOrientation.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.ListingOrientation(idQuestion + 1));

            if (maxQuestion >= QuestionOrientation.IdQuestion + 1)
            {
                QuestionOrientation questionSuivante = null;
                questionSuivante = listQuestions[QuestionOrientation.IdQuestion];
                QuestionOrientation = questionSuivante;

                MessageBox.Show(QuestionOrientation.QuestionText.ToString());
            }
            else
            {
                _navigationService.NavigateTo(nameof(ResultatOrientation));
            }
        }


        /*        public ICommand AjoutQuestion { get; set; }
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
                }*/
    }
}
