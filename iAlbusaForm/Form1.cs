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
        ResumenDiario rd = new ResumenDiario();
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
            txtUsuarioSol.Text = "MODDATOS";
            txtUsuarioSol.ReadOnly = true;
            txtClaveSol.Text = "MODDATOS";
            txtClaveSol.ReadOnly = true;
         //   txtRutaCertificado.Text = "D:\iAlbusaForm_TemporaryKey.pfx";
           txtPassCertificado.Text = "123456789";

            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";
            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";
            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";
            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";
            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";
            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";
            //dataGridView1.Columns[0].Name = "Nº DOCUMENTO";

            //dataGridView1.ColumnCount = 4;
            //dataGridView1.AutoGenerateColumns = false;
            //DataGridViewComboBoxColumn comboboxColumn = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
            //dataGridView1.Columns[1].Name = "documentoid";
            //dataGridView1.Columns[1].HeaderText = "Nº docuemnto";



        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            try
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
                // consultar factura 
                Boolean g = _dkddkd.CargaFactura(doc);
                Boolean h = _dkddkd.CargaDocumentoDetalle(doc,"");
                foreach (var detalleDocumento in doc.Items)
                {

                    MessageBox.Show(detalleDocumento.Descripcion);

                }


                    
                if (g)
                {
                    MessageBox.Show("Este : " + doc.FechaEmision + "" + doc.Emisor.NombreLegal);

                }
                //GrupoResumen gr = new GrupoResumen();
              var invoice = Generador.GenerarInvoice(doc);
                //rd.Emisor.Departamento = "ee";
                //gr.CorrelativoFin = 1;
                //gr.TotalVenta = 78;

                //rd.Resumenes.Add(gr);

                //var rde = Generador.GenerarSummaryDocuments(rd);
                //CreditNote cn = new CreditNote();
                //InvoiceDocumentReference idr = new InvoiceDocumentReference();
                //DocumentoRelacionado drelacionado = new DocumentoRelacionado();
                //drelacionado.NroDocumento = "nro factura anular";
                //drelacionado.TipoDocumento = "03";
                //doc.Relacionados.Add(drelacionado);
                //var creditNote = Generador.GenerarCreditNote(doc);
                // fin consultar factura



                // Una vez validado el XML seleccionado procedemos con obtener el Certificado.
                var serializar = new Serializador
                {
                    RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                    PasswordCertificado = txtPassCertificado.Text,
                    TipoDocumento = rbRetenciones.Checked ? 0 : 1
                };

                //generar xml sin firma 
                RutaArchivo = serializar.GenerarXmlFisico(invoice, string.Format("{0}-{1}-{2}",
               doc.Emisor.NroDocumento,
                doc.TipoDocumento,
                doc.IdDocumento));

                MessageBox.Show(RutaArchivo);
                // firma xml
                // var byteArray = File.ReadAllBytes("D:\\10711124123-1-seri.xml"); //ruta del xml 
                var byteArray = File.ReadAllBytes(RutaArchivo); //ruta del xml 



                // Firmamos el XML.
                var tramaFirmado = serializar.FirmarXml(Convert.ToBase64String(byteArray));
                // Le damos un nuevo nombre al archivo
                var nombreArchivo = string.Format("{0}-{1}-{2}", txtNroRuc.Text, codigoTipoDoc,
                        doc.IdDocumento);
                // Escribimos el archivo XML ya firmado en una nueva ubicación.
                using (var fs = File.Create(string.Format("{0}.xml", nombreArchivo)))
                {
                    var byteFirmado = Convert.FromBase64String(tramaFirmado);
                    fs.Write(byteFirmado, 0, byteFirmado.Length);
                }








                //
                // Validacion extra cuando sea un documento de resumen.
                if (rbResumen.Checked) serializar.TipoDocumento = 0;

                using (var conexion = new ConexionSunat(txtNroRuc.Text, txtUsuarioSol.Text,
                    txtClaveSol.Text, rbRetenciones.Checked ? "ServicioSunatRetenciones" : string.Empty))
                {
                    
                    var tramaZip = serializar.GenerarZip(tramaFirmado, nombreArchivo);

                    if (rbResumen.Checked)
                    {
                        var rptaSunat = conexion.EnviarResumenBaja(tramaZip, string.Format("{0}.zip", nombreArchivo));

                        if (rptaSunat.Item2)
                        {
                            var sb = new StringBuilder();

                            // Añadimos la respuesta del Servicio.
                        //    sb.AppendLine(Resources.procesoCorrecto);

                            sb.AppendLine(string.Format("Procesamiento correcto, el numero de Ticket es {0}",
                                rptaSunat.Item1));


                            txtResult.Text = sb.ToString();
                            sb.Length = 0;
                        }
                        else
                            txtResult.Text = rptaSunat.Item1;
                    }
                    else
                    {
                        var resultado = conexion.EnviarDocumento(tramaZip, string.Format("{0}.zip", nombreArchivo));

                        if (resultado.Item2)
                        {
                            var returnByte = Convert.FromBase64String(resultado.Item1);

                            var rutaArchivox = string.Format("{0}\\R-{1}.zip", Directory.GetCurrentDirectory(),
                                nombreArchivo);
                            var fs = new FileStream(rutaArchivox, FileMode.Create, FileAccess.Write);
                            fs.Write(returnByte, 0, returnByte.Length);
                            fs.Close();

                            var sb = new StringBuilder();

                            // Añadimos la respuesta del Servicio.
                          //  sb.AppendLine(Resources.procesoCorrecto);

                            // Extraemos el XML contenido en el archivo de respuesta como un XML.
                            var rutaArchivoXmlRespuesta = rutaArchivox.Replace(".zip", ".xml");
                            // Procedemos a desempaquetar el archivo y leer el contenido de la respuesta SUNAT.
                            using (var streamZip = ZipFile.Read(File.Open(rutaArchivox,
                                FileMode.Open,
                                FileAccess.ReadWrite)))
                            {
                                // Nos aseguramos de que el ZIP contiene al menos un elemento.
                                if (streamZip.Entries.Any())
                                {

                                    //estudiar este codigo entries.last();
                                    if (rbRetenciones.Checked)
                                        streamZip.Entries.Last()
                                        .Extract(".", ExtractExistingFileAction.OverwriteSilently);
                                    else
                                        streamZip.Entries.First()
                                            .Extract(".", ExtractExistingFileAction.DoNotOverwrite);
                                   


                                }
                               
                                     foreach (ZipEntry euii in streamZip)
                                {
                                    euii.Extract(Directory.GetCurrentDirectory());
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

                //Hablar();
            }
            catch (FaultException exSer)
            {
                txtResult.Text = exSer.ToString();
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
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
            MessageBox.Show(cboTipoDoc.Text);
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






            if (codigoTipoDoc == "01") {

            }
            else {
                dataGridView1.DataSource = _dkddkd.CargaCliente(dtp_a.Value, dtp_b.Value);
                MessageBox.Show(dataGridView1.RowCount.ToString());
            }


            
          //  MessageBox.Show(dtp_a.Format("dd/mm/aa");


        }
    }
}
