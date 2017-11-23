using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class UdtUvtRepo
    {
        public IEnumerable<UdtUvt> MostrarUdtUvts()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<UdtUvt> result = modeloDeDominio.UdtUvts.ToList();
                return result;
            }
        }
        public string TraerUdtUvt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                UdtUvt result = modeloDeDominio.UdtUvts.Where(c => c.IdUdtUvt == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public int GuardarUdtUvt(UdtUvt udtUvt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(udtUvt);
                modeloDeDominio.SaveChanges();
                return udtUvt.IdUdtUvt;
            }
        }

        public UdtUvt ObtenerUdtUvt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                UdtUvt result = modeloDeDominio.UdtUvts.Where(c => c.IdUdtUvt == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result;
            }
        }
        public void ActualizarUdtUvt(UdtUvt udtUvt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(udtUvt);
                modeloDeDominio.SaveChanges();
            }
        }
        public int TraerUdtUvtIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                UdtUvt result = modeloDeDominio.UdtUvts.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdUdtUvt;
            }
        }
    }
}
