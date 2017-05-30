using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ModalidadRepo
    {
        public void GuardarModalidad(Modalidad modalidad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(modalidad);
                modeloDeDominio.SaveChanges();
            }
        }
    }
}
