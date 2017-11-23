using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class SectorNego
    {
        SectorRepo sectorRepo = new SectorRepo();

        public IEnumerable<Sector> MostrarSectores()
        {
            return sectorRepo.MostrarSectores();
        }
        public string TraerSector(int id)
        {
            return sectorRepo.TraerSector(id);
        }
        public int GuardarSector(Sector sector)
        {
            return sectorRepo.GuardarSector(sector);
        }
        public int TraerSectorIdSegunItem(string item)
        {
            return sectorRepo.TraerSectorIdSegunItem(item);
        }
    }
}
