using InstitutoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoAPI.Services
{
    public class EstudianteService
    {
        public readonly EstudianteDbContext _estudianteDbContext;

        public EstudianteService(EstudianteDbContext estudianteDbContext)
        {
            _estudianteDbContext = estudianteDbContext;
        }
        public List<Estudiante> Obtener()
        {
            return _estudianteDbContext.T_Estudiante.Include(x => x.Autor).ToList();
        }

        public Boolean AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                _estudianteDbContext.T_Estudiante.Add(estudiante);
                _estudianteDbContext.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                Console.ReadLine();
                return false;
            }
        }
        public Boolean EditarEstudiante(Estudiante estudiante)
        {
            try
            {
                var estudianteDB = _estudianteDbContext.T_Estudiante.Where(x => x.EstudianteID == estudiante.EstudianteID).FirstOrDefault();
                estudianteDB.Nombre = estudiante.Nombre;
                estudianteDB.Apellido = estudiante.Apellido;
                estudianteDB.Edad = estudiante.Edad;
                estudianteDB.Escuela = estudiante.Escuela;
                estudianteDB.Carrera = estudiante.Carrera;
                estudianteDB.AutorID = estudiante.AutorID;

                _estudianteDbContext.SaveChanges();

                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                Console.ReadLine();
                return false;
            }
        }
        public Boolean EliminarEstudiante(int estudianteID)
        {
            try
            {
                var estudianteDB = _estudianteDbContext.T_Estudiante.Where(x => x.EstudianteID == estudianteID).FirstOrDefault();
                _estudianteDbContext.T_Estudiante.Remove(estudianteDB);
                _estudianteDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public List<Autor> listadoAutores()
        {
            try
            {
                var autores = _estudianteDbContext.T_Autor.ToList();
                return autores;
            }
            catch (Exception error)
            {
                return new List<Autor>();
            }

        }
    }
}