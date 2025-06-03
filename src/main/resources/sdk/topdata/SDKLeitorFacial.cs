using SDK_Leitor_Facial.Comando;
using SDK_Leitor_Facial.DAO;
using SDK_Leitor_Facial.Entity;
using SDK_Leitor_Facial.Negocio;
using SDK_Leitor_Facial.WebSocket;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SDK_Leitor_Facial
{
    public partial class SDKLeitorFacial : Form
    {
        private delegate void AtualizaListaStatus(Eventos.NotificarMenssagemParaUsuarioEventArgs e);
        private delegate void AtualizaStatus(bool conectado);
        private delegate void AtualizaEquipamentoAdd(string equipamento);
        private delegate void AtualizaCadastroUsuario(bool retorno, string equipamento);
        private delegate void AtualizaUsuario(bool retorno, Usuario user, string equipamento);
        private delegate void AtualizaConsultaLista(bool sucesso, string equipamento);
        private delegate void AtualizaHabilitarEquipamento(bool habilitar, string equipamento);
        private delegate void AtualizaRecebimentoFoto(RecebimentoFotoRegistro registroFoto);

        public static ConcurrentDictionary<string, Mensagem> item;
        private IDictionary<string, Constantes.ProcessoComunicacao> mapProcessoAtual = new Dictionary<string, Constantes.ProcessoComunicacao>();
        private Dictionary<string, List<Cmd>> mapSeqComando = new Dictionary<string, List<Cmd>>();
        private Dictionary<string, List<long>> mapUserEnvio = new Dictionary<string, List<long>>();
        private Dictionary<string, int> mapQtdEnvio = new Dictionary<string, int>();

        private WebSocketServer wssv;

        RecebimentoFotoRegistro usuarioFoto;
        bool aguardandoFoto = false;
        string fotoRecebida = null;
        private Image imagemProcessada;
        private string imagemRecebida;


        public SDKLeitorFacial()
        {
            InitializeComponent();
        }

        private void conectarPorta()
        {
            ServerRetorno svRet = new ServerRetorno();
            svRet.OnNotificarMenssagemParaUsuario += new EventHandler<Eventos.NotificarMenssagemParaUsuarioEventArgs>(OnUpdateMenssagem);
            svRet.OnNotificarStatusEquipamento += new EventHandler<Eventos.NotificarStatusEquipamentoEventArgs>(OnUpdateStatus);
            svRet.OnNotificarAddEquipamento += new EventHandler<Eventos.NotificarAddEquipamento>(OnUpdateEquipamento);
            svRet.OnNotificarCadastroUsuario += new EventHandler<Eventos.NotificarCadastroUsuario>(OnCadastroUsuario);
            svRet.OnNotificarRetornoUsuario += new EventHandler<Eventos.NotificarRetornoUsuario>(OnRetornoUsuario);
            svRet.OnNotificarConsultaLista += new EventHandler<Eventos.NotificarConsultaLista>(OnConsultaLista);
            svRet.OnNotificarHabilitarDispositivo += new EventHandler<Eventos.NotificarHabilitarDispositivo>(OnHabilitarDispositivo);
            svRet.OnNotificarRecebimentoFoto += new EventHandler<Eventos.NotificarRecebimentoFoto>(OnNotificarRecebimentoFoto);

            this.wssv = new WebSocketServer(Convert.ToInt32(txtPortaServer.Value));
            this.wssv.AddWebSocketService("/pub/chat", () => new Mensagem(svRet));
            //this.wssv.AddWebSocketService<Mensagem>("/pub/chat");
            this.wssv.Stop();
            Thread.Sleep(30);
            this.wssv.Start();

        }

        private void OnNotificarRecebimentoFoto(object sender, Eventos.NotificarRecebimentoFoto e)
        {

            Invoke(new AtualizaRecebimentoFoto(AtualizaRecebimentoImagem), new object[] { e.RegistroFoto });
        }

        private void OnHabilitarDispositivo(object sender, Eventos.NotificarHabilitarDispositivo e)
        {
            Invoke(new AtualizaHabilitarEquipamento(AtualizarHabilitarDispositivo), new object[] { e.Habilitado, e.Equipamento });
        }

        private void OnConsultaLista(object sender, Eventos.NotificarConsultaLista e)
        {
            Invoke(new AtualizaConsultaLista(AtualizarListaUsuario), new object[] { e.Retorno, e.Equipamento });
        }

        private void OnRetornoUsuario(object sender, Eventos.NotificarRetornoUsuario e)
        {
            Invoke(new AtualizaUsuario(AtualizarUsuario), new object[] { e.Retorno, e.User, e.Equipamento });
        }

        private void OnUpdateMenssagem(object sender, Eventos.NotificarMenssagemParaUsuarioEventArgs e)
        {
            Invoke(new AtualizaListaStatus(AtualizarListaStatus), new object[] { e });
        }

        private void OnUpdateStatus(object sender, Eventos.NotificarStatusEquipamentoEventArgs e)
        {
            Invoke(new AtualizaStatus(AtualizarStatus), new object[] { e.Conectado });
        }

        private void OnUpdateEquipamento(object sender, Eventos.NotificarAddEquipamento e)
        {
            Invoke(new AtualizaEquipamentoAdd(AtualizarEquipamento), new object[] { e.Equipamento });
        }

        private void OnCadastroUsuario(object sender, Eventos.NotificarCadastroUsuario e)
        {
            Invoke(new AtualizaCadastroUsuario(AtualizarCadastroUsuario), new object[] { e.Retorno, e.Equipamento });
        }


        private void AtualizaRecebimentoImagem(RecebimentoFotoRegistro registroFoto)
        {
            usuarioFoto = new RecebimentoFotoRegistro();
            Usuario retrornoUsuario = new Usuario();

            if (string.IsNullOrEmpty(registroFoto?.Image))
            {
                //MessageBox.Show("A imagem não está disponível ou é inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes;

            try
            {
                imagemRecebida = registroFoto.Image;
                imageBytes = Convert.FromBase64String(registroFoto.Image);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erro ao converter a imagem. O formato pode estar incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var ms = new MemoryStream(imageBytes))
            {
                Image originalImage = Image.FromStream(ms);
                imagemProcessada = ResizeImage(originalImage, 720, 1280);
                Image resizedImage = ResizeImage(originalImage, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = resizedImage;
                txtCaminhoFoto.Text = "Foto Recebida";
            }

            if (registroFoto.EnrollId == 99999999)
            {
                MessageBox.Show("O Usuário não está cadastrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var usuario = new DaoUsuario().ConsultarUsuario(Convert.ToInt64(registroFoto.EnrollId));
                long usuarioId = usuario.id;

                if (usuarioId == 0)
                {
                    buscarUsuarioPorId(registroFoto.EnrollId);
                    aguardandoFoto = true;
                }
                else
                {
                    txtIdUsuario.Value = usuario.id;
                    txtNomeUsuario.Text = usuario.nome;
                    txtSenhaUsuario.Text = usuario.senha.ToString();
                    txtCartao.Text = usuario.cartao.ToString();
                    switch (usuario.admin)
                    {
                        case 0:
                            cboAdmin.Text = "User";
                            break;
                        case 1:
                            cboAdmin.Text = "Admin";
                            break;
                        case 2:
                            cboAdmin.Text = "Super User";
                            break;
                    }
                    MessageBox.Show("O Usuário já está cadastrado na base.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSalvarFoto_Click(object sender, EventArgs e)
        {
            if (imagemProcessada != null)
            {
                // Cria uma instância do SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Define os filtros para o diálogo
                    saveFileDialog.Filter = "JPEG Image|*.jpg";
                    saveFileDialog.Title = "Salvar Imagem";
                    saveFileDialog.FileName = $"{txtIdUsuario.Value}_{txtNomeUsuario.Text}.jpg";

                    // Abre o diálogo e verifica se o usuário clicou em "Salvar"
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Salva a imagem no formato JPEG
                            imagemProcessada.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                            txtCaminhoFoto.Text = saveFileDialog.FileName;
                            MessageBox.Show("Imagem salva com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao salvar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma imagem disponível para salvar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buscarUsuarioPorId(long id)
        {
            CmdUserInfo cmd = new CmdUserInfo();
            cmd.cmd = "getuserinfo";
            cmd.enrollid = id;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }


        public Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var resizedImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private void AtualizarListaStatus(Eventos.NotificarMenssagemParaUsuarioEventArgs e)
        {
            if (lstStatus.Items.Count > 2000)
            {
                lstStatus.Items.Clear();
            }

            lstStatus.Items.Add(e.Equipamento + ": " + DateTime.Now.ToString("HH:mm:ss:fff") + " - " + e.Msg);
            lstStatus.Items[lstStatus.Items.Count - 1].EnsureVisible();
        }

        private void AtualizarListaUsuario(bool retorno, string equipamento)
        {
            dgvListaUsuario.Rows.Clear();
            List<Cmd> lstCmd = new List<Cmd>();

            foreach (var (key, value) in item[cboEquipamento.SelectedItem.ToString()].mapUsuario)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = value.id.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = value.nome });
                row.Cells.Add(new DataGridViewCheckBoxCell() { Value = value.possuiFoto });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = value.cartao.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = value.senha.ToString() });

                if (value.possuiCartao)
                {
                    CmdUserInfo cmd = new CmdUserInfo();
                    cmd.cmd = "getuserinfo";
                    cmd.enrollid = value.id;
                    cmd.backupnum = (int)Constantes.BackupNum.Cartao;
                    lstCmd.Add(cmd);
                }

                if (value.possuiSenha)
                {
                    CmdUserInfo cmd = new CmdUserInfo();
                    cmd.cmd = "getuserinfo";
                    cmd.enrollid = value.id;
                    cmd.backupnum = (int)Constantes.BackupNum.Senha;
                    lstCmd.Add(cmd);
                }

                dgvListaUsuario.Rows.Add(row);
            }

            if (lstCmd.Count > 0)
            {
                mapSeqComando.Remove(equipamento);
                mapSeqComando.Add(equipamento, lstCmd);
            }
            execultaComandos(equipamento);
        }

        private void execultaComandos(string equipamento)
        {
            if (!mapSeqComando.ContainsKey(equipamento) || mapSeqComando[equipamento].Count == 0)
            {
                if (mapUserEnvio.ContainsKey(equipamento) && mapUserEnvio[equipamento].Count > 0)
                {
                    Usuario user = (new DaoUsuario()).ConsultarUsuario(mapUserEnvio[equipamento][0]);
                    mapUserEnvio[equipamento].RemoveAt(0);
                    if (user != null)
                        montarComando(user, equipamento);
                }
            }

            if (mapSeqComando.ContainsKey(equipamento) && mapSeqComando[equipamento].Count > 0)
            {
                this.enviarComando(mapSeqComando[equipamento][0], equipamento);
            }
            else
            {
                CmdEnable cmd = new CmdEnable();
                cmd.cmd = "enabledevice";
                mapProcessoAtual.Remove(equipamento);
                mapProcessoAtual.Add(equipamento, Constantes.ProcessoComunicacao.Nenhum);
                this.enviarComando(cmd, equipamento);
            }
        }

        private void montarComando(Usuario user, string equipamento)
        {
            List<Cmd> lstCmd = new List<Cmd>();
            if (user.cartao > 0)
            {
                CmdSendUserNum cmd = new CmdSendUserNum();
                cmd.cmd = "setuserinfo";
                cmd.enrollid = user.id;
                cmd.name = user.nome;
                cmd.backupnum = (int)Constantes.BackupNum.Cartao;
                cmd.admin = user.admin;
                cmd.record = user.cartao;
                lstCmd.Add(cmd);
            }

            if (user.senha > 0)
            {
                CmdSendUserNum cmd = new CmdSendUserNum();
                cmd.cmd = "setuserinfo";
                cmd.enrollid = user.id;
                cmd.name = user.nome;
                cmd.backupnum = (int)Constantes.BackupNum.Senha;
                cmd.admin = user.admin;
                cmd.record = user.senha;
                lstCmd.Add(cmd);

            }
            string caminhoFotos = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "fotos\\";
            if (Directory.Exists(caminhoFotos))
            {
                string foto = caminhoFotos;
                if (!File.Exists(foto + user.id.ToString() + ".jpg"))
                {
                    foto = caminhoFotos + user.id.ToString().Substring(
                                          user.id.ToString().Length - 1, 1) + ".jpg";
                }
                if (File.Exists(foto))
                {

                    CmdSendUser cmdFoto = new CmdSendUser();
                    cmdFoto.cmd = "setuserinfo";
                    cmdFoto.enrollid = Convert.ToInt64(user.id.ToString());
                    cmdFoto.name = user.nome;
                    cmdFoto.backupnum = (int)Constantes.BackupNum.Foto;
                    byte[] fotoEmByte = System.IO.File.ReadAllBytes(foto);

                    cmdFoto.record = Convert.ToBase64String(fotoEmByte, 0, fotoEmByte.Length);
                    cmdFoto.admin = user.admin;
                    lstCmd.Add(cmdFoto);
                }
            }

            if (lstCmd.Count > 0)
            {
                mapSeqComando.Remove(equipamento);
                mapSeqComando.Add(equipamento, lstCmd);
            }
        }

        private void AtualizarStatus(bool conectado)
        {
            if (conectado)
            {
                btnStop.Enabled = true;
                grpEquipamento.Enabled = true;
                btnIniciar.Enabled = false;
            }
            else
            {
                cboEquipamento.Items.Clear();

                foreach (KeyValuePair<String, Mensagem> equip in getItem())
                {
                    cboEquipamento.Items.Add(equip.Key);
                }
                if (cboEquipamento.Items.Count > 0)
                    cboEquipamento.SelectedIndex = 0;
            }
        }

        private void AtualizarEquipamento(string equipamento)
        {
            cboEquipamento.Items.Clear();

            foreach (KeyValuePair<String, Mensagem> equip in getItem())
            {
                cboEquipamento.Items.Add(equip.Key);
            }
            cboEquipamento.SelectedIndex = 0;

            if (!mapProcessoAtual.ContainsKey(equipamento))
                mapProcessoAtual.Add(equipamento, Constantes.ProcessoComunicacao.Nenhum);


            /*Verifica se tava em processo de comunicacao*/
            if ((mapSeqComando.ContainsKey(equipamento) && mapSeqComando[equipamento].Count > 0) ||
                 mapUserEnvio.ContainsKey(equipamento) && mapUserEnvio[equipamento].Count > 0)
            {
                CmdEnable cmd = new CmdEnable();
                cmd.cmd = "disabledevice";
                this.enviarComando(cmd, equipamento);
            }
        }

        private void AtualizarUsuario(bool retorno, Usuario user, string equipamento)
        {
            if (aguardandoFoto)
            {
                txtIdUsuario.Value = user.id;
                txtNomeUsuario.Text = $"{user.nome} - Recebido";
                txtSenhaUsuario.Text = user.senha.ToString();
                txtCartao.Text = user.cartao.ToString();
                fotoRecebida = user.foto;

                switch (user.admin)
                {
                    case 0:
                        cboAdmin.Text = "User";
                        break;
                    case 1:
                        cboAdmin.Text = "Admin";
                        break;
                    case 2:
                        cboAdmin.Text = "Super User";
                        break;
                }

            }
            else if (retorno)
            {
                if (user.cartao > 0)
                    txtCartao.Text = Utils.ConvertWg10toWg26(user.cartao.ToString());

                if (user.senha > 0)
                    txtSenhaUsuario.Text = user.senha.ToString();
                if (user.foto != null)
                {
                    byte[] imageBytes;
                    try
                    {
                        imageBytes = Convert.FromBase64String(user.foto);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Erro ao converter a imagem. O formato pode estar incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        Image originalImage = Image.FromStream(ms);
                        Image resizedImage = ResizeImage(originalImage, pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Image = resizedImage;
                        txtCaminhoFoto.Text = null;
                    }
                }
            }
            VerificarRetorno(retorno, equipamento);

            if (this.mapProcessoAtual[equipamento] == Constantes.ProcessoComunicacao.BuscarListaUsuario)
                AtualizarListaUsuario(user, equipamento);

            if (this.mapProcessoAtual[equipamento] == Constantes.ProcessoComunicacao.BaixarFotos)
                BaixarFotoLista(user, equipamento);

        }

        private void BaixarFotoLista(Usuario user, string equipamento)
        {
            string caminho = txtCaminhoFotos.Text;
            if (user.foto != null)
            {
                byte[] fotoemBytes = Convert.FromBase64String(user.foto);
                System.IO.File.WriteAllBytes(@caminho + "\\" + user.id + ".jpg", fotoemBytes);
            }
            execultaComandos(equipamento);
        }

        private void AtualizarListaUsuario(Usuario user, string equipamento)
        {
            for (int i = 0; i < dgvListaUsuario.Rows.Count; i++)
            {
                if (dgvListaUsuario[1, i].Value.Equals(user.id.ToString()))
                {
                    if (user.cartao > 0)
                        dgvListaUsuario[4, i].Value = Utils.ConvertWg10toWg26(user.cartao.ToString());

                    if (user.senha > 0)
                        dgvListaUsuario[5, i].Value = user.senha.ToString();

                    if (user.nome.Length > 0)
                        dgvListaUsuario[2, i].Value = user.nome;

                    break;
                }
            }
            execultaComandos(equipamento);
        }

        private void AtualizarHabilitarDispositivo(bool habilitar, string equipamento)
        {
            if (!habilitar)
            {
                if (this.mapProcessoAtual[equipamento] == Constantes.ProcessoComunicacao.BuscarListaUsuario)
                {
                    CmdGet cmd = new CmdGet();
                    cmd.cmd = "getuserlist";
                    cmd.stn = true;
                    this.enviarComando(cmd, equipamento);
                }

                if (this.mapProcessoAtual[equipamento] == Constantes.ProcessoComunicacao.BaixarFotos ||
                   this.mapProcessoAtual[equipamento] == Constantes.ProcessoComunicacao.EnviarLista ||
                   this.mapProcessoAtual[equipamento] == Constantes.ProcessoComunicacao.ExcluirSelecionados)
                {
                    execultaComandos(equipamento);
                }
            }
        }


        private void btnBuscarLst_Click(object sender, EventArgs e)
        {

            CmdEnable cmd = new CmdEnable();
            cmd.cmd = "disabledevice";
            item[cboEquipamento.SelectedItem.ToString()].mapUsuario = new Dictionary<Int64, Usuario>();
            mapProcessoAtual.Remove(cboEquipamento.SelectedItem.ToString());
            mapProcessoAtual.Add(cboEquipamento.SelectedItem.ToString(), Constantes.ProcessoComunicacao.BuscarListaUsuario);

            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void btnProcurarLocal_Click(object sender, EventArgs e)
        {
            ofDialog.Title = "Selecione a foto do usuário.";
            ofDialog.Filter = "Foto|*.jpg;*.jpeg";
            DialogResult result = ofDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            txtCaminhoFoto.Text = ofDialog.FileName;
        }

        private void btnEnviarFoto_Click(object sender, EventArgs e)
        {
            CmdSendUser cmd = new CmdSendUser();
            cmd.cmd = "setuserinfo";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.name = txtNomeUsuario.Text;
            cmd.backupnum = (int)Constantes.BackupNum.Foto;

            if (txtCaminhoFoto.Text == "Foto Recebida")
            {
                cmd.record = imagemRecebida;
                cmd.admin = cboAdmin.SelectedIndex;
                this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
            }
            else
            {
                byte[] fotoEmByte = System.IO.File.ReadAllBytes(txtCaminhoFoto.Text);
                cmd.record = Convert.ToBase64String(fotoEmByte, 0, fotoEmByte.Length);
                cmd.admin = cboAdmin.SelectedIndex;
                this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
            }
        }


        private void btnBuscarFoto_Click(object sender, EventArgs e)
        {
            CmdUserInfo cmd = new CmdUserInfo();
            cmd.cmd = "getuserinfo";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.backupnum = (int)Constantes.BackupNum.Foto;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void txtSenhaUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != 46)
                    e.Handled = true;
            }
        }

        private void btnSenha_Click(object sender, EventArgs e)
        {
            CmdSendUserNum cmd = new CmdSendUserNum();
            cmd.cmd = "setuserinfo";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.name = txtNomeUsuario.Text;
            cmd.backupnum = (int)Constantes.BackupNum.Senha;
            cmd.admin = cboAdmin.SelectedIndex;
            cmd.record = Convert.ToInt32(txtSenhaUsuario.Text);
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void txtCartao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != 46)
                    e.Handled = true;
            }
        }

        private void btnCartao_Click(object sender, EventArgs e)
        {
            CmdSendUserNum cmd = new CmdSendUserNum();
            cmd.cmd = "setuserinfo";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.name = txtNomeUsuario.Text;
            cmd.backupnum = (int)Constantes.BackupNum.Cartao;
            cmd.admin = cboAdmin.SelectedIndex;
            cmd.record = Convert.ToInt32(Utils.ConvertWg26toWg10(txtCartao.Text));
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());

        }

        private void btnBuscarCartao_Click(object sender, EventArgs e)
        {
            CmdUserInfo cmd = new CmdUserInfo();
            cmd.cmd = "getuserinfo";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.backupnum = (int)Constantes.BackupNum.Cartao;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.wssv.Stop();
            grpEquipamento.Enabled = false;
            btnStop.Enabled = false;
            btnIniciar.Enabled = true;
            mapProcessoAtual = new Dictionary<string, Constantes.ProcessoComunicacao>();
            item = new ConcurrentDictionary<string, Mensagem>();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            CmdUserInfo cmd = new CmdUserInfo();
            cmd.cmd = "deleteuser";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.backupnum = (int)Constantes.BackupNum.Todos;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                item = new ConcurrentDictionary<string, Mensagem>();
            }
            btnStop.Enabled = true;
            this.conectarPorta();
        }
        public static ConcurrentDictionary<string, Mensagem> getItem()
        {
            if (item == null)
            {
                item = new ConcurrentDictionary<string, Mensagem>();
            }
            return item;
        }

        private bool enviarComando(Cmd comando, string equipamento)
        {
            if (item.ContainsKey(equipamento))
            {
                item[equipamento].enviarComando(comando);
                return true;
            }
            return false;
        }

        private void btnLimpaTela_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Clear();
            pictureBox1.Image = null;
        }

        private void AtualizarCadastroUsuario(bool retorno, string equipamento)
        {
            VerificarRetorno(retorno, equipamento);
            execultaComandos(equipamento);
        }

        private void VerificarRetorno(bool retorno, string equipamento)
        {
            if (retorno)
            {
                if (mapSeqComando.ContainsKey(equipamento) && mapSeqComando[equipamento].Count > 0)
                    mapSeqComando[equipamento].RemoveAt(0);
            }
            else
            {
                if (!mapQtdEnvio.ContainsKey(equipamento))
                {
                    mapQtdEnvio.Add(equipamento, 0);
                }
                mapQtdEnvio[equipamento]++;
                /*Não conseguiu enviar o comando, vai para o proximo da fila*/
                if (mapQtdEnvio[equipamento] > 3)
                {
                    if (mapSeqComando.ContainsKey(equipamento) && mapSeqComando[equipamento].Count > 0)
                    {
                        Log.getInstance().EscreveLog("Falha ao Enviar comando: " +
                            equipamento + " - " +
                            mapSeqComando[equipamento][0].getCmd());
                        mapSeqComando[equipamento].RemoveAt(0);
                    }
                    mapQtdEnvio[equipamento] = 0;
                }
            }
        }

        private void btnApagarTodos_Click(object sender, EventArgs e)
        {
            CmdGet cmd = new CmdGet();
            cmd.cmd = "cleanuser";
            enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void btnBuscarSenha_Click(object sender, EventArgs e)
        {
            CmdUserInfo cmd = new CmdUserInfo();
            cmd.cmd = "getuserinfo";
            cmd.enrollid = Convert.ToInt64(txtIdUsuario.Value);
            cmd.backupnum = (int)Constantes.BackupNum.Senha;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void btnBaixarFotos_Click(object sender, EventArgs e)
        {
            if (txtCaminhoFotos.Text.Equals(""))
            {
                return;
            }
            List<Cmd> lstCmd = new List<Cmd>();

            for (int i = 0; i < dgvListaUsuario.Rows.Count; i++)
            {
                if (dgvListaUsuario[0, i].Value != null && (bool)dgvListaUsuario[0, i].Value)
                {
                    if (dgvListaUsuario[3, i].Value != null && (bool)dgvListaUsuario[3, i].Value)
                    {
                        CmdUserInfo cmd = new CmdUserInfo();
                        cmd.cmd = "getuserinfo";
                        cmd.enrollid = Convert.ToInt64(dgvListaUsuario[1, i].Value);
                        cmd.backupnum = (int)Constantes.BackupNum.Foto;
                        lstCmd.Add(cmd);
                    }
                }
            }

            if (lstCmd.Count > 0)
            {
                CmdEnable cmdD = new CmdEnable();
                cmdD.cmd = "disabledevice";
                mapProcessoAtual.Remove(cboEquipamento.SelectedItem.ToString());
                mapProcessoAtual.Add(cboEquipamento.SelectedItem.ToString(), Constantes.ProcessoComunicacao.BaixarFotos);

                mapSeqComando.Remove(cboEquipamento.SelectedItem.ToString());
                mapSeqComando.Add(cboEquipamento.SelectedItem.ToString(), lstCmd);

                this.enviarComando(cmdD, cboEquipamento.SelectedItem.ToString());
            }
        }

        private void btnProcurarDiretorio_Click(object sender, EventArgs e)
        {
            fbDialog.Description = "Selecione a pasta onde será gravado as fotos";
            fbDialog.SelectedPath = "c:\\";

            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
                txtCaminhoFotos.Text = fbDialog.SelectedPath;
        }

        private void carregarGridLocal()
        {
            dgvListaUsuarioEnv.Rows.Clear();
            List<Usuario> lstUsuario = (new DaoUsuario()).ConsultarUsuarios();
            foreach (Usuario user in lstUsuario)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.id });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.nome });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.cartao.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = user.senha.ToString() });
                dgvListaUsuarioEnv.Rows.Add(row);
            }
        }


        private void btnEnviarSel_Click(object sender, EventArgs e)
        {
            List<long> lstUser = new List<long>();
            for (int i = 0; i < dgvListaUsuarioEnv.Rows.Count; i++)
            {
                if (dgvListaUsuarioEnv[1, i].Value != null && (bool)dgvListaUsuarioEnv[0, i].Value)
                {
                    lstUser.Add(Convert.ToInt64(dgvListaUsuarioEnv[1, i].Value.ToString()));
                }
            }

            if (lstUser.Count > 0)
            {
                AtualizarListaStatus(new Eventos.NotificarMenssagemParaUsuarioEventArgs(
                "Carregando comandos da lista", Color.Black, cboEquipamento.SelectedItem.ToString()));
                tabControl1.SelectedIndex = 0;


                mapProcessoAtual.Remove(cboEquipamento.SelectedItem.ToString());
                mapProcessoAtual.Add(cboEquipamento.SelectedItem.ToString(), Constantes.ProcessoComunicacao.EnviarLista);

                mapUserEnvio.Remove(cboEquipamento.SelectedItem.ToString());
                mapUserEnvio.Add(cboEquipamento.SelectedItem.ToString(), lstUser);


                CmdEnable cmdD = new CmdEnable();
                cmdD.cmd = "disabledevice";
                this.enviarComando(cmdD, cboEquipamento.SelectedItem.ToString());
            }
        }

        private void btnAdicionarLista_Click(object sender, EventArgs e)
        {
            if (txtIdUsuario.Value.Equals("0"))
            {
                MessageBox.Show("Informar o Id do Usuário.");
                return;
            }

            if (txtNomeUsuario.Text.Trim().Equals(""))
            {
                MessageBox.Show("Informar o nome do Usuário.");
                return;
            }

            if (txtSenhaUsuario.Text.Trim().Equals(""))
            {
                MessageBox.Show("Informar a senha do Usuário.");
                return;
            }

            if (txtCartao.Text.Trim().Equals(""))
            {
                MessageBox.Show("Informar o cartão do Usuário.");
                return;
            }

            for (int i = 0; i < dgvListaUsuarioEnv.Rows.Count; i++)
            {
                if (dgvListaUsuarioEnv[1, i].Value != null && dgvListaUsuarioEnv[1, i].Value.ToString().Equals(txtIdUsuario.Value.ToString()))
                {
                    if (MessageBox.Show("ID do Usuário já cadastrado, Deseja substiuir?.", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    (new DaoUsuario()).apagar(Convert.ToInt64(txtIdUsuario.Value));
                }
            }
            Usuario user = new Usuario();
            user.id = Convert.ToInt64(txtIdUsuario.Value);
            user.nome = txtNomeUsuario.Text;
            user.cartao = Convert.ToInt32(txtCartao.Text);
            user.senha = Convert.ToInt32(txtSenhaUsuario.Text);
            user.admin = cboAdmin.SelectedIndex;
            user.foto = fotoRecebida;

            (new DaoUsuario()).adicionar(user);
            carregarGridLocal();

            MessageBox.Show("Usuário cadastrado.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cartao = 12855640;
            for (int i = 1; i <= 5000; i++)
            {
                Usuario user = new Usuario();
                user.id = i;
                user.nome = "Nome " + i.ToString();
                user.cartao = cartao;
                user.senha = 123456;
                user.admin = 0;
                cartao++;
                (new DaoUsuario()).adicionar(user);
            }
            carregarGridLocal();
        }

        private void dgvListaUsuarioEnv_MouseDown(object sender, MouseEventArgs e)
        {
            if (dgvListaUsuarioEnv.RowCount > 0)
            {
                contextLocalGrid.Enabled = true;
            }
            else
            {
                contextLocalGrid.Enabled = false;
            }
        }

        private void selecionarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            habilitaTodosUsuarioEnv(true);
        }

        private void habilitaTodosUsuarioEnv(bool habilitaTodos)
        {
            for (int i = 0; i < dgvListaUsuarioEnv.Rows.Count; i++)
            {
                DataGridViewCell cell = dgvListaUsuarioEnv.Rows[i].Cells[0];
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)cell;
                checkCell.Value = habilitaTodos;
                dgvListaUsuarioEnv.RefreshEdit();
            }
        }

        private void habilitaTodosUsuarioEquipamento(bool habilitaTodos)
        {
            for (int i = 0; i < dgvListaUsuario.Rows.Count; i++)
            {
                DataGridViewCell cell = dgvListaUsuario.Rows[i].Cells[0];
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)cell;
                checkCell.Value = habilitaTodos;
                dgvListaUsuario.RefreshEdit();
            }
        }

        private void deselecionarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            habilitaTodosUsuarioEnv(false);
        }

        private void selecionarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            habilitaTodosUsuarioEquipamento(true);
        }

        private void deselecionarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            habilitaTodosUsuarioEquipamento(false);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in lstStatus.Items)
            {
                ListViewItem l = item as ListViewItem;
                if (l != null)
                    foreach (ListViewItem.ListViewSubItem sub in l.SubItems)
                        sb.Append(sub.Text + "\t");
                sb.AppendLine();
            }
            Clipboard.SetDataObject(sb.ToString());

            MessageBox.Show("Copiado para o ClipBoard.");
        }

        private void btnRecebeSel_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;

                for (int i = 0; i < dgvListaUsuario.Rows.Count; i++)
                {
                    if (dgvListaUsuario[0, i].Value != null && (bool)dgvListaUsuario[0, i].Value)
                    {
                        Usuario user = new Usuario();
                        user.id = Convert.ToInt64(dgvListaUsuario[1, i].Value);
                        if (dgvListaUsuario[2, i].Value != null && !dgvListaUsuario[2, i].Value.ToString().IsNullOrEmpty())
                            user.nome = dgvListaUsuario[2, i].Value.ToString();

                        if (dgvListaUsuario[4, i].Value != null && !dgvListaUsuario[4, i].Value.ToString().IsNullOrEmpty())
                            user.cartao = Int32.Parse(dgvListaUsuario[4, i].Value.ToString());

                        if (dgvListaUsuario[5, i].Value != null && !dgvListaUsuario[5, i].Value.ToString().IsNullOrEmpty())
                            user.senha = Int32.Parse(dgvListaUsuario[5, i].Value.ToString());

                        Usuario userValida = (new DaoUsuario()).ConsultarUsuario(user.id);
                        if (userValida != null && userValida.id == user.id)
                            (new DaoUsuario()).atualizar(user);
                        else
                            (new DaoUsuario()).adicionar(user);

                    }
                }

                carregarGridLocal();
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }
            catch
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }
        }

        private void btnApagaEquipamento_Click(object sender, EventArgs e)
        {
            List<Cmd> lstCmd = new List<Cmd>();

            for (int i = 0; i < dgvListaUsuario.Rows.Count; i++)
            {
                if (dgvListaUsuario[0, i].Value != null && (bool)dgvListaUsuario[0, i].Value)
                {
                    CmdUserInfo cmd = new CmdUserInfo();
                    cmd.cmd = "deleteuser";
                    cmd.enrollid = Convert.ToInt64(dgvListaUsuario[1, i].Value);
                    cmd.backupnum = (int)Constantes.BackupNum.Todos;
                    lstCmd.Add(cmd);
                }
            }

            if (lstCmd.Count > 0)
            {

                mapProcessoAtual.Remove(cboEquipamento.SelectedItem.ToString());
                mapProcessoAtual.Add(cboEquipamento.SelectedItem.ToString(), Constantes.ProcessoComunicacao.ExcluirSelecionados);

                mapSeqComando.Remove(cboEquipamento.SelectedItem.ToString());
                mapSeqComando.Add(cboEquipamento.SelectedItem.ToString(), lstCmd);

                CmdEnable cmdD = new CmdEnable();
                cmdD.cmd = "disabledevice";

                this.enviarComando(cmdD, cboEquipamento.SelectedItem.ToString());
            }
        }

        private void SDKLeitorFacial_Load(object sender, EventArgs e)
        {
            cboAdmin.SelectedIndex = 0;
            carregarGridLocal();
        }

        private void btnIniciarReceberfoto_Click(object sender, EventArgs e)
        {
            CmdRecebeFoto cmd = new CmdRecebeFoto();
            cmd.cmd = "setdevinfo";
            cmd.use_logphoto = 1;
            cmd.stranger_photo = 1;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }

        private void btnPararReceberfoto_Click(object sender, EventArgs e)
        {
            CmdRecebeFoto cmd = new CmdRecebeFoto();
            cmd.cmd = "setdevinfo";
            cmd.use_logphoto = 0;
            cmd.stranger_photo = 0;
            this.enviarComando(cmd, cboEquipamento.SelectedItem.ToString());
        }
    }
}
