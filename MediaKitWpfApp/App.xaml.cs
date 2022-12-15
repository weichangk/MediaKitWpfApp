using Prism.Ioc;
using System.Windows;
using MediaKitWpfApp.Views;
using System.Windows.Controls;
using MediaKitWpfApp.Views;

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
            //containerRegistry.RegisterForNavigation<WorkAreaPage>();
            containerRegistry.RegisterForNavigation<WorkingPage>();
            containerRegistry.RegisterForNavigation<WorkAreaPageVideoConverter>();     
        }
    }
}
