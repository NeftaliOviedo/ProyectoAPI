using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstitutoAPI.Models;
using InstitutoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstitutoAPI.Controllers
{
    [Route("api/estudiante")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteService _estudianteService;
        public EstudianteController(EstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            var resultado = _estudianteService.Obtener();
            return Ok(resultado);
        }
        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] Estudiante estudiante)
        {
            var resultado = _estudianteService.AgregarEstudiante(estudiante);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Estudiante estudiante)
        {
            var resultado = _estudianteService.EditarEstudiante(estudiante);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("borrar/{estudianteID}")]
        public IActionResult Eliminar(int estudianteID)
        {
            var resultado = _estudianteService.EliminarEstudiante(estudianteID);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("listadoAutores")]
        public IActionResult verAutores()
        {
            var resultado = _estudianteService.listadoAutores();
            return Ok(resultado);
        }
    }
}