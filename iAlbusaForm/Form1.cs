using System;
 
using System.Windows.Forms;
using ialbusacpr.Business;
using ialbusacpr.ialbusac.Models;
using ialbusacpr.ialbusac;

 
using System.IO;






namespace  iAlbusaForm
{
    public partial class Form1 : Form
    {

        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boleta _dkddkd = new Boleta();
            DocumentoElectronico doc = new DocumentoElectronico();
            Boolean g = _dkddkd.CargaCliente(doc);
            if (g)
            {
                MessageBox.Show("Este : " + doc.FechaEmision + "" + doc.Emisor.NombreLegal);



            }

            var invoice = Generador.GenerarInvoice(doc);

            var serializador = new Serializador
            {
                TipoDocumento = 1
                ,
                RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                PasswordCertificado = txtPassCertificado.Text,



            };

            RutaArchivo = serializador.GenerarXmlFisico(invoice, string.Format("{0}-{1}-{2}",
                "01",
                "oe",
                "2016"));

            MessageBox.Show(RutaArchivo);

            var byteArray = File.ReadAllBytes("D:\\01-oe-2016.xml"); //ruta del xml 
            // Firmamos el XML.
            var tramaFirmado = serializador.FirmarXml(Convert.ToBase64String(byteArray));
            // Le damos un nuevo nombre al archivo
            var nombreArchivo = string.Format("{0}-{1}-{2}", "10711124123", 01,
                "serie");
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
    }
}
