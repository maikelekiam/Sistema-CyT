using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ActividadNego
    {
        ActividadRepo actividadRepo = new ActividadRepo();

        public void GuardarActividad(Actividad actividad)
        {
            actividadRepo.GuardarActividad(actividad);
        }
        public IEnumerable<Actividad> TraerActividadsSegunIdProyecto(int id)
        {
            return actividadRepo.TraerActividadsSegunIdProyecto(id);
        }
        public void ActualizarActividad(Actividad actividad)
        {
            actividadRepo.ActualizarActividad(actividad);
        }
        public Actividad ObtenerActividadSegunId(int id)
        {
            return actividadRepo.ObtenerActividadSegunId(id);
        }
    }
}
