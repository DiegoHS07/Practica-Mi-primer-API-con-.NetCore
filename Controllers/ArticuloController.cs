using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;

namespace MiPrimeraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        List<Articulo> articulos { set; get; }
        public ArticuloController()
        {
            articulos = new List<Articulo>()
            {
                new Articulo { Id = 1, Nombre = "Laptop", Descripcion = "Laptop HP", Precio = 15000.00, FechaRegistro = DateTime.Now },
                new Articulo { Id = 2, Nombre = "Impresora", Descripcion = "Impresora Epson", Precio = 8700.00, FechaRegistro = DateTime.Now },
                new Articulo { Id = 3, Nombre = "Monito", Descripcion = "Monitor ASUS", Precio = 1600.00, FechaRegistro = DateTime.Now },
                new Articulo { Id = 4, Nombre = "Cable USB", Descripcion = "Cable USB Generico", Precio = 193.00, FechaRegistro = DateTime.Now }
            };
        }
        // GET api/articulo
        [HttpGet]
        [Route("")]

        public IActionResult Obtener()
        {
            return Ok(articulos);
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult ObtenerPorId(int id){
            var articulo = articulos.FirstOrDefault(a => a.Id == id);
            if(articulo == null){
                return NotFound();
            }
            return Ok(articulo);
        }

        [HttpPost]
        [Route("")]

        public IActionResult Registrar(Articulo articulo){
            
            articulos.Add(articulo);
            return CreatedAtAction(nameof(ObtenerPorId), new{articulo.Id}, articulo);
        }
        
    }
}