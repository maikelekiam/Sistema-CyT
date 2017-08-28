using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;


namespace CapaNegocio
{
    public class TipoEstadoNego
    {
        TipoEstadoRepo tipoEstadoRepo = new TipoEstadoRepo();

        public IEnumerable<TipoEstado> MostrarTipoEstados()
        {
            return tipoEstadoRepo.MostrarTipoEstados();
        }
    }
}
