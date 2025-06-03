using SDK_Leitor_Facial.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDK_Leitor_Facial.Comando
{
    public class RetornoLista
    {
        public string ret { get; set; }
        public bool result { get; set; }
        public int count { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public List<DadoListaUsuario> record { get; set; }
    }
}
