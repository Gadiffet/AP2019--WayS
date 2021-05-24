using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WayS.Services;

namespace WayS.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedCommand;

        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                       ?? (_loadedCommand = new RelayCommand(
                           () => { _navigationService.NavigateTo("Accueil"); }));
            }
        }

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
