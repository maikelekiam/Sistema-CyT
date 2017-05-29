using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ModalidadRepo
    {
        public void GuardarModalidad(Modalidad modalidad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(modalidad);
                modeloDeDominio.SaveChanges();
            }
        }

        public IEnumerable<Modalidad> MostrarModalidades(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Modalidad> result = modeloDeDominio.Modalidads.Where(c => c.IdModalidad == id).OrderBy(c => c.IdModalidad).ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
    }
}
