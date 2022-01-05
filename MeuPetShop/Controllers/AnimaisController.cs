using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro_de_pessoas.Data;
using Cadastro_de_pessoas.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cadastro_de_pessoas.Controllers
{
    [Authorize]
    public class AnimaisController : Controller
    {
        private readonly AppliccationContext _context;

        private readonly IAnimalRepository _animalRepository;

        public AnimaisController(AppliccationContext context,IAnimalRepository animalRepository)
        {
            _context = context;
            _animalRepository = animalRepository;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            var appliccationContext = _context.Animais.Include(a => a.Pessoa).Include(a => a.Tipo);
            return View(await appliccationContext.ToListAsync());
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais
                .Include(a => a.Pessoa)
                .Include(a => a.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "CPF");
            ViewData["TipoId"] = new SelectList(_context.TiposDeAnimais, "Id", "Nome");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "CPF", animal.PessoaId);
            ViewData["TipoId"] = new SelectList(_context.TiposDeAnimais, "Id", "Nome", animal.TipoId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "CPF", animal.PessoaId);
            ViewData["TipoId"] = new SelectList(_context.TiposDeAnimais, "Id", "Nome", animal.TipoId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "CPF", animal.PessoaId);
            ViewData["TipoId"] = new SelectList(_context.TiposDeAnimais, "Id", "Nome", animal.TipoId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animais
                .Include(a => a.Pessoa)
                .Include(a => a.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var animal = await _context.Animais.FindAsync(id);
            _context.Animais.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(Guid id)
        {
            return _context.Animais.Any(e => e.Id == id);
        }
    }
}
