using System;
 
using System.Windows.Forms;
using ialbusacpr.Business;
using ialbusacpr.ialbusac.Models;
using ialbusacpr.ialbusac;







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
            if (g) {
                MessageBox.Show("Este : " + doc.FechaEmision + "" + doc.Emisor.NombreLegal);



            }

            var invoice = Generador.GenerarInvoice(doc);

            var serializador = new Serializador { TipoDocumento = 1 };

            RutaArchivo = serializador.GenerarXmlFisico(invoice, string.Format("{0}-{1}-{2}",
                "01",
                "oe",
                "2016"));

            MessageBox.Show(RutaArchivo);
              
            


        }
    }
}
