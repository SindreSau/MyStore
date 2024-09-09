using Microsoft.EntityFrameworkCore;
using MyStore_Entity_Week4.Models;

namespace MyStore_Entity_Week4.Data;

public class ItemDbContext(DbContextOptions<ItemDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}