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
    public class PublisherManagerModel : PageModel
    {
        private IPublisherRepository repository = new PublisherRepository();
        public IList<Publisher> Publisher { get; set; } = default!;

        public Publisher Pub { get; set; }

        private readonly HttpClient client = null;
        private string PublisherApiUlr = "";
        public List<string> City { get; set; }

        public PublisherManagerModel()
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

        [HttpGet]
        public async Task OnGet(string DeleteId, string searchID, string searchPublisherName, string searchCity)
        {
            try
            {
                if (!string.IsNullOrEmpty(DeleteId))
                {
                    DeletePublisher(int.Parse(DeleteId));
                }
                else
                {
                    if (!string.IsNullOrEmpty(searchID))
                    {
                        int id = 0;
                        bool isNumber = int.TryParse(searchID, out id);
                        if (isNumber)
                        {
                            PublisherApiUlr += "?$filter=PubId eq " + id;
                        }
                        // PublisherApiUlr += "?$filter=contains(FirstName,'" + searchName + "')";

                    }
                    else if (!string.IsNullOrEmpty(searchPublisherName))
                    {
                        PublisherApiUlr += "?$filter=contains(PublisherName,'" + searchPublisherName + "')";
                    }
                    
                    else
                    {
                        PublisherApiUlr += "?$filter=contains(city,'" + searchCity + "')";
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            HttpResponseMessage respone = await client.GetAsync(PublisherApiUlr);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Publisher = JsonSerializer.Deserialize<List<Publisher>>(strData, options);

        }
        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
            repository.SavePublisher(Pub);
            return RedirectToPage();
        }


        public async Task<IActionResult> DeletePublisher(int id)
        {
            var author = repository.GetPublisherById(id);

            repository.DeletePublisher(author);
            return RedirectToPage();
        }
    }
}
