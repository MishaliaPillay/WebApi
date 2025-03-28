using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }


    }
}
