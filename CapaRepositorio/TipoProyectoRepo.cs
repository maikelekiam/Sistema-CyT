using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class TipoProyectoRepo
    {
        public IEnumerable<TipoProyecto> MostrarTipoProyectos()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<TipoProyecto> result = modeloDeDominio.TipoProyectos.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public int TraerTipoProyectoIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoProyecto result = modeloDeDominio.TipoProyectos.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdTipoProyecto;
            }
        }
        public string TraerTipoProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoProyecto result = modeloDeDominio.TipoProyectos.Where(c => c.IdTipoProyecto == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public TipoProyecto ObtenerTipoProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoProyecto tipoProyecto = modeloDeDominio.TipoProyectos.Where(c => c.IdTipoProyecto == id).FirstOrDefault();

                return tipoProyecto;
            }
        }
    }
}
