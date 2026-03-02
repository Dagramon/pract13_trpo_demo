using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.Classes.Models
{
    public class CourseStudent : ObservableObject
    {
        private int _courseId;
        public int CourseId
        {
            get => _courseId;
            set => SetProperty(ref _courseId, value);
        }
        private Course _course;
        public Course Course
        {
            get => _course;
            set => SetProperty(ref _course, value);
        }
        private int _studentId;
        public int StudentId
        {
            get => _studentId;
            set => SetProperty(ref _studentId, value);
        }
        private Student _student;
        public Student Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }
        private DateOnly _startDate;
        public DateOnly StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }
        private DateOnly _endDate;
        public DateOnly EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }
    }
}
