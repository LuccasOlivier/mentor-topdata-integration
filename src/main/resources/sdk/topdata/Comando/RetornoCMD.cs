using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SDK_Leitor_Facial.Comando
{
    class RetornoCMD : Cmd
    {
        public string ret { get; set; }
        public bool result { get; set; }
        public string cloudtime { get; set; }

        public override string getCmd()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
