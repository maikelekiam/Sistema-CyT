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
	public partial class UdtUvt
	{
		private int idUdtUvt;
		public virtual int IdUdtUvt
		{
			get
			{
				return this.idUdtUvt;
			}
			set
			{
				this.idUdtUvt = value;
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
		
		private string tipo;
		public virtual string Tipo
		{
			get
			{
				return this.tipo;
			}
			set
			{
				this.tipo = value;
			}
		}
		
		private int? referenteTecnico;
		public virtual int? ReferenteTecnico
		{
			get
			{
				return this.referenteTecnico;
			}
			set
			{
				this.referenteTecnico = value;
			}
		}
		
		private int? directorGerente;
		public virtual int? DirectorGerente
		{
			get
			{
				return this.directorGerente;
			}
			set
			{
				this.directorGerente = value;
			}
		}
		
		private string telefono;
		public virtual string Telefono
		{
			get
			{
				return this.telefono;
			}
			set
			{
				this.telefono = value;
			}
		}
		
		private string correoElectronico;
		public virtual string CorreoElectronico
		{
			get
			{
				return this.correoElectronico;
			}
			set
			{
				this.correoElectronico = value;
			}
		}
		
		private string domicilio;
		public virtual string Domicilio
		{
			get
			{
				return this.domicilio;
			}
			set
			{
				this.domicilio = value;
			}
		}
		
		private int? idLocalidad;
		public virtual int? IdLocalidad
		{
			get
			{
				return this.idLocalidad;
			}
			set
			{
				this.idLocalidad = value;
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
		
		private Persona persona;
		public virtual Persona Persona
		{
			get
			{
				return this.persona;
			}
			set
			{
				this.persona = value;
			}
		}
		
		private Persona persona1;
		public virtual Persona Persona1
		{
			get
			{
				return this.persona1;
			}
			set
			{
				this.persona1 = value;
			}
		}
		
		private Localidad localidad;
		public virtual Localidad Localidad
		{
			get
			{
				return this.localidad;
			}
			set
			{
				this.localidad = value;
			}
		}
		
	}
}
#pragma warning restore 1591
