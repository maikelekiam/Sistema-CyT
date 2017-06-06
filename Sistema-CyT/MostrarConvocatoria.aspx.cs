using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class MostrarConvocatoria : System.Web.UI.Page
    {
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private FondoNego fondoNego = new FondoNego();
        private TipoFinanciamientoNego tipoFinanciamientoNego = new TipoFinanciamientoNego();
        private TipoConvocatoriaNego tipoConvocatoriaNego = new TipoConvocatoriaNego();
        private ModalidadNego modalidadNego = new ModalidadNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarConvocatoriaSeleccionada();
        }

        public void MostrarConvocatoriaSeleccionada()
        {
            Convocatorium convocatoria = new Convocatorium();

            convocatoria = convocatoriaNego.ObtenerConvocatoria(ListarConvocatorias.idConvocatoriaSeleccionada);

            //RUTINAS PARA QUE EL TEXTBOX MULTILINE SE AJUSTE AUTOMATICAMENTE
            int contador = 45;
            int c2 = 45;
            int c3 = 45;
            int rows;
            string cadena;
            string cadcom = "qwertyuiopasdfghjklñzxcvbnm1234567890QWERTYUIOPASDFGHJKLÑZXCVBNM.,";

            //NOMBRE
            cadena = convocatoria.Nombre.ToString();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadcom.Contains(cadena.Substring(i, 1))) { contador++; }
                else if (cadena.Substring(i, 1) == " ") { contador++; }
                else if (cadena.Substring(i, 1) == "\n") { contador = contador + 90 - i; }
            }
            rows = contador / 90;
            txtNombre.Rows = rows + 1;
            txtNombre.Text = convocatoria.Nombre.ToString();

            //DESCRIPCION
            cadena = convocatoria.Descripcion.ToString();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadcom.Contains(cadena.Substring(i, 1))) { c2++; }
                else if (cadena.Substring(i, 1) == " ") { c2++; }
                else if (cadena.Substring(i, 1) == "\n") { c2 = c2 + 90 - i; }
            }
            rows = c2 / 90;
            txtDescripcion.Rows = rows + 1;
            txtDescripcion.Text = convocatoria.Descripcion.ToString();

            //OBJETIVO
            cadena = convocatoria.Objetivo.ToString();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadcom.Contains(cadena.Substring(i, 1))) { c3++; }
                else if (cadena.Substring(i, 1) == " ") { c3++; }
                else if (cadena.Substring(i, 1) == "\n") { c3 = c3 + 90 - i; }
            }
            rows = c3 / 90;
            txtObjetivo.Rows = rows + 1;
            txtObjetivo.Text = convocatoria.Objetivo.ToString();

            txtAnio.Text = convocatoria.Anio.ToString();
            txtFondo.Text = Convert.ToString(fondoNego.ObtenerFondoString(Convert.ToInt32(convocatoria.IdFondo)));
            txtTipoConvocatoria.Text = Convert.ToString(tipoConvocatoriaNego.ObtenerTipoConvocatoriaString(Convert.ToInt32(convocatoria.IdTipoConvocatoria)));
            txtTipoFinanciamiento.Text = Convert.ToString(tipoFinanciamientoNego.ObtenerTipoFinanciamientoString(Convert.ToInt32(convocatoria.IdTipoFinanciamiento)));
            txtFechaApertura.Text = Convert.ToDateTime(convocatoria.FechaApertura).ToShortDateString();
            txtFechaCierre.Text = Convert.ToDateTime(convocatoria.FechaCierre).ToShortDateString();

            if (convocatoria.Abierta.Value == true)
            {
                txtAbierta.Text = "ABIERTA";
            }
            else if (convocatoria.Abierta.Value == false)
            {
                txtAbierta.Text = "CERRADA";
            }
        }
    }
}