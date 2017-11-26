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
    public partial class EditarEtapa : System.Web.UI.Page
    {
        EtapaNego etapaNego = new EtapaNego();
        TipoEstadoEtapaNego tipoEstadoEtapaNego = new TipoEstadoEtapaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarListaTipoEstadoEtapas(); // SIRVE PARA EL DROP DOWN LIST
                
                CargarDatosEtapa(EditarProyecto.idEtapaActual);
            }
        }
        //Muestra en el DROPDOWNLIST los Tipos de Estado de la Etapa
        private void LlenarListaTipoEstadoEtapas()
        {
            ddlTipoEstadoEtapa.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapa.DataValueField = "nombre";
            ddlTipoEstadoEtapa.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapa.DataBind();
        }
        private void CargarDatosEtapa(int id)
        {
            Etapa item = etapaNego.ObtenerEtapaSegunId(id);

            txtNombreModal.Text = item.Nombre.ToString();
            ddlTipoEstadoEtapa.Text = Convert.ToString(item.IdTipoEstadoEtapa);
            txtFechaInicioModal.Text = Convert.ToString(item.FechaInicio);
            txtFechaFinalModal.Text = Convert.ToString(item.FechaFin);

            if (item.Rendicion.Value == true)
            {
                chkRendicion.Checked = true;
            }
            else if (item.Rendicion.Value == false)
            {
                chkRendicion.Checked = false;
            }

            if (item.Informe.Value == true)
            {
                chkInforme.Checked = true;
            }
            else if (item.Informe.Value == false)
            {
                chkInforme.Checked = false;
            }

        }

        protected void btnModalSalir_Click(object sender, EventArgs e)
        {

        }

        protected void btnModalActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}