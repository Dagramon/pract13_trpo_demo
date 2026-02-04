using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.DataBase.Service
{
    public class GroupsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<Group> Groups { get; set; } = new();

        public void GetAll()
        {
            var groups = _db.Groups.ToList();
            Groups.Clear();
            foreach (var group in groups)
                Groups.Add(group);
        }
        public int Commit() => _db.SaveChanges();
        public GroupsService()
        {
            GetAll();
        }
        public void Add(Group group)
        {
            var _group = new Group
            {
                Title = group.Title
            };
            _db.Add<Group>(_group);
            Commit();
            Groups.Add(_group);
        }
        public void Remove(Group group)
        {
            _db.Remove<Group>(group);
            if (Commit() > 0)
                if (Groups.Contains(group))
                    Groups.Remove(group);
        }
    }
}
