using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;

namespace MiPrimeraApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        List<Proveedor> proveedores { set; get; }
        public ProveedorController()
        {
            proveedores = new List<Proveedor>()
            {
                new Proveedor { Id = 1, Nombre = "Diego", Telefono = "3102754428"},
                new Proveedor { Id = 2, Nombre = "Daniela", Telefono = "3204445879"},
                new Proveedor { Id = 3, Nombre = "Estefa", Telefono = "3132654879"}
            };
            
        }
        // GET api/articulo
        [HttpGet]
        [Route("")]

        public IActionResult Obtener()
        {
            return Ok(proveedores);
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult ObtenerPorId(int id){
            var articulo = proveedores.FirstOrDefault(a => a.Id == id);
            if(articulo == null){
                return NotFound();
            }
            return Ok(articulo);
        }

        [HttpPost]
        [Route("")]

        public IActionResult Registrar(Proveedor proveedor){
            
            proveedores.Add(proveedor);

            return CreatedAtAction(nameof(ObtenerPorId), new{proveedor.Id}, proveedor);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Editar(int id, Proveedor proveedor){
            var proveedorOriginal = proveedores.FirstOrDefault(a => a.Id == id);
            proveedor.Id = id;
            var indice = proveedores.IndexOf(proveedorOriginal);
            proveedores[indice].Nombre = proveedor.Nombre;
            proveedores[indice].Telefono = proveedor.Telefono;
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Borrar(int id){
            var proveedor = proveedores.FirstOrDefault(a => a.Id == id);
            proveedores.Remove(proveedor);
            return Ok();
        }

    }
}