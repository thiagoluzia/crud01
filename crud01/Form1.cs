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

namespace crud01
{
    public partial class Form1 : Form
    {
        //1ºcriar uma conexão
        private SqlConnection mConn;
        private SqlDataAdapter mAdapter;
        private DataSet mDataSet;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVerResultados_Click(object sender, EventArgs e)
        {
            //2ºdefine o dataset
            mDataSet = new DataSet();

            //3ºdefine a string de conexao e criar a conexao
            mConn = new SqlConnection("server=desktop-easat3o\\sqlexpress; Database=crud01; User Id=sa; Password=bwy6932guz");
            mConn.Open();

            //4º Verifica se a conexao esta aberta 
            if (mConn.State == ConnectionState.Open)
            {
                //5ºcria um adapter utilizando a instrução sql para acessar a tabela dados
                mAdapter = new SqlDataAdapter("SELECT * FROM dados ORDER BY ID", mConn);

                //6ºPreenche o dataSet atraves do data adapter
                mAdapter.Fill(mDataSet, "dados");

                //7ºatribui a resultado a propriedade DataSource do DataridView
                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "dados";
            }
        }
    }
}
