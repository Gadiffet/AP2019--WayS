using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;
using WayS.Services;

namespace WayS.ViewModels
{
    class AccueilViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Candidat candidat;
        private CandidatRepository candidatRepository;

        private string pseudo;

        public string Pseudo
        {
            get => this.pseudo;
            set
            {
                this.pseudo = value;
                RaisePropertyChanged();
            }
        }


        public ICommand NavigateCommand { get; set; }

        public AccueilViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            candidatRepository = new CandidatRepository();
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
        }

        private void ActionNavigate(string page)
        {
            switch (page)
            {
                case "menu":
                    if (Pseudo is null)
                    {
                        MessageBox.Show("Please enter a username !", "Fatal Error", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        break;
                    }

                    _navigationService.NavigateTo(nameof(Menu), new Candidat(Pseudo));

                    break;
                case "admin":
                    /*                    _navigationService.NavigateTo(nameof(Login));*/
                    break;
            }
        }
    }
}
