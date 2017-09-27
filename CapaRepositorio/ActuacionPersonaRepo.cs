using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class ActuacionPersonaRepo
    {
        // METODO PARA GUARDAR UNA ACTUACION
        public int GuardarActuacionPersona(ActuacionPersona actuacionPersona)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(actuacionPersona);
                modeloDeDominio.SaveChanges();
                return actuacionPersona.IdActuacionPersona;
            }
        }

        public void EliminarActuacionPersona(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IQueryable<ActuacionPersona> query = modeloDeDominio.GetAll<ActuacionPersona>().Where(c => c.IdActuacionPersona == id);

                foreach (ActuacionPersona actuacionPersona in query)
                {
                    modeloDeDominio.Delete(actuacionPersona);
                    modeloDeDominio.SaveChanges();
                }
            }
        }

        public void ActualizarActuacionPersona(ActuacionPersona actuacionPersona)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(actuacionPersona);
                modeloDeDominio.SaveChanges();
            }
        }
        public ActuacionPersona ObtenerActuacionPersona(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                ActuacionPersona actuacionPersona = modeloDeDominio.ActuacionPersonas.Where(c => c.IdActuacionPersona == id).FirstOrDefault();

                return actuacionPersona;
            }
        }
    }
}