using MediaKitWpfApp.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace AVideoWpfApp.ViewModels
{
    public class MainButtonViewModel : BindableBase
    {
        readonly IEventAggregator ea;
        public DelegateCommand<string> OpenFuncCommand { get; private set; }

        public MainButtonViewModel(IEventAggregator ea)
        {
            this.ea = ea;
            OpenFuncCommand = new DelegateCommand<string>(OpenFunc);
        }

        private void OpenFunc(string oper)
        {
            ea.GetEvent<OpenFuncEvent>().Publish(oper);
        }
    }
}
