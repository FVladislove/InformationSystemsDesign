using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InformationSystemsDesign.Data;
using InformationSystemsDesign.Models;

namespace InformationSystemsDesign.Controllers
{
    public class StrRozvsController : Controller
    {
        private readonly InformationSystemsDesignContext _context;

        public StrRozvsController(InformationSystemsDesignContext context)
        {
            _context = context;
        }

        // GET: StrRozvs
        public async Task<IActionResult> Index()
        {
            var informationSystemsDesignContext = _context.StrRozv.Include(s => s.CdKpNavigation).Include(s => s.CdSbNavigation).Include(s => s.CdVyrNavigation);
            //return View(await informationSystemsDesignContext.ToListAsync());
            return View(StructuralDisentanglement());
        }

        // GET: StrRozvs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.StrRozv == null)
            {
                return NotFound();
            }

            var strRozv = await _context.StrRozv
                .Include(s => s.CdKpNavigation)
                .Include(s => s.CdSbNavigation)
                .Include(s => s.CdVyrNavigation)
                .FirstOrDefaultAsync(m => m.CdVyr == id);
            if (strRozv == null)
            {
                return NotFound();
            }

            return View(strRozv);
        }

        // GET: StrRozvs/Create
        public IActionResult Create()
        {
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            ViewData["CdVyr"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            return View();
        }

        // POST: StrRozvs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdVyr,CdSb,CdKp,QtyKp,RivNb,RivGrf")] StrRozv strRozv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strRozv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdSb);
            ViewData["CdVyr"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdVyr);
            return View(strRozv);
        }

        // GET: StrRozvs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.StrRozv == null)
            {
                return NotFound();
            }

            var strRozv = await _context.StrRozv.FindAsync(id);
            if (strRozv == null)
            {
                return NotFound();
            }
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdSb);
            ViewData["CdVyr"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdVyr);
            return View(strRozv);
        }

        // POST: StrRozvs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CdVyr,CdSb,CdKp,QtyKp,RivNb,RivGrf")] StrRozv strRozv)
        {
            if (id != strRozv.CdVyr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strRozv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StrRozvExists(strRozv.CdVyr))
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
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdSb);
            ViewData["CdVyr"] = new SelectList(_context.GLPR, "CdPr", "CdPr", strRozv.CdVyr);
            return View(strRozv);
        }

        // GET: StrRozvs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.StrRozv == null)
            {
                return NotFound();
            }

            var strRozv = await _context.StrRozv
                .Include(s => s.CdKpNavigation)
                .Include(s => s.CdSbNavigation)
                .Include(s => s.CdVyrNavigation)
                .FirstOrDefaultAsync(m => m.CdVyr == id);
            if (strRozv == null)
            {
                return NotFound();
            }

            return View(strRozv);
        }

        // POST: StrRozvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.StrRozv == null)
            {
                return Problem("Entity set 'InformationSystemsDesignContext.StrRozv'  is null.");
            }
            var strRozv = await _context.StrRozv.FindAsync(id);
            if (strRozv != null)
            {
                _context.StrRozv.Remove(strRozv);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StrRozvExists(string id)
        {
            return (_context.StrRozv?.Any(e => e.CdVyr == id)).GetValueOrDefault();
        }

        public List<StrRozv> StructuralDisentanglement()
        {
            var table = _context.StrRozv.ToList();
            var newTable = new List<StrRozv>();

            var codesAndTypes = _context.GLPR
                .Select(t => new { t.CdPr, t.CdTp })
                .ToDictionary(key => key.CdPr, value => value.CdTp);

            var spec = _context.Spec.ToList();

            foreach (var row in table)
            {
                Untangle(row, newTable, codesAndTypes, spec, 1);
            }
            return newTable;
        }
        public void Untangle(
            StrRozv row,
            List<StrRozv> tableToAdd,
            Dictionary<string, int> codesAndTypes,
            List<Spec> specs,
            int currentNestingLevel)
        {
            tableToAdd.Add(row);

            if(codesAndTypes[row.CdKp] != 2)
            {
                return;
            }

            currentNestingLevel += 1;
            var selectedSpecs = specs.Where(s => s.CdSb == row.CdKp).ToList();
            if (selectedSpecs.Count != 0)
            {
                foreach(var newSpec in selectedSpecs)
                {
                    var newRow = new StrRozv()
                    {
                        CdVyr = row.CdVyr,
                        CdSb = newSpec.CdSb,
                        CdKp = newSpec.CdKp,
                        QtyKp = row.QtyKp * newSpec.QtyKp,
                        RivNb = currentNestingLevel,
                        RivGrf = new string('.', currentNestingLevel) + currentNestingLevel.ToString()
                    };
                    Untangle(newRow, tableToAdd, codesAndTypes, specs, currentNestingLevel);
                };
            }
        }
    }
}
