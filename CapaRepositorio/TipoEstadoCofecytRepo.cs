using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class TipoEstadoCofecytRepo
    {
        public IEnumerable<TipoEstadoCofecyt> MostrarTipoEstadoCofecyts()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<TipoEstadoCofecyt> result = modeloDeDominio.TipoEstadoCofecyts.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public TipoEstadoCofecyt ObtenerTipoEstadoCofecytSegunNombre(string nom)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoEstadoCofecyt tipoEstadoCofecyt = modeloDeDominio.TipoEstadoCofecyts.Where(c => c.Nombre == nom).FirstOrDefault();

                return tipoEstadoCofecyt;
            }
        }
        public string TraerTipoEstadoCofecyt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoEstadoCofecyt result = modeloDeDominio.TipoEstadoCofecyts.Where(c => c.IdTipoEstadoCofecyt == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public int TraerTipoEstadoCofecytIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoEstadoCofecyt result = modeloDeDominio.TipoEstadoCofecyts.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdTipoEstadoCofecyt;
            }
        }
    }
}
