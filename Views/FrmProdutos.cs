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
    public partial class FrmProdutos : Form
    {
        Produto p;
        public FrmProdutos()
        {
            InitializeComponent();
        }

        void LimparControles()
        {
            txtID.Clear();
            txtDesc.Clear();
            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtValorVenda.Clear();
            txtEstoque.Clear();
            txtNomeParaPesquisa.Clear();
        }

        void CarregarGrid(String pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = p.Consultar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            p = new Produto();
            cboCategoria.DataSource = p.Consultar();
            cboCategoria.DisplayMember = "nome";
            cboCategoria.ValueMember = "id";
            cboMarca.DisplayMember = "marca";
            cboMarca.ValueMember = "id";

            LimparControles();
            CarregarGrid("");
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCategoria.SelectedItem;
                txtDesc.Text = reg["descricao"].ToString();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarGrid(txtNomeParaPesquisa.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregarGrid("");
            LimparControles();
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboMarca.SelectedItem;
                txtDesc.Text = reg["uf"].ToString();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text == "") return;

            p = new Produto()
            {
                descricao = txtDesc.Text,
                idCartegoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = int.Parse(txtEstoque.Text),
                valorVenda = double.Parse(txtValorVenda.Text),
            };
            p.Incluir();

            LimparControles();
            CarregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text == "") return;

            p = new Produto()
            {
                descricao = txtDesc.Text,
                idCartegoria = (int)cboCategoria.SelectedValue,
                idMarca = (int)cboMarca.SelectedValue,
                estoque = int.Parse(txtEstoque.Text),
                valorVenda = double.Parse(txtValorVenda.Text),
            };
            p.Alterar();

            LimparControles();
            CarregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja exlcuir o cliente?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    id = int.Parse(txtID.Text)
                };
                p.Excluir();

                LimparControles();
                CarregarGrid("");
            }
        }
    }
}
