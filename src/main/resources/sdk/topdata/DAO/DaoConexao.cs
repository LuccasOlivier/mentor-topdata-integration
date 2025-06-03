using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SDK_Leitor_Facial.DAO
{
    public class DaoConexao
    {
        private static string CaminhoBD = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\DB\\facialWS.db";
        private static SQLiteConnection Conn;

        public static SQLiteConnection ConectarBase()
        {
            if (Conn == null)
            {

                Conn = new SQLiteConnection("Data Source=" + CaminhoBD + ";Version=3");
                Conn.Open();
            }
            return Conn;
        }

    }
}
