using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prova.Itau.Twitter.WebAPI.Models
{
    public partial class TwitterItauContext : DbContext
    {
        public TwitterItauContext()
        {
        }

        public TwitterItauContext(DbContextOptions<TwitterItauContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Twitters> Twitters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=192.168.0.118;Initial Catalog=TwitterItau;User ID=sa;Password=Unimed#2;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Twitters>(entity =>
            {
                entity.ToTable("twitters");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
