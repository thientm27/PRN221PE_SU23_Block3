using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAOs.Models;
using Repo.Imple;
using Repo;

namespace CartoonFilm_TranMinhThien.Pages.Manage
{
    public class CreateModel : PageModel
    {
        ICartoonFirmRepo repo = new CartoonFirmRepo();
        public IActionResult OnGet()
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

            ViewData["ProducerId"] = new SelectList(repo.GetProducers(), "ProducerId", "ProducerName");
            return Page();
        }

        [BindProperty]
        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;

        public IActionResult OnPost()
        {
            if (CartoonFilmInformation == null)
            {
                return Page();
            }

            if (CartoonFilmInformation.Duration <= 0)
            {
                ModelState.AddModelError("CartoonFilmInformation.Duration",
                    "Duration must > 0");
                return OnGet();
            }
            if (!(CartoonFilmInformation.ReleaseYear <= 2023 && CartoonFilmInformation.ReleaseYear >= 1900))
            {
                ModelState.AddModelError("CartoonFilmInformation.ReleaseYear",
                    "1900 <= ReleaseYear <=2023");
                return OnGet();
            }

            if (!CheckName(CartoonFilmInformation.CartoonFilmName))
            {
                ModelState.AddModelError("CartoonFilmInformation.CartoonFilmName",
                    "CartoonFilmName from 15 to 120 characters. Each word must begin with capital letter");
                return OnGet();
            }
            var result = repo.AddNewFilm(CartoonFilmInformation);

            return RedirectToPage("./Index", new { id = result?.CartoonFilmId });
        }


        private bool CheckName(string name)
        {
            bool check = true;
            if (name.Length <= 14 || name.Length >= 121)
            {
                check = false;
            }

            // Check if each word starts with a capital letter
            string[] nameParts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in nameParts)
            {
                if (!char.IsUpper(part[0]))
                {
                    check = false;
                }
            }

            return check;
        }
    }
}
