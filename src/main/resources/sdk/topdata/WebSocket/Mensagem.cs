using Newtonsoft.Json.Linq;
using SDK_Leitor_Facial.Comando;
using SDK_Leitor_Facial.Entity;
using SDK_Leitor_Facial.Negocio;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SDK_Leitor_Facial.WebSocket
{
    public class Mensagem : WebSocketBehavior
    {
        public ServerRetorno svRetorno;
        public Dictionary<Int64, Usuario> mapUsuario;
        private string equipamento = "";

        public Mensagem(ServerRetorno i)
        {
            this.svRetorno = i;
        }

        protected override void OnMessage(MessageEventArgs e)
        {

            try
            {
                this.svRetorno.NotificarMenssagem("Retorno : " + e.Data, this.equipamento);
                JObject json = JObject.Parse(e.Data);

                if (!(json["cmd"] is null))
                {
                    if (json["cmd"].ToString().Equals("reg"))
                    {
                        CmdReg comando = JsonSerializer.Deserialize<CmdReg>(e.Data);
                        AdicionarConexao(comando);
                        Thread.Sleep(30);
                        equipamento = comando.sn;
                        this.svRetorno.NotificarAddEquipamento(comando.sn);
                    }
                    else if (json["cmd"].ToString().Equals("sendlog"))
                    {
                        DadosRecebimentoFotos comando = JsonSerializer.Deserialize<DadosRecebimentoFotos>(e.Data);

                        if (comando.Records != null && comando.Records.Count > 0)
                        {
                            var registroFoto = comando.Records[0];

                            this.svRetorno.NotificarRecebimentoFoto(registroFoto);

                        }
                    }


                    RetornoCMD retorno = new RetornoCMD();
                    retorno.ret = json["cmd"].ToString();
                    retorno.result = true;
                    retorno.cloudtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    this.enviarComando(retorno);
                }
                else if (!(json["ret"] is null))
                {
                    tratarRetorno(e, json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AdicionarConexao(CmdReg comando)
        {
            try
            {
                lock (SDKLeitorFacial.getItem())
                {
                    if (SDKLeitorFacial.getItem().ContainsKey(comando.sn))
                        SDKLeitorFacial.getItem()[comando.sn] = this;
                    else
                        SDKLeitorFacial.getItem().TryAdd(comando.sn, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void tratarRetorno(MessageEventArgs e, JObject json)
        {
            try
            {
                if (json["ret"].ToString().Equals("getuserlist"))
                {
                    if (json["result"].ToString().Equals("True"))
                    {
                        if (json["count"].ToString().Equals("0"))
                        {
                            //this.mostarUsuario();
                            this.svRetorno.NotificarConsultaLista(true, this.equipamento);
                            this.svRetorno.NotificarMenssagem("Fim da consulta", this.equipamento);
                        }
                        else
                        {
                            RetornoLista listaRet = JsonSerializer.Deserialize<RetornoLista>(e.Data);
                            this.montarMapUsuario(listaRet);
                            CmdGet cmd = new CmdGet();
                            cmd.cmd = "getuserlist";
                            cmd.stn = false;
                            this.enviarComando(cmd);
                            this.svRetorno.NotificarMenssagem("Consultando", this.equipamento);
                        }
                    }
                    else
                    {
                        this.svRetorno.NotificarMenssagem("Falha ao pedir a lista : " + e.Data, this.equipamento);
                    }

                }
                else if (json["ret"].ToString().Equals("getuserinfo"))
                {
                    if (json["result"].ToString().Equals("True"))
                    {
                        if (json["backupnum"].ToString().Equals(Convert.ToInt32(Constantes.BackupNum.Senha).ToString()))
                        {
                            RetornoUsuario retUsu = JsonSerializer.Deserialize<RetornoUsuario>(e.Data);
                            Usuario user = new Usuario();
                            user.id = retUsu.enrollid;
                            user.nome = retUsu.name;
                            user.senha = retUsu.record;
                            this.svRetorno.NotificarRetornoUsuario(retUsu.result, user, this.equipamento);
                        }
                        if (json["backupnum"].ToString().Equals(Convert.ToInt32(Constantes.BackupNum.Cartao).ToString()))
                        {
                            RetornoUsuario retUsu = JsonSerializer.Deserialize<RetornoUsuario>(e.Data);
                            Usuario user = new Usuario();
                            user.id = retUsu.enrollid;
                            user.nome = retUsu.name;
                            user.cartao = retUsu.record;
                            this.svRetorno.NotificarRetornoUsuario(retUsu.result, user, this.equipamento);
                        }
                        if (json["backupnum"].ToString().Equals(Convert.ToInt32(Constantes.BackupNum.Foto).ToString()))
                        {
                            RetornoFoto retFoto = JsonSerializer.Deserialize<RetornoFoto>(e.Data);
                            Usuario user = new Usuario();
                            user.id = retFoto.enrollid;
                            user.nome = retFoto.name;
                            user.foto = retFoto.record;
                            this.svRetorno.NotificarRetornoUsuario(retFoto.result, user, this.equipamento);
                        }
                        
                    }
                    else
                    {
                        if (json["backupnum"].ToString().Equals("0"))
                        {
                            RetornoUsuario retornoUsuario = JsonSerializer.Deserialize<RetornoUsuario>(e.Data);
                            Usuario user = new Usuario();
                            user.id = retornoUsuario.enrollid;
                            user.nome = retornoUsuario.name;
                            user.cartao = retornoUsuario.card;
                            user.senha = retornoUsuario.pwd;
                            user.admin = retornoUsuario.admin;
                            this.svRetorno.NotificarRetornoUsuario(retornoUsuario.result, user, this.equipamento);
                        }
                        else
                        {
                            RetornoUsuario ret = JsonSerializer.Deserialize<RetornoUsuario>(e.Data);
                            this.svRetorno.NotificarRetornoUsuario(ret.result, (new Usuario()), this.equipamento);
                        }
                    }
                }
                else if (json["ret"].ToString().Equals("setuserinfo"))
                {
                    RetornoUsuario ret = JsonSerializer.Deserialize<RetornoUsuario>(e.Data);
                    this.svRetorno.NotificarCadastroUsuario(ret.result, ret.sn);

                }
                else if (json["ret"].ToString().Equals("deleteuser"))
                {
                    RetornoUsuario ret = JsonSerializer.Deserialize<RetornoUsuario>(e.Data);
                    this.svRetorno.NotificarCadastroUsuario(ret.result, this.equipamento);

                }
                else if (json["ret"].ToString().Equals("disabledevice"))
                {
                    if (json["result"].ToString().ToLower().Equals("true"))
                    {
                        this.svRetorno.NotificarHabilitarDispositivo(false, this.equipamento);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void montarMapUsuario(RetornoLista listaRet)
        {
            try
            {
                foreach (DadoListaUsuario user in listaRet.record)
                {
                    Usuario userMap = new Usuario();
                    userMap.id = user.enrollid;
                    if (this.mapUsuario.ContainsKey(user.enrollid))
                    {
                        userMap = mapUsuario[user.enrollid];
                        this.mapUsuario.Remove(user.enrollid);
                    }

                    switch (user.backupnum)
                    {
                        case ((int)Constantes.BackupNum.Cartao):
                            userMap.possuiCartao = true;
                            break;
                        case ((int)Constantes.BackupNum.Foto):
                            userMap.possuiFoto = true;
                            break;
                        case ((int)Constantes.BackupNum.Senha):
                            userMap.possuiSenha = true;
                            break;
                    }
                    this.mapUsuario.Add(user.enrollid, userMap);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnOpen()
        {
            this.svRetorno.NotificarStatusEquipamento(true, this.equipamento);
            this.svRetorno.NotificarMenssagem("Equipamento Conectado!", this.equipamento);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Mensagem value;
            SDKLeitorFacial.getItem().TryRemove(this.equipamento, out value);

            this.svRetorno.NotificarStatusEquipamento(false, this.equipamento);
            this.svRetorno.NotificarMenssagem("Equipamento Desconectado! " + e.ToString(), this.equipamento);
        }

        public void enviarComando(Cmd comando)
        {
            try
            {
                Send(comando.getCmd());
                this.svRetorno.NotificarMenssagem("Enviar comando! " + comando.getCmd(), this.equipamento);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
