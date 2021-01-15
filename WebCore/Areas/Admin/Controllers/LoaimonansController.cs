using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.DBContextofSQLserver;

namespace WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaimonansController : Controller
    {
        private readonly QuanLyQuanAnContext _context;

        public LoaimonansController()
        {
            _context = new QuanLyQuanAnContext();
        }

        // GET: Admin/Loaimonans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loaimonans.ToListAsync());
        }

        // GET: Admin/Loaimonans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Loaimonans
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // GET: Admin/Loaimonans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Loaimonans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maloai,Tenloai")] Loaimonan loaimonan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaimonan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaimonan);
        }

        // GET: Admin/Loaimonans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Loaimonans.FindAsync(id);
            if (loaimonan == null)
            {
                return NotFound();
            }
            return View(loaimonan);
        }

        // POST: Admin/Loaimonans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Maloai,Tenloai")] Loaimonan loaimonan)
        {
            if (id != loaimonan.Maloai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaimonan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaimonanExists(loaimonan.Maloai))
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
            return View(loaimonan);
        }

        // GET: Admin/Loaimonans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaimonan = await _context.Loaimonans
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaimonan == null)
            {
                return NotFound();
            }

            return View(loaimonan);
        }

        // POST: Admin/Loaimonans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaimonan = await _context.Loaimonans.FindAsync(id);
            _context.Loaimonans.Remove(loaimonan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaimonanExists(string id)
        {
            return _context.Loaimonans.Any(e => e.Maloai == id);
        }
    }
}
