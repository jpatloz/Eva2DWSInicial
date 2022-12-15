using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;
using DAL.Modelo.DTO;

namespace Eva2DWSInicial.Controllers
{
    public class EvaTchNotasEvaluacionsController : Controller
    {
        //En este controlador hacemos el create necesario para la vista

        private readonly BdEvaluacionContext _context;

        public EvaTchNotasEvaluacionsController(BdEvaluacionContext context)
        {
            _context = context;
        }

        // GET: EvaTchNotasEvaluacions
        public async Task<IActionResult> Index()
        {
            var bdEvaluacionContext = _context.EvaTchNotasEvaluacions.Include(e => e.CodEvaluacionNavigation);
            return View(await bdEvaluacionContext.ToListAsync());
        }

        // GET: EvaTchNotasEvaluacions/Create
        public IActionResult Create()
        {
            ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion");
            return View();
        }

        // POST: EvaTchNotasEvaluacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdFch,IdNotaEvaluacion,CodAlumno,NotaEvaluacion,CodEvaluacion")] EvaTchNotasEvaluacion evaTchNotasEvaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaTchNotasEvaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion", evaTchNotasEvaluacion.CodEvaluacion);
            return View(evaTchNotasEvaluacion);
        }
    }
}
