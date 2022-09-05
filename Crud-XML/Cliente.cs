using System;
using System.Collections.Generic;
using System.Text;

namespace Crud_XML
{
    public class Cliente
    {
        private string nome;
        private string email;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


    }
}
