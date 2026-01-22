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
            Parametros Parametros;
            InitializeComponent();
        }

        private void FormParametros_Load(object sender, EventArgs e)
        {

        }
        private void FormParametros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja salvar as alteções ?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
                SalvarParametros();
        }
        void SalvarParametros()
        {
            Parametros = new Parametros
            {
                EanVazioInsereId = ckbEanVazioInsereId.Checked,
                ServidorMySQL = txtServidorMySQL.Text,
                BancoMySQL = txtBancoMySQL.Text,
                UsuarioMySQL = txtUsuarioMySQL.Text,
                SenhaMySQL = txtSenhaMySQL.Text
            };
        }
    }
}
