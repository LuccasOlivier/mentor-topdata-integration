using System;
using System.Collections.Generic;
using System.Text;

namespace SDK_Leitor_Facial.Negocio
{
    public class Constantes
    {
        public enum BackupNum
        {
            Senha = 10,
            Cartao = 11,
            Foto = 50,
            Todos = 13
        }

        public enum ProcessoComunicacao
        {
            Nenhum = 0,
            BuscarListaUsuario = 1,
            BaixarFotos = 2,
            EnviarLista = 3,
            ExcluirSelecionados = 4
        }
    }
}
