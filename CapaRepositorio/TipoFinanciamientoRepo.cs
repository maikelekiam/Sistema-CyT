﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class TipoFinanciamientoRepo
    {
        public void GuardarTipoFinanciamiento(TipoFinanciamiento tipoFinanciamiento)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(tipoFinanciamiento);
                modeloDeDominio.SaveChanges();
            }
        }

        public IEnumerable<TipoFinanciamiento> MostrarTipoFinanciamientos()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<TipoFinanciamiento> result = modeloDeDominio.TipoFinanciamientos.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public string ObtenerTipoFinanciamientoString(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoFinanciamiento result = modeloDeDominio.TipoFinanciamientos.Where(c => c.IdTipoFinanciamiento == id).FirstOrDefault();

                return result.Nombre.ToString(); ;
            }
        }
    }
}