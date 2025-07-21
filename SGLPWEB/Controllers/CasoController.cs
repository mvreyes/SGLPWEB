using Microsoft.AspNetCore.Mvc;
using SGLPWEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using SGLPWEB.Data;

namespace SGLPWEB.Controllers
{
    public class CasoController: Controller
    {
        private readonly AppDbContext _context;

        public CasoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var modelo = new Caso
            {
                NumeroCaso = "CASO-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                FechaInicio = DateTime.Now
            };

            ViewBag.Clientes = _context.Clientes
                .Select(c => new SelectListItem
                {
                    Value = c.idCliente.ToString(),
                    Text = c.Nombres + " " + c.Apellidos
                }).ToList();

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Caso caso)
        {
            if (string.IsNullOrEmpty(caso.NumeroCaso))
            {
                caso.NumeroCaso = "CASO-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            }

            if (ModelState.IsValid)
            {
                _context.Casos.Add(caso);
                _context.SaveChanges();

                ViewBag.Mensaje = "Caso registrado correctamente.";
                ModelState.Clear();
                caso = new Caso();
            }
            else
            {
                ViewBag.MensajeError = "Error al registrar el caso. Verifique los datos.";
            }

            ViewBag.Clientes = _context.Clientes
                .Select(c => new SelectListItem
                {
                    Value = c.idCliente.ToString(),
                    Text = c.Nombres + " " + c.Apellidos
                }).ToList();

            return View(caso);
        }

    }
}