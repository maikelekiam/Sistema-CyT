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
    }
}
