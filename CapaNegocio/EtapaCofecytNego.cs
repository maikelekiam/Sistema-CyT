using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class EtapaCofecytNego
    {
        EtapaCofecytRepo etapaCofecytRepo = new EtapaCofecytRepo();

        public void GuardarEtapaCofecyt(EtapaCofecyt etapaCofecyt)
        {
            etapaCofecytRepo.GuardarEtapaCofecyt(etapaCofecyt);
        }

        public EtapaCofecyt ObtenerEtapaCofecytSegunId(int id)
        {
            return etapaCofecytRepo.ObtenerEtapaCofecytSegunId(id);
        }

        public void ActualizarEtapaCofecyt(EtapaCofecyt etapaCofecyt)
        {
            etapaCofecytRepo.ActualizarEtapaCofecyt(etapaCofecyt);
        }
        public IEnumerable<EtapaCofecyt> TraerEtapaCofecytsSegunIdProyecto(int id)
        {
            return etapaCofecytRepo.TraerEtapaCofecytsSegunIdProyecto(id);
        }
    }
}
