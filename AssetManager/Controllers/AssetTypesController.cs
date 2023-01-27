using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManager.Data;
using AssetManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AssetManager.Controllers
{
    public class AssetTypesController : Controller
    {
        
        private readonly AssetManagerContext _context;

        public AssetTypesController(AssetManagerContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: AssetTypes
        public async Task<IActionResult> Index()
        {
              return _context.AssetType != null ? 
                          View(await _context.AssetType.ToListAsync()) :
                          Problem("Entity set 'AssetManagerContext.AssetType'  is null.");
        }
        [Authorize(Roles = "Admin")]
        // GET: AssetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AssetType == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }
        [Authorize(Roles = "Admin")]
        // GET: AssetTypes/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: AssetTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AssetType assetType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetType);
        }
        [Authorize(Roles = "Admin")]
        // GET: AssetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AssetType == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }
            return View(assetType);
        }
        [Authorize(Roles = "Admin")]
        // POST: AssetTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AssetType assetType)
        {
            if (id != assetType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetTypeExists(assetType.Id))
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
            return View(assetType);
        }
        [Authorize(Roles = "Admin")]
        // GET: AssetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AssetType == null)
            {
                return NotFound();
            }

            var assetType = await _context.AssetType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }
        [Authorize(Roles = "Admin")]
        // POST: AssetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AssetType == null)
            {
                return Problem("Entity set 'AssetManagerContext.AssetType'  is null.");
            }
            var assetType = await _context.AssetType.FindAsync(id);
            if (assetType != null)
            {
                _context.AssetType.Remove(assetType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetTypeExists(int id)
        {
          return (_context.AssetType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
