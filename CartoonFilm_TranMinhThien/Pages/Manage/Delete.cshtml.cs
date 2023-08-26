using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAOs.Models;
using Repo.Imple;
using Repo;

namespace CartoonFilm_TranMinhThien.Pages.Manage
{
    public class DeleteModel : PageModel
    {
        ICartoonFirmRepo repo = new CartoonFirmRepo();

        [BindProperty]
         public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            var loginId = HttpContext.Session.GetInt32("User").ToString();
            if (string.IsNullOrEmpty(loginId))
            {
                return RedirectToPage("../Login");
            }
            if (repo.CheckLogin(loginId) == null)
            {
                return RedirectToPage("../Login");
            }


            if (id == null)
            {
                return NotFound();
            }

            var correspondingauthor = repo.GetFilmById(id);

            if (correspondingauthor == null)
            {
                return NotFound();
            }
            else
            {
                CartoonFilmInformation = correspondingauthor;
            }

            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            repo.DeleteFilm(id);

            return RedirectToPage("./Index");
        }
    }
}
