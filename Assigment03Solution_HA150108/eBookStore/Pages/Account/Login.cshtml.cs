using BusinessObject.Model.Entities;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eBookStore.Pages.Account
{
	[BindProperties]
    public class LoginModel : PageModel
    {
        public const string SessionKeyId = "userId";
        public const string SessionKeyRole = "roleId";

        private IUserRepository repository = new UserRepository();
		private readonly HttpClient client = null;
		private string UserApiUlr = "";

		private string DefaultEmail = "";
		private string DefaultPassword = "";
		public LoginModel()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			UserApiUlr = "https://localhost:7055/api/Users";


            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();
            DefaultEmail = configuration["AppSettings:Email"];
            DefaultPassword = configuration["AppSettings:Password"];


        }
		public void OnGet()
		{
			
		}

		

		public async Task<IActionResult> OnPost(string email,string password)
		{
			if (email.Equals(DefaultEmail) && password.Equals(DefaultPassword))
			{
                HttpContext.Session.SetInt32(SessionKeyRole, 2);
            }

			else
			{

			 
			UserApiUlr += "?$filter=EmailAddress eq '" + email+ "' and Password eq '"+password+"'";
			HttpResponseMessage respone = await client.GetAsync(UserApiUlr);
			string strData = await respone.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			var ListUser = JsonSerializer.Deserialize<List<User>>(strData, options);
			User user = new User();

			foreach(var u in ListUser)
			{
				user = u;
			}

			if (ListUser.Count==0)
			{
				TempData["Message"] = "Email or Password is not correct";
				return RedirectToPage();

			}
			
			int roleId= (int)user.RoleId;
                HttpContext.Session.SetString("UserName", "admin");
                HttpContext.Session.SetInt32(SessionKeyId, user.UserId);
            HttpContext.Session.SetInt32(SessionKeyRole, roleId);
            }

            return RedirectToPage("/Home/Home");


		}

		
	}
}
