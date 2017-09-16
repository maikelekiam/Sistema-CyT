using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{    
    public class ConvocatoriaNego
    {
        ConvocatoriaRepo convocatoriaRepo = new ConvocatoriaRepo();

        public int GuardarConvocatoria(Convocatorium convocatoria)
        {
            return convocatoriaRepo.GuardarConvocatoria(convocatoria);
        }

        public IEnumerable<Convocatorium> MostrarConvocatorias()
        {
            return convocatoriaRepo.MostrarConvocatorias();
        }

        public Convocatorium ObtenerConvocatoria(int id)
        {
            return convocatoriaRepo.ObtenerConvocatoria(id);
        }
        public void ActualizarConvocatoria(Convocatorium convocatoria)
        {
            convocatoriaRepo.ActualizarConvocatoria(convocatoria);
        }
        public Convocatorium ObtenerConvocatoriaSegunNombre(string nom)
        {
            return convocatoriaRepo.ObtenerConvocatoriaSegunNombre(nom);
        }
        public IEnumerable<pr01ResultSet0> ListarChoiceConvocatorias(int id)
        {
            return convocatoriaRepo.ListarChoiceConvocatorias(id);
        }        
    }
}
