using System.ComponentModel.DataAnnotations;

namespace Prova.Itau.Models
{
    public class Twitter
    {
        [Key]
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int RetweetCount { get; set; }
        public int FavouritesCount { get; set; }
        public string CreatedDate { get; set; }
    }
}
