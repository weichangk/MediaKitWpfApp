using MediaKitWpfApp.Common;
using MediaKitWpfApp.Repositores;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class OutputFolderViewModel : BindableBase
    {
        //private readonly Lazy<ISysParmBaseRepository> sysParmBaseRepository;
        private ISysParmBaseRepository sysParmBaseRepository;
        public ISysParmBaseRepository SysParmBaseRepository
        {
            get { return sysParmBaseRepository; }
            set { sysParmBaseRepository = value; }
        }

        public DelegateCommand<string> OpenOutputFolderCommand { get; private set; }

        private VideoFuncEnum videoFunc;
        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        private ObservableCollection<string> outputFolderList = new();
        public ObservableCollection<string> OutputFolderList
        {
            get { return outputFolderList; }
            set { outputFolderList = value; }
        }

        private string currentOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
        public string CurrentOutputFolder
        {
            get { return currentOutputFolder; }
            set { currentOutputFolder  = value; }
        }

        public OutputFolderViewModel(VideoFuncEnum videoFunc)
        {
            OpenOutputFolderCommand = new DelegateCommand<string>(OpenOutputFolder);

            this.videoFunc = videoFunc;
        }



        private void OpenOutputFolder(string folder)
        {
            var sds = SysParmBaseRepository.GetListAllAsync();
        }
    }
}
