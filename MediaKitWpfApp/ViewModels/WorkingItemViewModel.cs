using MediaKitWpfApp.Common;
using Prism.Mvvm;

namespace MediaKitWpfApp.ViewModels
{
    public class WorkingItemViewModel : BindableBase
    {
        private VideoFuncEnum videoFunc;

        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        public WorkingItemViewModel()
        {

        }
    }
}
