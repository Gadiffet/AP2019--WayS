using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
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
        private Candidat candidat;
        private CandidatRepository candidatRepository;
        private List<QuestionMieuxVousConnaitre> listQuestions;

        private int idQuestion;
        private int maxQuestion;

        private string value;

        public string Value
        {
            get => this.value;
            set
            {
                this.value = value;
                RaisePropertyChanged();
            }
        }

        private Candidat Candidat
        {
            get => candidat;
            set
            {
                candidat = value;
                if (candidat != null)
                {
                    RaisePropertyChanged("QuestionText");
                }
            }
        }

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
        public ICommand NavigateCommand { get; set; }
        public ICommand AnswerQuestionCommand { get; set; }

        public QuestionMieuxVousConnaitreViewModel(IFrameNavigationService navigationService)
        {
            int ind = 0;
            AnswerQuestionCommand = new RelayCommand(ActionAnswer);
            NavigateCommand = new RelayCommand<string>(ActionNavigate);

            _navigationService = navigationService;
            Question = new QuestionMieuxVousConnaitre();
            questionRepository = new QuestionMieuxVousConnaitreRepository();
            Candidat = new Candidat();
            candidatRepository = new CandidatRepository();

            listQuestions = new List<QuestionMieuxVousConnaitre>(questionRepository.Listing());
            question = listQuestions[0];

            idQuestion = Question.IdQuestion;

        }


        private void ActionAnswer()
        {
            maxQuestion = listQuestions.Count;
            idQuestion = Question.IdQuestion;

            if (idQuestion == 1)
            {
                MessageBox.Show(Value);
                Candidat.Age = Int32.Parse(Value);
            }
            if (idQuestion == 2)
            {
                MessageBox.Show(Value);
                Candidat.Niveau = Value;
            }
            if (idQuestion == 3)
            {
                MessageBox.Show(Value);
                Candidat.Experience = Int32.Parse(Value);
            }
            if (idQuestion == 4)
            {
                MessageBox.Show(Value);
                Candidat.Localisation = Value;
            }
            if (idQuestion == 5)
            {
                MessageBox.Show(Value);
                Candidat.Hobby = Value;
            }
            Candidat.Pseudo = "test";
            candidatRepository.Create(Candidat);

            if (maxQuestion >= Question.IdQuestion + 1)
            {
                QuestionMieuxVousConnaitre questionSuivante = null;
                questionSuivante = listQuestions[Question.IdQuestion];
                Question = questionSuivante;

                MessageBox.Show(Question.QuestionText.ToString());
            }
            else
            {
                _navigationService.NavigateTo(nameof(ResultatJeu));
            }
        }

        private void ActionNavigate(string page)
        {
            _navigationService.NavigateTo(nameof(ResultatJeu));
        }
    }
}