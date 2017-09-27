using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;
using System.Globalization;

namespace Sistema_CyT
{
    public partial class Actuaciones : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ActuacionNego actuacionNego = new ActuacionNego();
        OrganismoNego organismoNego = new OrganismoNego();
        ViaComunicacionNego viaComunicacionNego = new ViaComunicacionNego();
        PersonaNego personaNego = new PersonaNego();

        public static int idActuacionActual;
        public static int idOrganismoActual;
        public static int idViaComunicacionActual; // = 0;
        public static int idPersonaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarProyecto(FiltrarProyecto.idProyectoSeleccionado);
            MostrarOrganismo();
            PanelNuevaActuacion.Visible = false;
            MostrarViaComunicacion(); //SIRVE PARA CARGAR DATOS EN EL DROPDOWNLIST
            LlenarListaPersonas(); //SIRVE PARA EL DROP DOWN LIST

            MostrarPersonaActual(); //MUESTRA EL CONTACTO DEL PROYECTO

            LlenarGrillaActuaciones();
            LimpiarPantalla();
        }

        private void MostrarPersonaActual()
        {
            Proyecto proyecto = proyectoNego.ObtenerProyecto(FiltrarProyecto.idProyectoSeleccionado);

            ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);
        }
        private void LlenarListaPersonas()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().OrderBy(c => c.Nombre).ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "nombre";
            ddlContacto.DataBind();
        }
        protected void ddlContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPersonaActual = ddlContacto.SelectedIndex;
        }

        //Muestro en el DROPDOWNLIST los ORGANISMOS
        private void MostrarOrganismo()
        {
            ddlOrganismo.DataSource = organismoNego.MostrarOrganismos().ToList();
            ddlOrganismo.DataValueField = "nombre";
            ddlOrganismo.DataBind();
        }

        private void MostrarProyecto(int id)
        {
            Proyecto proyecto = proyectoNego.ObtenerProyecto(id);

            lblProyecto.Text = proyecto.Nombre.ToString().ToUpper();
        }

        protected void btnAgregarActuacion_Click(object sender, EventArgs e)
        {
            btnActualizarActuacion.Visible = false;
            btnGuardarActuacion.Visible = true;
            LimpiarPantalla();

            if (PanelNuevaActuacion.Visible == true)
            {
                PanelNuevaActuacion.Visible = false;
            }
            else if (PanelNuevaActuacion.Visible == false)
            {
                PanelNuevaActuacion.Visible = true;
                btnAgregarActuacion.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelNuevaActuacion.Visible = false;
            btnAgregarActuacion.Visible = true;
            PanelActuacion.Visible = true;
        }

        protected void btnGuardarActuacion_Click(object sender, EventArgs e)
        {
            if (ddlViaComunicacion.SelectedValue != "-1" && ddlContacto.SelectedValue != "-1" && txtFechaActuacion.Text!="") //agregar tambien para la fecha que no sea vacia o null
            {
                PanelNuevaActuacion.Visible = false;
                btnAgregarActuacion.Visible = true;
                btnActualizarActuacion.Visible = false;

                GuardarActuacion();
                LimpiarPantalla();
            }
            else
            {
                //FALTA IMPLEMENTAR
            }
        }

        private void GuardarActuacion()
        {
            Actuacion actuacion = new Actuacion();

            actuacion.IdProyecto = FiltrarProyecto.idProyectoSeleccionado;
            actuacion.Fecha = DateTime.ParseExact(txtFechaActuacion.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            actuacion.Detalle = txtDetalle.Text;
            //actuacion.IdOrganismo = organismoNego.TraerOrganismoIdSegunItem(ddlOrganismo.SelectedItem.ToString());
            actuacion.IdViaComunicacion = viaComunicacionNego.TraerViaComunicacionIdSegunItem(ddlViaComunicacion.SelectedItem.ToString());
            //actuacion.IdPersona = proyectoNego.ObtenerProyecto(FiltrarProyecto.idProyectoSeleccionado).IdPersona;

            string cadena = ddlContacto.SelectedItem.ToString();
            string[] separadas;
            separadas = cadena.Split(',');
            string itemApellido = separadas[0];
            string itemNombre = separadas[1];

            actuacion.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);

            if (ddlOrganismo.SelectedValue == "-1")
            {
                actuacion.IdOrganismo = null;
            }
            else
            {
                actuacion.IdOrganismo = organismoNego.TraerOrganismoIdSegunItem(ddlOrganismo.SelectedItem.ToString());
            }

            idActuacionActual = actuacionNego.GuardarActuacion(actuacion);

            LlenarGrillaActuaciones();
        }

        private void LlenarGrillaActuaciones()
        {
            dgvActuaciones.Columns[0].Visible = true;
            dgvActuaciones.Columns[1].Visible = true;
            dgvActuaciones.Columns[2].Visible = true;
            dgvActuaciones.Columns[3].Visible = true;
            dgvActuaciones.Columns[4].Visible = true;
            dgvActuaciones.Columns[5].Visible = true;

            dgvActuaciones.DataSource = actuacionNego.MostrarActuacionSegunProyecto(FiltrarProyecto.idProyectoSeleccionado).ToList();
            dgvActuaciones.DataBind();

            dgvActuaciones.Columns[0].Visible = false;
            dgvActuaciones.Columns[1].Visible = false;
        }

        protected void btnModalOrganismoGuardar_Click(object sender, EventArgs e)
        {
            if (txtOrganismoNombreModal.Text == "") return;

            Organismo organismo = new Organismo();

            organismo.Nombre = txtOrganismoNombreModal.Text;
            organismo.Telefono = txtOrganismoTelefonoModal.Text;
            organismo.CorreoElectronico = txtOrganismoCorreoElectronicoModal.Text;

            idOrganismoActual = organismoNego.GuardarOrganismo(organismo);

            ddlOrganismo.Items.Clear();
            ddlOrganismo.Text = TraerOrganismo(idOrganismoActual);
            MostrarOrganismo();
        }
        private string TraerOrganismo(int id)
        {
            return organismoNego.TraerOrganismo(id);
        }

        protected void dgvActuaciones_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnGuardarActuacion.Visible = false;
            btnActualizarActuacion.Visible = true;
            PanelNuevaActuacion.Visible = true;
            PanelActuacion.Visible = false;

            GridViewRow row = dgvActuaciones.Rows[e.NewSelectedIndex];

            idActuacionActual = Convert.ToInt32(row.Cells[0].Text);

            Actuacion actuacion = actuacionNego.ObtenerActuacion(idActuacionActual);

            //****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
            //FECHA APERTURA
            string dia = Convert.ToString((actuacion.Fecha).Value.Day);
            string mes = Convert.ToString((actuacion.Fecha).Value.Month);
            string anio = Convert.ToString((actuacion.Fecha).Value.Year);
            string t1 = "";
            string t2 = "";
            if ((actuacion.Fecha).Value.Day < 10)
            {
                t1 = "0";
            }
            if ((actuacion.Fecha).Value.Month < 10)
            {
                t2 = "0";
            }
            txtFechaActuacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;
            //****FIN RUTINA PARA TRABAJAR CON FORMATO FECHA

            txtDetalle.Text = actuacion.Detalle.ToString();
            ddlContacto.Text = personaNego.TraerPersona(actuacion.IdPersona.Value);

            if (actuacion.IdOrganismo == null)
            {
                ddlOrganismo.Text = "-1";
            }
            else
            {
                ddlOrganismo.Text = organismoNego.TraerOrganismo(Convert.ToInt32(actuacion.IdOrganismo));
            }

            ddlViaComunicacion.Text = viaComunicacionNego.TraerViaComunicacion(Convert.ToInt32(actuacion.IdViaComunicacion));
        }

        protected void btnActualizarActuacion_Click(object sender, EventArgs e)
        {
            if (
                ddlViaComunicacion.SelectedValue != "-1"
                && ddlContacto.SelectedValue != "-1"
                && txtFechaActuacion.Text != ""
                )
            {
                Actuacion actuacion = new Actuacion();

                actuacion.IdProyecto = FiltrarProyecto.idProyectoSeleccionado;
                actuacion.Fecha = DateTime.ParseExact(txtFechaActuacion.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                actuacion.Detalle = txtDetalle.Text;
                actuacion.IdViaComunicacion = viaComunicacionNego.TraerViaComunicacionIdSegunItem(ddlViaComunicacion.SelectedItem.ToString());

                string cadena = ddlContacto.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];

                actuacion.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);


                if (ddlOrganismo.SelectedValue == "-1")
                {
                    actuacion.IdOrganismo = null;
                }
                else
                {
                    actuacion.IdOrganismo = organismoNego.TraerOrganismoIdSegunItem(ddlOrganismo.SelectedItem.ToString());
                }

                actuacion.IdActuacion = idActuacionActual;

                actuacionNego.ActualizarActuacion(actuacion);

                LlenarGrillaActuaciones();

                PanelNuevaActuacion.Visible = false;
                PanelActuacion.Visible = true;

                btnActualizarActuacion.Visible = false;
                LimpiarPantalla();
            }
            else
            {
                // Mostrar aviso de completar todos los datos
            }
        }

        private void LimpiarPantalla()
        {
            ddlOrganismo.SelectedIndex = 0;
            txtFechaActuacion.Text = null;
            txtDetalle.Text = null;
        }

        protected void btnModalViaComunicacionGuardar_Click(object sender, EventArgs e)
        {
            ViaComunicacion viaComunicacion = new ViaComunicacion();

            viaComunicacion.Nombre = txtViaComunicacionModal.Text;

            idViaComunicacionActual = viaComunicacionNego.GuardarViaComunicacion(viaComunicacion);

            ddlViaComunicacion.Items.Clear();
            ddlViaComunicacion.Text = TraerViaComunicacion(idViaComunicacionActual);
            MostrarViaComunicacion();
        }
        //Muestro en el DROPDOWNLIST las VIAS DE COMUNICACION
        private void MostrarViaComunicacion()
        {
            ddlViaComunicacion.DataSource = viaComunicacionNego.MostrarViaComunicacion().ToList();
            ddlViaComunicacion.DataValueField = "nombre";
            ddlViaComunicacion.DataBind();
        }
        private string TraerViaComunicacion(int id)
        {
            return viaComunicacionNego.TraerViaComunicacion(id);
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Persona persona = personaNego.ObtenerPersona(idPersonaActual);

            txtDetalleContactoNombreModal.Text = persona.Nombre.ToString();
            txtDetalleContactoApellidoModal.Text = persona.Apellido.ToString();
            txtDetalleContactoTelefonoModal.Text = persona.Telefono.ToString();
            txtDetalleContactoCorreoElectronicoModal.Text = persona.CorreoElectronico.ToString();
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }
        protected void btnModalContactoGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();

            persona.Nombre = txtContactoNombreModal.Text;
            persona.Apellido = txtContactoApellidoModal.Text;
            persona.Telefono = txtContactoTelefonoModal.Text;
            persona.CorreoElectronico = txtContactoCorreoElectronicoModal.Text;

            idPersonaActual = personaNego.GuardarPersona(persona);

            ddlContacto.Items.Clear();
            ddlContacto.Text = TraerPersona(idPersonaActual);

            LlenarListaPersonas();
        }
    }
}