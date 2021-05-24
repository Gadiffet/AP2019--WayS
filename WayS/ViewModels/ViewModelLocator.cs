using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using WayS.Services;
using WayS.Views;

namespace WayS.ViewModels
{
    class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        /// 
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SetupNavigation();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AccueilViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<JeuViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure(nameof(Accueil), new Uri("../Views/Accueil.xaml", UriKind.Relative));
            navigationService.Configure(nameof(Menu), new Uri("../Views/Menu.xaml", UriKind.Relative));
            navigationService.Configure(nameof(QuestionJeu), new Uri("../Views/QuestionJeu.xaml", UriKind.Relative));
            navigationService.Configure(nameof(MieuxVousConnaitre), new Uri("../Views/MieuxVousConnaitre.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        // <summary>
        // Gets the FirstPage view model.
        // </summary>
        // <value>
        // The FirstPage view model.
        // </value>
        public MainViewModel MainPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AccueilViewModel AccueilPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccueilViewModel>();
            }
        }

        public MenuViewModel MenuPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public JeuViewModel JeuPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<JeuViewModel>();
            }
        }

        public QuestionMieuxVousConnaitreViewModel MieuxVousConnaitrePageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionMieuxVousConnaitreViewModel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
