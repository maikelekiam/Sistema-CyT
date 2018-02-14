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

namespace CapaDominio	
{
	public partial class pr03ResultSet02
	{
		private int _idProyectoCofecyt;
		public virtual int idProyectoCofecyt
		{
			get
			{
				return this._idProyectoCofecyt;
			}
			set
			{
				this._idProyectoCofecyt = value;
			}
		}
		
		private int _idConvocatoria;
		public virtual int idConvocatoria
		{
			get
			{
				return this._idConvocatoria;
			}
			set
			{
				this._idConvocatoria = value;
			}
		}
		
		private string _titulo;
		public virtual string titulo
		{
			get
			{
				return this._titulo;
			}
			set
			{
				this._titulo = value;
			}
		}
		
		private string _objetivos;
		public virtual string objetivos
		{
			get
			{
				return this._objetivos;
			}
			set
			{
				this._objetivos = value;
			}
		}
		
		private string _descripcion;
		public virtual string descripcion
		{
			get
			{
				return this._descripcion;
			}
			set
			{
				this._descripcion = value;
			}
		}
		
		private string _destinatarios;
		public virtual string destinatarios
		{
			get
			{
				return this._destinatarios;
			}
			set
			{
				this._destinatarios = value;
			}
		}
		
		private string _localidad;
		public virtual string localidad
		{
			get
			{
				return this._localidad;
			}
			set
			{
				this._localidad = value;
			}
		}
		
		private int? _idSector;
		public virtual int? idSector
		{
			get
			{
				return this._idSector;
			}
			set
			{
				this._idSector = value;
			}
		}
		
		private int? _idTematica;
		public virtual int? idTematica
		{
			get
			{
				return this._idTematica;
			}
			set
			{
				this._idTematica = value;
			}
		}
		
		private string _observaciones;
		public virtual string observaciones
		{
			get
			{
				return this._observaciones;
			}
			set
			{
				this._observaciones = value;
			}
		}
		
		private string _numeroEspedienteCopade;
		public virtual string numeroEspedienteCopade
		{
			get
			{
				return this._numeroEspedienteCopade;
			}
			set
			{
				this._numeroEspedienteCopade = value;
			}
		}
		
		private string _numeroConvenio;
		public virtual string numeroConvenio
		{
			get
			{
				return this._numeroConvenio;
			}
			set
			{
				this._numeroConvenio = value;
			}
		}
		
		private string _numeroExpedienteDga;
		public virtual string numeroExpedienteDga
		{
			get
			{
				return this._numeroExpedienteDga;
			}
			set
			{
				this._numeroExpedienteDga = value;
			}
		}
		
		private DateTime? _fechaPresentacion;
		public virtual DateTime? fechaPresentacion
		{
			get
			{
				return this._fechaPresentacion;
			}
			set
			{
				this._fechaPresentacion = value;
			}
		}
		
		private DateTime? _ultimaEvaluacionTecnica;
		public virtual DateTime? ultimaEvaluacionTecnica
		{
			get
			{
				return this._ultimaEvaluacionTecnica;
			}
			set
			{
				this._ultimaEvaluacionTecnica = value;
			}
		}
		
		private DateTime? _fechaFinalizacion;
		public virtual DateTime? fechaFinalizacion
		{
			get
			{
				return this._fechaFinalizacion;
			}
			set
			{
				this._fechaFinalizacion = value;
			}
		}
		
		private int? _duracionEstimada;
		public virtual int? duracionEstimada
		{
			get
			{
				return this._duracionEstimada;
			}
			set
			{
				this._duracionEstimada = value;
			}
		}
		
		private int? _duracionEstimadaIfaa;
		public virtual int? duracionEstimadaIfaa
		{
			get
			{
				return this._duracionEstimadaIfaa;
			}
			set
			{
				this._duracionEstimadaIfaa = value;
			}
		}
		
		private string _beneficiarios;
		public virtual string beneficiarios
		{
			get
			{
				return this._beneficiarios;
			}
			set
			{
				this._beneficiarios = value;
			}
		}
		
		private string _entidadesIntervinientes;
		public virtual string entidadesIntervinientes
		{
			get
			{
				return this._entidadesIntervinientes;
			}
			set
			{
				this._entidadesIntervinientes = value;
			}
		}
		
		private int? _idTipoEstadoCofecyt;
		public virtual int? idTipoEstadoCofecyt
		{
			get
			{
				return this._idTipoEstadoCofecyt;
			}
			set
			{
				this._idTipoEstadoCofecyt = value;
			}
		}
		
		private decimal? _montoSolicitadoCofecyt;
		public virtual decimal? montoSolicitadoCofecyt
		{
			get
			{
				return this._montoSolicitadoCofecyt;
			}
			set
			{
				this._montoSolicitadoCofecyt = value;
			}
		}
		
		private decimal? _montoContraparteCofecyt;
		public virtual decimal? montoContraparteCofecyt
		{
			get
			{
				return this._montoContraparteCofecyt;
			}
			set
			{
				this._montoContraparteCofecyt = value;
			}
		}
		
		private decimal? _montoTotalCofecyt;
		public virtual decimal? montoTotalCofecyt
		{
			get
			{
				return this._montoTotalCofecyt;
			}
			set
			{
				this._montoTotalCofecyt = value;
			}
		}
		
		private decimal? _montoTotalDgaCofecyt;
		public virtual decimal? montoTotalDgaCofecyt
		{
			get
			{
				return this._montoTotalDgaCofecyt;
			}
			set
			{
				this._montoTotalDgaCofecyt = value;
			}
		}
		
		private decimal? _montoDevolucionCofecyt;
		public virtual decimal? montoDevolucionCofecyt
		{
			get
			{
				return this._montoDevolucionCofecyt;
			}
			set
			{
				this._montoDevolucionCofecyt = value;
			}
		}
		
		private decimal? _montoRescindidoCofecyt;
		public virtual decimal? montoRescindidoCofecyt
		{
			get
			{
				return this._montoRescindidoCofecyt;
			}
			set
			{
				this._montoRescindidoCofecyt = value;
			}
		}
		
	}
}
#pragma warning restore 1591