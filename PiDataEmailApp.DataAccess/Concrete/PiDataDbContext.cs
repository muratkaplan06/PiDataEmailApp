using Microsoft.EntityFrameworkCore;
using PiDataEmailApp.Entities;
using System.Reflection;

namespace PiDataEmailApp.DataAccess.Concrete
{
    public class PiDataDbContext:DbContext
    {
        public PiDataDbContext(DbContextOptions<PiDataDbContext> options):base(options)
        {
            
        }
      

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<EpostaAdresi> EpostaAdresleri { get; set; }
        public DbSet<EpostaGonderim> EpostaGonderimleri { get; set; }
        public DbSet<EpostaGonderimDetay> EpostaGonderimDetaylari { get; set; }

    }
}

