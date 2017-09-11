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
    }
}
