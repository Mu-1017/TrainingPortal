using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
    public class TeamManager : ITeamManager
    {
        IList<Member> _members;

        public TeamManager()
        {
            _members = new List<Member>
            {
                new Member(){Id = 0, Name = "Jonh Doe", Title="Scrum Master" },
                new Member(){Id = 1, Name = "Jane Doe", Title="Product Owner" },
                new Member(){Id = 2, Name = "Mike", Title="Senior Developer" },
                new Member(){Id = 3, Name = "Susan", Title="Developer" }
            };
        }
        public void Delete(long id)
        {
            var item = _members.FirstOrDefault(x => x.Id == id);
            _members.Remove(item);
        }

        public Member Find(long id)
        {
            return _members.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Member> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _members
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public void Save(Member member)
        {
            member.Id = _members.Count;
            _members.Add(member);
        }
    }
}
