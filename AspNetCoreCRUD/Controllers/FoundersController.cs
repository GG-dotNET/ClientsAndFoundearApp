using AspNetCoreCRUD.Data;
using AspNetCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCRUD.Controllers
{
    public class FoundersController : Controller
    {
        private readonly EntityContext _context;

        public FoundersController(EntityContext context)
        {
            _context = context;
        }

        // GET: Founders
        public async Task<IActionResult> Index()
        {
            var entityContext = await _context.Founders
                .Include(f => f.Client)
                .AsNoTracking()
                .ToListAsync();

            return View(entityContext);
        }

        // GET: Founders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.FounderID == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // GET: Founders/Create
        public IActionResult Create()
        {
            ClientsDropDownList();
            return View();
        }

        // POST: Founders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FounderID,IdentificationNumber,FullName,DateAdd,DateUpdate,ClientID")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(founder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", founder.ClientID);
            return View(founder);
        }

        // GET: Founders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders.FindAsync(id);
            if (founder == null)
            {
                return NotFound();
            }

            ClientsDropDownList();

            return View(founder);
        }

        // POST: Founders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FounderID,IdentificationNumber,FullName,DateAdd,DateUpdate,ClientID")] Founder founder)
        {
            if (id != founder.FounderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FounderExists(founder.FounderID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", founder.ClientID);
            return View(founder);
        }

        private void ClientsDropDownList(object selectedName = null)
        {
            var namesQuery = from t in _context.Clients
                             where t.Type == CompanyType.LegalEntity
                             orderby t.CompanyName
                             select t;
            ViewBag.ClientID = new SelectList(namesQuery.AsNoTracking(), "ClientID", "CompanyName", selectedName);
        }


        // GET: Founders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.FounderID == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // POST: Founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var founder = await _context.Founders.FindAsync(id);
            _context.Founders.Remove(founder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FounderExists(int id)
        {
            return _context.Founders.Any(e => e.FounderID == id);
        }
    }
}
