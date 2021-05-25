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
    class JeuAdminViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private Question question;
        private QuestionRepository questionRepository;
        private List<Question> listQuestions;

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
        public ICommand ModifyQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }

        public JeuAdminViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Question = new Question();
            questionRepository = new QuestionRepository();
            ModifyQuestionCommand = new RelayCommand(ModifyQuestion);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
            AddQuestionCommand = new RelayCommand(AddQuestion);

            listQuestions = new List<Question>(questionRepository.Listing());
            question = listQuestions[0];
        }

        private void ModifyQuestion()
        {
            listQuestions = new List<Question>(questionRepository.FindByQuestionText(Question.QuestionText));
            _navigationService.NavigateTo(nameof(ModifierJeu));
        }

        private void DeleteQuestion()
        {
            questionRepository.Delete(Question);
        }

        private void AddQuestion()
        {
            string newQuestionText = Interaction.InputBox("Modification en cours !", "Entrez la question", "");
            string newPosition = Interaction.InputBox("Modification en cours !", "Entrez position", "");
            Question.QuestionText = newQuestionText;
            Question.Position = Int32.Parse(newPosition);
            questionRepository.Create(Question);
        }

    }
}
