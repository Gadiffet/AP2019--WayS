using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class ResultatJeuViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Candidat candidat;
        private CandidatRepository candidatRepository;

        static Random rnd = new Random();

        private int score;

        public int Score
        {
            get => this.score;
            set
            {
                this.score = value;
                RaisePropertyChanged();
            }
        }

        public ICommand NavigateCommand { get; set; }

        public ResultatJeuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            candidatRepository = new CandidatRepository();
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
     
        }

        private void ActionNavigate(string page)
        {
          _navigationService.NavigateTo(nameof(Views.Classement));
        }
    }
}
