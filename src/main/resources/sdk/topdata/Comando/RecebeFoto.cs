using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SDK_Leitor_Facial.Comando
{
    public class CmdRecebeFoto : Cmd
    {
        public string cmd { get; set; }
        public int use_logphoto { get; set; }
        public int stranger_photo { get; set; }

        public override string getCmd()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class RecebimentoFotoRegistro
    {
        [JsonPropertyName("enrollid")]
        public int EnrollId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("mode")]
        public int Mode { get; set; }

        [JsonPropertyName("inout")]
        public int InOut { get; set; }

        [JsonPropertyName("event")]
        public int Event { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }

    public class DadosRecebimentoFotos
    {
        [JsonPropertyName("cmd")]
        public string Cmd { get; set; }

        [JsonPropertyName("sn")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("logindex")]
        public int LogIndex { get; set; }

        [JsonPropertyName("record")]
        public List<RecebimentoFotoRegistro> Records { get; set; }
    }

}
