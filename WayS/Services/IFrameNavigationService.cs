using GalaSoft.MvvmLight.Views;

namespace WayS.Services
{
    interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
