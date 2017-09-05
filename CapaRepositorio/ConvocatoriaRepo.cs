using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using Telerik.OpenAccess.Data.Common;
using System.Data;

namespace CapaRepositorio
{
    public class ConvocatoriaRepo
    {
        public int GuardarConvocatoria(Convocatorium convocatoria)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.Add(convocatoria);
                modeloDeDominio.SaveChanges();
                return convocatoria.IdConvocatoria;
            }
        }
        public IEnumerable<Convocatorium> MostrarConvocatorias()
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                IEnumerable<Convocatorium> result = modeloDeDominio.Convocatoria.OrderByDescending(c => c.Nombre).ToList();
                return result;
            }
        }
        public void ActualizarConvocatoria(Convocatorium convocatoria)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                modeloDeDominio.AttachCopy(convocatoria);
                modeloDeDominio.SaveChanges();
            }
        }

        public Convocatorium ObtenerConvocatoria(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Convocatorium convocatoria = modeloDeDominio.Convocatoria.Where(c => c.IdConvocatoria == id).FirstOrDefault();

                return convocatoria;
            }
        }
        public Convocatorium ObtenerConvocatoriaSegunNombre(string nom)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                Convocatorium convocatoria = modeloDeDominio.Convocatoria.Where(c => c.Nombre == nom).FirstOrDefault();

                return convocatoria;
            }
        }
        public IEnumerable<pr01ResultSet0> ListarChoiceConvocatorias(int id)
        {
            using (ModeloDeDominio modeloDeDominio = new ModeloDeDominio())
            {
                System.Data.Common.DbParameter prParameter = new OAParameter
                {
                    ParameterName = "@id",
                    Value = id
                };

                IEnumerable<pr01ResultSet0> result = modeloDeDominio.ExecuteQuery<pr01ResultSet0>("pr01", CommandType.StoredProcedure, prParameter);

                return result;
            }
        }
    }
}
