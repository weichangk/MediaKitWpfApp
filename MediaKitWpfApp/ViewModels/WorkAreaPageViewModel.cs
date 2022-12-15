using ImTools;
using MediaKitWpfApp.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MediaKitWpfApp.ViewModels
{
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

        public WorkAreaPageViewModel(IEventAggregator _ea, IRegionManager _rm)
        {
            ea = _ea;
            rm = _rm;
            OpenFileCommand = new DelegateCommand(OpenFile);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var func = navigationContext.Parameters["func"];
            if (func != null)
                videoFunc = Enum.Parse<VideoFuncEnum>(func.ToString());
            switch (videoFunc)
            {
                case VideoFuncEnum.VideoConverter:
                    break;
                case VideoFuncEnum.VideoCompress:
                    break;
                default:
                    break;
            }
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
            rm.RequestNavigate("WorkAreaRegion", "WorkingPage", parameters);
        }
    }
}
