using vendas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vendas.Views
{
    public partial class FrmMarcas : Form
    {
        Marcas m;
        public FrmMarcas()
        {
            InitializeComponent();
        }
        void LimparControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtNomeParaPesquisa.Clear();
        }

        void CarregarGrid(String pesquisa)
        {
            m = new Marcas()
            {
                marca = pesquisa
            };
            dgvMarcas.DataSource = m.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;

            m = new Marcas()
            {
                marca = txtMarca.Text
            };

            m.Incluir();

            LimparControles();
            CarregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            m = new Marcas()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text
            };
            m.Alterar();

            LimparControles();
            CarregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m = new Marcas()
                {
                    id = int.Parse(txtID.Text)
                };
                m.Excluir();

                LimparControles();
                CarregarGrid("");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtNomeParaPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }
    }
}
