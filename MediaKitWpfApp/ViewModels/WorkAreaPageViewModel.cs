using MediaKitWpfApp.Common;
using MediaKitWpfApp.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterWorkAreaPageViewModel : WorkAreaPageViewModel
    {
        public DelegateCommand OpenFormatCommand { get; private set; }
        public DelegateCommand<string> OpenOutputFolderCommand { get; private set; }


        private VideoConverterOutSettingViewModel videoConverterOutSettingViewModel;
        public VideoConverterOutSettingViewModel VideoConverterOutSettingViewModel
        {
            get { return videoConverterOutSettingViewModel; }
            set { videoConverterOutSettingViewModel = value; }
        }

        public VideoConverterWorkAreaPageViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoConverter;
            WorkAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;
            videoConverterOutSettingViewModel = new VideoConverterOutSettingViewModel();
            OpenFormatCommand = videoConverterOutSettingViewModel.OpenFormatCommand;
            OpenOutputFolderCommand = videoConverterOutSettingViewModel.OutputFolderViewModel.OpenOutputFolderCommand;
        }

        protected override void OpenFile()
        {
            rm.RequestNavigate(WorkAreaRegionName, nameof(VideoConverterWorkingPage));
            ea.GetEvent<AddVideoConverterWorkingFileEvent>().Publish(new VideoFileInfo());
        }
    }

    public class VideoCompressWorkAreaPageViewModel : WorkAreaPageViewModel
    {
        public VideoCompressWorkAreaPageViewModel(IEventAggregator _ea, IRegionManager _rm) : base(_ea, _rm)
        {
            VideoFunc = VideoFuncEnum.VideoCompress;
            WorkAreaRegionName = PrismRegionNameManager.VideoCompressWorkAreaRegionName;
        }

        protected override void OpenFile()
        {
            rm.RequestNavigate(WorkAreaRegionName, nameof(VideoCompressWorkingPage));
            ea.GetEvent<AddVideoCompressWorkingFileEvent>().Publish(new VideoFileInfo());
        }
    }

    public class WorkAreaPageViewModel : BindableBase
    {
        protected readonly IEventAggregator ea;
        protected readonly IRegionManager rm;
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

        protected virtual void OpenFile()
        {
            rm.RequestNavigate(workAreaRegionName, nameof(WorkingPage));
        }
    }
}
