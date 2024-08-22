using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }
        public DbSet<Models.Pizza>? Pizzas { get; set; }
    }
}
