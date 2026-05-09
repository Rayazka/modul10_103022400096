namespace Modul10_103022400096.api
{
    public class Game
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public string Developer { get; set; }
        public string TahunRilis { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string[] Plaform { get; set; }
        public string[] Mode { get; set; }
        public string isOnline { get; set; }
        public string Harga { get; set; }

        public Game() { }

       
    }
}
