using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Modul10_103022400096.api;

namespace Modul10_103022400096.Controllers
{
    /// GameController adalah sebuah API controller yang menyediakan endpoint untuk mengelola data game.
    [ApiController]
    // Route attribute menentukan rute dasar untuk semua endpoint dalam controller ini, yaitu "Game".
    [Route("[controller]")]
    // GameController mewarisi dari ControllerBase, yang menyediakan fungsionalitas dasar untuk API controller.
    public class GameController : ControllerBase
    {
        // List statis yang menyimpan data game. Ini berfungsi sebagai penyimpanan sementara untuk data game yang dapat diakses oleh semua instance controller.
        private static List<Game> games = new List<Game>()
        {
            // Menambahkan beberapa data game awal ke dalam list games.
            // Setiap game memiliki atribut seperti id,
                // nama, developer, tahun rilis, genre, rating, platform, mode, status online, dan harga.
            new Game { id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = "2020", Genre = "FPS", Rating = "8.5", Plaform = new string[] { "PC" }, Mode = new string[] {"Multiplayer"} , isOnline = "true", Harga = "0" },
            new Game { id = 2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = "2013", Genre = "Open World", Rating = "9.5", Plaform = new string[] { "PC", "PS4", "PS5", "Xbox" }, Mode = new string[] {"Singleplayer", "Multiplayer"}, isOnline = "true", Harga = "300000" },
            new Game { id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = "2015", Genre = "RPG", Rating = "9.7", Plaform = new string[] { "PC", "PS4", "PS5", "Xbox", "Switch" },Mode = new string[] {"Singleplayer"}, isOnline = "false", Harga = "250000" }
        };

        // Endpoint untuk mendapatkan semua game. Menggunakan atribut HttpGet
            // untuk menandai bahwa ini adalah endpoint GET. Mengembalikan daftar game dalam format JSON.
        [HttpGet]
        // ActionResult<IEnumerable<Game>> menunjukkan bahwa endpoint ini mengembalikan hasil berupa daftar game.
        // Ok() digunakan untuk mengembalikan status HTTP 200 OK beserta data game.
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(games);
        }

        // Endpoint untuk mendapatkan game berdasarkan ID. Menggunakan atribut HttpGet dengan parameter id.
        [HttpGet("{id}")]
        // ActionResult<Game> menunjukkan bahwa endpoint ini mengembalikan hasil berupa satu game.
        public ActionResult<Game> GetGameById(int id)
        {
            // Mencari game dalam list games berdasarkan ID yang diberikan. Jika game tidak ditemukan,
                // mengembalikan status HTTP 404 Not Found.
            var game = games.Find(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // Endpoint untuk menambahkan game baru. Menggunakan atribut HttpPost
            // untuk menandai bahwa ini adalah endpoint POST.
        [HttpPost]
        // ActionResult<Game> menunjukkan bahwa endpoint ini mengembalikan
            // hasil berupa game yang baru ditambahkan.
        public ActionResult<Game> Post(Game newGame)
        {
            // Menambahkan game baru ke dalam list games.
                // ID game baru diatur secara otomatis berdasarkan jumlah game yang sudah ada.
            newGame.id = games.Count + 1;
            games.Add(newGame);
            return CreatedAtAction(nameof(Get), new { id = newGame.id }, newGame);
        }


        // Endpoint untuk memperbarui game yang sudah ada. Menggunakan atribut HttpPut dengan parameter id.
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

        // Endpoint untuk menghapus game berdasarkan ID. Menggunakan atribut HttpDelete dengan parameter id.
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
