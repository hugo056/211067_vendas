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
    public partial class FrmCategorias : Form
    {
        Categorias ct;
        public FrmCategorias()
        {
            InitializeComponent();
        }
        void LimparControles()
        {
            txtID.Clear();
            txtDesc.Clear();
            txtNomeParaPesquisa.Clear();
        }

        void CarregarGrid(String pesquisa)
        {
            ct = new Categorias()
            {
                descricao = pesquisa
            };
            dgvCategorias.DataSource = ct.Consultar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text == String.Empty) return;

            ct = new Categorias()
            {
                descricao = txtDesc.Text
            };

            ct.Incluir();

            LimparControles();
            CarregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            ct = new Categorias()
            {
                id = int.Parse(txtID.Text),
                descricao = txtDesc.Text
            };
            ct.Alterar();

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

            if (MessageBox.Show("Deseja excluir a categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ct = new Categorias()
                {
                    id = int.Parse(txtID.Text)
                };
                ct.Excluir();

                LimparControles();
                CarregarGrid("");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtNomeParaPesquisa.Text);
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            LimparControles();
            CarregarGrid("");
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.RowCount > 0)
            {
                txtID.Text = dgvCategorias.CurrentRow.Cells["id"].Value.ToString();
                txtDesc.Text = dgvCategorias.CurrentRow.Cells["descricao"].Value.ToString();            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
