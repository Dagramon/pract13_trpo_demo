using pract12_trpo.DataBase.Service;
using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
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

namespace pract12_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public StudentService service { get; set; } = new();
        public Student? student { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void go_form(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentFormPage());
        }

        private void Edit(object sender, MouseButtonEventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Элемент не выбран");
                return;
            }
            NavigationService.Navigate(new StudentFormPage(student));
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Элемент не выбран");
                return;
            }
            MessageBoxResult result = MessageBox.Show(
                "Вы действительно хотите удалить запись?",
                "Удалить",
                MessageBoxButton.YesNo
                );
            if (result == MessageBoxResult.Yes)
            {
                service.Remove(student);
            }
        }
    }
}
