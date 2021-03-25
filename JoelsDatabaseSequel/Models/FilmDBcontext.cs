using System;
using Microsoft.EntityFrameworkCore;

namespace JoelsDatabaseSequel.Models
{
    public class FilmDBcontext : DbContext
    {
        public FilmDBcontext (DbContextOptions<FilmDBcontext> options) : base (options)
        {

        }

        public DbSet<Film> Films { get; set; }
    }
}
