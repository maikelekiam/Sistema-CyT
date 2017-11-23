using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using Telerik.OpenAccess.Data.Common;
using System.Data;

namespace CapaRepositorio
{
    public class ProyectoCofecytRepo
    {
        public int GuardarProyectoCofecyt(ProyectoCofecyt proyectoCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(proyectoCofecyt);
                modeloDeDominio.SaveChanges();
            }
            return proyectoCofecyt.IdProyectoCofecyt;
        }

        public IEnumerable<ProyectoCofecyt> MostrarProyectoCofecyts()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<ProyectoCofecyt> result = modeloDeDominio.ProyectoCofecyts.ToList();
                return result;
            }
        }

        public ProyectoCofecyt ObtenerProyectoCofecyt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                ProyectoCofecyt proyectoCofecyt = modeloDeDominio.ProyectoCofecyts.Where(c => c.IdProyectoCofecyt == id).FirstOrDefault();

                return proyectoCofecyt;
            }
        }

        public void ActualizarProyectoCofecyt(ProyectoCofecyt proyectoCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(proyectoCofecyt);
                modeloDeDominio.SaveChanges();
            }
        }

        public void EliminarProyectoCofecyt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IQueryable<ProyectoCofecyt> query = modeloDeDominio.GetAll<ProyectoCofecyt>().Where(c => c.IdProyectoCofecyt == id);

                foreach (ProyectoCofecyt proyectoCofecyt in query)
                {
                    modeloDeDominio.Delete(proyectoCofecyt);
                    modeloDeDominio.SaveChanges();
                }
            }
        }
        public string ObtenerProyectoCofecytString(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                ProyectoCofecyt result = modeloDeDominio.ProyectoCofecyts.Where(c => c.IdProyectoCofecyt == id).FirstOrDefault();

                return result.NumeroConvenio.ToString();
            }
        }
    }
}
