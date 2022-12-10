using AVideoWpfApp.Common;
using AVideoWpfApp.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Controls;

namespace AVideoWpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase, ITopWidgetOper
    {
        readonly IEventAggregator ea;
        readonly IRegionManager regionManager;

        public DelegateCommand<string> TopWidgetOperCommand { get; private set; }
        public Action Menu { get; set; } = () => { };
        public Action Min { get; set; } = () => { };
        public Action Close { get; set; } = () => { };

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            this.regionManager = regionManager;
            this.ea = ea;

            TopWidgetOperCommand = new DelegateCommand<string>(TopWidgetOper);

            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainButtonPage));
        }

        private void TopWidgetOper(string oper)
        {
            switch (oper)
            {
                case "Menu":
                    DoMenu();
                    break;
                case "Min":
                    Min?.Invoke();
                    break;
                case "Close":
                    Close?.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void DoMenu()
        {
            //Menu?.Invoke();
        }

    }
}
