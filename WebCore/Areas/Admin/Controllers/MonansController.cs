using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Helpers;
using WebCore.DBContextofSQLserver;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MonansController : Controller
    {
        private readonly QuanLyQuanAnContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MonansController(IWebHostEnvironment webHost)
        {
            webHostEnvironment = webHost;
            _context = new QuanLyQuanAnContext();
        }

        // GET: Admin/Monans
        public async Task<IActionResult> Index()
        {
            var quanLyQuanAnContext = _context.Monans.Include(m => m.MaloaiNavigation).Include(m => m.ManhomNavigation);
            return View(await quanLyQuanAnContext.ToListAsync());
        }
        //public ActionResult Index()
        //{
        //    var mONANs = _context.Monans.Include(m => m.MaloaiNavigation).Include(m => m.ManhomNavigation);
        //    return View(mONANs.ToList());
        //}

        // GET: Admin/Monans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans
                .Include(m => m.MaloaiNavigation)
                .Include(m => m.ManhomNavigation)
                .FirstOrDefaultAsync(m => m.Mamonan == id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // GET: Admin/Monans/Create
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.Loaimonans, "Maloai", "Tenloai");
            ViewData["Manhom"] = new SelectList(_context.Nhommonans, "Manhom", "Tennhom");
            return View();
        }

        // POST: Admin/Monans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Mamonan,Manhom,Maloai,Tenmonan,Mieuta,Giaban,Giagiam,Hinh")] Monan monan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(monan);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Maloai"] = new SelectList(_context.Loaimonans, "Maloai", "Maloai", monan.Maloai);
        //    ViewData["Manhom"] = new SelectList(_context.Nhommonans, "Manhom", "Manhom", monan.Manhom);
        //    return View(monan);
        //}
        [HttpPost]
        public async Task<IActionResult> Create(Monan monan)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;
                        var uploads = Path.Combine(webHostEnvironment.WebRootPath, "css\\images\\");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');

                           // System.Console.WriteLine(fileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                monan.Hinh = file.FileName;
                            }
                        }
                    }
                }
                Monan monAn_Old = new Monan();
                if(monan.Mamonan != null)
                {
                    _context.Monans.Update(monan);
                }
     
                
                return RedirectToAction("getAllDataNhaDat");

            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View(monan);
        }




        // GET: Admin/Monans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans.FindAsync(id);
            if (monan == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.Loaimonans, "Maloai", "Tenloai", monan.Maloai);
            ViewData["Manhom"] = new SelectList(_context.Nhommonans, "Manhom", "Tennhom", monan.Manhom);

            return View(monan);
        }

        // POST: Admin/Monans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mamonan,Manhom,Maloai,Tenmonan,Mieuta,Giaban,Giagiam,Hinh")] Monan monan)
        {
            if (id != monan.Mamonan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonanExists(monan.Mamonan))
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
            ViewData["Maloai"] = new SelectList(_context.Loaimonans, "Maloai", "Maloai", monan.Maloai);
            ViewData["Manhom"] = new SelectList(_context.Nhommonans, "Manhom", "Manhom", monan.Manhom);
            return View(monan);
        }

        // GET: Admin/Monans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monan = await _context.Monans
                .Include(m => m.MaloaiNavigation)
                .Include(m => m.ManhomNavigation)
                .FirstOrDefaultAsync(m => m.Mamonan == id);
            if (monan == null)
            {
                return NotFound();
            }

            return View(monan);
        }

        // POST: Admin/Monans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var monan = await _context.Monans.FindAsync(id);
            _context.Monans.Remove(monan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonanExists(string id)
        {
            return _context.Monans.Any(e => e.Mamonan == id);
        }
    }
}
