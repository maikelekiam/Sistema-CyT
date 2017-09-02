﻿using System;
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
    public partial class ListarProyectos : System.Web.UI.Page
    {
        private ProyectoNego proyectoNego = new ProyectoNego();
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        private FondoNego fondoNego = new FondoNego();

        private List<pr02ResultSet0> listaProyectosFiltrados = new List<pr02ResultSet0>();
        private List<pr02ResultSet0> listaChoiceProyectos = new List<pr02ResultSet0>();

        public static int idProyectoSeleccionado = 1;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idEstadoSeleccionado = 1;
        public static string numeroExpedienteProyectoSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarListaEstados();
            LlenarListaFondoChoice();
        }
        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
        }
        private void LlenarListaEstados()
        {
            ddlEstado.DataSource = tipoEstadoNego.MostrarTipoEstados().ToList();
            ddlEstado.DataValueField = "idTipoEstado";
            ddlEstado.DataBind();
        }
        private void LlenarListaConvocatorias()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().ToList();
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(ddlEstado.SelectedValue) != -1) && (ddlConvocatoria.SelectedValue != "-1") && (ddlConvocatoria.SelectedValue != ""))
            {
                idEstadoSeleccionado = tipoEstadoNego.ObtenerTipoEstadoSegunNombre(ddlEstado.SelectedItem.ToString()).IdTipoEstado;

                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                dgvProyectos.Columns[0].Visible = true;
                dgvProyectos.Columns[1].Visible = true;
                dgvProyectos.Columns[2].Visible = true;
                dgvProyectos.Columns[3].Visible = true;
                dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).Where(c => c.tipoEstado == ddlEstado.SelectedItem.ToString()).ToList();
                dgvProyectos.DataBind();

                //dgvProyectos.Columns[0].Visible = false;
            }
        }

        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFondoChoice.SelectedValue != "-1")
            {
                LlenarChoiceConvocatorias(Convert.ToInt32(ddlFondoChoice.SelectedValue));
            }
            else
            {
                Response.Redirect("ListarProyectos.aspx");
            }
        }
        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoria.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id);
            ddlConvocatoria.DataTextField = "nombre";
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();

            if (ddlConvocatoria.SelectedValue != "-1" && ddlConvocatoria.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                dgvProyectos.DataBind();
                //dgvProyectos.Columns[0].Visible = false;
            }
            else
            {
                dgvProyectos.DataSource = listaProyectosFiltrados.ToList();
                dgvProyectos.DataBind();
                //dgvProyectos.Columns[0].Visible = false;
            }
        }

        protected void ddlConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

            dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
            dgvProyectos.DataBind();
            //dgvProyectos.Columns[0].Visible = false;
        }

        protected void dgvProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.dgvProyectos.SelectedRow;

            numeroExpedienteProyectoSeleccionado = row.Cells[0].Text;

            Response.Redirect("MostrarProyecto.aspx");
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            if (ddlConvocatoria.SelectedValue != "-1" && ddlConvocatoria.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                dgvProyectos.Columns[0].Visible = true;
                dgvProyectos.Columns[1].Visible = true;
                dgvProyectos.Columns[2].Visible = true;
                dgvProyectos.Columns[3].Visible = true;
                dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                dgvProyectos.DataBind();

                //dgvProyectos.Columns[0].Visible = false;
            }
            ddlEstado.Text = "-1";
        }
    }
}