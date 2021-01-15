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
    public class NhanviensController : Controller
    {
        private readonly QuanLyQuanAnContext _context;

        public NhanviensController()
        {
            _context = new QuanLyQuanAnContext();
        }

        // GET: Admin/Nhanviens
        public async Task<IActionResult> Index()
        {
            var quanLyQuanAnContext = _context.Nhanviens.Include(n => n.MatkNavigation);
            return View(await quanLyQuanAnContext.ToListAsync());
        }

        // GET: Admin/Nhanviens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.MatkNavigation)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Admin/Nhanviens/Create
        public IActionResult Create()
        {
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk");
            return View();
        }

        // POST: Admin/Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manv,Matk,Tennv,Sdtnv,Diachinv,Gioitinh,Ngaysinh")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk", nhanvien.Matk);
            return View(nhanvien);
        }

        // GET: Admin/Nhanviens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk", nhanvien.Matk);
            return View(nhanvien);
        }

        // POST: Admin/Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Manv,Matk,Tennv,Sdtnv,Diachinv,Gioitinh,Ngaysinh")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Manv))
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
            ViewData["Matk"] = new SelectList(_context.Taikhoans, "Matk", "Matk", nhanvien.Matk);
            return View(nhanvien);
        }

        // GET: Admin/Nhanviens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.MatkNavigation)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Admin/Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
            return _context.Nhanviens.Any(e => e.Manv == id);
        }
    }
}
