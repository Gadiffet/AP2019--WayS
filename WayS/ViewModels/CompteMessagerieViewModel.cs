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
    class CompteMessagerieViewModel : ViewModelBase
    {
        private CompteMessagerie compteMessagerie;
        private CompteMessagerieRepository compteMessagerieRepository;

        public string AdresseMail
        {
            get => compteMessagerie.AdresseMail;
            set
            {
                compteMessagerie.AdresseMail = value;
                RaisePropertyChanged();
            }

        }
        public string Message
        {
            get => compteMessagerie.Message;
            set
            {
                compteMessagerie.Message = value;
                RaisePropertyChanged();
            }

        }

        public CompteMessagerie CompteMessagerie
        {
            get => CompteMessagerie;
            set
            {
                compteMessagerie = value;
                if(compteMessagerie != null)
                {
                    RaisePropertyChanged("AdressMail");
                    RaisePropertyChanged("Message");
                }
            }
        }

        public ICommand ModifCompteMessagerie { get; set; }

        public CompteMessagerieViewModel()
        {
            compteMessagerie = new CompteMessagerie();
            compteMessagerieRepository = new CompteMessagerieRepository();
            ModifCompteMessagerie = new RelayCommand(ModifierCompteMessagerie);
        }


        private void ModifierCompteMessagerie()
        {
            compteMessagerieRepository = new CompteMessagerieRepository();
            if(CompteMessagerie.Id > 0)
            {
                compteMessagerieRepository.Update(CompteMessagerie);
            }
        }

        public CompteMessagerie ModifierMessageOrientation(CompteMessagerie compteMessagerie)
        {
            return null;
        }

        public CompteMessagerie ModifierMessagejeu(CompteMessagerie compteMessagerie)
        {
            return null;
        }
    }
}
