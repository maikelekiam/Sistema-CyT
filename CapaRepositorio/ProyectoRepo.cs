﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ProyectoRepo
    {
        public int GuardarProyecto(Proyecto proyecto)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(proyecto);
                modeloDeDominio.SaveChanges();
            }
            return proyecto.IdProyecto;
        }

        public IEnumerable<Proyecto> MostrarProyectos()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Proyecto> result = modeloDeDominio.Proyectos.ToList();
                return result;
            }
        }

        public Proyecto ObtenerProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Proyecto proyecto = modeloDeDominio.Proyectos.Where(c => c.IdProyecto == id).FirstOrDefault();

                return proyecto;
            }
        }

        public void ActualizarProyecto(Proyecto proyecto)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(proyecto);
                modeloDeDominio.SaveChanges();
            }
        }

        public void EliminarProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IQueryable<Proyecto> query = modeloDeDominio.GetAll<Proyecto>().Where(c => c.IdProyecto == id);

                foreach (Proyecto proyecto in query)
                {
                    modeloDeDominio.Delete(proyecto);
                    modeloDeDominio.SaveChanges();
                }
            }
        }
        public string ObtenerProyectoString(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Proyecto result = modeloDeDominio.Proyectos.Where(c => c.IdProyecto == id).FirstOrDefault();

                return result.Nombre.ToString();
            }
        }
    }
}
