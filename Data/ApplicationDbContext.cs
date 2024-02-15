using Microsoft.EntityFrameworkCore;
using SimpleTodoApi.Models;

//Контекст  базы данных
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<TodoItem> Items { get; set; }
}