using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;

namespace eBookStore.Controllers
{
    public class BooksAuthorsController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";
        private string bookUrl = "";
        private string authorUrl = "";

        public BooksAuthorsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7196/api/BooksAuthors";
            bookUrl = "https://localhost:7196/api/Books";
            authorUrl = "https://localhost:7196/api/Authors";
        }
        // GET: BooksAuthorsController
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
            var booksAuthors = JsonSerializer.Deserialize<List<BookAuthorDTO>>(json, options);
            var pagedUsers = booksAuthors.ToPagedList(pageNumber, pageSize);
            return View(pagedUsers);
        }

        // GET: BooksAuthorsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var bookResponse = await client.GetAsync(bookUrl);
            var authorResponse = await client.GetAsync(authorUrl);
            string bookJson = await bookResponse.Content.ReadAsStringAsync();
            string authorJson = await authorResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ViewBag.Authors = JsonSerializer.Deserialize<List<Author>>(authorJson, options);
            ViewBag.Books = JsonSerializer.Deserialize<List<BookDTO>>(bookJson, options);
            return View();
        }

        // POST: BooksAuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateUpdateBookAuthorDTO bookAuthorDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(bookAuthorDTO);
                var response = await client.PostAsync($"{url}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "BooksAuthors");
                }
                else
                {
                    var bookResponse = await client.GetAsync(bookUrl);
                    var authorResponse = await client.GetAsync(authorUrl);
                    string bookJson = await bookResponse.Content.ReadAsStringAsync();
                    string authorJson = await authorResponse.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ViewBag.Authors = JsonSerializer.Deserialize<List<Author>>(authorJson, options);
                    ViewBag.Books = JsonSerializer.Deserialize<List<BookDTO>>(bookJson, options);
                    return View(bookAuthorDTO);
                }
            }
            catch
            {
                var bookResponse = await client.GetAsync(bookUrl);
                var authorResponse = await client.GetAsync(authorUrl);
                string bookJson = await bookResponse.Content.ReadAsStringAsync();
                string authorJson = await authorResponse.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                ViewBag.Authors = JsonSerializer.Deserialize<List<Author>>(authorJson, options);
                ViewBag.Books = JsonSerializer.Deserialize<List<BookDTO>>(bookJson, options);
                return View(bookAuthorDTO);
            }
        }

        // GET: BooksAuthorsController/Edit/5
        public async Task<ActionResult> EditAsync(string book, string author)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var response = await client.GetAsync($"{url}/{book}/{author}");
            var bookResponse = await client.GetAsync(bookUrl);
            var authorResponse = await client.GetAsync(authorUrl);
            string json = await response.Content.ReadAsStringAsync();
            string bookJson = await bookResponse.Content.ReadAsStringAsync();
            string authorJson = await authorResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var bookAuthorDTO = JsonSerializer.Deserialize<CreateUpdateBookAuthorDTO>(json, options);

            //ViewBag.Authors = 
            List<Author>? authors = JsonSerializer.Deserialize<List<Author>>(authorJson, options);
            ViewBag.Authors = new SelectList(
                authors.Select(x => new SelectListItem()
                {
                    Text = x.FullName,
                    Value = x.AuthorId
                }).ToList(), "Value", "Text", author);
            //ViewBag.Books = 
            List<BookDTO>? books = JsonSerializer.Deserialize<List<BookDTO>>(bookJson, options);
            ViewBag.Books = new SelectList(
                books.Select(x => new SelectListItem()
                {
                    Text = x.Title,
                    Value = x.BookId                
                }).ToList(), "Value", "Text", book);

            return View(bookAuthorDTO);
        }

        // POST: BooksAuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string book, string author, CreateUpdateBookAuthorDTO bookAuthorDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(bookAuthorDTO);
                var response = await client.PutAsync($"{url}/{book}/{author}", content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksAuthorsController/Delete/5
        public async Task<ActionResult> DeleteAsync(string book, string author)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            HttpResponseMessage response = await client.DeleteAsync($"{url}/{book}/{author}");
            return RedirectToAction(nameof(Index));
        }
    }
}
