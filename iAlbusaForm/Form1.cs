using System;
 
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Ionic.Zip;
 
using ialbusacpr.Business;
using ialbusacpr.ialbusac.Models;
using ialbusacpr.ialbusac.Estructuras;
using ialbusacpr.ialbusac;

  






namespace  iAlbusaForm
{
    public partial class Form1 : Form
    {
        Boleta _dkddkd = new Boleta();
        DocumentoElectronico doc = new DocumentoElectronico();
        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNroRuc.Text = "20484205249";
            txtNroRuc.ReadOnly = true;
            txtUsuarioSol.Text = "20484205249MODDATOS";
            txtUsuarioSol.ReadOnly = true;
            txtClaveSol.Text = "MODDATOS";
            txtClaveSol.ReadOnly = true;


          



        }

        private void button1_Click(object sender, EventArgs e)
        {


            string codigoTipoDoc;
            switch (cboTipoDoc.SelectedIndex)
            {
                case 0:
                    codigoTipoDoc = "01";
                    break;
                case 1:
                    codigoTipoDoc = "03";
                    break;
                case 2:
                    codigoTipoDoc = "07";
                    break;
                case 3:
                    codigoTipoDoc = "08";
                    break;
                case 4:
                    codigoTipoDoc = "20";
                    break;
                case 5:
                    codigoTipoDoc = "40";
                    break;
                case 6:
                    codigoTipoDoc = "RC";
                    break;
                case 7:
                    codigoTipoDoc = "RA";
                    break;
                default:
                    codigoTipoDoc = "01";
                    break;
            }

            
            
          //  Boolean g = _dkddkd.CargaCliente(doc);
            //if (g)
            //{
            //    MessageBox.Show("Este : " + doc.FechaEmision + "" + doc.Emisor.NombreLegal);



            //}

            var invoice = Generador.GenerarInvoice(doc);

            var serializador = new Serializador
            {
                TipoDocumento = 1
                ,
                RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                PasswordCertificado = txtPassCertificado.Text,



            };

            RutaArchivo = serializador.GenerarXmlFisico(invoice, string.Format("{0}-{1}-{2}",
               doc.Emisor.NroDocumento,
                doc.TipoDocumento,
                doc.IdDocumento));

            MessageBox.Show(RutaArchivo);

            var byteArray = File.ReadAllBytes("D:\\10711124123-1-seri.xml"); //ruta del xml 
            // Firmamos el XML.
            var tramaFirmado = serializador.FirmarXml(Convert.ToBase64String(byteArray));
            // Le damos un nuevo nombre al archivo
            var nombreArchivo = string.Format("{0}-{1}-{2}", txtNroRuc.Text, codigoTipoDoc,
                    doc.IdDocumento);
            // Escribimos el archivo XML ya firmado en una nueva ubicación.
            using (var fs = File.Create(string.Format("{0}.xml", nombreArchivo)))
            {
                var byteFirmado = Convert.FromBase64String(tramaFirmado);
                fs.Write(byteFirmado, 0, byteFirmado.Length);
            }
            // Ahora lo empaquetamos en un ZIP.
            var tramaZip = serializador.GenerarZip(tramaFirmado, nombreArchivo);
            var dataOrigen = Convert.FromBase64String(tramaZip);
            MessageBox.Show("Direccion del zip : " + tramaZip);


            //proceso de envio a la sunat //////

            using (var conexion = new ConexionSunat(txtNroRuc.Text, txtUsuarioSol.Text,
                   txtClaveSol.Text, rbRetenciones.Checked ? "ServicioSunatRetenciones" : string.Empty))
            {

                var resultado = conexion.EnviarDocumento(tramaZip, string.Format("{0}.zip", nombreArchivo));

            if (resultado.Item2)
            {
                var returnByte = Convert.FromBase64String(resultado.Item1);

                var rutaArchivo = string.Format("{0}\\R-{1}.zip", Directory.GetCurrentDirectory(),
                    nombreArchivo);
                var fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write);
                fs.Write(returnByte, 0, returnByte.Length);
                fs.Close();

                var sb = new StringBuilder();

                // Añadimos la respuesta del Servicio.
                sb.AppendLine("procesocorecto");

                // Extraemos el XML contenido en el archivo de respuesta como un XML.
                var rutaArchivoXmlRespuesta = rutaArchivo.Replace(".zip", ".xml");
                // Procedemos a desempaquetar el archivo y leer el contenido de la respuesta SUNAT.
                using (var streamZip = ZipFile.Read(File.Open(rutaArchivo,
                    FileMode.Open,
                    FileAccess.ReadWrite)))
                {
                    // Nos aseguramos de que el ZIP contiene al menos un elemento.
                    if (streamZip.Entries.Any())
                    {
                        if (rbRetenciones.Checked)
                            streamZip.Entries.Last()
                            .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                        else
                            streamZip.Entries.First()
                                .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                // Como ya lo tenemos extraido, leemos el contenido de dicho archivo.
                var xDoc = XDocument.Parse(File.ReadAllText(rutaArchivoXmlRespuesta));

                var respuesta = xDoc.Descendants(XName.Get("DocumentResponse", EspacioNombres.cac))
                    .Descendants(XName.Get("Response", EspacioNombres.cac))
                    .Descendants().ToList();

                if (respuesta.Any())
                {
                    // La respuesta se compone de 3 valores
                    // cbc:ReferenceID
                    // cbc:ResponseCode
                    // cbc:Description
                    // Obtendremos unicamente la Descripción (la última).
                    sb.AppendLine(string.Format("Respuesta de SUNAT a las {0}", DateTime.Now));
                    sb.AppendLine(((XText)respuesta.Nodes().Last()).Value);
                }

                txtResult.Text = sb.ToString();
                sb.Length = 0; // Limpiamos memoria del StringBuilder.
            }
            else
                txtResult.Text = resultado.Item1;

        }











        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                   // ofd.Title = Resources.seleccioneCertificado;
                 //   ofd.Filter = Resources.formatosCertificado;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtRutaCertificado.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dkddkd.CargaCliente(dtp_a.Value,dtp_b.Value);
            MessageBox.Show(dataGridView1.RowCount.ToString());
        }
    }
}
