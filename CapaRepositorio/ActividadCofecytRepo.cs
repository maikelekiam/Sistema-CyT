using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ActividadCofecytRepo
    {
        public void GuardarActividadCofecyt(ActividadCofecyt actividadCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(actividadCofecyt);
                modeloDeDominio.SaveChanges();
            }
        }
    }
}
