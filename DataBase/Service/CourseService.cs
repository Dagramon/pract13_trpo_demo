using Microsoft.EntityFrameworkCore;

using pract12_trpo.Classes.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.DataBase.Service
{
    public class CourseService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Course> Courses { get; set; } = new();
        public int Commit() => _db.SaveChanges();
        public void Add(Course course)
        {
            var _course = new Course
            {
                Id = course.Id,
                Title = course.Title,
            };
            _db.Add<Course>(_course);
            Commit();
            Courses.Add(_course);
        }
        public void GetAll()
        {
            var courses = _db.Course
                                .Include(c => c.CourseStudents)
                                .ThenInclude(cs => cs.Student)
                                .ToList();

            Courses.Clear();

            foreach (var course in courses)
            {
                Courses.Add(course);
            }
        }
        public CourseService()
        {
            GetAll();
        }
        public void Remove(Course course)
        {
            _db.Remove<Course>(course);
            if (Commit() > 0)
                if (Courses.Contains(course))
                    Courses.Remove(course);
        }
    }
}
