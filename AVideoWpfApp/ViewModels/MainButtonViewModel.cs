using Prism.Commands;
using Prism.Mvvm;

namespace AVideoWpfApp.ViewModels
{
    public class MainButtonViewModel : BindableBase
    {
        public DelegateCommand<string> OperCommand { get; private set; }

        public MainButtonViewModel()
        {
            OperCommand = new DelegateCommand<string>(Oper);
        }

        private void Oper(string oper)
        {
            switch (oper)
            {
                case "Open":
                    DoOpen();
                    break;
                default:
                    break;
            }
        }

        private void DoOpen()
        {
        }
    }
}
