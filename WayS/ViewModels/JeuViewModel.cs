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
    class JeuViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Question question;
        private Reponses reponseQuestion;
        private QuestionRepository questionRepository;
        private ReponsesRepository reponsesRepository;
        private List<Question> listQuestions;
        private List<Reponses> listReponses;

        private int idQuestion;
        private int maxQuestion;

        public List<Question> ListQuestions
        {
            get => listQuestions;
            set => listQuestions = value;
        }

        public Question Question
        {
            get => question;
            set
            {
                question = value;
                if (question != null)
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

        public JeuViewModel(IFrameNavigationService navigationService)
        {
            AnswerQuestionCommand = new RelayCommand(ActionAnswer);

            _navigationService = navigationService;
            Question = new Question();
            questionRepository = new QuestionRepository();
            reponseQuestion = new Reponses();
            reponsesRepository = new ReponsesRepository();

            listQuestions = new List<Question>(questionRepository.Listing());
            question = listQuestions[0];

            idQuestion = Question.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.Listing(idQuestion));
        }


        private void ActionAnswer()
        {
            maxQuestion = listQuestions.Count;
            idQuestion = Question.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.Listing(idQuestion + 1));

            if (maxQuestion >= Question.IdQuestion + 1)
            {
                Question questionSuivante = null;
                questionSuivante = listQuestions[Question.IdQuestion];
                Question = questionSuivante;

                MessageBox.Show(Question.QuestionText.ToString());
            }
            else
            {
                _navigationService.NavigateTo(nameof(MieuxVousConnaitre));
            }
        }
    }
}
