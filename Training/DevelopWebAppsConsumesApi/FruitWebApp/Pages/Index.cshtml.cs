using System.Text.Json;
using FruitWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FruitWebApp.Pages
{
    public class IndexModel : PageModel
    {
        // IHttpClientFactory set using dependency injection
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Add the data model and bind the form data to the page model properties
        // Enumerable since an array is expected as a response
        [BindProperty]
        public IEnumerable<FruitModel> FruitModels { get; set; }

        // Begin GET operation code
        // OnGet() is async since HTTP requests should be performed async
        public async Task OnGet()
        {
            // Create the HTTP client using the FruitAPI named factory
            var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            // Perform the GET request and store the response. The empty parameter
            // in GetAsync doesn't modify the base address set in the client factory
            using HttpResponseMessage response = await httpClient.GetAsync(string.Empty);

            // If the request is successful deserialize the results into the data model
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                FruitModels = await JsonSerializer.DeserializeAsync<IEnumerable<FruitModel>>(contentStream);
            }
        }
        // End GET operation code
    }
}
