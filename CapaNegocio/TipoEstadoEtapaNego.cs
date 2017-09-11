using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;


namespace CapaNegocio
{
    public class TipoEstadoEtapaNego
    {
        TipoEstadoEtapaRepo tipoEstadoEtapaRepo = new TipoEstadoEtapaRepo();

        public IEnumerable<TipoEstadoEtapa> MostrarTipoEstadoEtapas()
        {
            return tipoEstadoEtapaRepo.MostrarTipoEstadoEtapas();
        }
        public int TraerTipoEstadoEtapaIdSegunItem(string item)
        {
            return tipoEstadoEtapaRepo.TraerTipoEstadoEtapaIdSegunItem(item);
        }
    }
}
