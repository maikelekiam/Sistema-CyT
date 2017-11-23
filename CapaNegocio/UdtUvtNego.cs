using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class UdtUvtNego
    {
        UdtUvtRepo udtUvtRepo = new UdtUvtRepo();

        public IEnumerable<UdtUvt> MostrarUdtUvts()
        {
            return udtUvtRepo.MostrarUdtUvts();
        }
        public string TraerUdtUvt(int id)
        {
            return udtUvtRepo.TraerUdtUvt(id);
        }
        public int GuardarUdtUvt(UdtUvt udtUvt)
        {
            return udtUvtRepo.GuardarUdtUvt(udtUvt);
        }
        public UdtUvt ObtenerUdtUvt(int id)
        {
            return udtUvtRepo.ObtenerUdtUvt(id);
        }
        public void ActualizarUdtUvt(UdtUvt udtUvt)
        {
            udtUvtRepo.ActualizarUdtUvt(udtUvt);
        }
        public int TraerUdtUvtIdSegunItem(string item)
        {
            return udtUvtRepo.TraerUdtUvtIdSegunItem(item);
        }
    }
}
