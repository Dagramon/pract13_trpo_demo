using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.Classes.Models
{
    public class Course : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private ObservableCollection<CourseStudent> _courseStudents;
        public ObservableCollection<CourseStudent> CourseStudents
        {
            get => _courseStudents;
            set => SetProperty(ref _courseStudents, value);
        }
    }
}
