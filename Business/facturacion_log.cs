using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.Data;
using System.Data.OracleClient;
using System.Collections.ObjectModel;
using ialbusacpr.ialbusac.Models;
using ialbusacpr.ialbusac;
using ialbusacpr.Business;


namespace ialbusacpr.Business
{
    [Serializable]
    public     class facturacion_log:ICloneable 
    {
  private Int32      _IDFACTURACION;
private string _DESCRIPCION;
private Int32 _ESTADO;
private Int32 _ENVIADO;
 private Int32 _ZIP;
  private Int32 _GENERADO;
   private string _RUTAZIP; 
   private string _RUTAXML;
    private Int32 _PKDOCUMENTOID;
    private Int32 _PKKUSUARIOID;
    private DateTime _FECHA;
     private string _RESPSUNAT;
        private string _IDTIPODOC;

        public int IDFACTURACION
        {
            get
            {
                return _IDFACTURACION;
            }

            set
            {
                _IDFACTURACION = value;
            }
        }

        public string DESCRIPCION
        {
            get
            {
                return _DESCRIPCION;
            }

            set
            {
                _DESCRIPCION = value;
            }
        }

        public int ESTADO
        {
            get
            {
                return _ESTADO;
            }

            set
            {
                _ESTADO = value;
            }
        }

        public int ENVIADO
        {
            get
            {
                return _ENVIADO;
            }

            set
            {
                _ENVIADO = value;
            }
        }

        public int ZIP
        {
            get
            {
                return _ZIP;
            }

            set
            {
                _ZIP = value;
            }
        }

        public int GENERADO
        {
            get
            {
                return _GENERADO;
            }

            set
            {
                _GENERADO = value;
            }
        }

        public string RUTAZIP
        {
            get
            {
                return _RUTAZIP;
            }

            set
            {
                _RUTAZIP = value;
            }
        }

        public string RUTAXML
        {
            get
            {
                return _RUTAXML;
            }

            set
            {
                _RUTAXML = value;
            }
        }

        public int PKDOCUMENTOID
        {
            get
            {
                return _PKDOCUMENTOID;
            }

            set
            {
                _PKDOCUMENTOID = value;
            }
        }

        public int PKKUSUARIOID
        {
            get
            {
                return _PKKUSUARIOID;
            }

            set
            {
                _PKKUSUARIOID = value;
            }
        }

        public DateTime FECHA
        {
            get
            {
                return _FECHA;
            }

            set
            {
                _FECHA = value;
            }
        }

        public string RESPSUNAT
        {
            get
            {
                return _RESPSUNAT;
            }

            set
            {
                _RESPSUNAT = value;
            }
        }

        public string IDTIPODOC
        {
            get
            {
                return _IDTIPODOC;
            }

            set
            {
                _IDTIPODOC = value;
            }
        }
        public object Clone()
        {
            return Utiles.Copia(this);
        }
    }
}
