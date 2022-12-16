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
            containerRegistry.RegisterForNavigation<VideoConverterWorkAreaPage>();
            containerRegistry.RegisterForNavigation<VideoCompressWorkAreaPage>();
            containerRegistry.RegisterForNavigation<VideoConverterWorkingPage>();
            containerRegistry.RegisterForNavigation<VideoCompressWorkingPage>();
            containerRegistry.RegisterForNavigation<VideoConverterWorkfinishPage>();
            containerRegistry.RegisterForNavigation<VideoCompressWorkfinishPage>();
        }
    }
}
