using Microsoft.EntityFrameworkCore;
using SimpleTodoApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<TodoItem> Items { get; set; }
}