using BusinessObject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;

namespace eBookStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public UsersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7196/api/Users";
        }

        // GET: UsersController
        public async Task<IActionResult> Index(int? page)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var users = JsonSerializer.Deserialize<List<UserDTO>>(json, options);
            var pagedUsers = users.ToPagedList(pageNumber, pageSize);
            return View(pagedUsers);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            HttpResponseMessage response = await client.DeleteAsync($"{url}/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
