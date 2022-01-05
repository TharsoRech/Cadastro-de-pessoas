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
    public class EventosController : Controller
    {
        private readonly AppliccationContext _context;
        private readonly IEventoRepository _eventoRepository;

        public EventosController(AppliccationContext context,IEventoRepository eventoRepository)
        {
            _context = context;
            _eventoRepository = eventoRepository;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            var appliccationContext = _context.Eventos.Include(e => e.Animal).Include(e => e.Atendente);
            return View(await appliccationContext.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Animal)
                .Include(e => e.Atendente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Nome");
            ViewData["AtendenteId"] = new SelectList(_context.Atendentes, "Id", "Nome");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Nome", evento.AnimalId);
            ViewData["AtendenteId"] = new SelectList(_context.Atendentes, "Id", "Nome", evento.AtendenteId);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Nome", evento.AnimalId);
            ViewData["AtendenteId"] = new SelectList(_context.Atendentes, "Id", "Nome", evento.AtendenteId);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Nome", evento.AnimalId);
            ViewData["AtendenteId"] = new SelectList(_context.Atendentes, "Id", "Nome", evento.AtendenteId);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Animal)
                .Include(e => e.Atendente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(Guid id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
