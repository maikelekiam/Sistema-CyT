using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class EtapaCofecytRepo
    {
        public int GuardarEtapaCofecyt(EtapaCofecyt etapaCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(etapaCofecyt);
                modeloDeDominio.SaveChanges();
            }
            return etapaCofecyt.IdEtapaCofecyt;
        }

        public EtapaCofecyt ObtenerEtapaCofecytSegunId(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                EtapaCofecyt etapaCofecyt = modeloDeDominio.EtapaCofecyts.Where(c => c.IdEtapaCofecyt == id).FirstOrDefault();
                return etapaCofecyt;
            }
        }

        public void ActualizarEtapaCofecyt(EtapaCofecyt etapaCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(etapaCofecyt);
                modeloDeDominio.SaveChanges();
            }
        }
        public IEnumerable<EtapaCofecyt> TraerEtapaCofecytsSegunIdProyecto(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<EtapaCofecyt> result = modeloDeDominio.EtapaCofecyts.Where(c => c.IdProyectoCofecyt == id).ToList();
                return result;
            }
        }
    }
}
