using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;

namespace Sistema_CyT
{
    public partial class MostrarFondo : System.Web.UI.Page
    {
        FondoNego fondoNego = new FondoNego();
        OrigenNego origenNego = new OrigenNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();

        private static List<Convocatorium> listaConvocatoriasFiltradas = new List<Convocatorium>();

        public static int idFondoActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarFondoSeleccionado();
        }

        public void MostrarFondoSeleccionado()
        {
            Fondo fondo = new Fondo();

            fondo = fondoNego.ObtenerFondo(ListarFondos.idFondoSeleccionado);

            idFondoActual = ListarFondos.idFondoSeleccionado;

            txtNombre.Text = fondo.Nombre;
            txtDescripcion.Text = fondo.Descripcion;
            txtOrigen.Text = origenNego.TraerOrigenSegunIdFondo(Convert.ToInt32(fondo.IdOrigen));
            txtTelefono.Text = fondo.Telefono;
            txtDireccion.Text = fondo.Direccion;
            txtContacto.Text = fondo.Contacto;

            MostrarListaConvocatorias();
        }
        public void MostrarListaConvocatorias()
        {
            listaConvocatoriasFiltradas = convocatoriaNego.MostrarConvocatorias().OrderByDescending(c => c.Anio).Where(c => c.IdFondo == idFondoActual).ToList();

            dgvConvocatoria.DataSource = listaConvocatoriasFiltradas;
            dgvConvocatoria.DataBind();

        }
    }
}