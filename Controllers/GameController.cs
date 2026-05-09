using Microsoft.AspNetCore.Mvc;
using Modul10_103022400105.Models;

namespace Modul10_103022400105.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        public static List<Game> gameList = new List<Game>()
        {
            new Game
            {
                Id = 1,
                Name = "Valorant",
                Developer = "Riot Games",
                TahunRilis = "2020",
                Genre = "FPS",
                Rating = 8.5,
                Platform = ["PC"],
                Mode = ["Multiplayer"],
                IsOnline = true,
                Harga = 0
            },
            
            new Game
            {
                Id = 2,
                Name = "GTA V",
                Developer = "Rockstar Games",
                TahunRilis = "2013",
                Genre = "Open World",
                Rating = 9.5,
                Platform = ["PC", "PS4", "PS5", "Xbox"],
                Mode = ["Singleplayer", "Multiplayer"],
                IsOnline = true,
                Harga = 300000
            },

            new Game
            {
                Id = 3,
                Name = "The Witcher 3",
                Developer = "CD Projekt Red",
                TahunRilis = "2015",
                Genre = "RPG",
                Rating = 9.7,
                Platform = ["PC", "PS4", "PS5", "Xbox", "Switch"],
                Mode = ["Singleplayer"],
                IsOnline = false,
                Harga = 250000
            }
    
        };

        // GET api/Game
        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return Ok(gameList);
        }

        // GET api/Game/id
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var game = gameList.FirstOrDefault(g => g.Id == id);
            if (gameList == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // POST api/Game
        [HttpPost]
        public ActionResult Post(Game game)
        {
            gameList.Add(game);
            return Ok(game);
        }

        // PUT api/Game
        [HttpPut]
        public ActionResult Put(Game updatedGame, int id)
        {  
            var index = gameList.FindIndex(g => g.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            gameList[index] = updatedGame;
            return Ok(updatedGame);
        }

        // DELETE api/Game
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = gameList.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            gameList.Remove(game);
            return Ok(game);    
        }
    }
}
