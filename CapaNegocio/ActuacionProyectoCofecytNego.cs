using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ActuacionProyectoCofecytNego
    {
        ActuacionProyectoCofecytRepo actuacionProyectoCofecytRepo = new ActuacionProyectoCofecytRepo();

        public int GuardarActuacionProyectoCofecyt(ActuacionProyectoCofecyt actuacionProyectoCofecyt)
        {
            return actuacionProyectoCofecytRepo.GuardarActuacionProyectoCofecyt(actuacionProyectoCofecyt);
        }

        public void EliminarActuacionProyectoCofecyt(int id)
        {
            actuacionProyectoCofecytRepo.EliminarActuacionProyectoCofecyt(id);
        }

        public void ActualizarActuacionProyectoCofecyt(ActuacionProyectoCofecyt actuacionProyectoCofecyt)
        {
            actuacionProyectoCofecytRepo.ActualizarActuacionProyectoCofecyt(actuacionProyectoCofecyt);
        }

        public ActuacionProyectoCofecyt ObtenerActuacionProyectoCofecyt(int id)
        {
            return actuacionProyectoCofecytRepo.ObtenerActuacionProyectoCofecyt(id);
        }
        public IEnumerable<ActuacionProyectoCofecyt> MostrarActuacionProyectoCofecytSegunProyectoCofecyt(int id)
        {
            return actuacionProyectoCofecytRepo.MostrarActuacionProyectoCofecytSegunProyectoCofecyt(id);
        }
    }
}
