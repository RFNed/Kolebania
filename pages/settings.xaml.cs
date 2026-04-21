using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using kolebania;
namespace kolebania.pages
{
    /// <summary>
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        public settings()
        {
            InitializeComponent();
        }
        public class SettingsData
        {
            public float duration { get; set; }
            public float sample_rate { get; set; }
            public float frequency { get; set; }
            public float amplitude { get; set; }
            public float phase { get; set; }
        }
        private void duration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        

        private void phase_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (duration.Text != "" && sample_rate.Text != "" && frequency.Text != "" && amplitude.Text != "" && phase.Text != "")
            {
                var mainWin = Application.Current.MainWindow as MainWindow;
                if (mainWin != null)
                {
                    DateTime time = DateTime.Now;
                    float durationValue = float.Parse(duration.Text, CultureInfo.InvariantCulture);
                    mainWin.InsertConsoleLogs($"* Duration: {durationValue}");
                    float sampleRateValue = float.Parse(sample_rate.Text, CultureInfo.InvariantCulture);
                    mainWin.InsertConsoleLogs($"* Sample Rate: {sampleRateValue}");
                    float frequencyValue = float.Parse(frequency.Text, CultureInfo.InvariantCulture);
                    mainWin.InsertConsoleLogs($"* Frequency: {frequencyValue}");
                    float amplitudeValue = float.Parse(amplitude.Text, CultureInfo.InvariantCulture);
                    mainWin.InsertConsoleLogs($"* Amplitude: {amplitudeValue}");
                    float phaseValue = float.Parse(phase.Text, CultureInfo.InvariantCulture);
                    mainWin.InsertConsoleLogs($"* Phase: {phaseValue}");
                    SettingsData data = new SettingsData
                    {
                        duration = durationValue,
                        sample_rate = sampleRateValue,
                        frequency = frequencyValue,
                        amplitude = amplitudeValue,
                        phase = phaseValue
                    };
                    string jsonString = JsonSerializer.Serialize(data);
                    try
                    {
                        mainWin.InsertConsoleLogs($"Saving File...");
                        File.WriteAllText("Resources/data/config.json", jsonString);
                        mainWin.InsertConsoleLogs($"Launching Graphics...");
                        Process.Start("Resources/data/graphics.exe");
                        DateTime time_over = DateTime.Now;
                        mainWin.InsertConsoleLogs($"<b>Done!!!</b> <u>{(time_over - time).TotalSeconds}</u> s");

                    }
                    catch
                    {
                        MessageBox.Show("Отсутствует исполняемый файл или директория", "Ошибка", button: MessageBoxButton.OK, icon: MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", button: MessageBoxButton.OK, icon: MessageBoxImage.Warning);
            }
        }

        private void frequency_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
