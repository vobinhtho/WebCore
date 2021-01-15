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
    public class KhachhangsController : Controller
    {
        private readonly QuanLyQuanAnContext _context;

        public KhachhangsController(QuanLyQuanAnContext context)
        {
            _context = context;
        }

        // GET: Admin/Khachhangs
        public async Task<IActionResult> Index()
        {
            var quanLyQuanAnContext = _context.Khachhangs.Include(k => k.MatkNavigation);
            return View(await quanLyQuanAnContext.ToListAsync());
        }

        // GET: Admin/Khachhangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.MatkNavigation)
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Admin/Khachhangs/Create
        public IActionResult Create()
        {
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk");
            return View();
        }

        // POST: Admin/Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makh,Matk,Tenkh,Sdtkh,Diachikh")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk", khachhang.Matk);
            return View(khachhang);
        }

        // GET: Admin/Khachhangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk", khachhang.Matk);
            return View(khachhang);
        }

        // POST: Admin/Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Makh,Matk,Tenkh,Sdtkh,Diachikh")] Khachhang khachhang)
        {
            if (id != khachhang.Makh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.Makh))
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
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk", khachhang.Matk);
            return View(khachhang);
        }

        // GET: Admin/Khachhangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.MatkNavigation)
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Admin/Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(string id)
        {
            return _context.Khachhangs.Any(e => e.Makh == id);
        }
    }
}
