using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteApi.Contexto;
using RestauranteApi.Models;
using System.Linq;

namespace pratoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Prato")]
    public class PratoController : Controller
    {
        private readonly RestauranteContexto _context;

        public PratoController(RestauranteContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var prato = _context.Pratos.ToList();
            return Json(prato);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var prato = _context.Pratos.Include(i => i.Restaurante).AsNoTracking().SingleOrDefault(w => w.Id == id);
            return Json(prato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Prato item)
        {
            var prato = _context.Pratos.Find(id);
            if (prato == null)
            {
                return NotFound();
            }
            prato.Descricao = item.Descricao;
            prato.RestauranteId = item.RestauranteId;
            _context.Pratos.Update(prato);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Prato prato)
        {
            _context.Pratos.Add(prato);
            _context.SaveChanges();
            return CreatedAtRoute("Getprato", new { id = prato.Id }, prato);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prato = _context.Pratos.Find(id);
            if (prato == null)
            {
                return NotFound();
            }
            _context.Pratos.Remove(prato);
            _context.SaveChanges();
            return NoContent();
        }
    }
}