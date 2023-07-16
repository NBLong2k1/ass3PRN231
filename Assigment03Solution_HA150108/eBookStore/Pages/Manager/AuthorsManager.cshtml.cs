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
    public class AuthorsManagerModel : PageModel
    {
        private IAuthorRepository repository = new AuthorRepository();
        public IList<Author> Author { get; set; } = default!;

        public Author auth { get; set; }

        private readonly HttpClient client = null;
        private string AuthorApiUlr = "";
        public List<string>City { get; set; }

        public AuthorsManagerModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthorApiUlr = "https://localhost:7055/api/Authors";
            City=new List<string>();
            City.Add("Ha Noi");
            City.Add("Da Nang");
            City.Add("Nha Trang");
            City.Add("Sai Gon");
            City.Add("Hai Phong");

        }

        [HttpGet]
        public async Task OnGet(string DeleteId, string searchID, string searchLastName, string searchFirstName, string searchCity)
        {
            

                try
                {
                    if (!string.IsNullOrEmpty(DeleteId))
                    {
                        DeleteAuthor(int.Parse(DeleteId));
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(searchID))
                        {
                            int id = 0;
                            bool isNumber = int.TryParse(searchID, out id);
                            if (isNumber)
                            {
                                AuthorApiUlr += "?$filter=AuthorId eq " + id;
                            }
                            // AuthorApiUlr += "?$filter=contains(FirstName,'" + searchName + "')";

                        }
                        else if (!string.IsNullOrEmpty(searchLastName))
                        {
                            AuthorApiUlr += "?$filter=contains(LastName,'" + searchLastName + "')";
                        }
                        else if (!string.IsNullOrEmpty(searchFirstName))
                        {
                            AuthorApiUlr += "?$filter=contains(FirstName,'" + searchFirstName + "')";
                        }
                        else
                        {
                            AuthorApiUlr += "?$filter=contains(city,'" + searchCity + "')";
                        }
                    }



                }
                catch (Exception ex)
                {
                    throw ex;
                }

                HttpResponseMessage respone = await client.GetAsync(AuthorApiUlr);
                string strData = await respone.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                Author = JsonSerializer.Deserialize<List<Author>>(strData, options);

        }



        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.SaveAuthor(auth);
           return RedirectToPage();
        }


        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = repository.GetAuthorById(id);
            
            repository.DeleteAuthor(author);
            return RedirectToPage();
        }
        
    }
}
