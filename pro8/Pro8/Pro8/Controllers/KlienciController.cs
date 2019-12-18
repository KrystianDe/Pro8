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
    public class KlienciController : ControllerBase
    {

        private SkniContext _context;
        public KlienciController(SkniContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metoda zwraca na temat klientow pizzeri
        /// </summary>

        [HttpGet]
        public IActionResult GetKlienci()
        {
            return Ok(_context.Osoba.ToList());
        }



        [HttpGet("{id:int}")]
        public IActionResult GetKlient(int id)
        {
            var osoba = _context.Klient.FirstOrDefault(e => e.IdKlient == id);
            if (osoba == null)
            {
                return NotFound();
            }
            return Ok(osoba);
        }

        [HttpPut("{IdKlient:int}")]
        public IActionResult Update(Klient updatedKlient)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdKlient ==
                    updatedKlient.IdKlient);

            if(_context.Klient.Count(e => e.IdKlient ==
                    updatedKlient.IdKlient) == 0)
            {
                return NotFound();
            }
            _context.Klient.Attach(updatedKlient);
            _context.Entry(updatedKlient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedKlient);
        }

        [HttpDelete("{IdKlient:int}")]
        public IActionResult Delete(int idKlient)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdKlient ==
                    idKlient);

            if (klient == null)
            {
                return NotFound();
            }
            _context.Klient.Remove(klient);
            _context.SaveChanges();

            return Ok(klient);
        }

    }
}