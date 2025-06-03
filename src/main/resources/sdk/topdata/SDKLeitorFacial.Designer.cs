namespace SDK_Leitor_Facial
{
    partial class SDKLeitorFacial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpConectar = new System.Windows.Forms.GroupBox();
            btnIniciar = new System.Windows.Forms.Button();
            btnStop = new System.Windows.Forms.Button();
            txtPortaServer = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            grpEquipamento = new System.Windows.Forms.GroupBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnPararReceberFoto = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnIniciarReceberFoto = new System.Windows.Forms.Button();
            btnCopy = new System.Windows.Forms.Button();
            cboAdmin = new System.Windows.Forms.ComboBox();
            btnAdicionarLista = new System.Windows.Forms.Button();
            btnBuscarSenha = new System.Windows.Forms.Button();
            btnLimpaTela = new System.Windows.Forms.Button();
            lstStatus = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            btnApagarTodos = new System.Windows.Forms.Button();
            btnApagar = new System.Windows.Forms.Button();
            btnBuscarCartao = new System.Windows.Forms.Button();
            btnCartao = new System.Windows.Forms.Button();
            txtCartao = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            btnSenha = new System.Windows.Forms.Button();
            txtSenhaUsuario = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            btnBuscarFoto = new System.Windows.Forms.Button();
            btnEnviarFoto = new System.Windows.Forms.Button();
            btnProcurarLocal = new System.Windows.Forms.Button();
            txtCaminhoFoto = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtNomeUsuario = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtIdUsuario = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            groupBox3 = new System.Windows.Forms.GroupBox();
            btnEnviarSel = new System.Windows.Forms.Button();
            dgvListaUsuarioEnv = new System.Windows.Forms.DataGridView();
            dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            contextLocalGrid = new System.Windows.Forms.ContextMenuStrip(components);
            selecionarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deselecionarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnApagaEquipamento = new System.Windows.Forms.Button();
            btnRecebeSel = new System.Windows.Forms.Button();
            btnBaixarFotos = new System.Windows.Forms.Button();
            btnProcurarDiretorio = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            txtCaminhoFotos = new System.Windows.Forms.TextBox();
            dgvListaUsuario = new System.Windows.Forms.DataGridView();
            Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            foto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            cartao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            contextEquipamento = new System.Windows.Forms.ContextMenuStrip(components);
            selecionarTodosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            deselecionarTodosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            cboEquipamento = new System.Windows.Forms.ComboBox();
            btnBuscarLst = new System.Windows.Forms.Button();
            ofDialog = new System.Windows.Forms.OpenFileDialog();
            fbDialog = new System.Windows.Forms.FolderBrowserDialog();
            button1 = new System.Windows.Forms.Button();
            grpConectar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPortaServer).BeginInit();
            grpEquipamento.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIdUsuario).BeginInit();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaUsuarioEnv).BeginInit();
            contextLocalGrid.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaUsuario).BeginInit();
            contextEquipamento.SuspendLayout();
            SuspendLayout();
            // 
            // grpConectar
            // 
            grpConectar.Controls.Add(btnIniciar);
            grpConectar.Controls.Add(btnStop);
            grpConectar.Controls.Add(txtPortaServer);
            grpConectar.Controls.Add(label1);
            grpConectar.Location = new System.Drawing.Point(6, 12);
            grpConectar.Name = "grpConectar";
            grpConectar.Size = new System.Drawing.Size(611, 58);
            grpConectar.TabIndex = 0;
            grpConectar.TabStop = false;
            grpConectar.Text = "Conectar";
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new System.Drawing.Point(429, 22);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new System.Drawing.Size(75, 23);
            btnIniciar.TabIndex = 4;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new System.Drawing.Point(524, 22);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Parar";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtPortaServer
            // 
            txtPortaServer.Location = new System.Drawing.Point(50, 28);
            txtPortaServer.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            txtPortaServer.Name = "txtPortaServer";
            txtPortaServer.Size = new System.Drawing.Size(96, 23);
            txtPortaServer.TabIndex = 2;
            txtPortaServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtPortaServer.Value = new decimal(new int[] { 7792, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Porta:";
            // 
            // grpEquipamento
            // 
            grpEquipamento.Controls.Add(tabControl1);
            grpEquipamento.Controls.Add(cboEquipamento);
            grpEquipamento.Controls.Add(btnBuscarLst);
            grpEquipamento.Enabled = false;
            grpEquipamento.Location = new System.Drawing.Point(6, 78);
            grpEquipamento.Name = "grpEquipamento";
            grpEquipamento.Size = new System.Drawing.Size(1034, 498);
            grpEquipamento.TabIndex = 2;
            grpEquipamento.TabStop = false;
            grpEquipamento.Text = "Equipamento";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(6, 52);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1022, 440);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1014, 412);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Comandos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(btnPararReceberFoto);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(btnIniciarReceberFoto);
            groupBox1.Controls.Add(btnCopy);
            groupBox1.Controls.Add(cboAdmin);
            groupBox1.Controls.Add(btnAdicionarLista);
            groupBox1.Controls.Add(btnBuscarSenha);
            groupBox1.Controls.Add(btnLimpaTela);
            groupBox1.Controls.Add(lstStatus);
            groupBox1.Controls.Add(btnApagarTodos);
            groupBox1.Controls.Add(btnApagar);
            groupBox1.Controls.Add(btnBuscarCartao);
            groupBox1.Controls.Add(btnCartao);
            groupBox1.Controls.Add(txtCartao);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnSenha);
            groupBox1.Controls.Add(txtSenhaUsuario);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnBuscarFoto);
            groupBox1.Controls.Add(btnEnviarFoto);
            groupBox1.Controls.Add(btnProcurarLocal);
            groupBox1.Controls.Add(txtCaminhoFoto);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNomeUsuario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtIdUsuario);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new System.Drawing.Point(5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1003, 432);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = " ";
            // 
            // btnPararReceberFoto
            // 
            btnPararReceberFoto.Location = new System.Drawing.Point(702, 83);
            btnPararReceberFoto.Name = "btnPararReceberFoto";
            btnPararReceberFoto.Size = new System.Drawing.Size(127, 23);
            btnPararReceberFoto.TabIndex = 28;
            btnPararReceberFoto.Text = "Parar Receber Foto";
            btnPararReceberFoto.UseVisualStyleBackColor = true;
            btnPararReceberFoto.Click += btnPararReceberfoto_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.Location = new System.Drawing.Point(555, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(90, 160);
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // btnIniciarReceberFoto
            // 
            btnIniciarReceberFoto.Location = new System.Drawing.Point(702, 49);
            btnIniciarReceberFoto.Name = "btnIniciarReceberFoto";
            btnIniciarReceberFoto.Size = new System.Drawing.Size(127, 23);
            btnIniciarReceberFoto.TabIndex = 5;
            btnIniciarReceberFoto.Text = "Iniciar Receber Foto";
            btnIniciarReceberFoto.UseVisualStyleBackColor = true;
            btnIniciarReceberFoto.Click += btnIniciarReceberfoto_Click;
            // 
            // btnCopy
            // 
            btnCopy.Location = new System.Drawing.Point(902, 115);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(88, 23);
            btnCopy.TabIndex = 26;
            btnCopy.Text = "CopyBoard";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // cboAdmin
            // 
            cboAdmin.FormattingEnabled = true;
            cboAdmin.Items.AddRange(new object[] { "User", "Admin", "Super User" });
            cboAdmin.Location = new System.Drawing.Point(181, 15);
            cboAdmin.Name = "cboAdmin";
            cboAdmin.Size = new System.Drawing.Size(120, 23);
            cboAdmin.TabIndex = 25;
            // 
            // btnAdicionarLista
            // 
            btnAdicionarLista.Location = new System.Drawing.Point(369, 173);
            btnAdicionarLista.Name = "btnAdicionarLista";
            btnAdicionarLista.Size = new System.Drawing.Size(127, 23);
            btnAdicionarLista.TabIndex = 24;
            btnAdicionarLista.Text = "Adicionar Lista";
            btnAdicionarLista.UseVisualStyleBackColor = true;
            btnAdicionarLista.Click += btnAdicionarLista_Click;
            // 
            // btnBuscarSenha
            // 
            btnBuscarSenha.Location = new System.Drawing.Point(406, 115);
            btnBuscarSenha.Name = "btnBuscarSenha";
            btnBuscarSenha.Size = new System.Drawing.Size(90, 23);
            btnBuscarSenha.TabIndex = 23;
            btnBuscarSenha.Text = "Buscar Senha";
            btnBuscarSenha.UseVisualStyleBackColor = true;
            btnBuscarSenha.Click += btnBuscarSenha_Click;
            // 
            // btnLimpaTela
            // 
            btnLimpaTela.Location = new System.Drawing.Point(902, 144);
            btnLimpaTela.Name = "btnLimpaTela";
            btnLimpaTela.Size = new System.Drawing.Size(88, 23);
            btnLimpaTela.TabIndex = 22;
            btnLimpaTela.Text = "Limpar";
            btnLimpaTela.UseVisualStyleBackColor = true;
            btnLimpaTela.Click += btnLimpaTela_Click;
            // 
            // lstStatus
            // 
            lstStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1 });
            lstStatus.HideSelection = false;
            lstStatus.Location = new System.Drawing.Point(6, 211);
            lstStatus.Name = "lstStatus";
            lstStatus.Size = new System.Drawing.Size(991, 180);
            lstStatus.TabIndex = 21;
            lstStatus.UseCompatibleStateImageBehavior = false;
            lstStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "";
            columnHeader1.Width = 900;
            // 
            // btnApagarTodos
            // 
            btnApagarTodos.Location = new System.Drawing.Point(406, 49);
            btnApagarTodos.Name = "btnApagarTodos";
            btnApagarTodos.Size = new System.Drawing.Size(90, 23);
            btnApagarTodos.TabIndex = 19;
            btnApagarTodos.Text = "Apagar todos";
            btnApagarTodos.UseVisualStyleBackColor = true;
            btnApagarTodos.Click += btnApagarTodos_Click;
            // 
            // btnApagar
            // 
            btnApagar.Location = new System.Drawing.Point(310, 49);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new System.Drawing.Size(90, 23);
            btnApagar.TabIndex = 17;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            // 
            // btnBuscarCartao
            // 
            btnBuscarCartao.Location = new System.Drawing.Point(406, 144);
            btnBuscarCartao.Name = "btnBuscarCartao";
            btnBuscarCartao.Size = new System.Drawing.Size(90, 23);
            btnBuscarCartao.TabIndex = 15;
            btnBuscarCartao.Text = "Buscar Cartão";
            btnBuscarCartao.UseVisualStyleBackColor = true;
            btnBuscarCartao.Click += btnBuscarCartao_Click;
            // 
            // btnCartao
            // 
            btnCartao.Location = new System.Drawing.Point(310, 144);
            btnCartao.Name = "btnCartao";
            btnCartao.Size = new System.Drawing.Size(90, 23);
            btnCartao.TabIndex = 14;
            btnCartao.Text = "Cartão";
            btnCartao.UseVisualStyleBackColor = true;
            btnCartao.Click += btnCartao_Click;
            // 
            // txtCartao
            // 
            txtCartao.Location = new System.Drawing.Point(59, 147);
            txtCartao.Name = "txtCartao";
            txtCartao.Size = new System.Drawing.Size(242, 23);
            txtCartao.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 155);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 15);
            label6.TabIndex = 12;
            label6.Text = "Cartão:";
            // 
            // btnSenha
            // 
            btnSenha.Location = new System.Drawing.Point(310, 115);
            btnSenha.Name = "btnSenha";
            btnSenha.Size = new System.Drawing.Size(90, 23);
            btnSenha.TabIndex = 11;
            btnSenha.Text = "Senha";
            btnSenha.UseVisualStyleBackColor = true;
            btnSenha.Click += btnSenha_Click;
            // 
            // txtSenhaUsuario
            // 
            txtSenhaUsuario.Location = new System.Drawing.Point(59, 115);
            txtSenhaUsuario.Name = "txtSenhaUsuario";
            txtSenhaUsuario.Size = new System.Drawing.Size(242, 23);
            txtSenhaUsuario.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 123);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 15);
            label5.TabIndex = 9;
            label5.Text = "Senha:";
            // 
            // btnBuscarFoto
            // 
            btnBuscarFoto.Location = new System.Drawing.Point(406, 83);
            btnBuscarFoto.Name = "btnBuscarFoto";
            btnBuscarFoto.Size = new System.Drawing.Size(90, 23);
            btnBuscarFoto.TabIndex = 8;
            btnBuscarFoto.Text = "Buscar Foto";
            btnBuscarFoto.UseVisualStyleBackColor = true;
            btnBuscarFoto.Click += btnBuscarFoto_Click;
            // 
            // btnEnviarFoto
            // 
            btnEnviarFoto.Location = new System.Drawing.Point(310, 83);
            btnEnviarFoto.Name = "btnEnviarFoto";
            btnEnviarFoto.Size = new System.Drawing.Size(90, 23);
            btnEnviarFoto.TabIndex = 7;
            btnEnviarFoto.Text = "Foto";
            btnEnviarFoto.UseVisualStyleBackColor = true;
            btnEnviarFoto.Click += btnEnviarFoto_Click;
            // 
            // btnProcurarLocal
            // 
            btnProcurarLocal.Location = new System.Drawing.Point(258, 83);
            btnProcurarLocal.Name = "btnProcurarLocal";
            btnProcurarLocal.Size = new System.Drawing.Size(43, 23);
            btnProcurarLocal.TabIndex = 6;
            btnProcurarLocal.Text = "...";
            btnProcurarLocal.UseVisualStyleBackColor = true;
            btnProcurarLocal.Click += btnProcurarLocal_Click;
            // 
            // txtCaminhoFoto
            // 
            txtCaminhoFoto.Enabled = false;
            txtCaminhoFoto.Location = new System.Drawing.Point(58, 83);
            txtCaminhoFoto.Name = "txtCaminhoFoto";
            txtCaminhoFoto.Size = new System.Drawing.Size(194, 23);
            txtCaminhoFoto.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 89);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 4;
            label4.Text = "Foto:";
            // 
            // txtNomeUsuario
            // 
            txtNomeUsuario.Location = new System.Drawing.Point(59, 49);
            txtNomeUsuario.Name = "txtNomeUsuario";
            txtNomeUsuario.Size = new System.Drawing.Size(242, 23);
            txtNomeUsuario.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 53);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Nome:";
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new System.Drawing.Point(59, 16);
            txtIdUsuario.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.Size = new System.Drawing.Size(116, 23);
            txtIdUsuario.TabIndex = 1;
            txtIdUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(21, 15);
            label2.TabIndex = 0;
            label2.Text = "ID:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1014, 412);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lista Usuários";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnEnviarSel);
            groupBox3.Controls.Add(dgvListaUsuarioEnv);
            groupBox3.Location = new System.Drawing.Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(446, 394);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dados Locais";
            // 
            // btnEnviarSel
            // 
            btnEnviarSel.Location = new System.Drawing.Point(21, 317);
            btnEnviarSel.Name = "btnEnviarSel";
            btnEnviarSel.Size = new System.Drawing.Size(139, 23);
            btnEnviarSel.TabIndex = 10;
            btnEnviarSel.Text = "Enviar Selecionados";
            btnEnviarSel.UseVisualStyleBackColor = true;
            btnEnviarSel.Click += btnEnviarSel_Click;
            // 
            // dgvListaUsuarioEnv
            // 
            dgvListaUsuarioEnv.AllowUserToAddRows = false;
            dgvListaUsuarioEnv.AllowUserToDeleteRows = false;
            dgvListaUsuarioEnv.AllowUserToOrderColumns = true;
            dgvListaUsuarioEnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaUsuarioEnv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvListaUsuarioEnv.ContextMenuStrip = contextLocalGrid;
            dgvListaUsuarioEnv.EnableHeadersVisualStyles = false;
            dgvListaUsuarioEnv.Location = new System.Drawing.Point(6, 22);
            dgvListaUsuarioEnv.Name = "dgvListaUsuarioEnv";
            dgvListaUsuarioEnv.RowTemplate.Height = 25;
            dgvListaUsuarioEnv.Size = new System.Drawing.Size(434, 283);
            dgvListaUsuarioEnv.TabIndex = 9;
            dgvListaUsuarioEnv.MouseDown += dgvListaUsuarioEnv_MouseDown;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.HeaderText = "Sel";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Nome";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Cartão";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Senha";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // contextLocalGrid
            // 
            contextLocalGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { selecionarTodosToolStripMenuItem, deselecionarTodosToolStripMenuItem });
            contextLocalGrid.Name = "contextLocalGrid";
            contextLocalGrid.Size = new System.Drawing.Size(164, 48);
            // 
            // selecionarTodosToolStripMenuItem
            // 
            selecionarTodosToolStripMenuItem.Name = "selecionarTodosToolStripMenuItem";
            selecionarTodosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            selecionarTodosToolStripMenuItem.Text = "Selecionar todos";
            selecionarTodosToolStripMenuItem.Click += selecionarTodosToolStripMenuItem_Click;
            // 
            // deselecionarTodosToolStripMenuItem
            // 
            deselecionarTodosToolStripMenuItem.Name = "deselecionarTodosToolStripMenuItem";
            deselecionarTodosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            deselecionarTodosToolStripMenuItem.Text = "Remover seleção";
            deselecionarTodosToolStripMenuItem.Click += deselecionarTodosToolStripMenuItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnApagaEquipamento);
            groupBox2.Controls.Add(btnRecebeSel);
            groupBox2.Controls.Add(btnBaixarFotos);
            groupBox2.Controls.Add(btnProcurarDiretorio);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtCaminhoFotos);
            groupBox2.Controls.Add(dgvListaUsuario);
            groupBox2.Location = new System.Drawing.Point(458, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(550, 400);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados Equipamento";
            // 
            // btnApagaEquipamento
            // 
            btnApagaEquipamento.Location = new System.Drawing.Point(6, 371);
            btnApagaEquipamento.Name = "btnApagaEquipamento";
            btnApagaEquipamento.Size = new System.Drawing.Size(146, 23);
            btnApagaEquipamento.TabIndex = 9;
            btnApagaEquipamento.Text = "Apagar Selecionados";
            btnApagaEquipamento.UseVisualStyleBackColor = true;
            btnApagaEquipamento.Click += btnApagaEquipamento_Click;
            // 
            // btnRecebeSel
            // 
            btnRecebeSel.Location = new System.Drawing.Point(6, 346);
            btnRecebeSel.Name = "btnRecebeSel";
            btnRecebeSel.Size = new System.Drawing.Size(146, 23);
            btnRecebeSel.TabIndex = 8;
            btnRecebeSel.Text = "Receber Selecionados";
            btnRecebeSel.UseVisualStyleBackColor = true;
            btnRecebeSel.Click += btnRecebeSel_Click;
            // 
            // btnBaixarFotos
            // 
            btnBaixarFotos.Location = new System.Drawing.Point(431, 371);
            btnBaixarFotos.Name = "btnBaixarFotos";
            btnBaixarFotos.Size = new System.Drawing.Size(113, 23);
            btnBaixarFotos.TabIndex = 7;
            btnBaixarFotos.Text = "Baixar Fotos";
            btnBaixarFotos.UseVisualStyleBackColor = true;
            btnBaixarFotos.Click += btnBaixarFotos_Click;
            // 
            // btnProcurarDiretorio
            // 
            btnProcurarDiretorio.Location = new System.Drawing.Point(483, 317);
            btnProcurarDiretorio.Name = "btnProcurarDiretorio";
            btnProcurarDiretorio.Size = new System.Drawing.Size(61, 23);
            btnProcurarDiretorio.TabIndex = 6;
            btnProcurarDiretorio.Text = "...";
            btnProcurarDiretorio.UseVisualStyleBackColor = true;
            btnProcurarDiretorio.Click += btnProcurarDiretorio_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 317);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(59, 15);
            label7.TabIndex = 5;
            label7.Text = "Caminho:";
            // 
            // txtCaminhoFotos
            // 
            txtCaminhoFotos.Location = new System.Drawing.Point(71, 317);
            txtCaminhoFotos.Name = "txtCaminhoFotos";
            txtCaminhoFotos.ReadOnly = true;
            txtCaminhoFotos.Size = new System.Drawing.Size(398, 23);
            txtCaminhoFotos.TabIndex = 4;
            // 
            // dgvListaUsuario
            // 
            dgvListaUsuario.AllowUserToAddRows = false;
            dgvListaUsuario.AllowUserToDeleteRows = false;
            dgvListaUsuario.AllowUserToOrderColumns = true;
            dgvListaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Sel, idUsuario, nome, foto, cartao, senha });
            dgvListaUsuario.ContextMenuStrip = contextEquipamento;
            dgvListaUsuario.EnableHeadersVisualStyles = false;
            dgvListaUsuario.Location = new System.Drawing.Point(6, 22);
            dgvListaUsuario.Name = "dgvListaUsuario";
            dgvListaUsuario.RowTemplate.Height = 25;
            dgvListaUsuario.Size = new System.Drawing.Size(538, 283);
            dgvListaUsuario.TabIndex = 1;
            // 
            // Sel
            // 
            Sel.HeaderText = "Sel";
            Sel.Name = "Sel";
            Sel.Width = 40;
            // 
            // idUsuario
            // 
            idUsuario.HeaderText = "ID";
            idUsuario.Name = "idUsuario";
            idUsuario.ReadOnly = true;
            idUsuario.Width = 80;
            // 
            // nome
            // 
            nome.HeaderText = "Nome";
            nome.Name = "nome";
            nome.ReadOnly = true;
            nome.Width = 120;
            // 
            // foto
            // 
            foto.HeaderText = "Tem Foto?";
            foto.Name = "foto";
            foto.ReadOnly = true;
            foto.Width = 70;
            // 
            // cartao
            // 
            cartao.HeaderText = "Cartão";
            cartao.Name = "cartao";
            cartao.ReadOnly = true;
            // 
            // senha
            // 
            senha.HeaderText = "Senha";
            senha.Name = "senha";
            senha.ReadOnly = true;
            // 
            // contextEquipamento
            // 
            contextEquipamento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { selecionarTodosToolStripMenuItem1, deselecionarTodosToolStripMenuItem1 });
            contextEquipamento.Name = "contextEquipamento";
            contextEquipamento.Size = new System.Drawing.Size(164, 48);
            // 
            // selecionarTodosToolStripMenuItem1
            // 
            selecionarTodosToolStripMenuItem1.Name = "selecionarTodosToolStripMenuItem1";
            selecionarTodosToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            selecionarTodosToolStripMenuItem1.Text = "Selecionar todos";
            selecionarTodosToolStripMenuItem1.Click += selecionarTodosToolStripMenuItem1_Click;
            // 
            // deselecionarTodosToolStripMenuItem1
            // 
            deselecionarTodosToolStripMenuItem1.Name = "deselecionarTodosToolStripMenuItem1";
            deselecionarTodosToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            deselecionarTodosToolStripMenuItem1.Text = "Remover seleção";
            deselecionarTodosToolStripMenuItem1.Click += deselecionarTodosToolStripMenuItem1_Click;
            // 
            // cboEquipamento
            // 
            cboEquipamento.FormattingEnabled = true;
            cboEquipamento.Location = new System.Drawing.Point(6, 22);
            cboEquipamento.Name = "cboEquipamento";
            cboEquipamento.Size = new System.Drawing.Size(140, 23);
            cboEquipamento.TabIndex = 2;
            // 
            // btnBuscarLst
            // 
            btnBuscarLst.Location = new System.Drawing.Point(917, 23);
            btnBuscarLst.Name = "btnBuscarLst";
            btnBuscarLst.Size = new System.Drawing.Size(101, 23);
            btnBuscarLst.TabIndex = 0;
            btnBuscarLst.Text = "Buscar Lista";
            btnBuscarLst.UseVisualStyleBackColor = true;
            btnBuscarLst.Click += btnBuscarLst_Click;
            // 
            // ofDialog
            // 
            ofDialog.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(702, 115);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(127, 23);
            button1.TabIndex = 29;
            button1.Text = "Salvar Foto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSalvarFoto_Click;
            // 
            // SDKLeitorFacial
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1052, 588);
            Controls.Add(grpEquipamento);
            Controls.Add(grpConectar);
            Name = "SDKLeitorFacial";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Leitor Facial";
            TransparencyKey = System.Drawing.Color.Lime;
            Load += SDKLeitorFacial_Load;
            grpConectar.ResumeLayout(false);
            grpConectar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPortaServer).EndInit();
            grpEquipamento.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIdUsuario).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListaUsuarioEnv).EndInit();
            contextLocalGrid.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaUsuario).EndInit();
            contextEquipamento.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpConectar;
        private System.Windows.Forms.NumericUpDown txtPortaServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpEquipamento;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ComboBox cboEquipamento;
        private System.Windows.Forms.Button btnBuscarLst;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpaTela;
        private System.Windows.Forms.ListView lstStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnApagarTodos;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnBuscarCartao;
        private System.Windows.Forms.Button btnCartao;
        private System.Windows.Forms.TextBox txtCartao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSenha;
        private System.Windows.Forms.TextBox txtSenhaUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscarFoto;
        private System.Windows.Forms.Button btnEnviarFoto;
        private System.Windows.Forms.Button btnProcurarLocal;
        private System.Windows.Forms.TextBox txtCaminhoFoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtIdUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBuscarSenha;
        private System.Windows.Forms.FolderBrowserDialog fbDialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBaixarFotos;
        private System.Windows.Forms.Button btnProcurarDiretorio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCaminhoFotos;
        private System.Windows.Forms.DataGridView dgvListaUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewCheckBoxColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cartao;
        private System.Windows.Forms.DataGridViewTextBoxColumn senha;
        private System.Windows.Forms.DataGridView dgvListaUsuarioEnv;
        private System.Windows.Forms.Button btnEnviarSel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnAdicionarLista;
        private System.Windows.Forms.Button btnIniciarReceberFoto;
        private System.Windows.Forms.ContextMenuStrip contextLocalGrid;
        private System.Windows.Forms.ToolStripMenuItem selecionarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselecionarTodosToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextEquipamento;
        private System.Windows.Forms.ToolStripMenuItem selecionarTodosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deselecionarTodosToolStripMenuItem1;
        private System.Windows.Forms.ComboBox cboAdmin;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnApagaEquipamento;
        private System.Windows.Forms.Button btnRecebeSel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPararReceberFoto;
        private System.Windows.Forms.Button button1;
    }
}