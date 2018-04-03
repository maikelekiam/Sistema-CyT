using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sistema_CyT
{
    public partial class Contenidos : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if ((string)Session["usergrupo"].ToString() == "1")
            {
                PanelProyectos.Visible = true;
            }
            else
            {
                PanelProyectos.Visible = false;
            }
        }




        //RUTINA PARA SUBIR UN EXCEL
        protected void Upload2(object sender, EventArgs e)
        {
            //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileUpload2.SaveAs(csvPath);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[9] { 
            new DataColumn("numeroEspedienteCopade", typeof(string)),
            new DataColumn("idConvocatoria", typeof(int)),            
            new DataColumn("idLocalidad", typeof(int)),
            new DataColumn("titulo", typeof(string)),
            new DataColumn("montoTotalCofecyt", typeof(decimal)),
            new DataColumn("montoSolicitadoCofecyt", typeof(decimal)),
            new DataColumn("montoContraparteCofecyt", typeof(decimal)),
            new DataColumn("observaciones", typeof(string)),
            new DataColumn("fechaPresentacion", typeof(DateTime)),});

            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.  
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    //Execute a loop over the columns.  
                    foreach (string cell in row.Split(';'))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                string codigoCsv = row[0].ToString();

                ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(codigoCsv);

                if (proyectoCofecyt != null)
                {
                    ProyectoCofecyt proy = new ProyectoCofecyt();

                    proy.IdProyectoCofecyt = proyectoCofecytNego.TraerIdSegunCodigo(codigoCsv);

                    proy.NumeroEspedienteCopade = proyectoCofecyt.NumeroEspedienteCopade;
                    proy.IdConvocatoria = proyectoCofecyt.IdConvocatoria;
                    proy.IdLocalidad = proyectoCofecyt.IdLocalidad;
                    proy.Titulo = proyectoCofecyt.Titulo;
                    proy.MontoTotalCofecyt = proyectoCofecyt.MontoTotalCofecyt;
                    proy.MontoSolicitadoCofecyt = proyectoCofecyt.MontoSolicitadoCofecyt;
                    proy.MontoContraparteCofecyt = proyectoCofecyt.MontoContraparteCofecyt;
                    proy.Observaciones = proyectoCofecyt.Observaciones;
                    proy.FechaPresentacion = proyectoCofecyt.FechaPresentacion;

                    proyectoCofecytNego.ActualizarProyectoCofecyt(proy);
                }
                else if (proyectoCofecyt == null)
                {
                    ProyectoCofecyt proy = new ProyectoCofecyt();

                    proy.NumeroEspedienteCopade = row[0].ToString();
                    proy.IdConvocatoria = Convert.ToInt32(row[1].ToString());
                    proy.IdLocalidad = Convert.ToInt32(row[2].ToString());
                    proy.Titulo = row[3].ToString();
                    proy.MontoTotalCofecyt = Convert.ToDecimal(row[4].ToString());
                    proy.MontoSolicitadoCofecyt = Convert.ToDecimal(row[5].ToString());
                    proy.MontoContraparteCofecyt = Convert.ToDecimal(row[6].ToString());
                    proy.Observaciones = row[7].ToString();
                    proy.FechaPresentacion = Convert.ToDateTime(row[8].ToString());

                    proy.Objetivos = null;

                    proyectoCofecytNego.GuardarProyectoCofecyt(proy);
                }
            }
            Response.Redirect("AltaProyectoCofecyt.aspx");
        }

    }
}