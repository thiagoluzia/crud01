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

namespace crud02
{
    public partial class Form1 : Form
    {
        //1ºCriar a conexao
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter;
        private DataSet mDataset;
        public Form1()
        {
            InitializeComponent();

            //CRIADO POR ULTIMO E POR CONTA - Chamando o metodo de mostrarResultados no datagridview
            mostrarResultado();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Início da Conexão com indicação de qual o servidor, nome de base de dados e utilizar

            /* É aconselhável criar um utilizador com password. Para acrescentar a password é somente
            necessário acrescentar o seguinte código a seguir ao uid=root;password=xxxxx*/
            mConn = new SqlConnection("server=desktop-easat3o\\sqlexpress; Database=crud02; User Id=sa; Password=bwy6932guz");

            //abrir conexao
            mConn.Open();

            //query sql
            SqlCommand comando = new SqlCommand("INSERT INTO tabela_dados (titulo, descricao) VALUES('" + txtTitulo.Text + "','" + txtDescricao.Text + "')", mConn);
                                                
            //executa a query sql
            comando.ExecuteNonQuery();

            //fecha conexao
            mConn.Close();

            //messagem de sucesso
            MessageBox.Show("Gravado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //CRIADO POR ULTIMO E POR CONTA - Limpando os campos apos os dados serem inseridos
            txtTitulo.Text = "";
            txtDescricao.Text = "";

            // Método criado para que quando o registo é gravado, automaticamente a dataGridView efectue um "Refresh"
            mostrarResultado();
        }

        //metodo para visualização de dados
        private void mostrarResultado()
        {
            mDataset = new DataSet();
            mConn = new SqlConnection("server=desktop-easat3o\\sqlexpress; Database=crud02; User Id=sa; Password=bwy6932guz");
            mConn.Open();

            //criar um adapter utilizando a instrução sql  para aceder á tabela
            mAdapter = new SqlDataAdapter("SELECT * FROM tabela_dados ORDER BY id", mConn);

            //preenche o dataset atravez do dataAdapter
            mAdapter.Fill(mDataset, "tabela_dados");

            //atribui o resultado a proriedade datasource da datagridview
            dataGridView1.DataSource = mDataset;
            dataGridView1.DataMember = "tabela_dados";

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //chamando o metodo de visualizar os registros no datagrid
            mostrarResultado();
        }
    }
}
