using pract12_trpo.Classes.Models;
using pract12_trpo.DataBase.Service;

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
    /// Логика взаимодействия для CourseList.xaml
    /// </summary>
    public partial class CourseList : Page
    {
        public CourseService service { get; set; } = new();
        public Course? current { get; set; } = null;
        public CourseList()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void go_edit(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CourseForm(current));
        }

        private void go_add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseForm());
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить курс?",
                "Удалить курс?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите курс для удаления", "Выберите курс",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
