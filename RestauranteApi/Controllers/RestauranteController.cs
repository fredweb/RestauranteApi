using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Contexto;
using RestauranteApi.Models;
using System.Linq;

namespace RestauranteApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurante")]
    public class RestauranteController : Controller
    {
        private readonly RestauranteContexto _context;

        public RestauranteController(RestauranteContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var restaurantes = _context.Restaurantes.ToList();
            return Json(restaurantes);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var restaurante = _context.Restaurantes.SingleOrDefault(w => w.Id == id);
            return Json(restaurante);
        }

        [HttpPost("{Nome}")]
        public ActionResult GetByName(string Nome)
        {
            var restaurante = _context.Restaurantes.SingleOrDefault(w => w.Descricao.Equals(Nome));
            if (restaurante == null)
            {
                return NotFound();
            }
            return Json(restaurante);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Restaurante item)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            restaurante.Descricao = item.Descricao;
            _context.Restaurantes.Update(restaurante);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();

            return CreatedAtRoute("Getrestaurante", new { id = restaurante.Id }, restaurante);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var restaurante = _context.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(restaurante);
            _context.SaveChanges();
            return NoContent();
        }
    }
}