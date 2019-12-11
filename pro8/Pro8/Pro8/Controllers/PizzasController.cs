using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pro8.Models;

namespace Pro8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private SkniContext _context;
        public PizzasController(SkniContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Osoba.ToList());
        }



        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var osoba = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (osoba == null)
            {
                return NotFound();
            }
            return Ok(osoba);
        }

        [HttpPut("{IdPizza:int}")]
        public IActionResult Update(Pizza updatedPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza ==
                    updatedPizza.IdPizza);

            if (_context.Pizza.Count(e => e.IdPizza ==
                     updatedPizza.IdPizza) == 0)
            {
                return NotFound();
            }
            _context.Pizza.Attach(pizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        [HttpDelete("{IdPizza:int}")]
        public IActionResult Delete(int IdPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza ==
                    IdPizza);

            if (pizza == null)
            {
                return NotFound();
            }
            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}