using Interview.WebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace Interview.WebApp.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./todo.db");
        }
    }
}
