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
    class ReponsesViewModel : ViewModelBase
    {
        private Reponses reponses;
        private ReponsesRepository reponsesRepository;

        public int IdQuestion
        {
            get => reponses.IdQuestion;
            set
            {
                reponses.IdQuestion = value;
                RaisePropertyChanged();
            }
        }
        public String Reponse
        {
            get => reponses.Reponse;
            set
            {
                reponses.Reponse = value;
                RaisePropertyChanged();
            }
        }

        public int NbrPoints
        {
            get => reponses.NbrPoints;
            set
            {
                reponses.NbrPoints = value;
                RaisePropertyChanged();
            }
        }

        public bool Correct
        {
            get => reponses.Correct;
            set
            {
                reponses.Correct = value;
                RaisePropertyChanged();
            }
        }

        public Reponses Reponses
        {
            get => reponses;
            set
            {
                reponses = value;
                if (reponses != null)
                {
                    RaisePropertyChanged("IdQuestion");
                    RaisePropertyChanged("Reponse");
                    RaisePropertyChanged("NbrPoints");
                    RaisePropertyChanged("Correct");
                }
            }
        }


        public ICommand AjoutReponse { get; set; }
        public ICommand SuppReponse { get; set; }
        public ICommand ModifReponse { get; set; }
        public ObservableCollection<Reponses> ListReponses { get; set; }

        public ReponsesViewModel()
        {
            reponses = new Reponses();
            reponsesRepository = new ReponsesRepository();
            ListReponses = new ObservableCollection<Reponses>(reponsesRepository.Listing());
            AjoutReponse = new RelayCommand(AjouterReponse);
            SuppReponse = new RelayCommand(SupprimerReponse);
            ModifReponse = new RelayCommand(ModifierReponse);
        }

        private void AjouterCandidat()
        {
            reponsesRepository = new ReponsesRepository();
            reponsesRepository.Create(reponses);
            if (Reponses.Id > 0)
            {
                ListReponses.Add(Reponses);
                Reponses = new Reponses();
            }
        }

        private void SupprimerCandidat()
        {
            reponsesRepository = new ReponsesRepository();
            reponsesRepository.Delete(reponses);
            if (Reponses.Id > 0)
            {
                ListReponses.Remove(Reponses);
            }
        }

        private void ModifierCandidat()
        {
            reponsesRepository = new ReponsesRepository();
            reponsesRepository.Update(reponses);
            if (Reponses.Id > 0)
            {
                ListReponses.Remove(Reponses);
                ListReponses.Add(Reponses);
            }
        }
    }
}
