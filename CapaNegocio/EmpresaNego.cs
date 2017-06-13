using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaRepositorio;

namespace CapaNegocio
{
    public class EmpresaNego
    {
        EmpresaRepo empresaRepo= new EmpresaRepo();

        public IEnumerable<Empresa> MostrarEmpresas()
        {
            return empresaRepo.MostrarEmpresas();
        }
    }
}
