﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class PersonaNego
    {
        PersonaRepo personaRepo = new PersonaRepo();

        public IEnumerable<Persona> MostrarPersonas()
        {
            return personaRepo.MostrarPersonas();
        }
    }
}
