#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using CapaDominio;

namespace CapaDominio	
{
	public partial class EtapaCofecyt
	{
		private int idEtapaCofecyt;
		public virtual int IdEtapaCofecyt
		{
			get
			{
				return this.idEtapaCofecyt;
			}
			set
			{
				this.idEtapaCofecyt = value;
			}
		}
		
		private int idProyectoCofecyt;
		public virtual int IdProyectoCofecyt
		{
			get
			{
				return this.idProyectoCofecyt;
			}
			set
			{
				this.idProyectoCofecyt = value;
			}
		}
		
		private string nombre;
		public virtual string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = value;
			}
		}
		
		private DateTime? fechaInicio;
		public virtual DateTime? FechaInicio
		{
			get
			{
				return this.fechaInicio;
			}
			set
			{
				this.fechaInicio = value;
			}
		}
		
		private DateTime? fechaFin;
		public virtual DateTime? FechaFin
		{
			get
			{
				return this.fechaFin;
			}
			set
			{
				this.fechaFin = value;
			}
		}
		
		private bool? rendicion;
		public virtual bool? Rendicion
		{
			get
			{
				return this.rendicion;
			}
			set
			{
				this.rendicion = value;
			}
		}
		
		private bool? informe;
		public virtual bool? Informe
		{
			get
			{
				return this.informe;
			}
			set
			{
				this.informe = value;
			}
		}
		
		private string duracionSegunUvt;
		public virtual string DuracionSegunUvt
		{
			get
			{
				return this.duracionSegunUvt;
			}
			set
			{
				this.duracionSegunUvt = value;
			}
		}
		
		private int idTipoEstadoEtapa;
		public virtual int IdTipoEstadoEtapa
		{
			get
			{
				return this.idTipoEstadoEtapa;
			}
			set
			{
				this.idTipoEstadoEtapa = value;
			}
		}
		
		private ProyectoCofecyt proyectoCofecyt;
		public virtual ProyectoCofecyt ProyectoCofecyt
		{
			get
			{
				return this.proyectoCofecyt;
			}
			set
			{
				this.proyectoCofecyt = value;
			}
		}
		
		private TipoEstadoEtapa tipoEstadoEtapa;
		public virtual TipoEstadoEtapa TipoEstadoEtapa
		{
			get
			{
				return this.tipoEstadoEtapa;
			}
			set
			{
				this.tipoEstadoEtapa = value;
			}
		}
		
		private IList<ActividadCofecyt> actividadCofecyts = new List<ActividadCofecyt>();
		public virtual IList<ActividadCofecyt> ActividadCofecyts
		{
			get
			{
				return this.actividadCofecyts;
			}
		}
		
	}
}
#pragma warning restore 1591