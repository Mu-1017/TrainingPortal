using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainingPortal.Models;

namespace TrainingPortal.Pages.Team
{
    public class AddMemberModel : PageModel
    {
        [BindProperty]
        public Member Member { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public readonly ITeamManager _teamManage;

        public AddMemberModel([FromServices]ITeamManager manager)
        {
            _teamManage = manager;
        }


        public IActionResult OnPost()
        {
            if (Image != null)
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    Image.CopyTo(stream);

                    Member.Image = stream.ToArray();
                    Member.ImageContentType = Image.ContentType;
                }
            }
            _teamManage.Save(Member);
            return RedirectToPage("/Team/Team");
        }
    }
}