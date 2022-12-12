using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MediaKitWpfApp.ViewModels
{
    public class WorkAreaPageViewModel : BindableBase
    {
        private readonly IEventAggregator ea;
        private readonly IRegionManager regionManager;
        public WorkAreaPageViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            regionManager = _rm;
        }
    }
}
