using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ActuacionNego
    {
        ActuacionRepo actuacionRepo = new ActuacionRepo();

        public int GuardarActuacion(Actuacion actuacion)
        {
            return actuacionRepo.GuardarActuacion(actuacion);
        }

        public IEnumerable<Actuacion> MostrarActuacionSegunProyecto(int id)
        {
            return actuacionRepo.MostrarActuacionSegunProyecto(id);
        }

        public void EliminarActuacion(int id)
        {
            actuacionRepo.EliminarActuacion(id);
        }

        public void ActualizarActuacion(Actuacion actuacion)
        {
            actuacionRepo.ActualizarActuacion(actuacion);
        }

        public Actuacion ObtenerActuacion(int id)
        {
            return actuacionRepo.ObtenerActuacion(id);
        }
    }
}