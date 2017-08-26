using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaRepositorio
{
    public class EmpresaRepo
    {
        public IEnumerable<Empresa> MostrarEmpresas()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Empresa> result = modeloDeDominio.Empresas.ToList();
                return result;
            }
        }
        public string TraerEmpresa(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Empresa result = modeloDeDominio.Empresas.Where(c => c.IdEmpresa == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.Nombre;
            }
        }
        public int GuardarEmpresa(Empresa empresa)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(empresa);
                modeloDeDominio.SaveChanges();
                return empresa.IdEmpresa;
            }
        }
        public int TraerEmpresaIdSegunItem(string item)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Empresa result = modeloDeDominio.Empresas.Where(c => c.Nombre == item).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result.IdEmpresa;
            }
        }
        public Empresa ObtenerEmpresa(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Empresa result = modeloDeDominio.Empresas.Where(c => c.IdEmpresa == id).FirstOrDefault();

                modeloDeDominio.CreateDetachedCopy(result);

                return result;
            }
        }

    }
}
