using Microsoft.AspNetCore.Mvc;
using SGLPWEB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using SGLPWEB.Data;

namespace SGLPWEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                ViewBag.Mensaje = "Cliente registrado correctamente.";

                ModelState.Clear();

                return View();
            }

            return View(cliente);
        }
    }
}
