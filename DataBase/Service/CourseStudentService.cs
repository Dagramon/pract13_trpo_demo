using pract12_trpo.Classes.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.DataBase.Service
{
    public class CourseStudentService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public void Add(CourseStudent courseStudent)
        {
            var _courseStudent = new CourseStudent()
            {
                CourseId = courseStudent.CourseId,
                Course = courseStudent.Course,
                StudentId = courseStudent.StudentId,
                Student = courseStudent.Student,
                StartDate = courseStudent.StartDate,
                EndDate = courseStudent.EndDate,
            };
            _db.Add<CourseStudent>(_courseStudent);
            _db.SaveChanges();
        }
    }
}
