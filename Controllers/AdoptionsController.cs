using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;
using System.Threading.Tasks;
using System;

namespace AdopcionMascotas.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> AsignarAdopcion(int petId, int adopterId)
        {
            var adopcion = new Adoption
            {
                PetId = petId,
                AdopterId = adopterId,
                FechaAdopcion = DateTime.Now
            };

            _context.Add(adopcion);

            var pet = await _context.Pets.FindAsync(petId);
            pet.EstadoAdopcion = "Adoptada";

            await _context.SaveChangesAsync();
            return RedirectToAction("ListadoAdopciones");
        }

        public async Task<IActionResult> ListadoAdopciones()
        {
            var lista = await _context.Adoptions
                .Include(a => a.Pet)
                .Include(a => a.Adopter)
                .ToListAsync();

            return View(lista);
        }
    }
}
