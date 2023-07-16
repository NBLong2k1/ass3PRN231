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
    
    public class EditAuthorModel : PageModel
    {
        private IAuthorRepository repository = new AuthorRepository();
        

        private readonly HttpClient client = null;
        private string AuthorApiUlr = "";
        public List<string> City { get; set; }
        public EditAuthorModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthorApiUlr = "https://localhost:7055/api/Authors";
            City = new List<string>();
            City.Add("Ha Noi");
            City.Add("Da Nang");
            City.Add("Nha Trang");
            City.Add("Sai Gon");
            City.Add("Hai Phong");
        }

        List<Author> listAuth { get; set; }

        public Author auth { get; set; } = default!;
        [HttpGet]
        public async Task OnGet(int id)
        {
            AuthorApiUlr += "?$filter=AuthorId eq " + id;
            HttpResponseMessage respone = await client.GetAsync(AuthorApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //auth = JsonSerializer.Deserialize<Author>(strData, options);
            listAuth = JsonSerializer.Deserialize<List<Author>>(strData, options);
            
            foreach(var au in listAuth)
            {
                auth = au;
            }


        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.UpdateAuthor(auth);
            return RedirectToPage("AuthorsManager");
        }
    }
}
