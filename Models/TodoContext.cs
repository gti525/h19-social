
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreHeroku.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<bumb> bumb { get; set; }
    }
}
