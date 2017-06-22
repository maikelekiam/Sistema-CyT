﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ActuacionRepo
    {
        // METODO PARA GUARDAR UNA ACTUACION
        public int GuardarActuacion(Actuacion actuacion)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(actuacion);
                modeloDeDominio.SaveChanges();
                return actuacion.IdActuacion;
            }
        }

        public IEnumerable<Actuacion> MostrarActuacionSegunProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Actuacion> result = modeloDeDominio.Actuacions.Where(c => c.IdProyecto == id).OrderBy(c => c.IdOrganismo).ToList();

                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }

        public void EliminarActuacion(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IQueryable<Actuacion> query = modeloDeDominio.GetAll<Actuacion>().Where(c => c.IdActuacion == id);

                foreach (Actuacion actuacion in query)
                {
                    modeloDeDominio.Delete(actuacion);
                    modeloDeDominio.SaveChanges();
                }
            }
        }

        public void ActualizarActuacion(Actuacion actuacion)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(actuacion);
                modeloDeDominio.SaveChanges();
            }
        }
    }
}