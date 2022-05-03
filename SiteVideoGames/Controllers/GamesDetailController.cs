using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteVideoGames.Models;

namespace SiteVideoGames.Controllers
{
    public class GamesDetailController : Controller
    {
        JsonSerializer serializer = new JsonSerializer();
        [Route("[controller]/{gameName}")]
        public IActionResult Index(string gameName)
        {
            using (var streamReader = new StreamReader(@"Json\InfoGame.json"))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var model = serializer.Deserialize<Games[]>(jsonReader);
                    foreach (var game in model)
                    {
                        if(game.NameGame == gameName)
                        {
                            return View(game);
                        }
                    }
                   return NotFound();
                }
            }
        }
    }
}
