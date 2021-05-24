using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;

namespace WayS.ViewModels
{
    class CandidatViewModel : ViewModelBase
    {
        private Candidat candidat;
        private CandidatRepository candidatRepository;

        public string Pseudo
        {
            get => candidat.Pseudo;
            set
            {
                candidat.Pseudo = value;
                RaisePropertyChanged();
            }
        }

        public int Score
        {
            get => candidat.Score;
            set
            {
                candidat.Score = value;
                RaisePropertyChanged();
            }
        }

        public int Age
        {
            get => candidat.Age;
            set
            {
                candidat.Age = value;
                RaisePropertyChanged();
            }
        }

        public string Niveau
        {
            get => candidat.Niveau;
            set
            {
                candidat.Niveau = value;
                RaisePropertyChanged();
            }
        }

        public int Experience
        {
            get => candidat.Experience;
            set
            {
                candidat.Experience = value;
                RaisePropertyChanged();
            }
        }

        public string Localisation
        {
            get => candidat.Localisation;
            set
            {
                candidat.Localisation = value;
                RaisePropertyChanged();
            }
        }

        public string Hobby
        {
            get => candidat.Hobby;
            set
            {
                candidat.Hobby = value;
                RaisePropertyChanged();
            }
        }

        public Candidat Candidat
        {
            get => candidat;
            set
            {
                candidat = value;
                if (candidat != null)
                {
                    RaisePropertyChanged("Pseudo");
                    RaisePropertyChanged("Score");
                    RaisePropertyChanged("Age");
                    RaisePropertyChanged("Niveau");
                    RaisePropertyChanged("Experience");
                    RaisePropertyChanged("Localisation");
                    RaisePropertyChanged("Hobby");
                }
            }
        }

        public ICommand AjoutCandidat { get; set; }
        public ICommand SuppCandidat { get; set; }
        public ICommand ModifCandidat { get; set; }

        public ObservableCollection<Candidat> Candidats { get; set; }

        public CandidatViewModel()
        {
            candidat = new Candidat();
            candidatRepository = new CandidatRepository();
            Candidats = new ObservableCollection<Candidat>(candidatRepository.Listing());
            AjoutCandidat = new RelayCommand(AjouterCandidat);
            SuppCandidat = new RelayCommand(SupprimerCandidat);
            ModifCandidat = new RelayCommand(ModifierCandidat);

        }

        private void AjouterCandidat()
        {
            candidatRepository = new CandidatRepository();
            candidatRepository.Create(candidat);
            if (Candidat.Id > 0)
            {
                Candidats.Add(Candidat);
                Candidat = new Candidat();
            }
        }

        private void SupprimerCandidat()
        {
            candidatRepository = new CandidatRepository();
            candidatRepository.Delete(candidat);
            if (Candidat.Id > 0)
            {
                Candidats.Remove(Candidat);
            }
        }

        private void ModifierCandidat()
        {
            candidatRepository = new CandidatRepository();
            candidatRepository.Update(candidat);
            if (Candidat.Id > 0)
            {
                Candidats.Remove(Candidat);
                Candidats.Add(Candidat);
            }
        }
    }
}
