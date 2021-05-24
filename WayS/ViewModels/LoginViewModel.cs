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
    class LoginViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Administrateur administrateur;
        private AdministrateurRepository administrateurRepository;
        private List<Administrateur> listAdministrateur;

        private string login;

        public string Login
        {
            get => this.login;
            set
            {
                this.login = value;
                RaisePropertyChanged();
            }
        }

        private string mdp;

        public string Mdp
        {
            get => this.mdp;
            set
            {
                this.mdp = value;
                RaisePropertyChanged();
            }
        }

        public Administrateur Administrateur
        {
            get => administrateur;
            set
            {
                administrateur = value;
                if (administrateur != null)
                {
                    RaisePropertyChanged("baremeTitle");
                }
            }
        }

        public ICommand NavigateCommand { get; set; }

        public LoginViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            administrateurRepository = new AdministrateurRepository();
            NavigateCommand = new RelayCommand(ActionNavigate);
        }

        private void ActionNavigate()
        {
            try
            {
                listAdministrateur = new List<Administrateur>(administrateurRepository.FindByLogin(Login));
                Administrateur = listAdministrateur[0];
                if (Administrateur.Mdp == Mdp)
                {
                    _navigationService.NavigateTo(nameof(MenuAdmin));
                }
            }
            catch
            {
                MessageBox.Show("Bad Login !", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }



        }
    }
}
