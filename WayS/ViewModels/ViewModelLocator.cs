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
            SimpleIoc.Default.Register<QuestionMieuxVousConnaitreViewModel>();
            SimpleIoc.Default.Register<QuestionOrientationViewModel>();
            SimpleIoc.Default.Register<ResultatOrientationViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MenuAdminViewModel>();
            SimpleIoc.Default.Register<OrientationAdminViewModel>();
            SimpleIoc.Default.Register<ModifierOrientationViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure(nameof(Accueil), new Uri("../Views/Accueil.xaml", UriKind.Relative));
            navigationService.Configure(nameof(Menu), new Uri("../Views/Menu.xaml", UriKind.Relative));
            navigationService.Configure(nameof(QuestionJeu), new Uri("../Views/QuestionJeu.xaml", UriKind.Relative));
            navigationService.Configure(nameof(MieuxVousConnaitre), new Uri("../Views/MieuxVousConnaitre.xaml", UriKind.Relative));
            navigationService.Configure(nameof(QuestionOrientationView), new Uri("../Views/QuestionOrientationView.xaml", UriKind.Relative));
            navigationService.Configure(nameof(ResultatOrientation), new Uri("../Views/ResultatOrientation.xaml", UriKind.Relative));
            navigationService.Configure(nameof(Login), new Uri("../Views/Login.xaml", UriKind.Relative));
            navigationService.Configure(nameof(MenuAdmin), new Uri("../Views/MenuAdmin.xaml", UriKind.Relative));
            navigationService.Configure(nameof(OrientationAdmin), new Uri("../Views/OrientationAdmin.xaml", UriKind.Relative));
            navigationService.Configure(nameof(ModiferOrientation), new Uri("../Views/ModiferOrientation.xaml", UriKind.Relative));

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

        public QuestionOrientationViewModel OrientationPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QuestionOrientationViewModel>();
            }
        }

        public ResultatOrientationViewModel ResultatOrientationPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ResultatOrientationViewModel>();
            }
        }

        public LoginViewModel LoginPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public MenuAdminViewModel MenuAdminPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuAdminViewModel>();
            }
        }

        public OrientationAdminViewModel OrientationAdminPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrientationAdminViewModel>();
            }
        }

        public ModifierOrientationViewModel ModifierOrientationPageInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ModifierOrientationViewModel>();
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
