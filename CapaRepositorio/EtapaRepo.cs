using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class EtapaRepo
    {
        public void GuardarEtapa(Etapa etapa)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(etapa);
                modeloDeDominio.SaveChanges();
            }
        }

        public Etapa ObtenerEtapaSegunId(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Etapa etapa = modeloDeDominio.Etapas.Where(c => c.IdEtapa == id).FirstOrDefault();
                return etapa;
            }
        }

        public void ActualizarEtapa(Etapa etapa)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(etapa);
                modeloDeDominio.SaveChanges();
            }
        }
    }
}
