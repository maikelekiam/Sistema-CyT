using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class PersonaRepo
    {
        public IEnumerable<Persona> MostrarPersonas()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Persona> result = modeloDeDominio.Personas.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public string TraerPersona(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Persona result = modeloDeDominio.Personas.Where(c => c.IdPersona == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre + "," + result.Apellido;
            }
        }
        public int GuardarPersona(Persona persona)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(persona);
                modeloDeDominio.SaveChanges();
                return persona.IdPersona;
            }
        }
        public int TraerPersonaIdSegunItem(string item1, string item2)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Persona result = modeloDeDominio.Personas.Where(c => ((c.Nombre == item1) && (c.Apellido == item2))).FirstOrDefault();
                modeloDeDominio.CreateDetachedCopy(result);
                return result.IdPersona;
            }
        }
    }
}
