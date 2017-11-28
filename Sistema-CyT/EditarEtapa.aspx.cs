using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Globalization;

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

            //****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
            //FECHA INICIO
            string dia = Convert.ToString((item.FechaInicio).Value.Day);
            string mes = Convert.ToString((item.FechaInicio).Value.Month);
            string anio = Convert.ToString((item.FechaInicio).Value.Year);
            string t1 = "";
            string t2 = "";
            if ((item.FechaInicio).Value.Day < 10)
            {
                t1 = "0";
            }
            if ((item.FechaInicio).Value.Month < 10)
            {
                t2 = "0";
            }
            txtFechaInicioModal.Text = t2 + mes + "/" + t1 + dia + "/" + anio;
            //****FIN RUTINA PARA TRABAJAR CON FORMATO FECHA

            //****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
            //FECHA INICIO
            dia = Convert.ToString((item.FechaFin).Value.Day);
            mes = Convert.ToString((item.FechaFin).Value.Month);
            anio = Convert.ToString((item.FechaFin).Value.Year);
            t1 = "";
            t2 = "";
            if ((item.FechaFin).Value.Day < 10)
            {
                t1 = "0";
            }
            if ((item.FechaFin).Value.Month < 10)
            {
                t2 = "0";
            }
            txtFechaFinalModal.Text = t2 + mes + "/" + t1 + dia + "/" + anio;
            //****FIN RUTINA PARA TRABAJAR CON FORMATO FECHA

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

        protected void btnModalActualizar_Click(object sender, EventArgs e)
        {
            Etapa etapa = new Etapa();

            etapa.IdEtapa = EditarProyecto.idEtapaActual;
            etapa.IdProyecto = EditarProyecto.idProyectoActual;

            etapa.Nombre = txtNombreModal.Text;
            etapa.FechaInicio = DateTime.ParseExact(txtFechaInicioModal.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            etapa.FechaFin = DateTime.ParseExact(txtFechaFinalModal.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            etapa.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicion.Checked)
            {
                etapa.Rendicion = true;
            }
            else if (!chkRendicion.Checked)
            {
                etapa.Rendicion = false;
            }

            if (chkInforme.Checked)
            {
                etapa.Informe = true;
            }
            else if (!chkInforme.Checked)
            {
                etapa.Informe = false;
            }

            etapaNego.ActualizarEtapa(etapa);

            Response.Redirect("EditarProyecto.aspx");
        }


        protected void btnModalSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarProyectos.aspx");
        }
    }
}