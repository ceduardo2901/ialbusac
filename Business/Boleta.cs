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
   public class Boleta: ICloneable
    {
        //private readonly DocumentoElectronico _documento;
       
         
     public DataTable CargaCliente( DateTime f1,DateTime f2)
        {
            OracleConnection Cn = new OracleConnection();
            
            // var doc = (DocumentoElectronico)_documento.Clone();
            if (Cn.State == ConnectionState.Closed)
            {
                Cn.ConnectionString = "Data Source=maximus;Persist Security Info=True;User ID=db_prueba;Password=db_prueba;Unicode=True";
                Cn.Open();
            }

            //           //SUSPENDIDA POR EL NUEVO DATAGRIDVIEW 
            //           String sSQL = " SELECT d.documentoid,  (to_char(d.fecha, 'yyyy') || '-' || to_char(d.fecha, 'mm') || '-' || to_char(d.fecha, 'dd')) as IssueDate, "//- 1 Fecha de emision
            //+ " 'INVERSIONES ALBUSA SAC' as RegistrationName, "// 2 Apellidos nombres  denominacion o razon social
            //+ "'20484245249' as CustomerAssignedAccountID, "//5 RUC
            //+ "'6' as AdditionalAccountID,"//5 
            //+ "'03' as InvoiceTypeCode ,"//6 Tipo de documento(Boleta)
            //+ "'B' || c.seriedocumentos || '-' || d.numero as ID,"// 7 Numeracion , conformada por serie y numero correlativo
            //+ "cl.dni as CustomerAssignedAccountID,"// 8 Tipo y (numero) de documento de identidad del adquiriente o usuario
            //+ "'1' as AdditionalAccountID,"//  8 (Tipo) y numero de documento de identidad del adquiriente o usuario
            //+ "trim(cl.apellidocliente) || ' ' || trim(cl.nombrecliente) as RegistrationName," //9 Apellidos y nombres de adquiriente o usuario
            // //10 Direccion en el pais adquiriente o lugar de destino 
            // + "'1' as unitCode,"//11  Unidad de medidda por Item
            // + "'1' as InvoicedQuantity,"//12 cantidad de unidades  por item 
            // + "'PAGO DE CUOTA DE CREDITO' || '  ' || cr.codigocredito as Description , "//13  DEscrIPCION DETALLA DEL SERVICIO PRESTADO bien vendido 
            // + "'0.00', "//14 precio de venta unitario por item y codigo
            //+ " d.montototal as ID ,"//15 total valo de ventas gravadas 
            // + "p.montocapital as PayableAmount,"//16  total valor venta operaciones inafectas
            // //17
            // + "p.montointeres," //18
            //     //19
            //     //20
            //     //21
            //     //22
            //     + "       p.montototal as currencyID,"//23
            // + "'PEN' as DocumentCurrencyCode,"//24
            //     //25
            //     //26
            //     + "       p.montoimpuesto as ,"//27
            //         //28
            //         //29
            //         //30
            //         + "   p.montointeres,"//31
            //  + "p.montointeres"//32
            //                    //33
            //                    //34
            //                    //35
            //                    //36
            //                    //37
            //                    //38
            //                    //39
            //                    //40
            //                    //41
            //                    //42



            //        + "    FROM       pagos p, documentos d,  tiposdocumento td, cajas c,  clientes cl, creditos cr,  tipo_documento td2,"
            //  + " tipo_cambio tc WHERE p.pagoid = d.pagoid(+)  AND d.tipodocumentoid = td.tipodocumentoid(+)  AND td.tipo_doc = td2.id_tipodoc(+)"
            //    + "   AND td.cajaid = c.cajaid(+)  AND p.creditoid = cr.creditoid(+)  AND cr.clienteid = cl.clienteid(+) and trunc(d.fechareal) = trunc(tc.fechaingreso)  "
            //    + "     AND  trunc(d.fecha) >= '" + f1.ToShortDateString() + "'     AND   trunc(d.fecha)  <= '" + f1.ToShortDateString()  +"' AND c.seriedocumentos is not null  "
            //    // + " ---and  d.numero='2247370'  "
            //    + "    order by d.documentoid asc ";


            String sSQL = "  select    d.serie,   d.serie|| '-' ||   d.numero as NoTicket,D.DOCUMENTOID , d.fechareal  as FECHA,  "

   + "  (select fl.descripcion from facturacion_log  fl  "
+ " where trunc(fl.fecha)  >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "'  and fl.pkdocumentoid = d.documentoid )as DESCRIPCION,"

+ " (select fl.rutazip from facturacion_log fl"
+ " where trunc(fl.fecha)  >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "'  and fl.pkdocumentoid = d.documentoid )as RUTAZIP,"

+ " (select fl.Rutaxml from facturacion_log fl"
+ " where trunc(fl.fecha)  >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "'  and fl.pkdocumentoid = d.documentoid )as RUTAXML,"


+ " (select fl.Fecha from facturacion_log fl"
+ " where trunc(fl.fecha) >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "'  and fl.pkdocumentoid = d.documentoid )as FECHA,"

+ " (select  CASE fl.Enviado when   1  then  'ENVIADO' when 0 then 'EN ESPERA' END from facturacion_log fl"
+ " where trunc(fl.fecha) >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "'  and fl.pkdocumentoid = d.documentoid )as ENVIADO ,"

+ "(select case        fl.Generado when   1  then  'GENERADO' when 0 then 'EN ESPERA' END from facturacion_log fl "
+ "where trunc(fl.fecha)  >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "'  and fl.pkdocumentoid = d.documentoid )as GENERADO, "

+ " (select   case fl.Zip when   1  then  'ZIPEADO' when 0 then 'EN ESPERA' END from facturacion_log fl "
+ " where trunc(fl.fecha) >='" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <='" + f2.ToShortDateString() + "' and fl.pkdocumentoid = d.documentoid )as ZIP, "

+ " (select     fl.respsunat from facturacion_log fl "
+ " where trunc(fl.fecha) >= '" + f1.ToShortDateString() + "'  AND   trunc(fl.fecha) <= '" + f2.ToShortDateString() + "' and fl.pkdocumentoid = d.documentoid )as SUNAT"

 + "  from documentos d"
 +  " where d.anulado = 0 and trunc(d.fechareal) >= '" + f1.ToShortDateString() + "'  AND   trunc(d.fechareal) <= '" + f2.ToShortDateString() + "'";



             OracleCommand Cmd = new OracleCommand();
             OracleDataAdapter Dap = new OracleDataAdapter();
            Cmd.CommandText = sSQL;
            Cmd.CommandType = CommandType.Text;
            Cmd.Connection = Cn;

            ///llenar datagridview
            Dap.SelectCommand = Cmd;
            DataTable Dt = new DataTable();
            Dap.Fill(Dt);
            return Dt;

             
        }


        public Boolean CargaDocumento( DocumentoElectronico doc)
        {
            OracleConnection Cn = new OracleConnection();

            // var doc = (DocumentoElectronico)_documento.Clone();
            if (Cn.State == ConnectionState.Closed)
            {
                Cn.ConnectionString = "Data Source=maximus;Persist Security Info=True;User ID=db_albusa;Password=db_albusa;Unicode=True";
                Cn.Open();
            }
            String sSQL = " SELECT d.documentoid,  (to_char(d.fecha, 'yyyy') || '-' || to_char(d.fecha, 'mm') || '-' || to_char(d.fecha, 'dd')) as IssueDate, "//- 1 Fecha de emision
 + " 'INVERSIONES ALBUSA SAC' as RegistrationName, "// 2 Apellidos nombres  denominacion o razon social
 + "'20484245249' as CustomerAssignedAccountID, "//5 RUC
 + "'6' as AdditionalAccountID,"//5 
 + "'03' as InvoiceTypeCode ,"//6 Tipo de documento(Boleta)
 + "'B' || c.seriedocumentos || '-' || d.numero as ID,"// 7 Numeracion , conformada por serie y numero correlativo
 + "cl.dni as CustomerAssignedAccountID,"// 8 Tipo y (numero) de documento de identidad del adquiriente o usuario
 + "'1' as AdditionalAccountID,"//  8 (Tipo) y numero de documento de identidad del adquiriente o usuario
 + "trim(cl.apellidocliente) || ' ' || trim(cl.nombrecliente) as RegistrationName," //9 Apellidos y nombres de adquiriente o usuario
                                                                                    //10 Direccion en el pais adquiriente o lugar de destino 
  + "'1' as unitCode,"//11  Unidad de medidda por Item
  + "'1' as InvoicedQuantity,"//12 cantidad de unidades  por item 
  + "'PAGO DE CUOTA DE CREDITO' || '  ' || cr.codigocredito as Description , "//13  DEscrIPCION DETALLA DEL SERVICIO PRESTADO bien vendido 
  + "'0.00', "//14 precio de venta unitario por item y codigo
 + " d.montototal as ID ,"//15 total valo de ventas gravadas 
  + "p.montocapital as PayableAmount,"//16  total valor venta operaciones inafectas
                                      //17
  + "p.montointeres," //18
                      //19
                      //20
                      //21
                      //22
      + "       p.montototal as currencyID,"//23
  + "'PEN' as DocumentCurrencyCode,"//24
                                    //25
                                    //26
      + "       p.montoimpuesto as ,"//27
                                     //28
                                     //29
                                     //30
          + "   p.montointeres,"//31
   + "p.montointeres"//32
                     //33
                     //34
                     //35
                     //36
                     //37
                     //38
                     //39
                     //40
                     //41
                     //42

         + "    FROM       pagos p, documentos d,  tiposdocumento td, cajas c,  clientes cl, creditos cr,  tipo_documento td2,"
   + " tipo_cambio tc WHERE p.pagoid = d.pagoid(+)  AND d.tipodocumentoid = td.tipodocumentoid(+)  AND td.tipo_doc = td2.id_tipodoc(+)"
     + "   AND td.cajaid = c.cajaid(+)  AND p.creditoid = cr.creditoid(+)  AND cr.clienteid = cl.clienteid(+) and trunc(d.fechareal) = trunc(tc.fechaingreso)  "
     + "    AND c.seriedocumentos is not null  "
     + " and  d.numero='2247370'  "
     + "    order by d.documentoid asc ";

            OracleCommand Cmd = new OracleCommand();
            OracleDataAdapter Dap = new OracleDataAdapter();
            Cmd.CommandText = sSQL;
            Cmd.CommandType = CommandType.Text;
            Cmd.Connection = Cn;

            ///llenar datagridview
            //Dap.SelectCommand = Cmd;
            //DataTable Dt = new DataTable();
            //Dap.Fill(Dt);
            //return Dt;

            /// 




             OracleDataReader Dr;

              Dr = Cmd.ExecuteReader();

              if (Dr.HasRows)
              {
                  Dr.Read();

                  doc.FechaEmision = Dr["IssueDate"].ToString();
                  doc.Emisor.NombreLegal = Dr["RegistrationName"].ToString();
                  doc.TotalVenta =     Convert.ToDecimal( Dr["PayableAmount"].ToString());
                  doc.TotalOtrosTributos = 0 ;
                  doc.TotalIsc =0;
                  doc.TotalIgv = 32;
                  doc.TipoOperacion = "";
                  doc.TipoDocumento = Dr["InvoiceTypeCode"].ToString() ;

                  doc.Receptor.NombreComercial = "";
                  doc.Receptor.NombreLegal = "armestar merino chirtofer";
                  doc.Receptor.NroDocumento = "42544373";
                  doc.Receptor.Provincia = "01";
                  doc.Receptor.TipoDocumento = "01";
                  doc.Receptor.Ubigeo = "200101";
                  doc.Receptor.Urbanizacion = "mananzales";
                  doc.Receptor.Distrito = "20";
                  doc.Receptor.Direccion = "sucasa ";
                  doc.Receptor.Departamento = "20";

                  doc.MontoEnLetras = "cuanrenta y cinco";
                  doc.Moneda = "PEN";
                  doc.Inafectas = 2;
                  doc.IdDocumento = Dr["ID"].ToString() ; 
                  doc.Gravadas = 455;
                  doc.Gratuitas = 2;
                  doc.Exoneradas = 12;
                  doc.CalculoIsc = 125;
                  doc.CalculoIgv = 22;
                  doc.CalculoDetraccion = 21;
                  doc.Emisor.NombreComercial = "INVERSIONES ALBUSA";

                  doc.Emisor.NroDocumento = "20484205249";
                  doc.Emisor.Provincia = "01";
                  doc.Emisor.TipoDocumento = "ew";
                  doc.Emisor.Ubigeo = "200101";
                  doc.Emisor.Urbanizacion = "Jr Junin 817";
                  doc.Emisor.Distrito = "20";
                  doc.Emisor.Direccion = "Jr junin";
                  doc.Emisor.Departamento = "20"; 
              //  doc.Items.Add()



                  return true;
              }
              else
              {
                  Dr.Close();

                  return false;
              }
        }

        /// <summary>
        public Boolean CargaDocumentoDetalle(DocumentoElectronico doc   , String nroDoc)
        {
            OracleConnection Cn = new OracleConnection();
            DetalleDocumento _detralle = new DetalleDocumento();

           
//            if (Cn.State == ConnectionState.Closed)
//            {
//                Cn.ConnectionString = "Data Source=maximus;Persist Security Info=True;User ID=db_albusa;Password=db_albusa;Unicode=True";
//                Cn.Open();
//            }
//            String sSQL = " select  cpd.*,   "
//       + " (select nvl(t.importe, 5)  from cp_doc_det_imp t where t.nro_doc = cpd.nro_doc and  "
//      + " t.item = cpd.item and t.idproveedor = cpd.idproveedor ) as igv "

//     + " from cntas_pagar_det cpd  "


//+ "where cpd.nro_doc = '"+ nroDoc +"' ";

//            OracleCommand Cmd = new OracleCommand();
//            OracleDataAdapter Dap = new OracleDataAdapter();
//            Cmd.CommandText = sSQL;
//            Cmd.CommandType = CommandType.Text;
//            Cmd.Connection = Cn;

             




//            OracleDataReader Dr;

//            Dr = Cmd.ExecuteReader();

//            if (Dr.HasRows)
//            {
//                Dr.Read();

                _detralle.Id = 1;
                _detralle.Cantidad = 5;
                _detralle.PrecioReferencial = 20;
                _detralle.PrecioUnitario = 20;
                _detralle.TipoPrecio = "01";
                _detralle.CodigoItem = "1234234";
                _detralle.Descripcion = "pelado gay ";
                _detralle.UnidadMedida = "KG";
                _detralle.Impuesto = 18;
                _detralle.TipoImpuesto = "10";
                _detralle.TotalVenta = 100; //vetenta toto la sumatoria igv gravadas etc
                _detralle.Suma = 100;

                doc.Items.Add(_detralle);



                return true;
            //}
            //else
            //{
            //    Dr.Close();

            //    return false;
            //}
        }
        ///
         
        /// 


        public Boolean CargaFactura(DocumentoElectronico doc)
        {
            
            
            OracleConnection Cn = new OracleConnection();

            // var doc = (DocumentoElectronico)_documento.Clone();
            if (Cn.State == ConnectionState.Closed)
            {
                Cn.ConnectionString = "Data Source=maximus;Persist Security Info=True;User ID=db_albusa;Password=db_albusa;Unicode=True";
                Cn.Open();
            }
            String sSQL = "";

            OracleCommand Cmd = new OracleCommand();
            OracleDataAdapter Dap = new OracleDataAdapter();
            Cmd.CommandText = sSQL;
            Cmd.CommandType = CommandType.Text;
            Cmd.Connection = Cn;

            

 

            OracleDataReader Dr;

            Dr = Cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();

                doc.FechaEmision = Dr["IssueDate"].ToString();
                doc.Emisor.NombreLegal = Dr["RegistrationName"].ToString();
                doc.TotalVenta = Convert.ToDecimal(Dr["PayableAmount"].ToString());
                doc.TotalOtrosTributos = 0;
                doc.TotalIsc = 0;
                doc.TotalIgv = 32;
                doc.TipoOperacion = "";
                doc.TipoDocumento = Dr["InvoiceTypeCode"].ToString();

                doc.Receptor.NombreComercial = "";
                doc.Receptor.NombreLegal = "armestar merino chirtofer";
                doc.Receptor.NroDocumento = "42544373";
                doc.Receptor.Provincia = "01";
                doc.Receptor.TipoDocumento = "01";
                doc.Receptor.Ubigeo = "200101";
                doc.Receptor.Urbanizacion = "mananzales";
                doc.Receptor.Distrito = "20";
                doc.Receptor.Direccion = "sucasa ";
                doc.Receptor.Departamento = "20";

                doc.MontoEnLetras = "cuanrenta y cinco";
                doc.Moneda = "PEN";
                doc.Inafectas = 2;
                doc.IdDocumento = Dr["ID"].ToString();
                doc.Gravadas = 455;
                doc.Gratuitas = 2;
                doc.Exoneradas = 12;
                doc.CalculoIsc = 125;
                doc.CalculoIgv = 22;
                doc.CalculoDetraccion = 21;
                doc.Emisor.NombreComercial = "INVERSIONES ALBUSA";

                doc.Emisor.NroDocumento = "20484205249";
                doc.Emisor.Provincia = "01";
                doc.Emisor.TipoDocumento = "ew";
                doc.Emisor.Ubigeo = "200101";
                doc.Emisor.Urbanizacion = "Jr Junin 817";
                doc.Emisor.Distrito = "20";
                doc.Emisor.Direccion = "Jr junin";
                doc.Emisor.Departamento = "20";
                 

            doc.Emisor.NroDocumento = "20484205249";
                doc.Emisor.TipoDocumento = "6";
                doc.Emisor.Direccion = "CAL.MORELLI NRO. 181 INT. P-2";
                doc.Emisor.Urbanizacion = "-";
                doc.Emisor.Departamento = "LIMA";
                doc.Emisor.Provincia = "LIMA";
                doc.Emisor.Distrito = "SAN BORJA";
                doc.Emisor.NombreComercial = "PLAZA VEA";
                doc.Emisor.NombreLegal = "SUPERMERCADOS PERUANOS SOCIEDAD ANONIMA";


                doc.Receptor.NroDocumento = "20100039207";
                doc.Receptor.TipoDocumento = "6";
                doc.Receptor.NombreLegal = "RANSA COMERCIAL S.A.";

                doc.IdDocumento = "FF11-002";
                doc.FechaEmision = "02/02/2016";
                doc.Moneda = "PEN";
                doc.MontoEnLetras = "SON CIENTO DIECIOCHO SOLES CON 0/100";
                doc.CalculoIgv = 180;
                doc.CalculoIsc = 0;
                doc.CalculoDetraccion = 0;
                    doc.TipoDocumento = "01";
                doc.TotalIgv = 180;
                doc.TotalVenta = 118;
                doc.Gravadas = 100;









                return true;
            }
            else
            {
                Dr.Close();

                return false;
            }
        }

        /// <summary>
        /// Registra un documento factura procesado
        /// </summary>
        /// <returns></returns>
        /// 
        public Boolean InsertarRegistros(facturacion_log f )
        {
            OracleConnection Cn = new OracleConnection();
            if (Cn.State == ConnectionState.Closed)
            {
                Cn.ConnectionString = "Data Source=maximus;Persist Security Info=True;User ID=db_prueba;Password=db_prueba;Unicode=True";
                Cn.Open();
            }

            OracleCommand Cmd = Cn.CreateCommand();
            Cmd.CommandText = "usp_insertarDocFAc";
            Cmd.CommandType = CommandType.StoredProcedure;
            OracleTransaction Trs;
            Trs = Cn.BeginTransaction();
            Cmd.Transaction = Trs;

            try
            {
                Cmd.Parameters.Add("IDFACTURACION", OracleType.Number, 10).Value = f.IDFACTURACION;
                Cmd.Parameters.Add("DESCRIPCION", OracleType.VarChar, 90).Value = f.DESCRIPCION;
                Cmd.Parameters.Add("ESTADO", OracleType.Number, 10).Value = f.ESTADO;
                Cmd.Parameters.Add("ENVIADO", OracleType.Number, 10).Value = f.ENVIADO;
                Cmd.Parameters.Add("ZIP", OracleType.Number, 8).Value = f.ZIP;
                Cmd.Parameters.Add("GENERADO", OracleType.Number, 8).Value = f.GENERADO;
                Cmd.Parameters.Add("RUTAZIP", OracleType.VarChar, 100).Value = f.RUTAZIP;
                Cmd.Parameters.Add("RUTAXML", OracleType.VarChar, 100).Value = f.RUTAXML;
                Cmd.Parameters.Add("PKDOCUMENTOID", OracleType.Number, 16).Value = f.PKDOCUMENTOID;
                Cmd.Parameters.Add("PKKUSUARIOID", OracleType.Number, 16).Value = f.PKKUSUARIOID;
                Cmd.Parameters.Add("FECHA", OracleType.DateTime, 8).Value = f.FECHA;
                Cmd.Parameters.Add("RESPSUNAT", OracleType.NVarChar, 200).Value = f.RESPSUNAT;
                Cmd.Parameters.Add("IDTIPODOC", OracleType.NVarChar, 8).Value = f.IDTIPODOC;



          



                     Cmd.ExecuteNonQuery();
                Trs.Commit();

                return true;
            }

            catch //(Exception e)
            {
                Trs.Rollback();
                return false;
            }


        }


        public object Clone()
        {
            return Utiles.Copia(this);
        }

    }
}
