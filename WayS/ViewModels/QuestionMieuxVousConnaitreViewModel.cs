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
    class QuestionMieuxVousConnaitreViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private QuestionMieuxVousConnaitre question;
        private QuestionMieuxVousConnaitreRepository questionRepository;
        private List<QuestionMieuxVousConnaitre> listQuestions;

        private int idQuestion;
        private int maxQuestion;

        public List<QuestionMieuxVousConnaitre> ListQuestions
        {
            get => listQuestions;
            set => listQuestions = value;
        }

        public QuestionMieuxVousConnaitre Question
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

        public ICommand AnswerQuestionCommand { get; set; }

        public QuestionMieuxVousConnaitreViewModel(IFrameNavigationService navigationService)
        {
            AnswerQuestionCommand = new RelayCommand(ActionAnswer);

            _navigationService = navigationService;
            Question = new QuestionMieuxVousConnaitre();
            questionRepository = new QuestionMieuxVousConnaitreRepository();


            listQuestions = new List<QuestionMieuxVousConnaitre>(questionRepository.Listing());
            question = listQuestions[0];

            idQuestion = Question.IdQuestion;
        }


        private void ActionAnswer()
        {
            maxQuestion = listQuestions.Count;
            idQuestion = Question.IdQuestion;

            if (maxQuestion >= Question.IdQuestion + 1)
            {
                QuestionMieuxVousConnaitre questionSuivante = null;
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