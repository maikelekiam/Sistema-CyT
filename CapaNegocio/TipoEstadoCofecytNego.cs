using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class TipoEstadoCofecytNego
    {
        TipoEstadoCofecytRepo tipoEstadoCofecytRepo = new TipoEstadoCofecytRepo();

        public IEnumerable<TipoEstadoCofecyt> MostrarTipoEstadoCofecyts()
        {
            return tipoEstadoCofecytRepo.MostrarTipoEstadoCofecyts();
        }
        public TipoEstadoCofecyt ObtenerTipoEstadoCofecytSegunNombre(string nom)
        {
            return tipoEstadoCofecytRepo.ObtenerTipoEstadoCofecytSegunNombre(nom);
        }
        public string TraerTipoEstadoCofecyt(int id)
        {
            return tipoEstadoCofecytRepo.TraerTipoEstadoCofecyt(id);
        }
        public int TraerTipoEstadoCofecytIdSegunItem(string item)
        {
            return tipoEstadoCofecytRepo.TraerTipoEstadoCofecytIdSegunItem(item);
        }
    }
}
