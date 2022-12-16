using MediaKitWpfApp.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MediaKitWpfApp.ViewModels
{
    public class WorkAreaPageVideoConverterViewModel : WorkAreaPageViewModel
    {
        public WorkAreaPageVideoConverterViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoConverter;
            WorkAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;
        }
    }

    public class WorkAreaPageVideoCompressViewModel : WorkAreaPageViewModel
    {
        public WorkAreaPageVideoCompressViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoCompress;
            WorkAreaRegionName = PrismRegionNameManager.VideoCompressWorkAreaRegionName;
        }
    }

    public class WorkAreaPageViewModel : BindableBase, INavigationAware
    {
        private readonly IEventAggregator ea;
        private readonly IRegionManager rm;
        public DelegateCommand OpenFileCommand { get; private set; }

        private VideoFuncEnum videoFunc;
        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        private string workAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;

        public string WorkAreaRegionName
        {
            get { return workAreaRegionName; }
            set { workAreaRegionName = value; }
        }

        public WorkAreaPageViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
            OpenFileCommand = new DelegateCommand(OpenFile);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void OpenFile()
        {
            var parameters = new NavigationParameters();
            parameters.Add("func", videoFunc);
            rm.RequestNavigate(workAreaRegionName, "WorkingPage", parameters);
        }
    }
}
