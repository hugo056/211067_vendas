﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace vendas
{
    public class Banco
    {
        //Connection responsável pela conexão com o MySQL
        public static MySqlConnection Conexao;
        //Command responsável pelas instruções SQL a serem executadas
        public static MySqlCommand Comando;
        //Adapter responsável por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;
        //DataTable responsável por ligar o banco de dados em controles com a propriedade DataSource
        public static DataTable dataTabela;

        public static void AbrirConexao()
        {
            try
            {
                //Estabelece os parâmetros para a conexão com o banco de dados
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                //Abre a conexão com o banco de dados
                Conexao.Open();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                //Fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                //Chama a função para a abertura de conexão com o banco
                AbrirConexao();

                //Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas;", Conexao);
                //Executa a Query no MySQL (Raio do Workbench)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cidades" +
                    "(id integer auto_increment primary key, " +
                    "nome char(45), " +
                    "uf char(02)); ", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS marcas" +
                    "(id integer auto_increment primary key, " +
                    "marca char(45)); ", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS categorias" +
                    "(id integer auto_increment primary key, " +
                    "descricao char(45)); ", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS clientes" +
                    "(id integer auto_increment primary key, " +
                    "nome char(45), " +
                    "idCidade integer, " +
                    "dataNasc date," +
                    "renda decimal(10,2), " +
                    "cpf char(14), " +
                    "foto varchar(100), " +
                    "venda boolean);", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS produtos" +
                    "(id integer auto_increment primary key, " +
                    "descricao varchar(45), " +
                    "idCidade integer, " +
                    "idMarca integer," +
                    "estoque decimal(10,3), " +
                    "valorVenda decimal(10,2), " +
                    "foto varchar(100));", Conexao);
                Comando.ExecuteNonQuery();



                //Chama a função para o fechamento de conexão com o banco
                FecharConexao();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
