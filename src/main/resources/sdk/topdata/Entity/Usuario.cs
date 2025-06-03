using System;
using System.Collections.Generic;
using System.Text;

namespace SDK_Leitor_Facial.Entity
{
    public class Usuario
    {
        public long id { get; set; }
        public string nome { get; set; }
        public bool possuiFoto { get; set; }
        public string foto { get; set; }
        public bool possuiCartao { get; set; }
        public int cartao { get; set; }
        public bool possuiSenha { get; set; }
        public int senha { get; set; }
        public int admin { get; set; }
    }
}
