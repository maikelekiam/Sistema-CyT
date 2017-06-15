using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ProyectoNego
    {
        ProyectoRepo proyectoRepo = new ProyectoRepo();
        public int GuardarProyecto(Proyecto proyecto)
        {
            return proyectoRepo.GuardarProyecto(proyecto);
        }

        public IEnumerable<Proyecto> MostrarProyectos()
        {
            return proyectoRepo.MostrarProyectos();
        }

        public void ActualizarProyecto(Proyecto proyecto)
        {
            proyectoRepo.ActualizarProyecto(proyecto);
        }

        public void EliminarProyecto(int id)
        {
            proyectoRepo.EliminarProyecto(id);
        }
        public Proyecto ObtenerProyecto(int id)
        {
            return proyectoRepo.ObtenerProyecto(id);
        }
        public string ObtenerProyectoString(int id)
        {
            return proyectoRepo.ObtenerProyectoString(id);
        }
    }
}
