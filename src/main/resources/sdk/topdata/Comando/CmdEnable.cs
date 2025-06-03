using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SDK_Leitor_Facial.Comando
{
    public class CmdEnable : Cmd
    {
        public string cmd { get; set; }

        public override string getCmd()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
