﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_CyT
{
    public partial class EditarConvocatoria : System.Web.UI.Page
    {
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private FondoNego fondoNego = new FondoNego();
        private TipoFinanciamientoNego tipoFinanciamientoNego = new TipoFinanciamientoNego();
        private TipoConvocatoriaNego tipoConvocatoriaNego = new TipoConvocatoriaNego();
        private ModalidadNego modalidadNego = new ModalidadNego();
        private ListaConvocatoriaModalidadNego listaConvocatoriaModalidadNego = new ListaConvocatoriaModalidadNego();
        IEnumerable<Convocatorium> listaConvocatorias;
        static int id;
        static List<Modalidad> listaConvocatoriaModalidades = new List<Modalidad>();
        static IEnumerable<ListaConvocatoriaModalidad> lista = new List<ListaConvocatoriaModalidad>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListaConvocatorias();
                LlenarListaFondos();
                LlenarListaTipofinanciamiento();
                LlenarListaTipoConvocatoria();
                LlenarGrillaModalidades();
            }
        }

        private void CargarListaConvocatorias()
        {
            //DESPUES IMPLEMENTAR UN DROPDOWN ANIDADO ENTE FONDO-CONVOCATORIA
            
            listaConvocatorias = convocatoriaNego.MostrarConvocatorias();

            ddlActualizarConvocatoria.DataSource = listaConvocatorias.ToList();
            ddlActualizarConvocatoria.DataTextField = "nombre";
            ddlActualizarConvocatoria.DataValueField = "idConvocatoria";
            ddlActualizarConvocatoria.DataBind();
        }
        private void LlenarListaFondos()
        {
            ddlFondo.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondo.DataValueField = "idFondo";
            ddlFondo.DataBind();
        }
        private void LlenarListaTipofinanciamiento()
        {
            ddlTipoFinanciamiento.DataSource = tipoFinanciamientoNego.MostrarTipoFinanciamientoes().ToList();
            ddlTipoFinanciamiento.DataValueField = "idTipoFinanciamiento";
            ddlTipoFinanciamiento.DataBind();
        }
        private void LlenarListaTipoConvocatoria()
        {
            ddlTipoConvocatoria.DataSource = tipoConvocatoriaNego.MostrarTipoConvocatorias().ToList();
            ddlTipoConvocatoria.DataValueField = "idTipoConvocatoria";
            ddlTipoConvocatoria.DataBind();
        }

        private void LlenarGrillaModalidades()
        {
            dgvModalidades.Columns[0].Visible = true;
            dgvModalidades.DataSource = listaConvocatoriaModalidades;
            dgvModalidades.DataBind();
            dgvModalidades.Columns[0].Visible = false;
        }

        protected void btnActualizarConvocatoria_Click(object sender, EventArgs e)
        {
            ActualizarConvocatoria();
        }

        private void ActualizarConvocatoria()
        {
            Convocatorium convocatoria = new Convocatorium();

            convocatoria.IdConvocatoria = id;

            convocatoria.Nombre = txtNombre.Text;
            convocatoria.Descripcion = txtDescripcion.Text;
            convocatoria.Objetivo = txtObjetivo.Text;
            convocatoria.Anio = Int32.Parse(txtAnio.Text);
            convocatoria.IdFondo = Int32.Parse(ddlFondo.SelectedValue);
            convocatoria.IdTipoFinanciamiento = Int32.Parse(ddlTipoFinanciamiento.SelectedValue);
            convocatoria.IdTipoConvocatoria = Int32.Parse(ddlTipoConvocatoria.SelectedValue);
            convocatoria.FechaApertura = Convert.ToDateTime(txtFechaApertura.Text);
            convocatoria.FechaCierre = Convert.ToDateTime(txtFechaCierre.Text);

            if (chkAbierta.Checked)
            {
                convocatoria.Abierta = true;
            }
            else if (!chkAbierta.Checked)
            {
                convocatoria.Abierta = false;
            }

            convocatoriaNego.ActualizarConvocatoria(convocatoria);
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtDescripcion.Text = null;
            txtObjetivo.Text = null;
            txtAnio.Text = null;
            ddlFondo.SelectedIndex = 0;
            ddlTipoConvocatoria.SelectedIndex = 0;
            ddlTipoFinanciamiento.SelectedIndex = 0;
            txtFechaApertura.Text = null;
            txtFechaCierre.Text = null;
            chkAbierta.Checked = false;
            listaConvocatoriaModalidades.Clear();
            LlenarGrillaModalidades();            
        }

        protected void ddlActualizarConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaConvocatoriaModalidades.Clear();
            LlenarGrillaModalidades();
            
            id = Convert.ToInt32(ddlActualizarConvocatoria.SelectedValue.ToString());

            Convocatorium convocatoria = convocatoriaNego.ObtenerConvocatoria(id);

            if (convocatoria == null)
            {
                LimpiarFormulario();
                return;
            }

            txtNombre.Text = convocatoria.Nombre.ToString();
            txtDescripcion.Text = convocatoria.Descripcion.ToString();
            txtObjetivo.Text = convocatoria.Objetivo.ToString();
            txtAnio.Text = convocatoria.Anio.ToString();
            ddlFondo.Text = Convert.ToString(convocatoria.IdFondo);
            ddlTipoConvocatoria.Text = Convert.ToString(convocatoria.IdTipoConvocatoria);
            ddlTipoFinanciamiento.Text = Convert.ToString(convocatoria.IdTipoFinanciamiento);
            txtFechaApertura.Text = Convert.ToDateTime(convocatoria.FechaApertura).ToShortDateString();
            txtFechaCierre.Text = Convert.ToDateTime(convocatoria.FechaCierre).ToShortDateString();

            if (convocatoria.Abierta.Value == true)
            {
                chkAbierta.Checked = true;
            }
            else if (convocatoria.Abierta.Value == false)
            {
                chkAbierta.Checked = false;
            }

            //AHORA TENGO QUE TRAER UNA LISTA DE MODALIDADES SEGUN EL IdConvocatoriaActual
            lista=listaConvocatoriaModalidadNego.TraerModalidadSegunConvocatoria(id);
            dgvCM.DataSource = listaConvocatoriaModalidadNego.TraerModalidadSegunConvocatoria(id);
            dgvCM.DataBind();
            //DESPUES QUITAR ESTO DE ARRIBA

            foreach (ListaConvocatoriaModalidad lcm in lista)
            {
                Modalidad modalidad = modalidadNego.ObtenerModalidadSegunId(lcm.IdModalidad);

                listaConvocatoriaModalidades.Add(modalidad);
            }

            LlenarGrillaModalidades();
            


        }

        protected void dgvModalidades_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvModalidades.Rows[e.NewSelectedIndex];

            string id01 = row.Cells[0].Text;

            lblNombre.Text = Convert.ToString(id01);
        }
    }
}