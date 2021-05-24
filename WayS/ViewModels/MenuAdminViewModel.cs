using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class MenuAdminViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        public ICommand NavigateCommand { get; set; }

        public MenuAdminViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
        }
        private void ActionNavigate(string page)
        {
            switch (page)
            {
                case "jeu":
                    _navigationService.NavigateTo(nameof(JeuAdmin));
                    break;
                case "orientation":
                    _navigationService.NavigateTo(nameof(OrientationAdmin));
                    break;
                case "compteMessagerie":
                    _navigationService.NavigateTo(nameof(CompteMessagerieMenu));
                    break;
                case "mieuxVousConnaitre":
                    _navigationService.NavigateTo(nameof(MieuxVousConnaitreAdmin));
                    break;
            }
        }
    }
}
