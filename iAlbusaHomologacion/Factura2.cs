using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ialbusacpr.iAlbusaHomologacion
{
    public partial class Factura2 : Form
    {
        public Factura2()
        {
            InitializeComponent();
        }

        private void Factura2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
