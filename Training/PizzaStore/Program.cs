using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaStore.DB;
using PizzaStore.Models;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(serviceCollection =>
{
    serviceCollection.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1"
    });
});
// CORS
builder.Services.AddCors(options =>
    options.AddPolicy(name: myAllowSpecificOrigins, corsPolicyBuilder => { corsPolicyBuilder.WithOrigins("*"); }));
// Memory Database
// builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));
// Sqlite
// 设置数据库连接字符串
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";
// 将上下文添加到服务
builder.Services.AddDbContext<PizzaDb>(options => options.UseSqlite(connectionString));


var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
// Swagger
app.UseSwagger();
app.UseSwaggerUI(applicationBuilder =>
    applicationBuilder.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1"));
// CORS
app.UseCors(myAllowSpecificOrigins);
app.MapGet("/", () => "Hello World!");
app.MapGet("/pizza", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});
app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatePizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = updatePizza.Name;
    pizza.Description = updatePizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }

    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});
app.Run();