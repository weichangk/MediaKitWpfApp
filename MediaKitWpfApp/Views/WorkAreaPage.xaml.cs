using System.Windows.Controls;

namespace MediaKitWpfApp.Views
{
    /// <summary>
    /// WorkAreaPage.xaml 的交互逻辑
    /// </summary>
    public partial class WorkAreaPage : UserControl
    {
        public WorkAreaPage()
        {
            InitializeComponent();
        }
    }

    public partial class WorkAreaPageVideoConverter : WorkAreaPage
    {
        public WorkAreaPageVideoConverter() : base()
        {
        }
    }

    public partial class WorkAreaPageVideoCompress : WorkAreaPage
    {
        public WorkAreaPageVideoCompress() : base()
        {
        }
    }
}
