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
    public class PublisherAuthorManagerModel : PageModel
    {
        private IBookAuthorRepository repository = new BookAuthorRepository();
        private IBookRepository repositoryBook = new BookRepository();
        private IAuthorRepository repositoryAuthor = new AuthorRepository();
        public IList<BookAuthor> BookAuthorList { get; set; } = default!;

        public BookAuthor BookAuthor { get; set; }

        private readonly HttpClient client = null;
        private string BookAuthorApiUlr = "";

        public List<Book> listBook { get; set; }
        public List<Author> listAuthor { get; set; }

        public PublisherAuthorManagerModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookAuthorApiUlr = "https://localhost:7055/api/BookAuthors";
            listBook = repositoryBook.GetBook();
            listAuthor = repositoryAuthor.GetAuthor();
        }

        [HttpGet]
        public async Task OnGet(string DeleteId, string searchBookID, string searchAuthorID,string searchAuthorOrder,string searchRoyalityPerentage)
        {
            try
            {
                if (!string.IsNullOrEmpty(DeleteId))
                {
                    DeleteBookAuthor(int.Parse(DeleteId));
                }
                else
                {
                    if (!string.IsNullOrEmpty(searchBookID))
                    {
                        int id = 0;
                        bool isNumber = int.TryParse(searchBookID, out id);
                        if (isNumber)
                        {
                            BookAuthorApiUlr += "?$filter=BookId eq " + id;
                        }
                        // AuthorApiUlr += "?$filter=contains(FirstName,'" + searchName + "')";

                    }
                    else if (!string.IsNullOrEmpty(searchAuthorID))
                    {
                        int id = 0;
                        bool isNumber = int.TryParse(searchAuthorID, out id);
                        if (isNumber)
                        {
                            BookAuthorApiUlr += "?$filter=AuthorId eq " + id;
                        }
                    }
                    else if (!string.IsNullOrEmpty(searchAuthorOrder))
                    {
                        
                            BookAuthorApiUlr += "?$filter=contains(AuthorOrder,'" + searchAuthorOrder+"')";
                        
                    }
                    else if (!string.IsNullOrEmpty(searchRoyalityPerentage))
                    {
                        
                            BookAuthorApiUlr += "?$filter=contains(RoyalityPerentage,'" + searchRoyalityPerentage+"')";
                        
                    }

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            HttpResponseMessage respone = await client.GetAsync(BookAuthorApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            BookAuthorList = JsonSerializer.Deserialize<List<BookAuthor>>(strData, options);

        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.SaveBookAuthor(BookAuthor);
            return RedirectToPage();
        }

        public async Task<IActionResult> DeleteBookAuthor(int id)
        {
            var author = repository.GetBookAuthorById(id);

            repository.DeleteBookAuthor(author);
            return RedirectToPage();
        }

    }
}
