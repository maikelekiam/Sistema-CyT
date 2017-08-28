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
        public TipoEstado ObtenerTipoEstadoSegunNombre(string nom)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoEstado tipoEstado = modeloDeDominio.TipoEstados.Where(c => c.Nombre == nom).FirstOrDefault();

                return tipoEstado;
            }
        }
    }
}
