using System.Data.Entity;

namespace Api.Twitter.Itau.Models
{
    public class contexto : DbContext
    {
        public contexto()
            : base("Api.Twitter.Itau") { }

        public DbSet<twitter>Twitters { get; set; }
    }
}