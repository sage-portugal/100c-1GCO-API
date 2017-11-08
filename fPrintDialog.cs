using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiLaunchBusiness
{
    public partial class fPrintDialog : Form
    {
        public fPrintDialog()
        {
            InitializeComponent();
            Cancelou = true;
        }

        private Boolean m_Cancelou;
        private String m_Impressora;

        public bool Cancelou
        {
            get { return this.m_Cancelou; }
            set { this.m_Cancelou = value; }
        }

        public string Impressora
        {
            get { return cbImpressoras.SelectedItem.ToString(); }
        }

        public string Modelo
        {
            get { return tbModelo.Text; }
        }

        public short NumVias
        {
        get { return (short)Convert.ToInt32(Double.Parse(tbNumeroVias.Text)); }
            
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Cancelou = false;
            this.Close();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Cancelou = true;
            this.Close();
        }
    }



}
