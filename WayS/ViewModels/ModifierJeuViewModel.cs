using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class ModifierJeuViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Reponses reponseQuestion;
        private ReponsesRepository reponsesRepository;
        private Question question;
        private QuestionRepository questionRepository;
        private List<Question> listQuestions;
        private List<Reponses> listReponses;

        private int idQuestion;


        private int id;

        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;
                RaisePropertyChanged();
            }
        }

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

        public ICommand ModifyReponseCommand { get; set; }
        public ICommand ModifyQuestionCommand { get; set; }
        public ICommand ModifyScoreCommand { get; set; }
        public ICommand DeleteReponseCommand { get; set; }
        public ICommand AddReponseCommand { get; set; }
        public ICommand NavigateCommand { get; set; }
        public ModifierJeuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Question = new Question();
            questionRepository = new QuestionRepository();
            reponseQuestion = new Reponses();
            reponsesRepository = new ReponsesRepository();

            ModifyReponseCommand = new RelayCommand(ModifyReponse);
            ModifyQuestionCommand = new RelayCommand<Question>(ModifyQuestion);
            ModifyScoreCommand = new RelayCommand(ModifyScore);
            DeleteReponseCommand = new RelayCommand(DeleteReponse);
            AddReponseCommand = new RelayCommand(AddReponse);
            NavigateCommand = new RelayCommand(ActionNavigate);

            listQuestions = new List<Question>(questionRepository.Listing());
            Question = listQuestions[0];

            idQuestion = Question.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.Listing(idQuestion));
            Reponses = listReponses[0];
        }

        private void ModifyReponse()
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entrez la valeur", "");
            Reponses.Reponse = newQuestionText;
            reponsesRepository.Update(Reponses);
        }

        private void ModifyScore()
        {
            string newNbrPoints = Interaction.InputBox("Modification en cours !", "Entrez la valeur", "");
            Reponses.NbrPoints = Int32.Parse(newNbrPoints);
            reponsesRepository.Update(Reponses);
        }

        private void DeleteReponse()
        {
            reponsesRepository.Delete(Reponses);
        }

        private void AddReponse()
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entrez la question", "");
            string newNbrPoints = Interaction.InputBox("Modification en cours !", "Entrez nbrPoint", "");
            Reponses.Reponse = newQuestionText;
            Reponses.NbrPoints = Int32.Parse(newNbrPoints);
            Reponses.IdQuestion = Question.IdQuestion;
            reponsesRepository.Create(Reponses);
        }

        private void ModifyQuestion(Question question)
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entreez la valeur", "");
            Question.QuestionText = newQuestionText;
            questionRepository.Update(Question);
        }

        private void ActionNavigate()
        {
            _navigationService.NavigateTo(nameof(MenuAdmin));
        }
    }
}
