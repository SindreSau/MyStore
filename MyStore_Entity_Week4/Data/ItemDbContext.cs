using Microsoft.EntityFrameworkCore;
using MyStore_Entity_Week4.Models;

namespace MyStore_Entity_Week4.Data;

public class ItemDbContext : DbContext
{
    public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Item?> Items { get; set; }
}