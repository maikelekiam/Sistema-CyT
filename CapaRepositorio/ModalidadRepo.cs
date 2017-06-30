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

        public Modalidad ObtenerModalidadSegunId(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Modalidad modalidad = modeloDeDominio.Modalidads.Where(c => c.IdModalidad == id).FirstOrDefault();
                return modalidad;
            }
        }

        public void ActualizarModalidad(Modalidad modalidad)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(modalidad);
                modeloDeDominio.SaveChanges();
            }
        }
        public IEnumerable<Modalidad> MostrarModalidades()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Modalidad> result = modeloDeDominio.Modalidads.ToList();

                return result;
            }
        }
        public IEnumerable<Modalidad> TraerModalidadesSegunIdConvocatoria(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Modalidad> result = modeloDeDominio.Modalidads.Where(c => c.IdConvocatoria == id).ToList();

                return result;
            }
        }
    }
}
