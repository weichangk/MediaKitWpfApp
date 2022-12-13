using MediaKitWpfApp.Common;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class WorkingPageViewModel : BindableBase
    {
        private readonly IEventAggregator ea;

        private VideoFuncEnum videoFunc;

        public VideoFuncEnum VideoFunc
        {
            get { return videoFunc; }
            set { videoFunc = value; }
        }

        private ObservableCollection<WorkingItemViewModel> workingItems = new();

        public ObservableCollection<WorkingItemViewModel> WorkingItems
        {
            get { return workingItems; }
            set { workingItems = value; RaisePropertyChanged(); }
        }

        public WorkingPageViewModel(IEventAggregator _ea)
        {
            ea = _ea;
        }
    }
}
