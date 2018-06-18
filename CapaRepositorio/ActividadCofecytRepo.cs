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
        public IEnumerable<ActividadCofecyt> TraerActividadCofecytsSegunIdProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<ActividadCofecyt> result = modeloDeDominio.ActividadCofecyts.Where(c => c.IdProyectoCofecyt == id).ToList();
                return result;
            }
        }
        public void ActualizarActividadCofecyt(ActividadCofecyt actividadCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(actividadCofecyt);
                modeloDeDominio.SaveChanges();
            }
        }
        public ActividadCofecyt ObtenerActividadCofecytSegunId(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                ActividadCofecyt actividadCofecyt = modeloDeDominio.ActividadCofecyts.Where(c => c.IdActividadCofecyt == id).FirstOrDefault();
                return actividadCofecyt;
            }
        }
    }
}
