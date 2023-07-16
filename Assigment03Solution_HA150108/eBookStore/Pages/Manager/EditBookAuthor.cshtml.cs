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
    public class EditBookAuthorModel : PageModel
    {
        private IBookAuthorRepository repository = new BookAuthorRepository();


        private readonly HttpClient client = null;
        private string BookAuthorApiUlr = "";

        public EditBookAuthorModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookAuthorApiUlr = "https://localhost:7055/api/BookAuthors";

        }
        List<BookAuthor> listBookAuth { get; set; }

        public BookAuthor BookAuth { get; set; } = default!;
        public async Task OnGet(int id)
        {
            BookAuthorApiUlr += "?$filter=AuthorId eq " + id;
            HttpResponseMessage respone = await client.GetAsync(BookAuthorApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //auth = JsonSerializer.Deserialize<Author>(strData, options);
            listBookAuth = JsonSerializer.Deserialize<List<BookAuthor>>(strData, options);

            foreach (var au in listBookAuth)
            {
                BookAuth = au;
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.UpdateBookAuthor(BookAuth);
            return RedirectToPage("PublisherAuthorManager");
        }
    }
}
