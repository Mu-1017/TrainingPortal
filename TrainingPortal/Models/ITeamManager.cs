using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
    public interface ITeamManager
    {
        void Delete(long id);
        Member Find(long id);
        IEnumerable<Member> GetAll(int? count = null, int? page = null);
        void Save(Member member);
    }
}
