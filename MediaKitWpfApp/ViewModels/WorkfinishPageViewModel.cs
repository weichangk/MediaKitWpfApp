using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace MediaKitWpfApp.ViewModels
{
    public class WorkfinishPageViewModel : BindableBase
    {
        private readonly IEventAggregator ea;

        private ObservableCollection<WorkfinishItemViewModel> workfinishItems = new();

        public ObservableCollection<WorkfinishItemViewModel> WorkfinishItems
        {
            get { return workfinishItems; }
            set { workfinishItems = value; RaisePropertyChanged(); }
        }

        public WorkfinishPageViewModel(IEventAggregator _ea)
        {
            ea = _ea;
        }
    }
}
