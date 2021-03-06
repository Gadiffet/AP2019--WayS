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
    class ModifierOrientationViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Reponses reponseQuestion;
        private ReponsesRepository reponsesRepository;
        private QuestionOrientation questionOrientation;
        private QuestionOrientationRepository questionOrientationRepository;
        private List<QuestionOrientation> listQuestions;
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

        public ICommand ModifyReponseCommand { get; set; }
        public ICommand ModifyQuestionCommand { get; set; }
        public ICommand ModifyScoreCommand { get; set; }
        public ICommand DeleteReponseCommand { get; set; }
        public ICommand AddReponseCommand { get; set; }
        public ICommand NavigateCommand { get; set; }
        public ModifierOrientationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            QuestionOrientation = new QuestionOrientation();
            questionOrientationRepository = new QuestionOrientationRepository();
            reponseQuestion = new Reponses();
            reponsesRepository = new ReponsesRepository();

            ModifyReponseCommand = new RelayCommand(ModifyReponse);
            ModifyQuestionCommand = new RelayCommand<QuestionOrientation>(ModifyQuestion);
            ModifyScoreCommand = new RelayCommand(ModifyScore);
            DeleteReponseCommand = new RelayCommand(DeleteReponse);
            AddReponseCommand = new RelayCommand(AddReponse);
            NavigateCommand = new RelayCommand(ActionNavigate);

            listQuestions = new List<QuestionOrientation>(questionOrientationRepository.Listing());
            QuestionOrientation = listQuestions[0];

            idQuestion = QuestionOrientation.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.ListingOrientation(idQuestion));
            Reponses = listReponses[0];
        }

        private void ModifyReponse()
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entrez la valeur", "");
            Reponses.Reponse = newQuestionText;
            reponsesRepository.UpdateOrientation(Reponses);
        }

        private void ModifyScore()
        {
            string newNbrPoints = Interaction.InputBox("Modification en cours !", "Entrez la valeur", "");
            Reponses.NbrPoints = Int32.Parse(newNbrPoints);
            reponsesRepository.UpdateOrientation(Reponses);
        }

        private void DeleteReponse()
        {
            reponsesRepository.DeleteOrientation(Reponses);
        }

        private void AddReponse()
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entrez la question", "");
            string newNbrPoints = Interaction.InputBox("Modification en cours !", "Entrez nbrPoint", "");
            Reponses.Reponse = newQuestionText;
            Reponses.NbrPoints = Int32.Parse(newNbrPoints);
            Reponses.IdQuestion = QuestionOrientation.IdQuestion;
            reponsesRepository.CreateOrientation(Reponses);
        }

        private void ModifyQuestion(QuestionOrientation questionOrientation)
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entreez la valeur", "");
            QuestionOrientation.QuestionText = newQuestionText;
            questionOrientationRepository.Update(QuestionOrientation);
        }

        private void ActionNavigate()
        {
            _navigationService.NavigateTo(nameof(MenuAdmin));
        }
    }
}
