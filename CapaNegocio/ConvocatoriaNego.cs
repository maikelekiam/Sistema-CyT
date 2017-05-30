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
    }
}
