using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SDK_Leitor_Facial.Comando
{
    public class RetornoUsuario
    {
        [JsonPropertyName("ret")]
        public string ret { get; set; }

        [JsonPropertyName("sn")]
        public string sn { get; set; }

        [JsonPropertyName("result")]
        public bool result { get; set; }

        [JsonPropertyName("enrollid")]
        public long enrollid { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("admin")]
        public int admin { get; set; }

        [JsonPropertyName("card")]
        public int card { get; set; }

        [JsonPropertyName("pwd")]
        public int pwd { get; set; }

        [JsonPropertyName("backupnum")]
        public int backupnum { get; set; }

        [JsonPropertyName("record")]
        public int record { get; set; }
    }
}
