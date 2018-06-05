using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ActividadRepo
    {
        public void GuardarActividad(Actividad actividad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(actividad);
                modeloDeDominio.SaveChanges();
            }
        }
        public IEnumerable<Actividad> TraerActividadsSegunIdProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Actividad> result = modeloDeDominio.Actividads.Where(c => c.IdProyecto == id).ToList();
                return result;
            }
        }
        public void ActualizarActividad(Actividad actividad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(actividad);
                modeloDeDominio.SaveChanges();
            }
        }
        public Actividad ObtenerActividadSegunId(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Actividad actividad = modeloDeDominio.Actividads.Where(c => c.IdActividad == id).FirstOrDefault();
                return actividad;
            }
        }
    }
}
