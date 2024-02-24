using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

// httprepl https://localhost:44375
[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    // get 1
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    // post -c "{"name":"Hawaii", "isGlutenFree":false}"
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    // put 3 -c  "{"id": 3, "name":"Hawaiian", "isGlutenFree":false}"
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);

        return NoContent();
    }

    // delete 3
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}
