using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kolebania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InintializeWeb();
        }

        async void InintializeWeb()
        {
            await WebView.EnsureCoreWebView2Async(null);
            await WebView.ExecuteScriptAsync("document.body.style.backgroundColor = 'black';");
            await WebView.ExecuteScriptAsync("document.body.style.color = 'white';");
            DateTime time = DateTime.Now;
            await WebView.ExecuteScriptAsync($"document.body.innerHTML = '[{time.Hour}:{time.Minute}:{time.Second}] — Console Loaded —<br>';");
        }

        public void InitPython()
        {
            // python init.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page.Source = new Uri("pages/settings.xaml", UriKind.Relative);
        }
    }
}