using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;


namespace CapaRepositorio
{
    public class OrigenRepo
    {
        public int GuardarOrigen(Origen origen)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(origen);
                modeloDeDominio.SaveChanges();
                return origen.IdOrigen;
            }            
        }

        public IEnumerable<Origen> MostrarOrigenes()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Origen> result = modeloDeDominio.Origens.ToList();
                return modeloDeDominio.CreateDetachedCopy(result);
            }
        }

        public string TraerOrigenSegunIdFondo(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Origen result = modeloDeDominio.Origens.Where(c => c.IdOrigen == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);
                return result.Nombre;
            }
        }

        public int TraerOrigenIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Origen result = modeloDeDominio.Origens.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdOrigen;
            }
        }
        public string TraerOrigen(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Origen result = modeloDeDominio.Origens.Where(c => c.IdOrigen == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
    }
}
