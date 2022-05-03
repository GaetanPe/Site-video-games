using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteVideoGames.Models;

namespace SiteVideoGames.Controllers
{
    public class ShopController : Controller
    {
        JsonSerializer serializer = new JsonSerializer();

        public IActionResult Index()
        {
            using(var streamReader = new StreamReader(@"Json\InfoGame.json"))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var model = serializer.Deserialize<Games[]>(jsonReader);
                    return View(model);
                }
            }
            
        }
    }
}
