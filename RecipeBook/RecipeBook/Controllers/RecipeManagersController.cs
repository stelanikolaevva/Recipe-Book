using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipeManagersController : Controller
    {
        private readonly RecipeBookContext _context;

        public RecipeManagersController(RecipeBookContext context)
        {
            _context = context;
        }

        // GET: RecipeManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeBook.ToListAsync());
        }

        // GET: RecipeManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeManager = await _context.RecipeBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeManager == null)
            {
                return NotFound();
            }

            return View(recipeManager);
        }

        // GET: RecipeManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Published")] RecipeManager recipeManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeManager);
        }

        // GET: RecipeManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeManager = await _context.RecipeBook.FindAsync(id);
            if (recipeManager == null)
            {
                return NotFound();
            }
            return View(recipeManager);
        }

        // POST: RecipeManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Published")] RecipeManager recipeManager)
        {
            if (id != recipeManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeManagerExists(recipeManager.Id))
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
            return View(recipeManager);
        }

        // GET: RecipeManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeManager = await _context.RecipeBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeManager == null)
            {
                return NotFound();
            }

            return View(recipeManager);
        }

        // POST: RecipeManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeManager = await _context.RecipeBook.FindAsync(id);
            _context.RecipeBook.Remove(recipeManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeManagerExists(int id)
        {
            return _context.RecipeBook.Any(e => e.Id == id);
        }
    }
}
