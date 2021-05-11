using WayS.Interfaces;
using WayS.Models;
using WayS.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace WayS.ViewModels
{
    class AdministrateurViewModel : ViewModelBase
    {
        private Administrateur administrateur;
        private AdministrateurRepository administrateurRepository;

        public string Login
        {
            get => administrateur.Login;
            set
            {
                administrateur.Login = value;
                RaisePropertyChanged();
            }
                
        }

        public string Mdp
        {
            get => administrateur.Mdp;
            set
            {
                administrateur.Mdp = value;
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
                    RaisePropertyChanged("Login");
                    RaisePropertyChanged("Mdp");
                }
            }
        }

        public ICommand ValidConnexion { get; set; }
        public AdministrateurViewModel()
        {
            administrateur = new Administrateur();
            administrateurRepository = new AdministrateurRepository();
            ValidConnexion = new RelayCommand(ConnexionAdmin);
        }

        private void ConnexionAdmin()
        {
            administrateurRepository = new AdministrateurRepository();
            Administrateur administrateur = administrateurRepository.FindByLogin(Login);            
        }


/*        public Question ModifierReponse(Question question)
        {
            return null;
        }

        public Question SupprimerReponse(Question question)
        {
            return null;
        }

        public Classement ModifierPointsPseudo(Classement classement)
        {
            return null;
        }

        public Classement ModifierPseudo(Classement classement)
        {
            return null;
        }

        public Classement SupprimerPseudo(Classement classement)
        {
            return null;
        }*/
    }
}
