using Microsoft.EntityFrameworkCore;

using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls;

namespace pract12_trpo.DataBase.Service
{
    public class StudentService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Student> Students { get; set; } = new();
        public StudentService()
        {
            GetAll();
        }
        public void Add(Student student)
        {
            var _student = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Birthday = student.Birthday,
                Passport = student.Passport,
                GroupId = student.GroupId,
                Group = student.Group,
            };
            _db.Add<Student>(_student);
            Commit();
            Students.Add(_student);
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var students = _db.Students
                .Include(s => s.Passport)
                .Include(s => s.Group)
                .Include(s => s.CourseStudents)
                .ToList();

            Students.Clear();

            foreach (var student in students)
            {
                Students.Add(student);
            }
        }
        public void Remove(Student student)
        {
            _db.Remove<Student>(student);
            if (Commit() > 0)
            {
                if (Students.Contains(student))
                {
                    Students.Remove(student);
                }
            }
        }
    }
}
