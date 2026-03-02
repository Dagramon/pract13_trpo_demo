using pract12_trpo.Classes;
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
    /// Логика взаимодействия для SignCourse.xaml
    /// </summary>
    public partial class SignCourse : Page
    {

        public CourseService service { get; set; } = new();
        public CourseStudentService studentService { get; set; } = new();
        public CourseStudent? courseStudent { get; set; } = new();
        public SignCourse(Student student)
        {
            InitializeComponent();
            courseStudent.Student = student;
            DataContext = this;
        }

        private void sign(object sender, RoutedEventArgs e)
        {
            if (courseStudent.Course == null)
            {
                MessageBox.Show("Выберите курс");
            }
            if (startDate.SelectedDate != null &&
                endDate.SelectedDate != null)
            {
                try
                {
                    courseStudent.StartDate = DateOnly.FromDateTime((DateTime)startDate.SelectedDate);
                    courseStudent.EndDate = DateOnly.FromDateTime((DateTime)endDate.SelectedDate);
                    studentService.Add(courseStudent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
