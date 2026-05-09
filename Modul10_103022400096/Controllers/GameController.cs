using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Modul10_103022400096.api;

namespace Modul10_103022400096.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>()
        {
            new Game { id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = "2020", Genre = "FPS", Rating = "8.5", Plaform = new string[] { "PC" }, Mode = new string[] {"Multiplayer"} , isOnline = "true", Harga = "0" },
            new Game { id = 2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = "2013", Genre = "Open World", Rating = "9.5", Plaform = new string[] { "PC", "PS4", "PS5", "Xbox" }, Mode = new string[] {"Singleplayer", "Multiplayer"}, isOnline = "true", Harga = "300000" },
            new Game { id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = "2015", Genre = "RPG", Rating = "9.7", Plaform = new string[] { "PC", "PS4", "PS5", "Xbox", "Switch" },Mode = new string[] {"Singleplayer"}, isOnline = "false", Harga = "250000" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(games);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = games.Find(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<Game> Post(Game newGame)
        {
            newGame.id = games.Count + 1;
            games.Add(newGame);
            return CreatedAtAction(nameof(Get), new { id = newGame.id }, newGame);
        }

        [HttpPut("{id}")]
        public ActionResult<Game> Put(int id, Game updatedGame)
        {
            var game = games.Find(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Nama = updatedGame.Nama;
            game.Developer = updatedGame.Developer;
            game.TahunRilis = updatedGame.TahunRilis;
            game.Genre = updatedGame.Genre;
            game.Rating = updatedGame.Rating;
            game.Plaform = updatedGame.Plaform;
            game.Mode = updatedGame.Mode;
            game.isOnline = updatedGame.isOnline;
            game.Harga = updatedGame.Harga;
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = games.Find(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            games.Remove(game);
            return NoContent();
        }


    }
}
