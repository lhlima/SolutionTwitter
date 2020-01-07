using System;
using System.Collections.Generic;

namespace Prova.Itau.Twitter.WebAPI.Models
{
    public partial class Twitters
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int RetweetCount { get; set; }
        public int FavouritesCount { get; set; }
        public string CreatedDate { get; set; }
    }
}
