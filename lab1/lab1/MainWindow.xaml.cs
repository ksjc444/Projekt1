using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>
        {
            new Person {FirstName = "Imię", SurName="Nazwisko", Photo= new BitmapImage(new Uri("person_image_sample.jpg", UriKind.Relative))}
        };

        public ObservableCollection<Person> Items
        {
            get => people;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog pictureDialog = new OpenFileDialog();
            pictureDialog.Title = "Wybierz zdjęcie";
            pictureDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        "Portable Network Graphic (*.png)|*.png";

            if (pictureDialog.ShowDialog() == true)
            {
                BigImageDisplay.Source = new BitmapImage(new Uri(pictureDialog.FileName));
            }
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            people.Add(new Person { FirstName = FirstNameTextBox.Text, SurName = SurNameTextBox.Text, Photo=BigImageDisplay.Source });
        }
    }
}
