using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SDK_Leitor_Facial.Negocio
{
    public class Log
    {
        private static Log objetoUnico;
        public static Log getInstance()
        {
            if (objetoUnico == null)
            {
                objetoUnico = new Log();
            }
            return objetoUnico;
        }

        public Log()
        {
            //Topdriver.Utils.NomeSistma = "DriverRepTopdata";
            this.diretorioLog = CriaDiretorioLog();
        }

        private string diretorioLog = "";

        public void EscreveLog(string info)
        {
            try
            {
                StreamWriter escreve = null;
                string caminho = this.diretorioLog + "\\LOG_" + DateTime.Now.ToString("dd.MM") + ".txt";


                Thread.BeginCriticalRegion();
                escreve = new StreamWriter(caminho, true);
                escreve.WriteLine(info);

                escreve.Dispose();
                escreve.Close();
                Thread.EndCriticalRegion();
            }
            catch (Exception)
            {
            }
        }

        private static string CriaDiretorioLog()
        {
            string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\LOG";

            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
            return caminho;
        }
    }
}
