using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ProyectoCofecytNego
    {
        ProyectoCofecytRepo proyectoCofecytRepo = new ProyectoCofecytRepo();
        public int GuardarProyectoCofecyt(ProyectoCofecyt proyectoCofecyt)
        {
            return proyectoCofecytRepo.GuardarProyectoCofecyt(proyectoCofecyt);
        }

        public IEnumerable<ProyectoCofecyt> MostrarProyectoCofecyts()
        {
            return proyectoCofecytRepo.MostrarProyectoCofecyts();
        }

        public void ActualizarProyectoCofecyt(ProyectoCofecyt proyectoCofecyt)
        {
            proyectoCofecytRepo.ActualizarProyectoCofecyt(proyectoCofecyt);
        }

        public void EliminarProyectoCofecyt(int id)
        {
            proyectoCofecytRepo.EliminarProyectoCofecyt(id);
        }
        public ProyectoCofecyt ObtenerProyectoCofecyt(int id)
        {
            return proyectoCofecytRepo.ObtenerProyectoCofecyt(id);
        }
        public string ObtenerProyectoCofecytString(int id)
        {
            return proyectoCofecytRepo.ObtenerProyectoCofecytString(id);
        }
        public IEnumerable<pr03ResultSet0> ListarChoiceProyectoCofecyts(int id)
        {
            return proyectoCofecytRepo.ListarChoiceProyectoCofecyts(id);
        }
        public ProyectoCofecyt ObtenerProyectoCofecytSegunNombreYConvocatoria(int id, string nom)
        {
            return proyectoCofecytRepo.ObtenerProyectoCofecytSegunNombreYConvocatoria(id, nom);
        }
    }
}
