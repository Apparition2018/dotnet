using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.DB;

public class PizzaDb : DbContext
{
    public PizzaDb(DbContextOptions options) : base(options)
    {
    }

    [NotNull] public DbSet<Pizza>? Pizzas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 数据种子设定
        // https://learn.microsoft.com/zh-cn/ef/core/modeling/data-seeding
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza {Id = 1, Name = "Pepperoni", Description = "Classic Pepperoni Pizza"});
    }
}
