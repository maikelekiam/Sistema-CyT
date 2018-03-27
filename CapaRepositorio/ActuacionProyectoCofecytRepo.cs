using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ActuacionProyectoCofecytRepo
    {
        public int GuardarActuacionProyectoCofecyt(ActuacionProyectoCofecyt actuacionProyectoCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(actuacionProyectoCofecyt);
                modeloDeDominio.SaveChanges();
                return actuacionProyectoCofecyt.IdActuacionProyectoCofecyt;
            }
        }

        public void EliminarActuacionProyectoCofecyt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IQueryable<ActuacionProyectoCofecyt> query = modeloDeDominio.GetAll<ActuacionProyectoCofecyt>().Where(c => c.IdActuacionProyectoCofecyt == id);

                foreach (ActuacionProyectoCofecyt actuacionProyectoCofecyt in query)
                {
                    modeloDeDominio.Delete(actuacionProyectoCofecyt);
                    modeloDeDominio.SaveChanges();
                }
            }
        }

        public void ActualizarActuacionProyectoCofecyt(ActuacionProyectoCofecyt actuacionProyectoCofecyt)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(actuacionProyectoCofecyt);
                modeloDeDominio.SaveChanges();
            }
        }
        public ActuacionProyectoCofecyt ObtenerActuacionProyectoCofecyt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                ActuacionProyectoCofecyt actuacionProyectoCofecyt = modeloDeDominio.ActuacionProyectoCofecyts.Where(c => c.IdActuacionProyectoCofecyt == id).FirstOrDefault();

                return actuacionProyectoCofecyt;
            }
        }
        public IEnumerable<ActuacionProyectoCofecyt> MostrarActuacionProyectoCofecytSegunProyectoCofecyt(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<ActuacionProyectoCofecyt> result = modeloDeDominio.ActuacionProyectoCofecyts.Where(c => c.IdProyectoCofecyt == id).OrderBy(c => c.FechaActuacion).ToList();

                return result;
            }
        }
    }
}
