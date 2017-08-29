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
        public TipoEstado ObtenerTipoEstadoSegunNombre(string nom)
        {
            return tipoEstadoRepo.ObtenerTipoEstadoSegunNombre(nom);
        }
        public string TraerTipoEstado(int id)
        {
            return tipoEstadoRepo.TraerTipoEstado(id);
        }
        public int TraerTipoEstadoIdSegunItem(string item)
        {
            return tipoEstadoRepo.TraerTipoEstadoIdSegunItem(item);
        }
    }
}
