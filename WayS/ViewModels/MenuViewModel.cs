using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class MenuViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        public ICommand NavigateCommand { get; set; }

        public MenuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
        }
        private void ActionNavigate(string page)
        {
            switch (page)
            {
                case "jeu":
                    _navigationService.NavigateTo(nameof(QuestionJeu));
                    break;
                case "orientation":
                    /*                    _navigationService.NavigateTo(nameof(Orientation));*/
                    break;
            }
        }
    }
}
