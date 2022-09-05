using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Clientes clientes;

        private void Form1_Load(object sender, EventArgs e)
        {
            clientes = new Clientes();
            clientes.Carregar();
            dataGridView1.DataSource = clientes.ListarTodos();

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text; 
            string email = txt_email.Text; 
            if (nome != "" && email != "")
            {
                Cliente cli = new Cliente()
                {
                    Nome = txt_nome.Text,
                    Email = txt_email.Text
                };

                clientes.Adicionar(cli);
                clientes.Salvar();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = clientes.ListarTodos();
            }
            else
            {
                MessageBox.Show("Digite todos os campos!");
            }


        }
    }
}
