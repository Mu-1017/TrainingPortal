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
    public class EditMemberModel : PageModel
    {
        public readonly ITeamManager _teamManage;

        [FromRoute]
        public long? Id { get; set; }

        [BindProperty]
        public Member CurrentMember { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }


        public EditMemberModel([FromServices]ITeamManager manager)
        {
            _teamManage = manager;
        }
        public void OnGet()
        {
            CurrentMember = Id == null? new Member(): _teamManage.Find(Id.Value);
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var member = _teamManage.Find(Id.Value);
            member.Name = CurrentMember.Name;
            member.Title = CurrentMember.Title;
            member.Description = CurrentMember.Description;

            if (Image != null)
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    Image.CopyTo(stream);

                    member.Image = stream.ToArray();
                    member.ImageContentType = Image.ContentType;
                }
            }

            _teamManage.Save(member);

            return RedirectToPage("/Team/Team");
        }

        public IActionResult OnPostDelete()
        {
            if (Id != null)
                _teamManage.Delete(Id.Value);

            return RedirectToPage("/Team/Team");
        }
    }
}