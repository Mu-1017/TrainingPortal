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
                new Member(){Id = DateTime.Now.ToFileTime(), Name = "Jonh Doe", Title="Scrum Master", Description="Some dummy description here" },
                new Member(){Id = DateTime.Now.ToFileTime(), Name = "Jane Doe", Title="Product Owner", Description="I am who I am" },
                new Member(){Id = DateTime.Now.ToFileTime(), Name = "Mike", Title="Senior Developer", Description="I got nothing to say" },
                new Member(){Id = DateTime.Now.ToFileTime(), Name = "Susan", Title="Developer", Description="What you say is not what it is" }
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
            if(_members.Contains(member))
            {
                //Existing Item
                _members.Remove(member);
            }
            else
            {
                //New Item
                member.Id = DateTime.Now.ToFileTime();
            }

            _members.Add(member);
        }
    }
}
