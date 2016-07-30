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
     + "     AND  trunc(d.fecha) >= '" + f1.ToShortDateString() + "'     AND   trunc(d.fecha)  <= '" + f1.ToShortDateString()  +"' AND c.seriedocumentos is not null  "
     // + " ---and  d.numero='2247370'  "
     + "    order by d.documentoid asc ";

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

            /// 



 
          /*  OracleDataReader Dr;

            Dr = Cmd.ExecuteReader();
           
            if (Dr.HasRows)
            {
                Dr.Read();

                doc.FechaEmision = Dr["IssueDate"].ToString();
                doc.Emisor.NombreLegal = Dr["RegistrationName"].ToString();
                doc.TotalVenta = 2;
                doc.TotalOtrosTributos = 2;
                doc.TotalIsc = 3;
                doc.TotalIgv = 32;
                doc.TipoOperacion = "ddd";
                doc.TipoDocumento = "dd";
                doc.Receptor.NombreComercial = "albusa";
                doc.Receptor.NombreLegal = "dd";
                doc.Receptor.NroDocumento = "ddd";
                doc.Receptor.Provincia = "ddd";
                doc.Receptor.TipoDocumento = "dd";
                doc.Receptor.Ubigeo = "3";
                doc.Receptor.Urbanizacion = "3";
                doc.Receptor.Distrito = "2";
                doc.Receptor.Direccion = "dd";
                doc.Receptor.Departamento = "ww";
                doc.MontoEnLetras = "djdjdjd";
                doc.Moneda = "PEN";
                doc.Inafectas = 2;
                doc.IdDocumento = "454";
                doc.Gravadas = 455;
                doc.Gratuitas = 2;
                doc.Exoneradas = 12;
                doc.CalculoIsc = 125;
                doc.CalculoIgv = 22;
                doc.CalculoDetraccion = 21;
                doc.Emisor.NombreComercial = "albusa";
                
                doc.Emisor.NroDocumento = "wee";
                doc.Emisor.Provincia = "eew";
                doc.Emisor.TipoDocumento = "ew";
                doc.Emisor.Ubigeo = "3";
                doc.Emisor.Urbanizacion = "3";
                doc.Emisor.Distrito = "2";
                doc.Emisor.Direccion = "ew";
                doc.Emisor.Departamento = "eee"; 



               
                return true;
            }
            else
            {
                Dr.Close();

                return false;
            }*/
        }

        public object Clone()
        {
            return Utiles.Copia(this);
        }

    }
}
