using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using WayS.Models;
using WayS.Repositories;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class ResultatOrientationViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private Bareme bareme;
        private BaremeRepository baremeRepository;
        private List<Bareme> listBareme;

        private int scoreFrontEnd;
        private int scoreBackEnd;
        private int scoreReseaux;
        private int scoreManager;
        private string baremeTitle;


        public Bareme Bareme
        {
            get => bareme;
            set
            {
                bareme = value;
                if (bareme != null)
                {
                    RaisePropertyChanged("baremeTitle");
                }
            }
        }

        public ICommand NavigateCommand { get; set; }

        public ResultatOrientationViewModel(IFrameNavigationService navigationService)
        {

            _navigationService = navigationService;
            Bareme = new Bareme();
            baremeRepository = new BaremeRepository();
            NavigateCommand = new RelayCommand(ActionNavigate);

            scoreFrontEnd = 3;
            scoreBackEnd = 0;
            scoreReseaux = 0;
            scoreManager = 0;

            if (scoreFrontEnd > scoreBackEnd && scoreFrontEnd > scoreReseaux && scoreFrontEnd > scoreManager)
            {
                baremeTitle = "Front-End";
                listBareme = new List<Bareme>(baremeRepository.FindByBareme(baremeTitle));
                Bareme = listBareme[0];
            }
        }

        private void ActionNavigate()
        {
            _navigationService.NavigateTo(nameof(Accueil));
        }
    }
}
