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
    class MieuxVousConnaitreAdminViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private QuestionMieuxVousConnaitre questionMieuxVousConnaitre;
        private QuestionMieuxVousConnaitreRepository questionMieuxVousConnaitreRepository;
        private List<QuestionMieuxVousConnaitre> listQuestionMieuxVousConnaitres;

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
        public ICommand ModifyQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }


        public MieuxVousConnaitreAdminViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            QuestionMieuxVousConnaitre = new QuestionMieuxVousConnaitre();
            questionMieuxVousConnaitreRepository = new QuestionMieuxVousConnaitreRepository();
            ModifyQuestionCommand = new RelayCommand(ModifyQuestion);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
            AddQuestionCommand = new RelayCommand(AddQuestion);

            listQuestionMieuxVousConnaitres = new List<QuestionMieuxVousConnaitre>(questionMieuxVousConnaitreRepository.Listing());
            QuestionMieuxVousConnaitre = listQuestionMieuxVousConnaitres[0];
        }

        private void ModifyQuestion()
        {
            listQuestionMieuxVousConnaitres = new List<QuestionMieuxVousConnaitre>(questionMieuxVousConnaitreRepository.FindByQuestionText(QuestionMieuxVousConnaitre.QuestionText));
            _navigationService.NavigateTo(nameof(ModifierJeu));
        }

        private void DeleteQuestion()
        {
            questionMieuxVousConnaitreRepository.Delete(QuestionMieuxVousConnaitre);
        }

        private void AddQuestion()
        {
            string newQuestionMieuxVousConnaitreText = Interaction.InputBox("Modification en cours !", "Entrez la QuestionMieuxVousConnaitre", "");
            string newPosition = Interaction.InputBox("Modification en cours !", "Entrez position", "");
            QuestionMieuxVousConnaitre.QuestionText = newQuestionMieuxVousConnaitreText;
            QuestionMieuxVousConnaitre.Position = Int32.Parse(newPosition);
            questionMieuxVousConnaitreRepository.Create(QuestionMieuxVousConnaitre);
        }

    }
}
