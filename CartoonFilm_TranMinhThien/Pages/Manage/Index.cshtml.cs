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
    public class IndexModel : PageModel
    {
        ICartoonFirmRepo repo = new CartoonFirmRepo();

        public IList<CartoonFilmInformation> CartoonFilmInformation { get;set; } = default!;
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;

        [BindProperty] public string? SearchBy { get; set; }

        [BindProperty] public string? Keyword { get; set; }
        [BindProperty] public string? NewId { get; set; }


        public IActionResult OnGet(string? id)
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
                NewId = null;
                var data = repo.GetCartoonPagination(PageIndex - 1, PageSize);
                TotalPages = data.TotalPagesCount;
                CartoonFilmInformation = data.Items.ToList();
                return Page();

            }
            else
            {
                NewId = id;
                var data = repo.GetAuthorPaginationSpecialEntity(PageIndex - 1, PageSize, NewId);
                TotalPages = data.TotalPagesCount;
                CartoonFilmInformation = data.Items.ToList();
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (Keyword == null)
            {
                return OnGet(NewId);
            }
            else
            {
                NewId = null;
                if (SearchBy!.Equals("duration"))
                {
                    var data = repo.GetCartoonPaginationSearch(PageIndex - 1, PageSize, Keyword, 1);
                    TotalPages = data.TotalPagesCount;
                    CartoonFilmInformation = data.Items.ToList();
                    return Page();
                }
                else
                {
                    var data = repo.GetCartoonPaginationSearch(PageIndex - 1, PageSize, Keyword, 2);
                    TotalPages = data.TotalPagesCount;
                    CartoonFilmInformation = data.Items.ToList();
                    return Page();
                }
            }
        }
    }
}
