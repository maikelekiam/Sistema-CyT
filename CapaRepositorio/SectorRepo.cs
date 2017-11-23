using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class SectorRepo
    {
        public IEnumerable<Sector> MostrarSectores()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Sector> result = modeloDeDominio.Sectors.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }
        public string TraerSector(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Sector result = modeloDeDominio.Sectors.Where(c => c.IdSector == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public int GuardarSector(Sector sector)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(sector);
                modeloDeDominio.SaveChanges();
                return sector.IdSector;
            }
        }
        public int TraerSectorIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Sector result = modeloDeDominio.Sectors.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdSector;
            }
        }
    }
}
