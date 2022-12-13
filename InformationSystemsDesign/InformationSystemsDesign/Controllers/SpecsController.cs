using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InformationSystemsDesign.Data;
using InformationSystemsDesign.Models;
using InformationSystemsDesign.Models.ViewModels;

namespace InformationSystemsDesign.Controllers
{
    public class SpecsController : Controller
    {
        private readonly InformationSystemsDesignContext _context;

        public SpecsController(InformationSystemsDesignContext context)
        {
            _context = context;
        }

        // GET: Specs
        public async Task<IActionResult> Index()
        {
            var informationSystemsDesignContext = _context.Spec.Include(s => s.CdKpNavigation).Include(s => s.CdSbNavigation);
            return View(await informationSystemsDesignContext.ToListAsync());
        }

        // GET: Specs/TechnologicalStandards
        public async Task<IActionResult> TechnologicalStandards()
        {
            var requiredValuesFromSumRozv = await _context.SumRozv
                .Include(s => s.CdKpNavigation)
                .Where(s => s.CdKpNavigation.CdTp == 2 || s.CdKpNavigation.CdTp == 3)
                .ToListAsync();

            var products = await _context.GLPR
                .Where(g => g.CdTp == 1)
                .ToListAsync();

            foreach (var product in products)
            {
                requiredValuesFromSumRozv.Add(new SumRozv
                {
                    CdVyr = product.CdPr,
                    CdKp = product.CdPr,
                    SumKp = 1,
                    MinRv = 0,
                    CdTp = 1
                });
            }

            requiredValuesFromSumRozv = requiredValuesFromSumRozv
                .OrderBy(r => r.CdVyr)
                .ThenBy(r => r.CdTp)
                .ToList();

            var joinedSumRozvAndPTRN = requiredValuesFromSumRozv
                .Join(_context.PTRN
                    .Include(ptrn => ptrn.CdTONavigation),
                reqVal => reqVal.CdKp,
                ptrn => ptrn.CdPr,
                (reqVal, ptrn) => new
                {
                    reqVal.CdVyr,
                    ptrn.CdTO,
                    ptrn.CdTONavigation.NmTO,
                    ptrn.Godin
                });
            
            var techNorms = joinedSumRozvAndPTRN
                .GroupBy(techNorm => new { techNorm.CdVyr, techNorm.CdTO, techNorm.NmTO })
                .Select(techNorm => new TechnNorm
                {
                    CdVyr = techNorm.Key.CdVyr,
                    CdTO = techNorm.Key.CdTO,
                    NmTO = techNorm.Key.NmTO,
                    SumGodin = techNorm.Sum(tn => tn.Godin)
                })
                .ToList();
            return View(techNorms);
        }

        // GET: Specs/{CdSb, CdKp}/DirectApplicability
        public async Task<IActionResult> DirectApplicability(string CdSb, string CdKp)
        {
            if (CdSb == null || CdKp == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.CdSbNavigation)
                .Include(s => s.CdKpNavigation)
                .FirstOrDefaultAsync(m => m.CdSb == CdSb && m.CdKp == CdKp);
            if (spec == null)
            {
                return NotFound();
            }

            ViewData["SpecName"] = spec.CdKpNavigation.NmPr;

            var specsWhichContainsCurrent = await _context.Spec
                .Include(s => s.CdSbNavigation)
                .Where(s => s.CdKp == CdKp).ToListAsync();
            var directApplicabilities = new List<DirectApplicability>();
            foreach (var specContains in specsWhichContainsCurrent)
            {
                directApplicabilities.Add(new DirectApplicability()
                {
                    ComponentCode = specContains.CdSb,
                    ComponentName = specContains.CdSbNavigation.NmPr,
                    Quanity = specContains.QtyKp
                });
            }
            return View(directApplicabilities);
        }

        // GET: Specs/{CdSb, CdKp}/StructuralApplicability
        public async Task<IActionResult> StructuralApplicability(string CdSb, string CdKp)
        {
            if (CdSb == null || CdKp == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.CdSbNavigation)
                .Include(s => s.CdKpNavigation)
                .FirstOrDefaultAsync(m => m.CdSb == CdSb && m.CdKp == CdKp);
            if (spec == null)
            {
                return NotFound();
            }

            ViewData["SpecName"] = spec.CdKpNavigation.NmPr;

            var specsWhichContainsCurrent = await _context.Spec
                .Include(s => s.CdSbNavigation)
                .Where(s => s.CdKp == CdKp)
                .ToListAsync();
            var structuralApplicabilities = new List<StructuralApplicability>();

            foreach (var specContains in specsWhichContainsCurrent)
            {
                DetermineApplicability(specContains, spec.CdKp, structuralApplicabilities, 1);
            }
            return View(structuralApplicabilities);
        }
        public void DetermineApplicability(
            Spec row,
            string originalSpecCdKp,
            List<StructuralApplicability> tableToAdd,
            int currentNestingLevel)
        {
            tableToAdd.Add(new StructuralApplicability()
            {
                ComponentCode = row.CdSb,
                ComponentName = row.CdSbNavigation.NmPr,
                Quanity = row.QtyKp,
                EntryLevel = new string('.', currentNestingLevel) + currentNestingLevel.ToString()
            });

            var parentsCodes = _context.Spec
                .Where(s => s.CdKp == row.CdSb)
                .Select(s => s.CdSb)
                .ToList();
            if (parentsCodes.Count == 0)
            {
                return;
            }

            var parentSpecs = _context.Spec
                .Where(p => parentsCodes.Contains(p.CdSb))
                .Where(p => p.CdKp == originalSpecCdKp)
                .ToList();
            if (parentSpecs.Count == 0)
            {
                return;
            }

            currentNestingLevel += 1;
            foreach (var parentSpec in parentSpecs)
            {
                DetermineApplicability(parentSpec, originalSpecCdKp, tableToAdd, currentNestingLevel);
            };
        }

        // GET: Specs/{CdSb, CdKp}/OverallApplicability
        public async Task<IActionResult> OverallApplicability(string CdSb, string CdKp)
        {
            if (CdSb == null || CdKp == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.CdKpNavigation)
                .FirstOrDefaultAsync(m => m.CdSb == CdSb && m.CdKp == CdKp);
            if (spec == null)
            {
                return NotFound();
            }

            ViewData["SpecName"] = spec.CdKpNavigation.NmPr;

            return View(GetOverallApplicabilitiesForSpec(spec));
        }
        private Task<List<OverallApplicability>> GetOverallApplicabilitiesForSpec(Spec spec)
        {
            return _context.StrRozv
                .Where(s => s.CdKp == spec.CdKp)
                .Select(s => new OverallApplicability()
                {
                    ComponentCode = s.CdSb,
                    ComponentName = s.CdSbNavigation.NmPr,
                    Quanity = s.QtyKp,
                    EntryLevel = s.RivNb.ToString()
                })
                .ToListAsync();
        }

        // GET: Specs/GenerateOverallApplicability
        public async Task<IActionResult> GenerateOverallApplicability()
        {
            return View(await GetOverallApplicabilities());
        }

        public async Task<ICollection<OverallApplicability>> GetOverallApplicabilities()
        {
            var specs = await _context.Spec.ToListAsync();
            var overallApplicabilities = new HashSet<OverallApplicability>();
            foreach (var spec in specs)
            {
                foreach (var overallApplicability in await GetOverallApplicabilitiesForSpec(spec))
                {
                    overallApplicabilities.Add(overallApplicability);
                }
            }
            return overallApplicabilities;
        }
        // GET: Specs/MaterialStandards
        public async Task<IActionResult> MaterialStandards()
        {
            var requiredValuesFromSumRozv = _context.SumRozv
                .Where(sumRozv => sumRozv.CdTp == 3)
                .Select(sumRozv => new
                {
                    sumRozv.CdVyr,
                    sumRozv.CdVyrNavigation.NmPr,
                    sumRozv.CdKp,
                    sumRozv.SumKp
                });

            var combinedTablesSumRozvAndZastMt = requiredValuesFromSumRozv
                .Join(
                    _context.ZastMt,
                    sumRozv => sumRozv.CdKp,
                    zastMt => zastMt.CdKp,
                    (sumRozv, zastMt) => new
                    {
                        sumRozv.CdVyr,
                        sumRozv.NmPr,
                        zastMt.CdMtNavigation.CdMt,
                        sumRozv.SumKp,
                        zastMt.QtyMt
                    });

            var materialStandards = await combinedTablesSumRozvAndZastMt
                .GroupBy(ms => new { ms.CdVyr, ms.CdMt })
                .Select(materialStandard => new MaterialStandard
                {
                    ProductCode = materialStandard.Key.CdVyr,
                    StaffName = materialStandard.Max(ms => ms.NmPr)!,
                    MaterialCode = materialStandard.Key.CdMt,
                    GeneralNeedForMaterial = materialStandard
                        .Sum(ms => ms.QtyMt * ms.SumKp)
                })
                .ToListAsync();

            return View(materialStandards);
        }
        // GET: Specs/Details/5
        public async Task<IActionResult> Details(string CdSb, string CdKp)
        {
            if (CdSb == null || CdKp == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.CdKpNavigation)
                .Include(s => s.CdSbNavigation)
                .FirstOrDefaultAsync(m => m.CdSb == CdSb && m.CdKp == CdKp);
            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        // GET: Specs/Create
        public IActionResult Create()
        {
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr");
            return View();
        }

        // POST: Specs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CdSb,CdKp,QtyKp")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdSb);
            return View(spec);
        }

        // GET: Specs/Edit/5
        public async Task<IActionResult> Edit(string CdSb, string CdKp)
        {
            if (CdSb == null || CdKp == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec.FindAsync(CdSb, CdKp);
            if (spec == null)
            {
                return NotFound();
            }
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdSb);
            return View(spec);
        }

        // POST: Specs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CdSb,CdKp,QtyKp")] Spec spec)
        {
            if (id != spec.CdSb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecExists(spec.CdSb))
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
            ViewData["CdKp"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdKp);
            ViewData["CdSb"] = new SelectList(_context.GLPR, "CdPr", "CdPr", spec.CdSb);
            return View(spec);
        }

        // GET: Specs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Spec == null)
            {
                return NotFound();
            }

            var spec = await _context.Spec
                .Include(s => s.CdKpNavigation)
                .Include(s => s.CdSbNavigation)
                .FirstOrDefaultAsync(m => m.CdSb == id);
            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        // POST: Specs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Spec == null)
            {
                return Problem("Entity set 'InformationSystemsDesignContext.Spec'  is null.");
            }
            var spec = await _context.Spec.FindAsync(id);
            if (spec != null)
            {
                _context.Spec.Remove(spec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecExists(string id)
        {
            return (_context.Spec?.Any(e => e.CdSb == id)).GetValueOrDefault();
        }
    }
}
