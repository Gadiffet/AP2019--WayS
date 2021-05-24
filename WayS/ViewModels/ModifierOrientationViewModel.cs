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
    class ModifierOrientationViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private QuestionOrientation questionOrientation;
        private QuestionOrientationRepository questionOrientationRepository;
        private List<QuestionOrientation> listQuestions;

        private string questionText;

        public string QuestionText
        {
            get => this.questionText;
            set
            {
                this.questionText = value;
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
        public ICommand ModifyQuestionCommand { get; set; }
        public ModifierOrientationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            QuestionOrientation = new QuestionOrientation();
            questionOrientationRepository = new QuestionOrientationRepository();
            ModifyQuestionCommand = new RelayCommand(ModifyQuestion);

            listQuestions = new List<QuestionOrientation>(questionOrientationRepository.Listing());
            questionOrientation = listQuestions[0];
        }

        private void ModifyQuestion()
        {
            listQuestions = new List<QuestionOrientation>(questionOrientationRepository.FindByQuestionText(QuestionText));
            _navigationService.NavigateTo(nameof(MenuAdmin));
        }
    }
}
