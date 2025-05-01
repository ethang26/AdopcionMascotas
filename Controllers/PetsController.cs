using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Data{
    public class PetsController : Controller{

        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pet);
        }
    }

}
