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
    public class SkladnikiController : ControllerBase
    {
        private SkniContext _context;
        public SkladnikiController(SkniContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSkladniki()
        {
            return Ok(_context.Osoba.ToList());
        }



        [HttpGet("{id:int}")]
        public IActionResult GetSkladnik(int id)
        {
            var osoba = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == id);
            if (osoba == null)
            {
                return NotFound();
            }
            return Ok(osoba);
        }

        [HttpPut("{IdSkladnik:int}")]
        public IActionResult Update(Skladnik updatedSkladnik)
        {
            var skladnik = _context.Klient.FirstOrDefault(e => e.IdKlient ==
                    updatedSkladnik.IdSkladnik);

            if (_context.Klient.Count(e => e.IdKlient ==
                     updatedSkladnik.IdSkladnik) == 0)
            {
                return NotFound();
            }
            _context.Klient.Attach(skladnik);
            _context.Entry(updatedSkladnik).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedSkladnik);
        }

        [HttpDelete("{IdSkladnik:int}")]
        public IActionResult Delete(int idSkladnik)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik ==
                    idSkladnik);

            if (skladnik == null)
            {
                return NotFound();
            }
            _context.Skladnik.Remove(skladnik);
            _context.SaveChanges();

            return Ok(skladnik);
        }
    }
}