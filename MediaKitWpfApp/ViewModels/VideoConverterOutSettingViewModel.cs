using MediaKitWpfApp.Common;
using Prism.Commands;
using Prism.Mvvm;

namespace MediaKitWpfApp.ViewModels
{
    public class VideoConverterOutSettingViewModel : BindableBase
    {
        public DelegateCommand OpenFormatCommand { get; private set; }

        private OutputFolderViewModel outputFolderViewModel;

        public OutputFolderViewModel OutputFolderViewModel
        {
            get { return outputFolderViewModel; }
            set { outputFolderViewModel = value; }
        }

        public VideoConverterOutSettingViewModel()
        {
            OpenFormatCommand = new DelegateCommand(OpenFormat);
            outputFolderViewModel = new OutputFolderViewModel(VideoFuncEnum.VideoConverter);
        }

        private void OpenFormat()
        { 

        }
    }
}
