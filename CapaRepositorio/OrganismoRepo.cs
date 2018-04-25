using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class OrganismoRepo
    {
        public IEnumerable<Organismo> MostrarOrganismos()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Organismo> result = modeloDeDominio.Organismos.ToList();
                return result;
            }
        }
        public string TraerOrganismo(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Organismo result = modeloDeDominio.Organismos.Where(c => c.IdOrganismo == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public int GuardarOrganismo(Organismo organismo)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(organismo);
                modeloDeDominio.SaveChanges();
                return organismo.IdOrganismo;
            }
        }
        public int TraerOrganismoIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Organismo result = modeloDeDominio.Organismos.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdOrganismo;
            }
        }
        public Organismo ObtenerOrganismo(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Organismo result = modeloDeDominio.Organismos.Where(c => c.IdOrganismo == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result;
            }
        }
        public void ActualizarOrganismo(Organismo organismo)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(organismo);
                modeloDeDominio.SaveChanges();
            }
        }
    }
}
