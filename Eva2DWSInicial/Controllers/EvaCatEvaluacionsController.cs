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
    public class EvaCatEvaluacionsController : Controller
    {

        //En este controlador hacemos el create necesario para la vista

        private readonly BdEvaluacionContext _context;

        public EvaCatEvaluacionsController(BdEvaluacionContext context)
        {
            _context = context;
        }

        // GET: EvaCatEvaluacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.EvaCatEvaluacions.ToListAsync());
        }

        // GET: EvaCatEvaluacions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EvaCatEvaluacions == null)
            {
                return NotFound();
            }

            var evaCatEvaluacion = await _context.EvaCatEvaluacions
                .FirstOrDefaultAsync(m => m.CodEvaluacion == id);
            if (evaCatEvaluacion == null)
            {
                return NotFound();
            }

            return View(evaCatEvaluacion);
        }
    }
}
