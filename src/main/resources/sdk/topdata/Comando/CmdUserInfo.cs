using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SDK_Leitor_Facial.Comando
{
    class CmdUserInfo : Cmd
    {
        public string cmd { get; set; }
        public Int64 enrollid { get; set; }
        public int backupnum { get; set; }
        public string name { get; set; }

        public override string getCmd()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
