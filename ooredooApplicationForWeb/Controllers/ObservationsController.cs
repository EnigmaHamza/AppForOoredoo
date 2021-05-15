using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ooredooApplicationForWeb.Areas.Identity.Data;
using ooredooApplicationForWeb.Data;
using ooredooApplicationForWeb.Repository;

namespace ooredooApplicationForWeb.Controllers
{
    public class ObservationsController : Controller
    {
        private readonly ooredooDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IObservationRepository observationRepository;

        public ObservationsController(ooredooDbContext context, UserManager<ApplicationUser> userManager, IObservationRepository observationRepository)
        {
            _context = context;
            this._userManager = userManager;
            this.observationRepository = observationRepository;
        }

        // GET: Observations
        public async Task<IActionResult> Index( )
        {
            var ooredooDbContext = _context.Observations.Include(o => o.categorie).Include(o => o.user);
            
         

            return View(await ooredooDbContext.ToListAsync());
        }
        public async Task<IActionResult> listAvisperUser(int? id)
        {

            var ooredooDbContext = _context.Observations.Include(o => o.categorie).Include(o => o.user);

            var c = observationRepository.observations(id).Include(c=>c.categorie).Include(u=>u.user);        

            return View(c);
        }


        // GET: Observations/Create
        public IActionResult Create(bool IsSuccess = false)
        {
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "NomCategorie");
            ViewBag.issuccess = IsSuccess;


            return View();
        }

        // POST: Observations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserID,CategorieId,rating,Nom,text,typeSuivie")] Observations observations)
        {
            if (ModelState.IsValid)
            {
                // enregister les info dans categories 
                


                var userId = _userManager.GetUserId(HttpContext.User);
                observations.ApplicationUserID = userId;

                observations.dateObservation= DateTime.Now;
                _context.Add(observations);
                await _context.SaveChangesAsync();

                var listCat = await _context.Observations.ToListAsync();

             
                return RedirectToAction("Create",new { IsSuccess = true });
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "NomCategorie", observations.CategorieId);
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "UserName", observations.ApplicationUserID);
            return View(observations);
        }

        // GET: Observations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observations = await _context.Observations.FindAsync(id);
            if (observations == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", observations.CategorieId);
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", observations.ApplicationUserID);
            return View(observations);
        }

        // POST: Observations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ApplicationUserID,CategorieId,dateObservation,rating,Nom,text,typeSuivie")] Observations observations)
        {
            if (id != observations.ApplicationUserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(observations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObservationsExists(observations.ApplicationUserID))
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
            ViewData["CategorieId"] = new SelectList(_context.Categories, "Id", "Id", observations.CategorieId);
            ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id", observations.ApplicationUserID);
            return View(observations);
        }

        // GET: Observations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observations = await _context.Observations
                .Include(o => o.categorie)
                .Include(o => o.user)
                .FirstOrDefaultAsync(m => m.ApplicationUserID == id);
            if (observations == null)
            {
                return NotFound();
            }

            return View(observations);
        }

        // POST: Observations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var observations = await _context.Observations.FindAsync(id);
            _context.Observations.Remove(observations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Observations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var observations = await _context.Observations
                .Include(o => o.categorie)
                .Include(o => o.user)
                .FirstOrDefaultAsync(m => m.ApplicationUserID == id);
            if (observations == null)
            {
                return NotFound();
            }

            return View(observations);
        }

        private bool ObservationsExists(string id)
        {
            return _context.Observations.Any(e => e.ApplicationUserID == id);
        }
    }
}
