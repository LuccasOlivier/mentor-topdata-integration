using SDK_Leitor_Facial.Comando;
using SDK_Leitor_Facial.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SDK_Leitor_Facial.Negocio
{
    public class Eventos
    {
        public class NotificarMenssagemParaUsuarioEventArgs : EventArgs
        {
            private string _msg;
            private Color _corMensagem;
            private string _equipamento;


            public NotificarMenssagemParaUsuarioEventArgs(string msg, Color cor, string equipamento)
            {
                _msg = msg;
                _corMensagem = cor;
                _equipamento = equipamento;
            }

            public string Msg
            {
                get { return _msg; }
            }

            public Color corMensagem
            {
                get { return _corMensagem; }
            }
            public string Equipamento
            {
                get { return _equipamento; }
            }

        }

        public class NotificarStatusEquipamentoEventArgs : EventArgs
        {
            private bool _conectado;
            private string _equipamento;
            public NotificarStatusEquipamentoEventArgs(bool conectado, string equipamento)
            {
                _conectado = conectado;
                _equipamento = equipamento;
            }

            public bool Conectado
            {
                get { return _conectado; }
            }

            public string Equipamento
            {
                get { return _equipamento; }
            }
        }

        public class NotificarAddEquipamento : EventArgs
        {
            private string _equipamento;

            public NotificarAddEquipamento(string equipamento)
            {
                _equipamento = equipamento;
            }
            public string Equipamento
            {
                get { return _equipamento; }
            }
        }

        public class NotificarCadastroUsuario : EventArgs
        {
            private bool _retorno;
            private string _equipamento;
            public NotificarCadastroUsuario(bool retorno, string equipamento)
            {
                _retorno = retorno;
                _equipamento = equipamento;
            }

            public bool Retorno
            {
                get { return _retorno; }
            }
            public string Equipamento
            {
                get { return _equipamento; }
            }
        }

        public class NotificarRetornoUsuario : EventArgs
        {
            private bool _retorno;
            private Usuario _user;
            private string _equipamento;

            public NotificarRetornoUsuario(bool retorno, Usuario user, string equipamento)
            {
                _retorno = retorno;
                _user = user;
                _equipamento = equipamento;
            }
            public bool Retorno
            {
                get { return _retorno; }
            }

            public Usuario User
            {
                get { return _user; }
            }

            public string Equipamento
            {
                get { return _equipamento; }
            }
        }

        public class NotificarConsultaLista : EventArgs
        {
            private bool _retorno;
            private string _equipamento;
            public NotificarConsultaLista(bool retorno, string equipamento)
            {
                _retorno = retorno;
                _equipamento = equipamento;
            }

            public bool Retorno
            {
                get { return _retorno; }
            }

            public string Equipamento
            {
                get { return _equipamento; }
            }
        }

        public class NotificarHabilitarDispositivo : EventArgs
        {
            private bool _habilitado;
            private string _equipamento;
            public NotificarHabilitarDispositivo(bool habilitado, string equipamento)
            {
                _habilitado = habilitado;
                _equipamento = equipamento;
            }

            public bool Habilitado
            {
                get { return _habilitado; }
            }

            public string Equipamento
            {
                get { return _equipamento; }
            }

        }

        public class NotificarRecebimentoFoto : EventArgs
        {
            private RecebimentoFotoRegistro _registroFoto;
            private string _equipamento;
            private string registroFoto;
            private string equipamento;

            public NotificarRecebimentoFoto(RecebimentoFotoRegistro registroFoto)
            {
                _registroFoto = registroFoto;
                _equipamento = equipamento;
            }

            //public NotificarRecebimentoFoto(string registroFoto, string equipamento)
            //{
            //    this.registroFoto = registroFoto;
            //    this.equipamento = equipamento;
            //}

            public RecebimentoFotoRegistro RegistroFoto
            {
                get { return _registroFoto; }
            }

            public string Equipamento
            {
                get { return _equipamento; }
            }
        }



    }
}
