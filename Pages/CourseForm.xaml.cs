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
    /// Логика взаимодействия для CourseForm.xaml
    /// </summary>
    public partial class CourseForm : Page
    {
        Course _course = new();
        CourseService service = new();
        bool IsEdit = false;
        public CourseForm(Course? course = null)
        {
            InitializeComponent();
            if (course != null)
            {
                _course = course;
                IsEdit = true;
            }
            DataContext = _course;
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_course);

            go_back(sender, e);
        }
    }
}
