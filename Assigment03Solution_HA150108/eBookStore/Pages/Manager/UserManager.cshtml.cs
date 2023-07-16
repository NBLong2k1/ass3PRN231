using BusinessObject.Model.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStore.Pages.Manager
{
    [BindProperties]
    public class UserManagerModel : PageModel
    {
        private IUserRepository repository = new UserRepository();
        public IList<User> User { get; set; } = default!;



        public User us { get; set; }

        private readonly HttpClient client = null;
        private string UserApiUlr = "";

        public UserManagerModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUlr = "https://localhost:7055/api/Users";
        }
        [HttpGet]
        public async Task OnGet(string DeleteId, string searchID, string searchEmail, string searchName, string searchPub, string searchRole)
        {
            try
            {
                if (!string.IsNullOrEmpty(DeleteId))
                {
                    DeleteUser(int.Parse(DeleteId));
                }
                else
                {
                    if (!string.IsNullOrEmpty(searchID))
                    {
                        int id = 0;
                        bool isNumber = int.TryParse(searchID, out id);
                        if (isNumber)
                        {
                            UserApiUlr += "?$filter=UserId eq " + id;
                        }
                        // UserApiUlr += "?$filter=contains(FirstName,'" + searchName + "')";

                    }
                    else if (!string.IsNullOrEmpty(searchEmail))
                    {
                        UserApiUlr += "?$filter=contains(EmailAddress,'" + searchEmail + "')";
                    }
                    else if (!string.IsNullOrEmpty(searchName))
                    {
                        UserApiUlr += "?$filter=contains(FirstName,'" + searchName + "') or contains(LastName,'" + searchName + "') or contains(MiddleName,'" + searchName + "')";
                    }

                    else if(!string.IsNullOrEmpty(searchRole))
                    {
                        UserApiUlr += "?$filter=RoleId eq " + searchRole;
                    } else if (!string.IsNullOrEmpty(searchPub))
                    {
                        UserApiUlr += "?$filter=PubId eq " + searchPub;
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            HttpResponseMessage respone = await client.GetAsync(UserApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            User = JsonSerializer.Deserialize<List<User>>(strData, options);
        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.SaveUser(us);
            return RedirectToPage();
        }


        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = repository.GetUserById(id);

            repository.DeleteUser(user);
            return RedirectToPage();
        }
    }
}
