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
        public string TraerEmpresa(int id)
        {
            return empresaRepo.TraerEmpresa(id);
        }
        public int GuardarEmpresa(Empresa empresa)
        {
            return empresaRepo.GuardarEmpresa(empresa);
        }
        public int TraerEmpresaIdSegunItem(string item)
        {
            return empresaRepo.TraerEmpresaIdSegunItem(item);
        }
        public Empresa ObtenerEmpresa(int id)
        {
            return empresaRepo.ObtenerEmpresa(id);
        }
        public void ActualizarEmpresa(Empresa empresa)
        {
            empresaRepo.ActualizarEmpresa(empresa);
        }
    }
}
