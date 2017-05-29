﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ListaConvocatoriaModalidadRepo
    {
        public void GuardarListaConvocatoriaModalidad(ListaConvocatoriaModalidad listaConvocatoriaModalidad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(listaConvocatoriaModalidad);
                modeloDeDominio.SaveChanges();
            }
        }
    }
}
