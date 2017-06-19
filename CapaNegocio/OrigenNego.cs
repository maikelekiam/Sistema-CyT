using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaRepositorio;
using CapaDominio;

namespace CapaNegocio
{
    public class OrigenNego
    {
        OrigenRepo origenRepo = new OrigenRepo();

        public int GuardarOrigen(Origen origen)
        {
            return origenRepo.GuardarOrigen(origen);
        }

        public IEnumerable<Origen> MostrarOrigenes()
        {
            return origenRepo.MostrarOrigenes();
        }

        public string TraerOrigenSegunIdFondo(int id)
        {
            return origenRepo.TraerOrigenSegunIdFondo(id);
        }

        public int TraerOrigenIdSegunItem(string item)
        {
            return origenRepo.TraerOrigenIdSegunItem(item);
        }
        public string TraerOrigen(int id)
        {
            return origenRepo.TraerOrigen(id);
        }
    }


}