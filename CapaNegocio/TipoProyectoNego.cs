using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class TipoProyectoNego
    {
        TipoProyectoRepo tipoProyectoRepo = new TipoProyectoRepo();

        public IEnumerable<TipoProyecto> MostrarTipoProyectos()
        {
            return tipoProyectoRepo.MostrarTipoProyectos();
        }
        public int TraerTipoProyectoIdSegunItem(string item)
        {
            return tipoProyectoRepo.TraerTipoProyectoIdSegunItem(item);
        }
        public string TraerTipoProyecto(int id)
        {
            return tipoProyectoRepo.TraerTipoProyecto(id);
        }
        public TipoProyecto ObtenerTipoProyecto(int id)
        {
            return tipoProyectoRepo.ObtenerTipoProyecto(id);
        }
    }
}
