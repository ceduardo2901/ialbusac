using System;
 
using System.Windows.Forms;
using ialbusacpr.Business;
using ialbusacpr.ialbusac.Models;







namespace  iAlbusaForm
{
    public partial class Form1 : Form
    {
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
        }
    }
}
