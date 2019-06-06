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

namespace crud03
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Server=desktop-easat3o\\sqlexpress;Database=crud03;User Id=sa;Password=bwy6932guz");
        SqlCommand comando = new SqlCommand();
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LimparCampos();
            ListarTudo();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //inserir dados o banco
            conn.Open();
            SqlCommand comando = new SqlCommand( "insert into aluno(nome, idade, curso) values('" + txtNome.Text + "','" + txtIdade.Text + "','" + txtcurso.Text + "')", conn );
            comando.ExecuteNonQuery();
            LimparCampos();
            ListarTudo();
            conn.Close();
        }

        //*********MEUS METODOS*******************

        //METODO LISTAR TUDO
        private void ListarTudo()
        {
            dataSet = new DataSet();
            dataAdapter = new SqlDataAdapter("select * from aluno order by id ", conn);
            dataAdapter.Fill(dataSet, "aluno");

            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "aluno";
        }
        //METODO LIMPAR CAMPOS
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtIdade.Text = "";
            txtcurso.Text = "";
        }
        //*************************************************
    }
}
