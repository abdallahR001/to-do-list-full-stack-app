using Microsoft.EntityFrameworkCore;
using to_do_list.Models;

namespace to_do_list.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<ToDo> ToDos { get; set; } = null!;
    }
}