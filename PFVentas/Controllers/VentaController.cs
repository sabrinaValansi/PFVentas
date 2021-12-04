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
    public class VentaController : Controller
    {
        private readonly PFVentasContext _context;

        public VentaController(PFVentasContext context)
        {
            _context = context;
        }

        // GET: Venta
        public async Task<IActionResult> Index()
        {
            var consulta = 
                _context.Ventas.FromSqlRaw("select ventas.*, productos.nomprod from ventas left join productos ON ventas.productoid=productos.productoid").ToListAsync();

                    //from v in _context.Ventas
                    //join p in _context.Productos on v.ProductoId equals p.ProductoId into unionTablas
                    //from p in unionTablas.DefaultIfEmpty()
                    //select new
                    // {
                    //     Fecha=v.Fecha,
                    //     VentaId=v.VentaId,
                    //     Usuario=v.UsuarioId,
                    //     idProducto=v.ProductoId,
                    //     Canal=v.CanalVta,
                    //     Precio=v.PrecioVtaUnit,
                    //     Cantidad=v.Cantidad,
                    //     Producto=p.NomProd
                    //  }

                    


                    // );

           // var venta = consulta.ToListAsync();
            return View(await consulta);
           



        }

        // GET: Venta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Venta/Create
        public IActionResult Create()
        {
            ViewBag.NomProd = new SelectList(_context.Productos.ToList(), "ProductoId", "NomProd");
            return View();
        }

        // POST: Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,Fecha,CanalVta,ProductoId,Cantidad,PrecioVtaUnit,UsuarioId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(venta);
                await EliminarProdAsync(venta.ProductoId, venta.Cantidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            return View(venta);
        }

        // GET: Venta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }

        // POST: Venta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,Fecha,CanalVta,NomProd,Cantidad,PrecioVtaUnit")] Venta venta)
        {
            if (id != venta.VentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.VentaId))
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
            return View(venta);
        }

        // GET: Venta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .FirstOrDefaultAsync(m => m.VentaId == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.VentaId == id);
        }

        public async Task<IActionResult> EliminarProdAsync(int prod, int cant)
        {
            if (_context.Productos.Any(e => e.ProductoId == prod))
            {
                var prodAux = _context.Productos.FirstOrDefault(x => x.ProductoId == prod);
                if (prodAux.CantExist-cant <0)
                {
                    return NotFound();
                }
                prodAux.CantExist -= cant;
                await _context.SaveChangesAsync();
                
            }
            return View();
        }

    }
}
