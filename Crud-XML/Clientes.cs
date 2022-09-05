using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace Crud_XML
{
    public class Clientes
    {
        private List<Cliente> clientes;

        public Clientes()
        {
            this.clientes = new List<Cliente>();
        }

        public void Adicionar(Cliente cliente)
        {
            if (this.clientes.Count(c => c.Nome.Equals(cliente.Nome)) > 0)
            {
                throw new Exception("Já existe um Cliente com esse nome!");
            }
            else
            {
                this.clientes.Add(cliente);
            }
        }

        public void Remover(Cliente cliente)
        {
            this.clientes.Remove(cliente);
        }

        public List<Cliente> ListarTodos()
        {

            return this.clientes;
        }

        public void Salvar()

        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("C://POO//Clientes.xml", FileMode.OpenOrCreate);
            ser.Serialize(fs, this.clientes);
            fs.Close();
        }

        public void Carregar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("C://POO//Clientes.xml", FileMode.OpenOrCreate);
            try
            {
                this.clientes = ser.Deserialize(fs) as List<Cliente>;
            }
            catch(InvalidOperationException ex)
            {
                ser.Serialize(fs, this.clientes);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
