using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;

namespace eBookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";
        private string _url = "";
        

        public BooksController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7196/api/Books";
            _url = "https://localhost:7196/api/Publishers";
        }

        // GET: BooksController
        public async Task<ActionResult> IndexAsync(int? page)
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
            var books = JsonSerializer.Deserialize<List<BookDTO>>(json, options);
            var pagedUsers = books.ToPagedList(pageNumber, pageSize);
            return View(pagedUsers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? page, string? bookName, decimal? price)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var pageNumber = page ?? 1;
            var pageSize = 10;
            if (bookName is not null && price is not null) url += $"?$filter=contains(title,'{bookName}') and price eq {price}";
            else if (bookName is not null) url += $"?$filter=contains(title,'{bookName}')";
            else if (price is not null) url += $"?$filter=price eq {price}"; ;
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var books = JsonSerializer.Deserialize<List<BookDTO>>(json, options);
            var pagedUsers = books.ToPagedList(pageNumber, pageSize);
            ViewData["bookName"] = bookName;
            ViewData["price"] = price;
            return View(pagedUsers);
        }

        // GET: BooksController/Create
        public async Task<ActionResult> CreateAsync()
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var response = await client.GetAsync(_url);
            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var publishers = JsonSerializer.Deserialize<List<Publisher>>(json, options);
            ViewBag.Pub = publishers;
            return View(); ;
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateUpdateBookDTO bookDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(bookDTO);
                var response = await client.PostAsync($"{url}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    response = await client.GetAsync(_url);
                    string json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var publishers = JsonSerializer.Deserialize<List<Publisher>>(json, options);
                    ViewBag.Pub = publishers;
                    return View(bookDTO);
                }
            }
            catch
            {
                var response = await client.GetAsync(_url);
                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var publishers = JsonSerializer.Deserialize<List<Publisher>>(json, options);
                ViewBag.Pub = publishers;
                return View(bookDTO); ;
            }
        }

        // GET: BooksController/Edit/5
        public async Task<ActionResult> EditAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var response = await client.GetAsync($"{url}/Update/{id}");
            var _response = await client.GetAsync(_url);
            string json = await response.Content.ReadAsStringAsync();
            string _json = await _response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ViewBag.Pub = JsonSerializer.Deserialize<List<Publisher>>(_json, options);
            CreateUpdateBookDTO? bookDTO = JsonSerializer.Deserialize<CreateUpdateBookDTO>(json, options);
            ViewData["PublishedDate"] = DateTime.Parse(bookDTO.PublishedDate.ToString()).ToString("yyyy-MM-dd");
            return View(bookDTO);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateUpdateBookDTO bookDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(bookDTO);
                var response = await client.PutAsync($"{url}/{bookDTO.BookId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            HttpResponseMessage response = await client.DeleteAsync($"{url}/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
