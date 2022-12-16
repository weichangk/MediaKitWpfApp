using Prism.Ioc;
using System.Windows;
using MediaKitWpfApp.Views;
using MediaKitWpfApp.ViewModels;

namespace MediaKitWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<WorkAreaPageVideoConverter>();
            containerRegistry.RegisterForNavigation<WorkAreaPageVideoCompress>();
            containerRegistry.RegisterForNavigation<WorkingPage>();
            //containerRegistry.RegisterSingleton<WorkAreaPageViewModel>();
            //containerRegistry.RegisterForNavigation<WorkAreaPageVideoConverter>();     
        }
    }
}
