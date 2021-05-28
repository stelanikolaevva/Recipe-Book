using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using RecipeBook.Data;
using RecipeBook.Models;

namespace RecipeBook.Controllers
{
    public class RecipeIngredientsController : Controller
    {
        private readonly RecipeBookContext _context;
        private readonly IConfiguration _config;


        public RecipeIngredientsController(RecipeBookContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        // GET: RecipeIngredients
        public async Task<IActionResult> Index()
        {
            var recipeBookContext = _context.RecipeIngredients.Include(r => r.Ingredients).Include(r => r.Recipes);
            return View(await recipeBookContext.ToListAsync());
        }

        // GET: RecipeIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredients = await _context.RecipeIngredients
                .Include(r => r.Ingredients)
                .Include(r => r.Recipes) 
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeIngredients == null)
            {
                return NotFound();
            }

            return View(recipeIngredients);
        }

        // GET: RecipeIngredients/Create
        public IActionResult Create()
        {
            ViewData["IngredientsId"] = new SelectList(_context.Ingredients, "Id", "Name");
            ViewData["RecipesId"] = new SelectList(_context.Recipe, "Id", "Name");

            return View();
        }

        // POST: RecipeIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RecipesId,IngredientsId,Quantity,Unit")] RecipeIngredients recipeIngredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeIngredients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientsId"] = new SelectList(_context.Ingredients, "Id", "Name", recipeIngredients.IngredientsId);
            ViewData["RecipesId"] = new SelectList(_context.Recipe, "Id", "Name", recipeIngredients.RecipesId);
            return View(recipeIngredients);
        }

        // GET: RecipeIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredients = await _context.RecipeIngredients.FindAsync(id);
            if (recipeIngredients == null)
            {
                return NotFound();
            }
            ViewData["IngredientsId"] = new SelectList(_context.Ingredients, "Id", "Name", recipeIngredients.IngredientsId);
            ViewData["RecipesId"] = new SelectList(_context.Recipe, "Id", "Name", recipeIngredients.RecipesId);
            return View(recipeIngredients);
        }

        // POST: RecipeIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RecipesId,IngredientsId,Quantity,Unit")] RecipeIngredients recipeIngredients)
        {
            if (id != recipeIngredients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeIngredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeIngredientsExists(recipeIngredients.Id))
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
            ViewData["IngredientsId"] = new SelectList(_context.Ingredients, "Id", "Name", recipeIngredients.IngredientsId);
            ViewData["RecipesId"] = new SelectList(_context.Recipe, "Id", "Name", recipeIngredients.RecipesId);
            return View(recipeIngredients);
        }

        // GET: RecipeIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredients = await _context.RecipeIngredients
                .Include(r => r.Ingredients)
                .Include(r => r.Recipes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeIngredients == null)
            {
                return NotFound();
            }

            return View(recipeIngredients);
        }

        // POST: RecipeIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeIngredients = await _context.RecipeIngredients.FindAsync(id);
            _context.RecipeIngredients.Remove(recipeIngredients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeIngredientsExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.Id == id);
        }
    }
}
