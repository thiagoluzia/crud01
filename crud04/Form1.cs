using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud04
{
    public partial class Form1 : Form
    {
        //********PRINCIPAL A SER UTILIZADO*********
        SqlConnection mConexao = new SqlConnection("Server=desktop-easat3o\\sqlexpress; Database=crud04;User Id=sa;Password=bwy6932guz");
        SqlCommand mComando = new SqlCommand();
        DataSet mDataSet;
        SqlDataAdapter mDataAdapter;

        //**********METODOS***********
        //LISTAR DADOS
        private void ListarClientes()
        {
            mDataSet = new DataSet();
            mConexao = new SqlConnection("Server=desktop-easat3o\\sqlexpress; Database=crud04;User Id=sa;Password=bwy6932guz");
            mConexao.Open();

            mDataAdapter = new SqlDataAdapter("SELECT * FROM tabelaClientes ORDER BY id", mConexao);
            mDataAdapter.Fill(mDataSet, "tabelaClientes");

            dgClientes.DataSource = mDataSet;
            dgClientes.DataMember = "tabelaClientes";

        }

        //LIMPAR CAMPOS
        private void LimpaCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
        }
        //METODO  - CADASTRAR CLIENTE
        private void CadastarCliente()
        {
            mConexao = new SqlConnection("Server=desktop-easat3o\\sqlexpress; Database=crud04;User Id=sa;Password=bwy6932guz");
            mConexao.Open();
            mComando = new SqlCommand("INSERT INTO tabelaClientes(nome, email, telefone, endereco) VALUES('" + txtNome.Text + "','" + txtEmail.Text + "', '" + txtTelefone.Text + "', '" + txtEndereco.Text + "')", mConexao);
            mComando.ExecuteNonQuery();
            mConexao.Close();
            ListarClientes();

        }

        //***************TRABALHANDO COM ALGUNS METODS****************************

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastarCliente();
            LimpaCampos();
        }
    }
}
