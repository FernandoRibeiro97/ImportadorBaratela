using ImportadorBaratela.Models.Config;
using System;
using System.Windows.Forms;

namespace ImportadorBaratela.Formularios
{
    public partial class FormParametros : Form
    {
        public Parametros Parametros;
        public FormParametros()
        {
            Parametros = new Parametros();
            InitializeComponent();
        }

        private void FormParametros_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarParametros();
        }

        void SalvarParametros()
        {
            Parametros.EanVazioInsereId = ckbEanVazioInsereId.Checked;
        }

        private void FormParametros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja salvar as alteções ?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                SalvarParametros();
        }

        void PreencherTributacaoPadrao()
        {

        }
    }
}
