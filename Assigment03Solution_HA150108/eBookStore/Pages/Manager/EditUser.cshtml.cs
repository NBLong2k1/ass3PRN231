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
    public class EditUserModel : PageModel
    {
        private IUserRepository repository = new UserRepository();

        private IPublisherRepository repositoryPublisher = new PublisherRepository();
        private readonly HttpClient client = null;
        private string UserApiUlr = "";

        List<User> listUser { get; set; }

        public List<Publisher> listPublisher { get; set; }
        public User User { get; set; } = default!;

        public EditUserModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUlr = "https://localhost:7055/api/Users";
            listPublisher = repositoryPublisher.GetPublisher();
        }

        [HttpGet]
        public async Task OnGet(int id)
        {
            UserApiUlr += "?$filter=UserId eq " + id;
            HttpResponseMessage respone = await client.GetAsync(UserApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //auth = JsonSerializer.Deserialize<Author>(strData, options);
            listUser = JsonSerializer.Deserialize<List<User>>(strData, options);

            foreach (var au in listUser)
            {
                User = au;
            }
             


        }
        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            User.RoleId = 1;
            repository.UpdateUser(User);
            int roleUser = (int)HttpContext.Session.GetInt32("roleId");
            if (roleUser==2)
            {
                return RedirectToPage("UserManager");
            }
            return RedirectToPage("/Home/Home");
        }
    }
}
