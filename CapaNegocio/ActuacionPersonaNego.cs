using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ActuacionPersonaNego
    {
        ActuacionPersonaRepo actuacionPersonaRepo = new ActuacionPersonaRepo();

        public int GuardarActuacionPersona(ActuacionPersona actuacionPersona)
        {
            return actuacionPersonaRepo.GuardarActuacionPersona(actuacionPersona);
        }

        public void EliminarActuacionPersona(int id)
        {
            actuacionPersonaRepo.EliminarActuacionPersona(id);
        }

        public void ActualizarActuacionPersona(ActuacionPersona actuacionPersona)
        {
            actuacionPersonaRepo.ActualizarActuacionPersona(actuacionPersona);
        }

        public ActuacionPersona ObtenerActuacionPersona(int id)
        {
            return actuacionPersonaRepo.ObtenerActuacionPersona(id);
        }
        public IEnumerable<ActuacionPersona> MostrarActuacionPersonaSegunPersona(int id)
        {
            return actuacionPersonaRepo.MostrarActuacionPersonaSegunPersona(id);
        }
    }
}