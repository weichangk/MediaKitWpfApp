using AVideoWpfApp.Views;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace AVideoWpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        readonly IEventAggregator ea;
        readonly IRegionManager regionManager;
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            this.regionManager = regionManager;
            this.ea = ea;

            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainButtonPage));
        }
    }
}
