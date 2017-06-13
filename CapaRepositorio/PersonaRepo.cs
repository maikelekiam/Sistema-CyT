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
    }
}
