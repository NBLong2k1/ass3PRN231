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
    public class EditPublisherModel : PageModel
    {
        private IPublisherRepository repository = new PublisherRepository();


        private readonly HttpClient client = null;
        private string PublisherApiUlr = "";
        public List<string> City { get; set; }
        public EditPublisherModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PublisherApiUlr = "https://localhost:7055/api/Publishers";
            City = new List<string>();
            City.Add("Ha Noi");
            City.Add("Da Nang");
            City.Add("Nha Trang");
            City.Add("Sai Gon");
            City.Add("Hai Phong");
        }

        List<Publisher> listPub { get; set; }

        public Publisher pub { get; set; } = default!;

        [HttpGet]
        public async Task OnGet(int id)
        {
            PublisherApiUlr += "?$filter=PubId eq " + id;
            HttpResponseMessage respone = await client.GetAsync(PublisherApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //auth = JsonSerializer.Deserialize<Publisher>(strData, options);
            listPub= JsonSerializer.Deserialize<List<Publisher>>(strData, options);

            foreach (var pu in listPub)
            {
                pub = pu;
                pub.Books = pu.Books;
            }

           
            
            
           


        }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.UpdatePublisher(pub);
            return RedirectToPage("PublisherManager");
        }
    }
}
