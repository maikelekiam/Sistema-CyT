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
	public partial class ActuacionProyectoCofecyt
	{
		private int idActuacionProyectoCofecyt;
		public virtual int IdActuacionProyectoCofecyt
		{
			get
			{
				return this.idActuacionProyectoCofecyt;
			}
			set
			{
				this.idActuacionProyectoCofecyt = value;
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
		
		private DateTime? fechaActuacion;
		public virtual DateTime? FechaActuacion
		{
			get
			{
				return this.fechaActuacion;
			}
			set
			{
				this.fechaActuacion = value;
			}
		}
		
		private string detalle;
		public virtual string Detalle
		{
			get
			{
				return this.detalle;
			}
			set
			{
				this.detalle = value;
			}
		}
		
		private string pendiente;
		public virtual string Pendiente
		{
			get
			{
				return this.pendiente;
			}
			set
			{
				this.pendiente = value;
			}
		}
		
		private string responsable;
		public virtual string Responsable
		{
			get
			{
				return this.responsable;
			}
			set
			{
				this.responsable = value;
			}
		}
		
		private string agente;
		public virtual string Agente
		{
			get
			{
				return this.agente;
			}
			set
			{
				this.agente = value;
			}
		}
		
		private DateTime? fechaLimite;
		public virtual DateTime? FechaLimite
		{
			get
			{
				return this.fechaLimite;
			}
			set
			{
				this.fechaLimite = value;
			}
		}
		
		private string observaciones;
		public virtual string Observaciones
		{
			get
			{
				return this.observaciones;
			}
			set
			{
				this.observaciones = value;
			}
		}
		
		private string documentacionAnexada;
		public virtual string DocumentacionAnexada
		{
			get
			{
				return this.documentacionAnexada;
			}
			set
			{
				this.documentacionAnexada = value;
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
		
	}
}
#pragma warning restore 1591
