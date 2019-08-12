using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingPortal.Models;

namespace TrainingPortal.Pages.Team
{
    public class MemberModel : PageModel
    {
        public readonly ITeamManager _teamManage;

        [FromRoute]
        public long? Id { get; set; }

        [BindProperty]
        public Member CurrentMember { get; set; }

        public MemberModel([FromServices]ITeamManager manager)
        {
            _teamManage = manager;
        }
        public void OnGet()
        {
            CurrentMember = Id == null? new Member(): _teamManage.Find(Id.Value);
        }

        public IActionResult OnPostDelete()
        {
            if (Id != null)
                _teamManage.Delete(Id.Value);

            return RedirectToPage("/Team/Team");
        }
    }
}