using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab4.Models;

namespace lab4.Controllers
{

    public class HomeController : Controller
    {
        private LightingContext _db;

        public HomeController(LightingContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var masters = _db.Masters.ToList();

            return View(masters);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Masters()
        {
            return View();
        }
    }
}

namespace MvcApplication.Controllers
{
    public class LampsController : Controller
    {
        private readonly LightingContext _context;

        public LampsController(LightingContext context)
        {
            _context = context;
        }

        // GET: Lamps
        [ResponseCache(Duration = 250)]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 10;

            var lamps = _context.Lamps.ToList();
            var count = lamps.Count();
            var items = lamps.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Lamps = items
            };

            return View(viewModel);
        }

        // GET: Lamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamps
                .FirstOrDefaultAsync(m => m.LampId == id);
            if (lamp == null)
            {
                return NotFound();
            }

            return View(lamp);
        }

        // GET: Lamps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lamps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LampId,LampName,LampPower,LampLife")] Lamp lamp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lamp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lamp);
        }

        // GET: Lamps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamps.FindAsync(id);
            if (lamp == null)
            {
                return NotFound();
            }
            return View(lamp);
        }

        // POST: Lamps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LampId,LampName,LampPower,LampLife")] Lamp lamp)
        {
            if (id != lamp.LampId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lamp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LampExists(lamp.LampId))
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
            return View(lamp);
        }

        // GET: Lamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamps
                .FirstOrDefaultAsync(m => m.LampId == id);
            if (lamp == null)
            {
                return NotFound();
            }

            return View(lamp);
        }

        // POST: Lamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lamp = await _context.Lamps.FindAsync(id);
            _context.Lamps.Remove(lamp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LampExists(int id)
        {
            return _context.Lamps.Any(e => e.LampId == id);
        }
    }

}
