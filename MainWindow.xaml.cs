using System.IO;
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

namespace ParalimpiaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Paralimpia> paralimpiak = new();
        public MainWindow()
        {
            InitializeComponent();
            using StreamReader sr = new(
                path: @"../../../src/ermek.txt",
                encoding: Encoding.UTF8);
            while (!sr.EndOfStream) paralimpiak.Add(new(sr.ReadLine()));

            foreach (var p in paralimpiak) Paralimpiak.ItemsSource = paralimpiak;
        }

        private void Paralimpiak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValasztottEv.Content = paralimpiak.Where(x => x.Orszag.ToLower().Contains(Kereso.Text.ToLower()) || x.Varos.ToLower().Contains(Kereso.Text.ToLower())).ToList()[Paralimpiak.SelectedIndex].Ev;
            ValasztottArany.Text = paralimpiak.Where(x => x.Orszag.ToLower().Contains(Kereso.Text.ToLower()) || x.Varos.ToLower().Contains(Kereso.Text.ToLower())).ToList()[Paralimpiak.SelectedIndex].Arany.ToString();
            ValasztottEzust.Text = paralimpiak.Where(x => x.Orszag.ToLower().Contains(Kereso.Text.ToLower()) || x.Varos.ToLower().Contains(Kereso.Text.ToLower())).ToList()[Paralimpiak.SelectedIndex].Ezust.ToString();
            ValasztottBronz.Text = paralimpiak.Where(x => x.Orszag.ToLower().Contains(Kereso.Text.ToLower()) || x.Varos.ToLower().Contains(Kereso.Text.ToLower())).ToList()[Paralimpiak.SelectedIndex].Bronz.ToString();
        }

        private void Kereso_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Kereso.Text != string.Empty) Paralimpiak.ItemsSource = paralimpiak.Where(x => x.Orszag.ToLower().Contains(Kereso.Text.ToLower()) || x.Varos.ToLower().Contains(Kereso.Text.ToLower()));
            else Paralimpiak.ItemsSource = paralimpiak;
        }

        private void Ajanlat_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Valóban javaslatot tesz a(z) {ValasztottEv.Content} évi paralimpia éremszámára?","Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result.ToString().Equals("Yes"))
            {
                using StreamWriter sw = new(
                    path: @"../../../src/javaslat.txt",
                    append: true
                    );
                sw.WriteLine($"{DateTime.Now} Id:{paralimpiak.Where(x => x.Orszag.ToLower().Contains(Kereso.Text.ToLower()) || x.Varos.ToLower().Contains(Kereso.Text.ToLower())).ToList()[Paralimpiak.SelectedIndex].Id} Érmek: {ValasztottArany.Text} {ValasztottEzust.Text} {ValasztottBronz.Text}");
            }
        }
    }
}