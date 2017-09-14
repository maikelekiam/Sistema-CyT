using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.Windows.Forms;

namespace Sistema_CyT
{
    public partial class EditarProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        FondoNego fondoNego = new FondoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        ProyectoNego proyectoNego = new ProyectoNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        TipoEstadoEtapaNego tipoEstadoEtapaNego = new TipoEstadoEtapaNego();

        IEnumerable<Proyecto> listaProyectos;

        public static List<Etapa> listaTemporalEtapas = new List<Etapa>();
        public static List<Etapa> listaTemporalEtapasAgregado = new List<Etapa>();
        List<pr02ResultSet0> listaProyectosFiltrados = new List<pr02ResultSet0>();

        public static int idProyectoActual;
        public static int idEtapaActual;
        public static int idEmpresaActual = 0;
        public static int idLocalidadActual = 0;
        public static int idPersonaActual = 0;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idFondoSeleccionado = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarLocalidad(); //SIRVE PARA EL DROP DOWN LIST
            MostrarPersona(); //SIRVE PARA EL DROP DOWN LIST
            MostrarEmpresa(); // SIRVE PARA EL DROP DOWN LIST
            MostrarConvocatoria(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstados(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstadoEtapas(); // SIRVE PARA EL DROP DOWN LIST
            LimpiarFormulario();
            LlenarListaFondoChoice();
        }
        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
        }

        //Muestra en el DROPDOWNLIST los Tipos de Estado de la Etapa
        private void LlenarListaTipoEstadoEtapas()
        {
            ddlTipoEstadoEtapa.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapa.DataValueField = "nombre";
            ddlTipoEstadoEtapa.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapa.DataBind();
        }
        //Muestra en el DROPDOWNLIST los Tipos de Estado
        private void LlenarListaTipoEstados()
        {
            ddlTipoEstado.DataSource = tipoEstadoNego.MostrarTipoEstados().ToList();
            ddlTipoEstado.DataValueField = "nombre";
            ddlTipoEstado.DataBind();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void MostrarConvocatoria()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().OrderBy(c => c.Nombre).ToList();
            ddlConvocatoria.DataValueField = "IdConvocatoria";
            ddlConvocatoria.DataBind();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void MostrarLocalidad()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        //Muestra en el DROPDOWNLIST las EMPRESAS
        private void MostrarEmpresa()
        {
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().OrderBy(c => c.Nombre).ToList();
            ddlEmpresa.DataValueField = "nombre";
            ddlEmpresa.DataBind();
        }

        //Muestra en el DROPDOWNLIST las PERSONAS
        private void MostrarPersona()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "nombre";
            ddlContacto.DataBind();
        }

        protected void ddlProyectoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaTemporalEtapas.Clear();
            listaTemporalEtapasAgregado.Clear();

            idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue.ToString());

            Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

            if (proyecto == null)
            {
                LimpiarFormulario();
                return;
            }

            txtNombre.Text = proyecto.Nombre.ToString();
            txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
            ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
            txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
            txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
            txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);

            ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

            if (proyecto.IdEmpresa == null)
            {
                ddlEmpresa.Text = "-1";
            }
            else
            {
                ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value);
            }

            ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
            ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);

            //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
            listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;
            dgvEtapas.Columns[3].Visible = true;
            dgvEtapas.Columns[4].Visible = true;
            dgvEtapas.Columns[5].Visible = true;
            dgvEtapas.Columns[6].Visible = true;

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
            dgvEtapas.Columns[1].Visible = false;

            LlenarGrillaEtapas(); //no borrar esta linea!!!
        }

        private void LlenarGrillaEtapas()
        {
            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;
            dgvEtapas.Columns[3].Visible = true;
            dgvEtapas.Columns[4].Visible = true;
            dgvEtapas.Columns[5].Visible = true;
            dgvEtapas.Columns[6].Visible = true;

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
            dgvEtapas.Columns[1].Visible = false;
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
            MostrarPersona();
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }

        protected void btnModalEmpresaGuardar_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();

            empresa.Nombre = txtEmpresaModal.Text;

            idEmpresaActual = empresaNego.GuardarEmpresa(empresa);

            ddlEmpresa.Items.Clear();
            ddlEmpresa.Text = TraerEmpresa(idEmpresaActual);
            MostrarEmpresa();
        }

        private string TraerEmpresa(int id)
        {
            return empresaNego.TraerEmpresa(id);
        }

        protected void btnModalLocalidadGuardar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad();

            localidad.Nombre = txtLocalidadNombreModal.Text;
            localidad.CodigoPostal = txtLocalidadCodigoPostalModal.Text;

            idLocalidadActual = localidadNego.GuardarLocalidad(localidad);

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Text = TraerLocalidad(idLocalidadActual);
            MostrarLocalidad();
        }
        private string TraerLocalidad(int id)
        {
            return localidadNego.TraerLocalidad(id);
        }

        protected void btnModalEtapaGuardar_Click(object sender, EventArgs e)
        {
            Etapa item = new Etapa();

            item.IdProyecto = idProyectoActual;

            item.Nombre = txtNombreModal.Text;
            item.FechaInicio = DateTime.ParseExact(txtFechaInicioModal.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            item.FechaFin = DateTime.ParseExact(txtFechaFinalModal.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            item.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicion.Checked)
            {
                item.Rendicion = true;
            }
            else if (!chkRendicion.Checked)
            {
                item.Rendicion = false;
            }

            if (chkInforme.Checked)
            {
                item.Informe = true;
            }
            else if (!chkInforme.Checked)
            {
                item.Informe = false;
            }


            txtNombreModal.Text = null;
            txtFechaInicioModal.Text = null;
            txtFechaFinalModal.Text = null;
            chkInforme.Text = null;
            chkRendicion.Text = null;
            ddlTipoEstadoEtapa.Text = null;

            listaTemporalEtapasAgregado.Add(item);
            listaTemporalEtapas.Add(item);

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();
        }

        protected void btnActualizarProyecto_Click(object sender, EventArgs e)
        {
            ActualizarProyecto();
            ListarProyectos.numeroExpedienteProyectoSeleccionado = txtNumeroExp.Text;
            ListarProyectos.idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.Text);
            LimpiarFormulario();

            LlenarGrillaEtapas();

            listaTemporalEtapas.Clear();
            listaTemporalEtapasAgregado.Clear();

            Response.Redirect("MostrarProyecto.aspx");
        }

        private void ActualizarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            proyecto.IdProyecto = idProyectoActual;

            proyecto.Nombre = txtNombre.Text;
            proyecto.NumeroExpediente = txtNumeroExp.Text;
            proyecto.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);
            proyecto.MontoSolicitado = Convert.ToDecimal(txtMontoSolicitado.Text);
            proyecto.MontoContraparte = Convert.ToDecimal(txtMontoContraparte.Text);
            proyecto.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text);

            string cadena = ddlContacto.SelectedItem.ToString();
            string[] separadas;
            separadas = cadena.Split(',');
            string itemApellido = separadas[0];
            string itemNombre = separadas[1];

            proyecto.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);

            if (ddlEmpresa.SelectedValue == "-1")
            {
                proyecto.IdEmpresa = null;
            }
            else
            {
                proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString());
            }

            //proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString());
            proyecto.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            proyecto.IdTipoEstado = tipoEstadoNego.TraerTipoEstadoIdSegunItem(ddlTipoEstado.SelectedItem.ToString());

            proyectoNego.ActualizarProyecto(proyecto);

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO ACTUAL
            foreach (Etapa item in listaTemporalEtapas)
            {
                Etapa etapa = new Etapa();

                etapa.IdEtapa = item.IdEtapa;
                etapa.IdProyecto = idProyectoActual;
                etapa.Nombre = item.Nombre.ToString();
                etapa.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString());
                etapa.FechaFin = Convert.ToDateTime(item.FechaFin.ToString());
                etapa.IdTipoEstadoEtapa = item.IdTipoEstadoEtapa;

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
            }

            //LimpiarFormulario();
        }

        
        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtNumeroExp.Text = null;
            ddlConvocatoria.SelectedIndex = 0;
            txtMontoSolicitado.Text = null;
            txtMontoContraparte.Text = null;
            txtMontoTotal.Text = null;
            ddlContacto.SelectedIndex = 0;
            ddlEmpresa.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlTipoEstado.SelectedIndex = 0;
        }

        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFormulario();

            if (ddlFondoChoice.SelectedValue != "-1")
            {
                idFondoSeleccionado = Convert.ToInt32(ddlFondoChoice.SelectedValue);

                LlenarChoiceConvocatorias(idFondoSeleccionado);
            }
            else
            {
                Response.Redirect("EditarProyecto.aspx");
            }
        }

        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoriaChoice.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id);
            ddlConvocatoriaChoice.DataTextField = "nombre";
            ddlConvocatoriaChoice.DataValueField = "idConvocatoria";
            ddlConvocatoriaChoice.DataBind();

            if (ddlConvocatoriaChoice.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue);

                ddlProyectoChoice.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                ddlProyectoChoice.DataTextField = "nombre";
                ddlProyectoChoice.DataValueField = "idProyecto";
                ddlProyectoChoice.DataBind();

                //aca habria que cargar el 1er proyecto filtrado automaticamente
                listaTemporalEtapas.Clear();
                listaTemporalEtapasAgregado.Clear();

                //1ro hay que averiguar si existe al menos 1 proyecto o la lista viene vacia
                if (ddlProyectoChoice.SelectedValue != "")
                {
                    idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                    Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                    if (proyecto == null)
                    {
                        LimpiarFormulario();
                        return;
                    }

                    txtNombre.Text = proyecto.Nombre.ToString();
                    txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
                    ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                    txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                    txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                    txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);

                    ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

                    if (proyecto.IdEmpresa == null)
                    {
                        ddlEmpresa.Text = "-1";
                    }
                    else
                    {
                        ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value);
                    }

                    ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
                    ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);

                    //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                    listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

                    dgvEtapas.Columns[0].Visible = true;
                    dgvEtapas.Columns[1].Visible = true;
                    dgvEtapas.Columns[2].Visible = true;
                    dgvEtapas.Columns[3].Visible = true;
                    dgvEtapas.Columns[4].Visible = true;
                    dgvEtapas.Columns[5].Visible = true;
                    dgvEtapas.Columns[6].Visible = true;

                    dgvEtapas.DataSource = listaTemporalEtapas;
                    dgvEtapas.DataBind();

                    dgvEtapas.Columns[0].Visible = false;
                    dgvEtapas.Columns[1].Visible = false;

                    LlenarGrillaEtapas(); //no borrar esta linea!!!

                    //fin rutina para cargar el 1er proyecto
                }
                else
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                ddlProyectoChoice.DataSource = listaProyectosFiltrados.ToList();
                ddlProyectoChoice.DataBind();
            }
        }

        protected void ddlConvocatoriaChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue.ToString());

            ddlProyectoChoice.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
            ddlProyectoChoice.DataBind();

            //aca habria que cargar el 1er proyecto
            if (ddlProyectoChoice.SelectedValue != "")
            {
                idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                if (proyecto == null)
                {
                    LimpiarFormulario();
                    return;
                }

                txtNombre.Text = proyecto.Nombre.ToString();
                txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
                ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);

                ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

                if (proyecto.IdEmpresa == null)
                {
                    ddlEmpresa.Text = "-1";
                }
                else
                {
                    ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value);
                }

                ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
                ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);

                //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

                dgvEtapas.Columns[0].Visible = true;
                dgvEtapas.Columns[1].Visible = true;
                dgvEtapas.Columns[2].Visible = true;
                dgvEtapas.Columns[3].Visible = true;
                dgvEtapas.Columns[4].Visible = true;
                dgvEtapas.Columns[5].Visible = true;
                dgvEtapas.Columns[6].Visible = true;

                dgvEtapas.DataSource = listaTemporalEtapas;
                dgvEtapas.DataBind();

                dgvEtapas.Columns[0].Visible = false;
                dgvEtapas.Columns[1].Visible = false;

                LlenarGrillaEtapas(); //no borrar esta linea!!!

                //fin rutina para cargar el 1er proyecto
            }
            else
            {
                LimpiarFormulario();
            }
        }
        protected void dgvEtapas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //falta implementar...
        }
    }
}