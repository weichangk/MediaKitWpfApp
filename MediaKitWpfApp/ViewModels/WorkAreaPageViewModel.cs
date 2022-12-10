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
        public WorkAreaPageViewModel(IEventAggregator ea, IRegionManager regionManager)
        {
            this.ea = ea;
            this.regionManager = regionManager;

            this.ea.GetEvent<OpenFuncEvent>().Subscribe(OpenFuncReceived);
        }

        private void OpenFuncReceived(string func)
        {
            switch (func)
            {
                case "VideoConverter":
                    regionManager.RequestNavigate("WorkAreaRegion", "WorkAreaPage");
                    break;
                default:
                    break;
            }
        }
    }
}
