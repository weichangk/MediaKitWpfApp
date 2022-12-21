using MediaKitWpfApp.Common;
using MediaKitWpfApp.Repositores;
using MediaKitWpfApp.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterWorkAreaPageViewModel : WorkAreaPageViewModel
    {

        public DelegateCommand OpenFormatCommand { get; private set; }
        public DelegateCommand<string> OpenOutputFolderCommand { get; private set; }


        public VideoConverterOutSettingViewModel VideoConverterOutSettingViewModel { get; set; }
        public ObservableCollection<string> OutputFolderList { get; set; }
        public string CurrentOutputFolder { get; set; }

        public VideoConverterWorkAreaPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository) : base(ea, rm, sysParmBaseRepository)
        {
            WorkAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;
            VideoConverterOutSettingViewModel = new VideoConverterOutSettingViewModel(sysParmBaseRepository);
            OutputFolderList = VideoConverterOutSettingViewModel.OutputFolderViewModel.OutputFolderList;
            CurrentOutputFolder = VideoConverterOutSettingViewModel.OutputFolderViewModel.CurrentOutputFolder;
            OpenFormatCommand = VideoConverterOutSettingViewModel.OpenFormatCommand;
            OpenOutputFolderCommand = VideoConverterOutSettingViewModel.OutputFolderViewModel.OpenOutputFolderCommand;
        }

        protected override void OpenFile()
        {
            rm.RequestNavigate(WorkAreaRegionName, nameof(VideoConverterWorkingPage));
            ea.GetEvent<AddVideoConverterWorkingFileEvent>().Publish(new VideoFileInfo());
        }
    }

    public class VideoCompressWorkAreaPageViewModel : WorkAreaPageViewModel
    {
        public VideoCompressWorkAreaPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository) : base(ea, rm, sysParmBaseRepository)
        {
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
        protected readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;

        public DelegateCommand OpenFileCommand { get; private set; }


        private string workAreaRegionName = PrismRegionNameManager.VideoConverterWorkAreaRegionName;
        public string WorkAreaRegionName
        {
            get { return workAreaRegionName; }
            set { workAreaRegionName = value; }
        }


        public WorkAreaPageViewModel(IEventAggregator ea, IRegionManager rm, Lazy<ISysParmBaseRepository> sysParmBaseRepository)
        {
            this.ea = ea;
            this.rm = rm;
            this.sysParmBaseRepository = sysParmBaseRepository;

            OpenFileCommand = new DelegateCommand(OpenFile);
        }

        protected virtual void OpenFile()
        {
            rm.RequestNavigate(workAreaRegionName, nameof(WorkingPage));
        }
    }
}
