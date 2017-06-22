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
        OrganismoRepo organismoNego = new OrganismoRepo();

        public IEnumerable<Organismo> MostrarOrganismos()
        {
            return organismoNego.MostrarOrganismos();
        }
        public string TraerOrganismo(int id)
        {
            return organismoNego.TraerOrganismo(id);
        }
        public int GuardarOrganismo(Organismo organismo)
        {
            return organismoNego.GuardarOrganismo(organismo);
        }
        public int TraerOrganismoIdSegunItem(string item)
        {
            return organismoNego.TraerOrganismoIdSegunItem(item);
        }
    }
}