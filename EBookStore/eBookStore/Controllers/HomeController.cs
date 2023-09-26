using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = null;
        private string url = "";
        private string _url = "";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            url = "https://localhost:7196/api/Users";
            _url = "https://localhost:7196/api/Publishers";
        }

        public async Task<ActionResult> Profile()
        {
            string? getUser = HttpContext.Session.GetString("member");
            UserDTO? user = null;
            if (getUser is not null)
            {
                user = JsonSerializer.Deserialize<UserDTO>(getUser);
            }
            else
            {
                return RedirectToAction("Authen", "Home");
            }
            var response = await client.GetAsync($"{url}/{user.UserId}");
            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            UserDTO? userDTO = JsonSerializer.Deserialize<UserDTO>(json, options);
            return View(userDTO);
        }

        public async Task<ActionResult> RegisterAsync()
        {
            var response = await client.GetAsync(_url);
            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var publishers = JsonSerializer.Deserialize<List<Publisher>>(json, options);
            ViewBag.Pub = publishers;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(CreateUpdateUserDTO userDTO)
        {
            try
            {
                userDTO.RoleId = true;
                userDTO.HireDate = DateTime.Today;
                JsonContent content = JsonContent.Create(userDTO);
                var response = await client.PostAsync($"{url}/Save", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Authen", "Home");
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
                    return View(userDTO);
                }
            }
            catch
            {
                return RedirectToAction("Register", "Home");
            }
        }

        public ActionResult Authen()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Authen(AuthenDTO authenDTO)
        {
            try
            {
                JsonContent content = JsonContent.Create(authenDTO);
                var response = await client.PostAsync($"{url}/Authen", content);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var user = JsonSerializer.Deserialize<UserDTO>(json, options);
                    if (user.Role == "user")
                    {
                        HttpContext.Session.SetString("member", JsonSerializer.Serialize(user));
                        return RedirectToAction("Profile", "Home");
                    }
                    else if (user.Role == "admin")
                    {
                        HttpContext.Session.SetString("admin", JsonSerializer.Serialize(user));
                        return RedirectToAction("Index", "Users");
                    }
                    return View(authenDTO);
                }
                else
                {
                    return View(authenDTO);
                }
            }
            catch
            {
                return View(authenDTO);
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (HttpContext.Session.GetString("member") is null) return RedirectToAction("Authen", "Home");
            var response = await client.GetAsync($"{url}/Update/{id}");
            var _response = await client.GetAsync(_url);
            string json = await response.Content.ReadAsStringAsync();
            string _json = await _response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ViewBag.Pub = JsonSerializer.Deserialize<List<Publisher>>(_json, options);
            CreateUpdateUserDTO? userDTO = JsonSerializer.Deserialize<CreateUpdateUserDTO>(json, options);
            ViewData["HireDate"] = DateTime.Parse(userDTO.HireDate.ToString()).ToString("yyyy-MM-dd");
            return View(userDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateUpdateUserDTO userDTO)
        {
            if (HttpContext.Session.GetString("member") is null) return RedirectToAction("Authen", "Home");
            try
            {
                userDTO.RoleId = true;
                JsonContent content = JsonContent.Create(userDTO);
                var response = await client.PutAsync($"{url}/{userDTO.UserId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Profile", "Home");
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

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("member");
            HttpContext.Session.Remove("admin");
            return Redirect("~/Home/Authen");
        }
    }
}