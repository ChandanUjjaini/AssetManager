using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManager.Data;
using AssetManager.Models;
using System.Drawing;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AssetManager.Controllers
{
    [Authorize]
    public class AssetsController : Controller
    {
        private readonly AssetManagerContext _context;
        private readonly IWebHostEnvironment _webEnvi;
        public AssetsController(AssetManagerContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webEnvi = webHostEnvironment;
        }

        // GET: Assets
        public async Task<IActionResult> Index(string id, string BId, string Cid, string Uid, string sortOrder)
        {

            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["AssetTypeId"] = new SelectList(_context.AssetType, "Id", "Name");
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");

            ViewData["TypeSort"] = string.IsNullOrEmpty(sortOrder) ? "ByType_desc" : "";
            ViewData["DateSort"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceSort"] = sortOrder == "Price" ? "Price_desc" : "Price";
            ViewData["BrandSort"] = sortOrder == "Brand" ? "Brand_desc" : "Brand";
            ViewData["CountrySort"] = sortOrder == "Country" ? "Country_desc" : "Country";
            ViewData["OwnerSort"] = sortOrder == "Owner" ? "Owner_desc" : "Owner";
            var assetManagerContext = from m in _context.Asset select m;
            assetManagerContext = _context.Asset.Include(a => a.AssetType).Include(a => a.Brand).Include(a => a.Country).Include(a => a.ApplicationUser);
            switch (sortOrder)
            {
                case "ByType_desc":
                    assetManagerContext = assetManagerContext.OrderByDescending(s => s.AssetType.Name);
                    break;
                case "Date":
                    assetManagerContext = assetManagerContext.OrderBy(s => s.Pdate);
                    break;
                case "date_desc":
                    assetManagerContext = assetManagerContext.OrderByDescending(s => s.Pdate);
                    break;
                case "Price":
                    assetManagerContext = assetManagerContext.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    assetManagerContext = assetManagerContext.OrderByDescending(s => s.Price);
                    break;
                case "Brand":
                    assetManagerContext = assetManagerContext.OrderBy(s => s.Brand.Name);
                    break;
                case "Brand_desc":
                    assetManagerContext = assetManagerContext.OrderByDescending(s => s.Brand.Name);
                    break;
                case "Country":
                    assetManagerContext = assetManagerContext.OrderBy(s => s.Country.Name);
                    break;
                case "Country_desc":
                    assetManagerContext = assetManagerContext.OrderByDescending(s => s.Country.Name);
                    break;
                case "Owner":
                    assetManagerContext = assetManagerContext.OrderBy(s => s.ApplicationUser.FirstName);
                    break;
                case "Owner_desc":
                    assetManagerContext = assetManagerContext.OrderByDescending(s => s.ApplicationUser.FirstName);
                    break;

                default:
                    assetManagerContext = assetManagerContext.OrderBy(s => s.AssetType.Name);
                    break;
            }
            if (!string.IsNullOrEmpty(id))
            {
                int Tid = Int32.Parse(id);

                assetManagerContext = assetManagerContext.Where(s => s.AssetTypeId == Tid);

            }
            if (!string.IsNullOrEmpty(BId))
            {

                int Bid = Int32.Parse(BId);
                assetManagerContext = assetManagerContext.Where(s => s.BrandId == Bid);

            }
            if (!string.IsNullOrEmpty(Cid))
            {

                int Bid = Int32.Parse(Cid);
                assetManagerContext = assetManagerContext.Where(s => s.CountryId == Bid);

            }
            return View(await assetManagerContext.ToListAsync());
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asset == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.AssetType)
                .Include(a => a.Brand)
                .Include(a => a.Country)
                .Include(a=>a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }
        [Authorize(Roles = "Admin,User")]
        // GET: Assets/Create
        public IActionResult Create()
        {
            ViewData["AssetTypeId"] = new SelectList(_context.AssetType, "Id", "Name");
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "FirstName");
            return View();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Asset asset)
            //[Bind("Id,AssetTypeId,BrandId,Model,Pdate,CountryId,Price,LPrice,ImageFile")] 
        {
           // if (ModelState.IsValid)
            {
                var filePath =  asset.ImageFile;/*"\\Images\\" +asset.Image.FileName;*/
                var rootpath = _webEnvi.WebRootPath;
                var fullPath = Path.Join(rootpath, filePath);
                FileStream stream = new FileStream(fullPath, FileMode.Create);
                asset.Image.CopyTo(stream);              
                
                _context.Add(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AssetTypeId"] = new SelectList(_context.AssetType, "Id", "Id", asset.AssetTypeId);
            //ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", asset.BrandId);
            //ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", asset.CountryId);
            //return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asset == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            ViewData["AssetTypeId"] = new SelectList(_context.AssetType, "Id", "Name");
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "FirstName");
            return View(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    var filePath = asset.ImageFile;/*"\\Images\\" +asset.Image.FileName;*/
                    var rootpath = _webEnvi.WebRootPath;
                    var fullPath = Path.Join(rootpath, filePath);
                    FileStream stream = new FileStream(fullPath, FileMode.Create);
                    asset.Image.CopyTo(stream);
                    _context.Update(asset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetExists(asset.Id))
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
            //ViewData["AssetTypeId"] = new SelectList(_context.AssetType, "Id", "Id", asset.AssetTypeId);
            //ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", asset.BrandId);
            //ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Id", asset.CountryId);
            //return View(asset);
        }
        [Authorize(Roles = "Admin")]
        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asset == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset
                .Include(a => a.AssetType)
                .Include(a => a.Brand)
                .Include(a => a.Country)
                .Include(a=>a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }
        [Authorize(Roles = "Admin")]
        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asset == null)
            {
                return Problem("Entity set 'AssetManagerContext.Asset'  is null.");
            }
            var asset = await _context.Asset.FindAsync(id);
            if (asset != null)
            {
                
                //var path = asset.ImageFile;
                //var rootpath = _webEnvi.WebRootPath;
                //var fullPath = Path.Join(rootpath, path);
                //img = Image.FromFile(fullPath);
                //img.Dispose();
                //System.IO.File.Delete(fullPath);
                _context.Asset.Remove(asset);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetExists(int id)
        {
          return (_context.Asset?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public string fileupload(Asset asset) 
        {
            string data = null;
            return (data);
        }
        public string Convert(string Id)
        {
            string rate;
            string code = null;
            int id = Int32.Parse(Id);
            foreach (Country C in _context.Country)
            {

                if (C.Id == id)
                {
                    code = C.Code;
                    if (code == "USD")
                    {
                        rate = 1.ToString();
                        goto ret;
                    }
                    break;
                }
            }

            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb(); //Need to add HtmlAgilityPack Nuget
            string urlSrc = $"https://www.google.com/finance/quote/USD-" + code + "?hl=en";
            HtmlAgilityPack.HtmlDocument document = website.Load(urlSrc);
            rate = document.DocumentNode.SelectSingleNode("//div[@class='YMlKec fxKbKc']").InnerText;
        ret:
            return (rate);
        }
    }
}
