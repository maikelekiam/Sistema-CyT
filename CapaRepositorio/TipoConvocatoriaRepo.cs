using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class TipoConvocatoriaRepo
    {
        public void GuardarTipoConvocatoria(TipoConvocatorium tipoConvocatorium)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(tipoConvocatorium);
                modeloDeDominio.SaveChanges();
            }
        }
        public IEnumerable<TipoConvocatorium> MostrarTipoConvocatorias()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<TipoConvocatorium> result = modeloDeDominio.TipoConvocatoria.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public string ObtenerTipoConvocatoriaString(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                TipoConvocatorium result = modeloDeDominio.TipoConvocatoria.Where(c => c.IdTipoConvocatoria == id).FirstOrDefault();

                return result.Nombre.ToString(); ;
            }
        }

    }
}
