using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PFVentas.Models;

namespace PFVentas.Controllers
{
    public class VentaViewModelController : Controller
    {
        private readonly PFVentasContext _context;

        public VentaViewModelController(PFVentasContext context)
        {
            _context = context;
        }

        // GET: VentaViewModels
        public async Task<IActionResult> Index()
        {

            var consulta = (

                   from v in _context.Ventas
                   join p in _context.Productos
                   on v.ProductoId equals p.ProductoId
                   orderby p.NomProd
                   select new VentaViewModel
                   {
                       Fecha = v.Fecha,
                       VentaId = v.VentaId,
                       ProductoId = v.ProductoId,
                       CanalVta = v.CanalVta,
                       PrecioVtaUnit = v.PrecioVtaUnit,
                       Cantidad = (v.Cantidad),
                       NomProd = p.NomProd,
                       PrecioTotal = (v.PrecioVtaUnit * v.Cantidad),
                       PrecioCosto = (p.PrecioCosto * v.Cantidad),
                       MargenGanancia= (v.PrecioVtaUnit * v.Cantidad)- (p.PrecioCosto * v.Cantidad)
                   }

            ).ToListAsync();

            return View(await consulta);
        }

        // GET: VentaViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaViewModel = await _context.VentaViewModel
                .FirstOrDefaultAsync(m => m.VentaViewModelId == id);
            if (ventaViewModel == null)
            {
                return NotFound();
            }

            return View(ventaViewModel);
        }

        // GET: VentaViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentaViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaViewModelId,VentaId,ProductoId,Fecha,UsuarioId,CanalVta,Cantidad,PrecioVtaUnit,NomProd,CantExist,PrecioCosto")] VentaViewModel ventaViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaViewModel);
        }

        // GET: VentaViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaViewModel = await _context.VentaViewModel.FindAsync(id);
            if (ventaViewModel == null)
            {
                return NotFound();
            }
            return View(ventaViewModel);
        }

        // POST: VentaViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaViewModelId,VentaId,ProductoId,Fecha,UsuarioId,CanalVta,Cantidad,PrecioVtaUnit,NomProd,CantExist,PrecioCosto")] VentaViewModel ventaViewModel)
        {
            if (id != ventaViewModel.VentaViewModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaViewModelExists(ventaViewModel.VentaViewModelId))
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
            return View(ventaViewModel);
        }

        // GET: VentaViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaViewModel = await _context.VentaViewModel
                .FirstOrDefaultAsync(m => m.VentaViewModelId == id);
            if (ventaViewModel == null)
            {
                return NotFound();
            }

            return View(ventaViewModel);
        }

        // POST: VentaViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaViewModel = await _context.VentaViewModel.FindAsync(id);
            _context.VentaViewModel.Remove(ventaViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaViewModelExists(int id)
        {
            return _context.VentaViewModel.Any(e => e.VentaViewModelId == id);
        }
    }
}
