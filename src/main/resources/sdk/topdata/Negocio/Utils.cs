using System;
using System.Collections.Generic;
using System.Text;

namespace SDK_Leitor_Facial.Negocio
{
    public static class Utils
    {
        public static string ConvertWg10toWg26(string cartao)
        {
            string numHex = Int32.Parse(cartao).ToString("x").PadLeft(8, '0');
            return (Convert.ToInt32(numHex.Substring(2, 2), 16).ToString().PadLeft(3,'0') +
                   Convert.ToInt32(numHex.Substring(4, 4), 16).ToString().PadLeft(5,'0'));
        }


        public static string ConvertWg26toWg10(string cartao)
        {
            string numHex = Int32.Parse(cartao.PadLeft(8, '0').Substring(0, 3)).ToString("x") +
                            Int32.Parse(cartao.PadLeft(8, '0').Substring(3)).ToString("x").PadLeft(4,'0');
            return Convert.ToInt32(numHex, 16).ToString();
        }
    }
}
