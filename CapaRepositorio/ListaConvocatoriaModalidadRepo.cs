using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ListaConvocatoriaModalidadRepo
    {
        public void GuardarListaConvocatoriaModalidad(ListaConvocatoriaModalidad listaConvocatoriaModalidad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(listaConvocatoriaModalidad);
                modeloDeDominio.SaveChanges();
            }
        }

        public IEnumerable<ListaConvocatoriaModalidad> TraerModalidadSegunConvocatoria(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<ListaConvocatoriaModalidad> result = modeloDeDominio.ListaConvocatoriaModalidads.Where(c => c.IdConvocatoria == id).ToList();
                return result;
            }
        }
    }
}
