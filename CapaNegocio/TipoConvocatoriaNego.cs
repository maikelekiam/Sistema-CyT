using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class TipoConvocatoriaNego
    {
        TipoConvocatoriaRepo tipoConvocatoriaRepo = new TipoConvocatoriaRepo();

        public void GuardarTipoConvocatoria(TipoConvocatorium tipoConvocatorium)
        {
            tipoConvocatoriaRepo.GuardarTipoConvocatoria(tipoConvocatorium);
        }

        public IEnumerable<TipoConvocatorium> MostrarTipoConvocatorias()
        {
            return tipoConvocatoriaRepo.MostrarTipoConvocatorias();
        }

        

    }

}
