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
    }
}
