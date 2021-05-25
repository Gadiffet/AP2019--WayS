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
    class OrientationAdminViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private QuestionOrientation questionOrientation;
        private QuestionOrientationRepository questionOrientationRepository;
        private List<QuestionOrientation> listQuestions;

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
        public ICommand ModifyQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }

        public OrientationAdminViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            QuestionOrientation = new QuestionOrientation();
            questionOrientationRepository = new QuestionOrientationRepository();
            ModifyQuestionCommand = new RelayCommand(ModifyQuestion);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
            AddQuestionCommand = new RelayCommand(AddQuestion);

            listQuestions = new List<QuestionOrientation>(questionOrientationRepository.Listing());
            questionOrientation = listQuestions[0];
        }

        private void ModifyQuestion()
        {
            listQuestions = new List<QuestionOrientation>(questionOrientationRepository.FindByQuestionText(QuestionOrientation.QuestionText));
            _navigationService.NavigateTo(nameof(ModiferOrientation));
        }

        private void DeleteQuestion()
        {
            questionOrientationRepository.Delete(QuestionOrientation);
        }

        private void AddQuestion()
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entrez la question", "");
            string newPosition = Interaction.InputBox("Modification en cours !", "Entrez position", "");
            string newBareme = Interaction.InputBox("Modification en cours !", "Entrez bareme", "");
            QuestionOrientation.QuestionText = newQuestionText;
            QuestionOrientation.Position = Int32.Parse(newPosition);
            QuestionOrientation.Bareme = newBareme;
            questionOrientationRepository.Create(QuestionOrientation);
        }

    }
}
