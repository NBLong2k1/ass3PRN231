using BusinessObject.Model.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eBookStore.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private IUserRepository repository = new UserRepository();

        public User user { get;set; }

        public void OnGet()
        {
        }

		public async Task<IActionResult> OnPost()
		{
            if (checkUser(user.EmailAddress))
            {
                user.RoleId = 1;
				repository.SaveUser(user);
				return RedirectToPage("Login");
			}
			TempData["Message"] = "Email is already exist";
			return RedirectToPage();
		}

        bool checkUser(string email)
		{
			var listUser = repository.GetUser();
            if (listUser != null)
            {
                foreach(var user in listUser) {
                    if (user.EmailAddress.Equals(email))
                    {
						return false;
					}

                }

            }

			return true;
        }
	}
}
