using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ActividadCofecytNego
    {
        ActividadCofecytRepo actividadCofecytRepo = new ActividadCofecytRepo();

        public void GuardarActividadCofecyt(ActividadCofecyt actividadCofecyt)
        {
            actividadCofecytRepo.GuardarActividadCofecyt(actividadCofecyt);
        }
        public IEnumerable<ActividadCofecyt> TraerActividadCofecytsSegunIdProyecto(int id)
        {
            return actividadCofecytRepo.TraerActividadCofecytsSegunIdProyecto(id);
        }
        public void ActualizarActividadCofecyt(ActividadCofecyt actividadCofecyt)
        {
            actividadCofecytRepo.ActualizarActividadCofecyt(actividadCofecyt);
        }


    }
}
