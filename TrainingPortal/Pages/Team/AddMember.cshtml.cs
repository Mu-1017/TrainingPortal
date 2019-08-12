using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingPortal.Models;

namespace TrainingPortal.Pages.Team
{
    public class AddMemberModel : PageModel
    {
        [BindProperty]
        public Member Member { get; set; }

        public readonly ITeamManager _teamManage;

        public AddMemberModel([FromServices]ITeamManager manager)
        {
            _teamManage = manager;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _teamManage.Save(Member);
            return RedirectToPage("/Team/Team");
        }
    }
}