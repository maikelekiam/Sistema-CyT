using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class EtapaNego
    {
        EtapaRepo etapaRepo = new EtapaRepo();

        public void GuardarEtapa(Etapa etapa)
        {
            etapaRepo.GuardarEtapa(etapa);
        }

        public Etapa ObtenerEtapaSegunId(int id)
        {
            return etapaRepo.ObtenerEtapaSegunId(id);
        }

        public void ActualizarEtapa(Etapa etapa)
        {
            etapaRepo.ActualizarEtapa(etapa);
        }
        public IEnumerable<Etapa> TraerEtapasSegunIdProyecto(int id)
        {
            return etapaRepo.TraerEtapasSegunIdProyecto(id);
        }
    }
}
