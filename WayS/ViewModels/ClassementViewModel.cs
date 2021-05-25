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
    class ClassementViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        public ICommand NavigateCommand { get; set; }


        private Models.Classement classement;
        private ClassementReposiory classementReposiory;
        private List<Models.Classement> listClassement;

        public List<Models.Classement> ListClassement
        {
            get => listClassement;
            set => listClassement = value;
        }

        public Models.Classement Classement
        {
            get => classement;
            set
            {
                classement = value;
                if (classement != null)
                {
                    RaisePropertyChanged("QuestionText");
                }
            }
        }


    public ClassementViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand<string>(ActionNavigate);
            Classement = new Models.Classement();
            classementReposiory = new ClassementReposiory();

            listClassement = new List<Models.Classement>(classementReposiory.Listing());

        }

        private void ActionNavigate(string page)
        {
            _navigationService.NavigateTo(nameof(Accueil));
        }
    }
}
