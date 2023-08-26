using DAOs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo;
using Repo.Imple;

namespace AuthorInstitution_TranMinhThien.Pages
{
    public class LoginModel : PageModel
    {
        ICartoonFirmRepo repo = new CartoonFirmRepo();

        [BindProperty]
        public MemberAccount MemberAccount { get; set; } = default!;

        public IActionResult OnPostLogin()
        {
            MemberAccount? loginAccount = repo.Login(MemberAccount.Email, MemberAccount.Password);
            if (loginAccount == null)
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            }
            else
            if (loginAccount.Role == 3) //manager
            {
                HttpContext.Session.SetInt32("User", loginAccount.MemberId);
                return RedirectToPage("./Manage/Index");
            }
            else
            {
                ViewData["notification"] = "You do not have permission to do this function!";
                return Page();
            }

        }
        public IActionResult OnPostLogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }

    }
}
