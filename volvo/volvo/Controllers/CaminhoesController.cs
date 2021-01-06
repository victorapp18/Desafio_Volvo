using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using volvo.Data;
using volvo.Models;

namespace volvo.Controllers
{
    [Authorize]
    public class CaminhoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaminhoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caminhoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caminhao
                .Where(x=> (x.ModeloId == 1 || x.ModeloId == 2) &&
                            x.AnoFabricacao == DateTime.Now.Year && 
                           (x.AnoModelo == DateTime.Now.Year || x.AnoModelo == DateTime.Now.Year + 1))
                .ToListAsync());
        }

        // GET: Caminhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhoes/Create
        public IActionResult Create()
        {

            ViewBag.anoModelo = new List<int>(Enumerable.Range(1990, ((DateTime.Now.Year + 1) - 1990) + 1));
            ViewBag.anoFabricacao = new List<int>(Enumerable.Range(1990, (DateTime.Now.Year - 1990) + 1));
            
            return View();
        }

        // POST: Caminhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModeloId,AnoFabricacao,AnoModelo")] Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        // GET: Caminhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.anoModelo = new List<int>(Enumerable.Range(1990, ((DateTime.Now.Year + 1) - 1990) + 1));
            ViewBag.anoFabricacao = new List<int>(Enumerable.Range(1990, (DateTime.Now.Year - 1990) + 1));

            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao.FindAsync(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            return View(caminhao);
        }

        // POST: Caminhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModeloId,AnoFabricacao,AnoModelo")] Caminhao caminhao)
        {
            if (id != caminhao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.Id))
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
            return View(caminhao);
        }

        // GET: Caminhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caminhao = await _context.Caminhao.FindAsync(id);
            _context.Caminhao.Remove(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhao.Any(e => e.Id == id);
        }
    }
}
