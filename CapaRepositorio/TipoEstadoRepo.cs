using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class TipoEstadoRepo
    {
        public IEnumerable<TipoEstado> MostrarTipoEstados()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<TipoEstado> result = modeloDeDominio.TipoEstados.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
    }
}
