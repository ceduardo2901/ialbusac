using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;
using ialbusacpr.ialbusac.Models;

namespace Business
{
    class Boleta
    {
        private readonly DocumentoElectronico _documento;
        OracleConnection Cn = new OracleConnection();
        public Boolean CargaCliente(String sidCli, string Sidsucursal)
        {
            var doc = (DocumentoElectronico)_documento.Clone();
            if (Cn.State == ConnectionState.Closed)
            {
                Cn.ConnectionString = ClsConexion.sConex; Cn.Open();
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
     + "     AND to_number(to_char(d.fecha, 'yyyy')) = '2016'  AND to_number(to_char(d.fecha, 'mm')) = '07'  AND c.seriedocumentos is not null  "
     +" and  d.numero='2247370'  "
     + "    order by d.documentoid asc ";

            OracleCommand Cmd = new OracleCommand();
            Cmd.CommandText = sSQL;
            Cmd.CommandType = CommandType.Text;
            Cmd.Connection = Cn;

            OracleDataReader Dr;

            Dr = Cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();

                doc.FechaEmision = Dr["IssueDate"].ToString();
                doc.Emisor.NombreLegal = Dr[" RegistrationName"].ToString();
              /*  Cliente = Dr["CLIENTEID"].ToString();
                UsuarioID = Dr["USUARIOID"].ToString();
                ZonaId = Dr["ZONAID"].ToString();
                DistritoId = Dr["DISTRITOID"].ToString();
                CodCliente = Dr["CODIGOCLIENTE"].ToString();
                Nombre = Dr["NOMBRECLIENTE"].ToString();
                Apellido = Dr["APELLIDOCLIENTE"].ToString();
                Ruc = Dr["RUC"].ToString();
                Domicilio = Dr["DOMICILIO"].ToString();
                Ciudad = Dr["CIUDAD"].ToString();
                Dni = Dr["DNI"].ToString();
                FechaGestion = Dr.GetDateTime(11);   // Dr["FECHAGESTION"];
                FechaNaci = Dr.GetDateTime(12);      //  ["FECHANATAL"];
                EstadoCivil = Dr["ESTADOCIVIL"].ToString();
                Email = Dr["CORREOELECTRONICO"].ToString();
                Topes = Math.Round(Dr.GetDouble(15), 2);
                OrdenCobranza = Dr["ORDENCOBRANZA"].ToString();
                Estado = Dr["ESTADO"].ToString().Trim();
                Incobrable = Dr["INCOBRABLE"].ToString().Trim();
                PersonaJuridica = Dr["PERSONAJURIDICA"].ToString().Trim();
                Sexo = Dr["SEXO"].ToString().Trim();
                Disponible = Math.Round(Dr.GetDouble(21), 2);// Dr["DISPONIBLE"].ToString();
                Consumido = Math.Round(Dr.GetDouble(22), 2);
                TelefonoCasa = Dr["TELEFONOCASA"].ToString();
                Celular = Dr["CELULAR"].ToString();
                Dr.Close();*/
                return true;
            }
            else
            {
                Dr.Close();

                return false;
            }
        }
    }
}
