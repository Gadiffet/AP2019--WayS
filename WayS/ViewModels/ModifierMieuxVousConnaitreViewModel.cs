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
    class ModifierMieuxVousConnaitreViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Reponses reponseQuestionMieuxVousConnaitre;
        private ReponsesRepository reponsesRepository;
        private QuestionMieuxVousConnaitre questionMieuxVousConnaitre;
        private QuestionMieuxVousConnaitreRepository questionMieuxVousConnaitreRepository;
        private List<QuestionMieuxVousConnaitre> listQuestionMieuxVousConnaitres;
        private List<Reponses> listReponses;

        private int idQuestionMieuxVousConnaitre;


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

        public List<QuestionMieuxVousConnaitre> ListQuestionMieuxVousConnaitres
        {
            get => listQuestionMieuxVousConnaitres;
            set => listQuestionMieuxVousConnaitres = value;
        }

        public QuestionMieuxVousConnaitre QuestionMieuxVousConnaitre
        {
            get => questionMieuxVousConnaitre;
            set
            {
                questionMieuxVousConnaitre = value;
                if (questionMieuxVousConnaitre != null)
                {
                    RaisePropertyChanged("QuestionMieuxVousConnaitreText");
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
            get => reponseQuestionMieuxVousConnaitre;
            set
            {
                reponseQuestionMieuxVousConnaitre = value;
                if (reponseQuestionMieuxVousConnaitre != null)
                {
                    RaisePropertyChanged("QuestionMieuxVousConnaitreText");
                }
            }
        }

        public ICommand ModifyReponseCommand { get; set; }
        public ICommand ModifyQuestionCommand { get; set; }
        public ICommand ModifyScoreCommand { get; set; }
        public ICommand DeleteReponseCommand { get; set; }
        public ICommand AddReponseCommand { get; set; }
        public ICommand NavigateCommand { get; set; }
        public ModifierMieuxVousConnaitreViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            QuestionMieuxVousConnaitre = new QuestionMieuxVousConnaitre();
            questionMieuxVousConnaitreRepository = new QuestionMieuxVousConnaitreRepository();
            reponseQuestionMieuxVousConnaitre = new Reponses();
            reponsesRepository = new ReponsesRepository();

            ModifyReponseCommand = new RelayCommand(ModifyReponse);
            ModifyQuestionCommand = new RelayCommand<QuestionMieuxVousConnaitre>(ModifyQuestion);
            ModifyScoreCommand = new RelayCommand(ModifyScore);
            DeleteReponseCommand = new RelayCommand(DeleteReponse);
            AddReponseCommand = new RelayCommand(AddReponse);
            NavigateCommand = new RelayCommand(ActionNavigate);

            listQuestionMieuxVousConnaitres = new List<QuestionMieuxVousConnaitre>(questionMieuxVousConnaitreRepository.Listing());
            QuestionMieuxVousConnaitre = listQuestionMieuxVousConnaitres[0];

            idQuestionMieuxVousConnaitre = QuestionMieuxVousConnaitre.IdQuestion;
            listReponses = new List<Reponses>(reponsesRepository.ListingMieuxVousConnaitre(idQuestionMieuxVousConnaitre));
            Reponses = listReponses[0];
        }

        private void ModifyReponse()
        {
            string newQuestionMieuxVousConnaitreText = Interaction.InputBox("Modification en cours !", "Entrez la valeur", "");
            Reponses.Reponse = newQuestionMieuxVousConnaitreText;
            reponsesRepository.UpdateMieuxVousConnaitre(Reponses);
        }

        private void ModifyScore()
        {
            string newNbrPoints = Interaction.InputBox("Modification en cours !", "Entrez la valeur", "");
            Reponses.NbrPoints = Int32.Parse(newNbrPoints);
            reponsesRepository.UpdateMieuxVousConnaitre(Reponses);
        }

        private void DeleteReponse()
        {
            reponsesRepository.DeleteMieuxVousConnaitre(Reponses);
        }

        private void AddReponse()
        {
            string newQuestionMieuxVousConnaitreText = Interaction.InputBox("Modification en cours !", "Entrez la QuestionMieuxVousConnaitre", "");
            string newNbrPoints = Interaction.InputBox("Modification en cours !", "Entrez nbrPoint", "");
            Reponses.Reponse = newQuestionMieuxVousConnaitreText;
            Reponses.NbrPoints = Int32.Parse(newNbrPoints);
            Reponses.IdQuestion = QuestionMieuxVousConnaitre.IdQuestion;
            reponsesRepository.CreateMieuxVousConnaitre(Reponses);
        }

        private void ModifyQuestion(QuestionMieuxVousConnaitre questionMieuxVousConnaitre)
        {
            string newQuestionMieuxVousConnaitreText = Interaction.InputBox("Modification en cours !", "Entreez la valeur", "");
            QuestionMieuxVousConnaitre.QuestionText = newQuestionMieuxVousConnaitreText;
            questionMieuxVousConnaitreRepository.Update(QuestionMieuxVousConnaitre);
        }

        private void ActionNavigate()
        {
            _navigationService.NavigateTo(nameof(MenuAdmin));
        }
    }
}
