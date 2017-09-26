using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;
using System.Data;

namespace CapaNegocio
{
    public class PersonaNego
    {
        PersonaRepo personaRepo = new PersonaRepo();

        public IEnumerable<Persona> MostrarPersonas()
        {
            return personaRepo.MostrarPersonas();
        }
        public string TraerPersona(int id)
        {
            return personaRepo.TraerPersona(id);
        }
        public int GuardarPersona(Persona persona)
        {
            return personaRepo.GuardarPersona(persona);
        }
        public int TraerPersonaIdSegunItem(string item1, string item2)
        {
            return personaRepo.TraerPersonaIdSegunItem(item1, item2);
        }
        public Persona ObtenerPersona(int id)
        {
            return personaRepo.ObtenerPersona(id);
        }
        public List<Persona> MostrarPersonasDt()
        {
            return personaRepo.MostrarPersonasDt();
        }
        public void ActualizarPersona(Persona persona)
        {
            personaRepo.ActualizarPersona(persona);
        }
    }
}
