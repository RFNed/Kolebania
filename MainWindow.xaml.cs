using System.Text;
using System.Timers;
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
            await WebView.ExecuteScriptAsync($"document.body.innerHTML = '[{time:HH:mm:ss}] — Console Loaded —<br>';");
        }

        async public void InsertConsoleLogs(string? Log)
        {
            DateTime time = DateTime.Now;
            string formattedLog = $"[{time:HH:mm:ss}] - {Log}<br>";
            await WebView.ExecuteScriptAsync($"document.body.insertAdjacentHTML('beforeend', '{formattedLog}');");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page.Source = new Uri("pages/settings.xaml", UriKind.Relative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("https://github.com/RFNed/kolebania \n\nBackend Author: Yupiyushi\nFrontend Author: RFNed", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}