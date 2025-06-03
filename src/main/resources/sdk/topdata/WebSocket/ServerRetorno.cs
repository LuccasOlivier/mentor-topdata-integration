using SDK_Leitor_Facial.Comando;
using SDK_Leitor_Facial.Entity;
using SDK_Leitor_Facial.Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static SDK_Leitor_Facial.Negocio.Eventos;

namespace SDK_Leitor_Facial.WebSocket
{
    public class ServerRetorno
    {
        public event EventHandler<Eventos.NotificarMenssagemParaUsuarioEventArgs> OnNotificarMenssagemParaUsuario;
        public event EventHandler<Eventos.NotificarStatusEquipamentoEventArgs> OnNotificarStatusEquipamento;
        public event EventHandler<Eventos.NotificarAddEquipamento> OnNotificarAddEquipamento;
        public event EventHandler<Eventos.NotificarCadastroUsuario> OnNotificarCadastroUsuario;
        public event EventHandler<Eventos.NotificarRetornoUsuario> OnNotificarRetornoUsuario;
        public event EventHandler<Eventos.NotificarConsultaLista> OnNotificarConsultaLista;
        public event EventHandler<Eventos.NotificarHabilitarDispositivo> OnNotificarHabilitarDispositivo;
        public event EventHandler<Eventos.NotificarRecebimentoFoto> OnNotificarRecebimentoFoto;


        public void NotificarMenssagem(string menssagem, string equipamento)
        {
            NotificarMenssagem(menssagem, Color.Black, equipamento);
        }


        public void NotificarMenssagem(string menssagem, Color corMensagem, string equipamento)
        {
            Eventos.NotificarMenssagemParaUsuarioEventArgs eNotifica = new Eventos.NotificarMenssagemParaUsuarioEventArgs(menssagem, corMensagem, equipamento);
            if (OnNotificarMenssagemParaUsuario != null)
                OnNotificarMenssagemParaUsuario(typeof(SDKLeitorFacial), eNotifica);
        }

        public void NotificarStatusEquipamento(bool conectado, string equipamento)
        {
            Eventos.NotificarStatusEquipamentoEventArgs eNotifica = new Eventos.NotificarStatusEquipamentoEventArgs(conectado, equipamento);
            if (OnNotificarStatusEquipamento != null)
                OnNotificarStatusEquipamento(typeof(SDKLeitorFacial), eNotifica);
        }

        public void NotificarAddEquipamento(string equipamento)
        {
            Eventos.NotificarAddEquipamento eNotifica = new Eventos.NotificarAddEquipamento(equipamento);
            if (OnNotificarAddEquipamento != null)
                OnNotificarAddEquipamento(typeof(SDKLeitorFacial), eNotifica);
        }

        public void NotificarCadastroUsuario(bool retorno, string equipamento)
        {
            Eventos.NotificarCadastroUsuario eNotifica = new Eventos.NotificarCadastroUsuario(retorno, equipamento);
            if (OnNotificarCadastroUsuario != null)
                OnNotificarCadastroUsuario(typeof(SDKLeitorFacial), eNotifica);
        }

        public void NotificarRetornoUsuario(bool retorno, Usuario user, string equipamento)
        {
            Eventos.NotificarRetornoUsuario eNotifica = new Eventos.NotificarRetornoUsuario(retorno, user, equipamento);
            if (OnNotificarRetornoUsuario != null)
                OnNotificarRetornoUsuario(typeof(SDKLeitorFacial), eNotifica);
        }

        public void NotificarConsultaLista(bool sucesso, string equipamento)
        {
            Eventos.NotificarConsultaLista eNotifica = new Eventos.NotificarConsultaLista(sucesso, equipamento);
            if (OnNotificarConsultaLista != null)
                OnNotificarConsultaLista(typeof(SDKLeitorFacial), eNotifica);
        }

        public void NotificarHabilitarDispositivo(bool habilitar, string equipamento)
        {
            Eventos.NotificarHabilitarDispositivo eNotifica = new Eventos.NotificarHabilitarDispositivo(habilitar, equipamento);
            if (OnNotificarHabilitarDispositivo != null)
                OnNotificarHabilitarDispositivo(typeof(SDKLeitorFacial), eNotifica);
        }

        //public void NotificarRecebimentoFoto(RecebimentoFotoRegistro registroFoto, string equipamento)
        public void NotificarRecebimentoFoto(RecebimentoFotoRegistro registroFoto)
        {
            NotificarRecebimentoFoto eNotifica = new NotificarRecebimentoFoto(registroFoto);
            if (OnNotificarRecebimentoFoto != null)
                OnNotificarRecebimentoFoto(typeof(SDKLeitorFacial), eNotifica);

            //NotificarRecebimentoFoto eventoFoto = new NotificarRecebimentoFoto(registroFoto, equipamento);
            //MessageBox.Show($"Foto recebida do equipamento {eventoFoto.Equipamento}, Foto: {eventoFoto.RegistroFoto.Image}");
        }



    }
}
