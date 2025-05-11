using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventEase.Models;

namespace EventEase.Controllers
{
    public class EventLController : Controller
    {
        private readonly EventEaseContext _context;

        public EventLController(EventEaseContext context)
        {
            _context = context;
        }

        // GET: EventL
        public async Task<IActionResult> Index()
        {
            var eventEaseContext = _context.EventLs.Include(e => e.Venue);
            return View(await eventEaseContext.ToListAsync());
        }

        // GET: EventL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventL = await _context.EventLs
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventL == null)
            {
                return NotFound();
            }

            return View(eventL);
        }

        // GET: EventL/Create
        public IActionResult Create()
        {
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueId");
            return View();
        }

        // POST: EventL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,VenueId,EventName,EventDate,EventDescription")] EventL eventL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueId", eventL.VenueId);
            return View(eventL);
        }

        // GET: EventL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventL = await _context.EventLs.FindAsync(id);
            if (eventL == null)
            {
                return NotFound();
            }
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueId", eventL.VenueId);
            return View(eventL);
        }

        // POST: EventL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,VenueId,EventName,EventDate,EventDescription")] EventL eventL)
        {
            if (id != eventL.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventLExists(eventL.EventId))
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
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueId", eventL.VenueId);
            return View(eventL);
        }

        // GET: EventL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventL = await _context.EventLs
                .Include(e => e.Venue)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventL == null)
            {
                return NotFound();
            }

            return View(eventL);
        }

        // POST: EventL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventL = await _context.EventLs.FindAsync(id);
            if (eventL != null)
            {
                _context.EventLs.Remove(eventL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventLExists(int id)
        {
            return _context.EventLs.Any(e => e.EventId == id);
        }
    }
}
