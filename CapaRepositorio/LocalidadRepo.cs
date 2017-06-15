﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class LocalidadRepo
    {
        public IEnumerable<Localidad> MostrarLocalidades()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Localidad> result = modeloDeDominio.Localidads.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public string TraerLocalidad(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Localidad result = modeloDeDominio.Localidads.Where(c => c.IdLocalidad == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public int GuardarLocalidad(Localidad localidad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(localidad);
                modeloDeDominio.SaveChanges();
                return localidad.IdLocalidad;
            }
        }
        public int TraerLocalidadIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Localidad result = modeloDeDominio.Localidads.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdLocalidad;
            }
        }
    }
}
