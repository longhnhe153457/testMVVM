using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using X.PagedList;

namespace eBookStore.Controllers
{
    public class PublishersController : Controller
    {
        private readonly HttpClient client = null;
        private string url = "";

        public PublishersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7196/api/Publishers";
        }
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
            var publisher = JsonSerializer.Deserialize<List<PublisherDTO>>(json, options);
            var pagedUsers = publisher.ToPagedList(pageNumber, pageSize);
            return View(pagedUsers);
        }

        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            return View();
        }

        // POST: PublishersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PublisherDTO publisherDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(publisherDTO);
                var response = await client.PostAsync($"{url}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Publishers");
                }
                else
                {
                    return View(publisherDTO);
                }
            }
            catch
            {
                return View(publisherDTO);
            }
        }

        // GET: PublishersController/Edit/5
        public async Task<ActionResult> EditAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            var response = await client.GetAsync($"{url}/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var publisher = JsonSerializer.Deserialize<PublisherDTO>(json, options);
            return View(publisher);
        }

        // POST: PublishersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(PublisherDTO publisherDTO)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            try
            {
                JsonContent content = JsonContent.Create(publisherDTO);
                var response = await client.PutAsync($"{url}/{publisherDTO.PubId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Publishers");
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

        // GET: PublishersController/Delete/5
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (HttpContext.Session.GetString("admin") is null) return RedirectToAction("Authen", "Home");
            HttpResponseMessage response = await client.DeleteAsync($"{url}/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
