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

namespace crud05
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Server=desktop-easat3o\sqlexpress;Database=crud05;User Id=sa;Password=bwy6932guz");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            ExibirDados();
        }
        private void ExibirDados()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT * FROM Contatos", con);
                adapt.Fill(dt);
                dgvAgenda.DataSource = dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }
        private void LimparDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtNome.Focus();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO Contatos(nome, endereco, celular, telefone, email) VALUES(@nome, @endereco, @celular, @telefone, @email)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserido com sucesso");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    con.Close();
                    ExibirDados();
                    LimparDados();
                }
            }
            else
            {
                MessageBox.Show("Informe todos os dados requeridos");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text !="" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE Contatos SET nome=@nome, endereco=@endereco, celular=@celular, telefone=@telefone, email=@email WHERE id = @id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    throw;
                }
                finally
                {
                    con.Close();
                    ExibirDados();
                    LimparDados();
                }
            }
            else
            {
                MessageBox.Show("Infome os dados requeridos");
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                if (MessageBox.Show("Deseja deletar esse registro?", "Agenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cmd = new SqlCommand("DELETE Contatos WHERE id = @id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro Deletado com sucessso!");

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Erro: " + exc.Message);
                        throw;
                    }
                    finally
                    {
                        con.Close();
                        ExibirDados();
                        LimparDados();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para deletar");
            }
        }
        private void dgvAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgvAgenda.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtNome.Text = dgvAgenda.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEndereco.Text = dgvAgenda.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCelular.Text = dgvAgenda.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTelefone.Text = dgvAgenda.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dgvAgenda.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
