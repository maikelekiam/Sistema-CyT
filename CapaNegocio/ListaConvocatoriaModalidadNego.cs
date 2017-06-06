using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class ListaConvocatoriaModalidadNego
    {
        ListaConvocatoriaModalidadRepo listaConvocatoriaModalidadRepo = new ListaConvocatoriaModalidadRepo();

        public void GuardarListaConvocatoriaModalidad(ListaConvocatoriaModalidad listaConvocatoriaModalidad)
        {
            listaConvocatoriaModalidadRepo.GuardarListaConvocatoriaModalidad(listaConvocatoriaModalidad);
        }

        public IEnumerable<ListaConvocatoriaModalidad> TraerModalidadSegunConvocatoria(int id)
        {
            return listaConvocatoriaModalidadRepo.TraerModalidadSegunConvocatoria(id);
        }
        public void ActualizarListaConvocatoriaModalidad(ListaConvocatoriaModalidad listaConvocatoriaModalidad)
        {
            listaConvocatoriaModalidadRepo.ActualizarListaConvocatoriaModalidad(listaConvocatoriaModalidad);
        }
    }
}
