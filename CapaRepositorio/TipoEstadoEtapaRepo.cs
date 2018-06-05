using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class TipoEstadoEtapaRepo
    {
        public IEnumerable<TipoEstadoEtapa> MostrarTipoEstadoEtapas()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<TipoEstadoEtapa> result = modeloDeDominio.TipoEstadoEtapas.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public int TraerTipoEstadoEtapaIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoEstadoEtapa result = modeloDeDominio.TipoEstadoEtapas.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdTipoEstadoEtapa;
            }
        }
        public string TraerTipoEstadoEtapa(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoEstadoEtapa result = modeloDeDominio.TipoEstadoEtapas.Where(c => c.IdTipoEstadoEtapa == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
    }
}
