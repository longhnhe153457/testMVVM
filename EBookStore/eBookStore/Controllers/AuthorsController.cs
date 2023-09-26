using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;

namespace eBookStore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public AuthorsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7196/api/Authors";
        }
        // GET: AuthorsController
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
            var authors = JsonSerializer.Deserialize<List<AuthorDTO>>(json, options);
            var pagedUsers = authors.ToPagedList(pageNumber, pageSize);
            return View(pagedUsers);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AuthorDTO authorDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(authorDTO);
                var response = await client.PostAsync($"{url}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Authors");
                }
                else
                {
                    return View(authorDTO);
                }
            }
            catch
            {
                return View(authorDTO);
            }
        }

        // GET: AuthorsController/Edit/5
        public async Task<ActionResult> EditAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var response = await client.GetAsync($"{url}/{id}");
            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            AuthorDTO? authorDTO = JsonSerializer.Deserialize<AuthorDTO>(json, options);
            return View(authorDTO);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AuthorDTO authorDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(authorDTO);
                var response = await client.PutAsync($"{url}/{authorDTO.AuthorId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Authors");
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

        // GET: AuthorsController/Delete/5
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            HttpResponseMessage response = await client.DeleteAsync($"{url}/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
