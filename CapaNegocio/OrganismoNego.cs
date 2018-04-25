using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class OrganismoNego
    {
        OrganismoRepo organismoRepo = new OrganismoRepo();

        public IEnumerable<Organismo> MostrarOrganismos()
        {
            return organismoRepo.MostrarOrganismos();
        }
        public string TraerOrganismo(int id)
        {
            return organismoRepo.TraerOrganismo(id);
        }
        public int GuardarOrganismo(Organismo organismo)
        {
            return organismoRepo.GuardarOrganismo(organismo);
        }
        public int TraerOrganismoIdSegunItem(string item)
        {
            return organismoRepo.TraerOrganismoIdSegunItem(item);
        }
        public Organismo ObtenerOrganismo(int id)
        {
            return organismoRepo.ObtenerOrganismo(id);
        }
        public void ActualizarOrganismo(Organismo organismo)
        {
            organismoRepo.ActualizarOrganismo(organismo);
        }
    }
}