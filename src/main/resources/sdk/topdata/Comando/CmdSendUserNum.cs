using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SDK_Leitor_Facial.Comando
{
    public class CmdSendUserNum : Cmd
    {
        public string cmd { get; set; }
        public long enrollid { get; set; }
        public string name { get; set; }
        public int backupnum { get; set; }
        public int admin { get; set; }
        public int record { get; set; }
        public override string getCmd()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
