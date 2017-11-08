using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace ApiLaunchBusiness
{
	partial class fApi
	{

		#region "Upgrade Support "
		private static fApi m_FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static fApi DefInstance
		{
			get
			{
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
                    m_FormDefInstance = CreateInstance();
					m_InitializingDefInstance = false;
				}
                return m_FormDefInstance;
			}
			set
			{
                m_FormDefInstance = value;
			}
		}

		#endregion
		#region "Windows Form Designer generated code "
		public static fApi CreateInstance()
		{
			fApi theInstance = new fApi();
			//theInstance.Form_Load();

			return theInstance;
		}		
        //Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolTip ToolTipMain;
        public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public System.Windows.Forms.TextBox txtStatusMsg;
		public System.Windows.Forms.TextBox txtPwd;
		public System.Windows.Forms.TextBox txtUser;
		public System.Windows.Forms.TextBox txtCompany;
		public System.Windows.Forms.TextBox txtFicheiroLogErros;
        public System.Windows.Forms.TextBox txtPercursoWin;
		private System.Windows.Forms.Label _Label1_0;
		private System.Windows.Forms.Label _Bar1_1;
		private System.Windows.Forms.Label _Bar1_0;
		public System.Windows.Forms.Label Label66;
        public System.Windows.Forms.Label Label65;
		public System.Windows.Forms.Label Label40;
		public System.Windows.Forms.Label Label39;
		public System.Windows.Forms.Label[] Bar1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.PictureBox[] Frame = new System.Windows.Forms.PictureBox[10];
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] Label15 = new System.Windows.Forms.Label[10];
		public System.Windows.Forms.TextBox[] Text12 = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] Text23 = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] Text24 = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] Text30 = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.Button[] btnTrfArm = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmdClearFT = new System.Windows.Forms.Button[10];
		public System.Windows.Forms.PictureBox[] fAdicional = new System.Windows.Forms.PictureBox[4];
		public System.Windows.Forms.Label[] lbl = new System.Windows.Forms.Label[6];
		public System.Windows.Forms.RadioButton[] oModAdicional = new System.Windows.Forms.RadioButton[4];
		public System.Windows.Forms.TextBox[] txtSAFT = new System.Windows.Forms.TextBox[5];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fApi));
            this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
            this.txtStatusMsg = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtFicheiroLogErros = new System.Windows.Forms.TextBox();
            this.txtPercursoWin = new System.Windows.Forms.TextBox();
            this._Label1_0 = new System.Windows.Forms.Label();
            this._Bar1_1 = new System.Windows.Forms.Label();
            this._Bar1_0 = new System.Windows.Forms.Label();
            this.Label66 = new System.Windows.Forms.Label();
            this.Label65 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.pbCSharp = new System.Windows.Forms.PictureBox();
            this.label101 = new System.Windows.Forms.Label();
            this.Principal_menuStrip = new System.Windows.Forms.MenuStrip();
            this.SageApi_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planoDeContasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentoComercialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentoReciboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GerarDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentoContabilidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outrasExemplosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCSharp)).BeginInit();
            this.Principal_menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatusMsg
            // 
            this.txtStatusMsg.AcceptsReturn = true;
            this.txtStatusMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatusMsg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStatusMsg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStatusMsg.Location = new System.Drawing.Point(8, 589);
            this.txtStatusMsg.MaxLength = 0;
            this.txtStatusMsg.Name = "txtStatusMsg";
            this.txtStatusMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStatusMsg.Size = new System.Drawing.Size(1034, 20);
            this.txtStatusMsg.TabIndex = 7;
            // 
            // txtPwd
            // 
            this.txtPwd.AcceptsReturn = true;
            this.txtPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPwd.Location = new System.Drawing.Point(193, 175);
            this.txtPwd.MaxLength = 0;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPwd.Size = new System.Drawing.Size(82, 20);
            this.txtPwd.TabIndex = 6;
            // 
            // txtUser
            // 
            this.txtUser.AcceptsReturn = true;
            this.txtUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUser.Location = new System.Drawing.Point(68, 177);
            this.txtUser.MaxLength = 0;
            this.txtUser.Name = "txtUser";
            this.txtUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUser.Size = new System.Drawing.Size(82, 20);
            this.txtUser.TabIndex = 5;
            // 
            // txtCompany
            // 
            this.txtCompany.AcceptsReturn = true;
            this.txtCompany.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCompany.Location = new System.Drawing.Point(68, 207);
            this.txtCompany.MaxLength = 0;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompany.Size = new System.Drawing.Size(207, 20);
            this.txtCompany.TabIndex = 4;
            // 
            // txtFicheiroLogErros
            // 
            this.txtFicheiroLogErros.AcceptsReturn = true;
            this.txtFicheiroLogErros.BackColor = System.Drawing.SystemColors.Window;
            this.txtFicheiroLogErros.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFicheiroLogErros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFicheiroLogErros.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFicheiroLogErros.Location = new System.Drawing.Point(101, 462);
            this.txtFicheiroLogErros.MaxLength = 0;
            this.txtFicheiroLogErros.Name = "txtFicheiroLogErros";
            this.txtFicheiroLogErros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFicheiroLogErros.Size = new System.Drawing.Size(315, 20);
            this.txtFicheiroLogErros.TabIndex = 3;
            // 
            // txtPercursoWin
            // 
            this.txtPercursoWin.AcceptsReturn = true;
            this.txtPercursoWin.BackColor = System.Drawing.SystemColors.Window;
            this.txtPercursoWin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPercursoWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercursoWin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPercursoWin.Location = new System.Drawing.Point(101, 426);
            this.txtPercursoWin.MaxLength = 0;
            this.txtPercursoWin.Name = "txtPercursoWin";
            this.txtPercursoWin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPercursoWin.Size = new System.Drawing.Size(315, 20);
            this.txtPercursoWin.TabIndex = 2;
            // 
            // _Label1_0
            // 
            this._Label1_0.BackColor = System.Drawing.Color.Transparent;
            this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(113)))));
            this._Label1_0.Location = new System.Drawing.Point(867, 540);
            this._Label1_0.Name = "_Label1_0";
            this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_0.Size = new System.Drawing.Size(187, 13);
            this._Label1_0.TabIndex = 180;
            this._Label1_0.Text = "Copyright © 2016 - Sage Portugal";
            // 
            // _Bar1_1
            // 
            this._Bar1_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(177)))), ((int)(((byte)(158)))));
            this._Bar1_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._Bar1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Bar1_1.Location = new System.Drawing.Point(5, 569);
            this._Bar1_1.Name = "_Bar1_1";
            this._Bar1_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._Bar1_1.Size = new System.Drawing.Size(1040, 3);
            this._Bar1_1.TabIndex = 179;
            // 
            // _Bar1_0
            // 
            this._Bar1_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(177)))), ((int)(((byte)(158)))));
            this._Bar1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._Bar1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Bar1_0.Location = new System.Drawing.Point(10, 130);
            this._Bar1_0.Name = "_Bar1_0";
            this._Bar1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Bar1_0.Size = new System.Drawing.Size(1039, 3);
            this._Bar1_0.TabIndex = 178;
            // 
            // Label66
            // 
            this.Label66.BackColor = System.Drawing.Color.Transparent;
            this.Label66.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label66.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label66.ForeColor = System.Drawing.Color.Black;
            this.Label66.Location = new System.Drawing.Point(10, 177);
            this.Label66.Name = "Label66";
            this.Label66.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label66.Size = new System.Drawing.Size(59, 17);
            this.Label66.TabIndex = 177;
            this.Label66.Text = "Utilizador";
            // 
            // Label65
            // 
            this.Label65.BackColor = System.Drawing.Color.Transparent;
            this.Label65.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label65.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label65.ForeColor = System.Drawing.Color.Black;
            this.Label65.Location = new System.Drawing.Point(150, 177);
            this.Label65.Name = "Label65";
            this.Label65.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label65.Size = new System.Drawing.Size(44, 18);
            this.Label65.TabIndex = 176;
            this.Label65.Text = "Senha";
            // 
            // Label40
            // 
            this.Label40.BackColor = System.Drawing.Color.Transparent;
            this.Label40.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label40.Location = new System.Drawing.Point(10, 210);
            this.Label40.Name = "Label40";
            this.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label40.Size = new System.Drawing.Size(56, 17);
            this.Label40.TabIndex = 87;
            this.Label40.Text = "Empresa";
            // 
            // Label39
            // 
            this.Label39.BackColor = System.Drawing.Color.Transparent;
            this.Label39.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label39.Location = new System.Drawing.Point(7, 465);
            this.Label39.Name = "Label39";
            this.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label39.Size = new System.Drawing.Size(71, 17);
            this.Label39.TabIndex = 86;
            this.Label39.Text = "Log da Api";
            // 
            // pbCSharp
            // 
            this.pbCSharp.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCSharp.Image = ((System.Drawing.Image)(resources.GetObject("pbCSharp.Image")));
            this.pbCSharp.Location = new System.Drawing.Point(911, 28);
            this.pbCSharp.Name = "pbCSharp";
            this.pbCSharp.Size = new System.Drawing.Size(131, 99);
            this.pbCSharp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCSharp.TabIndex = 288;
            this.pbCSharp.TabStop = false;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Transparent;
            this.label101.Cursor = System.Windows.Forms.Cursors.Default;
            this.label101.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.Black;
            this.label101.Location = new System.Drawing.Point(10, 147);
            this.label101.Name = "label101";
            this.label101.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label101.Size = new System.Drawing.Size(265, 14);
            this.label101.TabIndex = 290;
            this.label101.Text = "Login do Utilizador";
            // 
            // Principal_menuStrip
            // 
            this.Principal_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SageApi_toolStripMenuItem,
            this.entidadesToolStripMenuItem,
            this.DocumentoComercialToolStripMenuItem,
            this.DocumentoReciboToolStripMenuItem,
            this.GerarDocumentosToolStripMenuItem,
            this.DocumentoContabilidadeToolStripMenuItem,
            this.outrasExemplosToolStripMenuItem});
            this.Principal_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.Principal_menuStrip.Name = "Principal_menuStrip";
            this.Principal_menuStrip.Size = new System.Drawing.Size(1048, 24);
            this.Principal_menuStrip.TabIndex = 294;
            this.Principal_menuStrip.Text = "Sage Gestão API";
            // 
            // SageApi_toolStripMenuItem
            // 
            this.SageApi_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarToolStripMenuItem,
            this.terminarToolStripMenuItem,
            this.fimToolStripMenuItem});
            this.SageApi_toolStripMenuItem.Name = "SageApi_toolStripMenuItem";
            this.SageApi_toolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.SageApi_toolStripMenuItem.Text = "Sage Api Launch";
            this.SageApi_toolStripMenuItem.Click += new System.EventHandler(this.SageApi_toolStripMenuItem_Click);
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.iniciarToolStripMenuItem.Text = "Abrir Empresa";
            this.iniciarToolStripMenuItem.Click += new System.EventHandler(this.iniciarToolStripMenuItem_Click);
            // 
            // terminarToolStripMenuItem
            // 
            this.terminarToolStripMenuItem.Name = "terminarToolStripMenuItem";
            this.terminarToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.terminarToolStripMenuItem.Text = "Fechar Empresa";
            this.terminarToolStripMenuItem.Click += new System.EventHandler(this.terminarToolStripMenuItem_Click);
            // 
            // fimToolStripMenuItem
            // 
            this.fimToolStripMenuItem.Name = "fimToolStripMenuItem";
            this.fimToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.fimToolStripMenuItem.Text = "Saír";
            this.fimToolStripMenuItem.Click += new System.EventHandler(this.fimToolStripMenuItem_Click);
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unidadesToolStripMenuItem,
            this.artigosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.fornecedoresToolStripMenuItem,
            this.planoDeContasToolStripMenuItem});
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.entidadesToolStripMenuItem.Text = "Entidades";
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.unidadesToolStripMenuItem.Text = "Unidades";
            this.unidadesToolStripMenuItem.Click += new System.EventHandler(this.unidadesToolStripMenuItem_Click);
            // 
            // artigosToolStripMenuItem
            // 
            this.artigosToolStripMenuItem.Name = "artigosToolStripMenuItem";
            this.artigosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.artigosToolStripMenuItem.Text = "Artigos";
            this.artigosToolStripMenuItem.Click += new System.EventHandler(this.artigosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            this.fornecedoresToolStripMenuItem.Click += new System.EventHandler(this.fornecedoresToolStripMenuItem_Click);
            // 
            // planoDeContasToolStripMenuItem
            // 
            this.planoDeContasToolStripMenuItem.Name = "planoDeContasToolStripMenuItem";
            this.planoDeContasToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.planoDeContasToolStripMenuItem.Text = "Plano de Contas";
            this.planoDeContasToolStripMenuItem.Click += new System.EventHandler(this.planoDeContasToolStripMenuItem_Click);
            // 
            // DocumentoComercialToolStripMenuItem
            // 
            this.DocumentoComercialToolStripMenuItem.Name = "DocumentoComercialToolStripMenuItem";
            this.DocumentoComercialToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.DocumentoComercialToolStripMenuItem.Text = "Documento Comercial";
            this.DocumentoComercialToolStripMenuItem.Click += new System.EventHandler(this.documentoComercialToolStripMenuItem_Click);
            // 
            // DocumentoReciboToolStripMenuItem
            // 
            this.DocumentoReciboToolStripMenuItem.Name = "DocumentoReciboToolStripMenuItem";
            this.DocumentoReciboToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.DocumentoReciboToolStripMenuItem.Text = "Documento Recibo";
            this.DocumentoReciboToolStripMenuItem.Click += new System.EventHandler(this.DocumentoReciboToolStripMenuItem_Click);
            // 
            // GerarDocumentosToolStripMenuItem
            // 
            this.GerarDocumentosToolStripMenuItem.Name = "GerarDocumentosToolStripMenuItem";
            this.GerarDocumentosToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.GerarDocumentosToolStripMenuItem.Text = "Gerar Documentos";
            this.GerarDocumentosToolStripMenuItem.Click += new System.EventHandler(this.GerarDocumentosToolStripMenuItem_Click);
            // 
            // DocumentoContabilidadeToolStripMenuItem
            // 
            this.DocumentoContabilidadeToolStripMenuItem.Name = "DocumentoContabilidadeToolStripMenuItem";
            this.DocumentoContabilidadeToolStripMenuItem.Size = new System.Drawing.Size(159, 20);
            this.DocumentoContabilidadeToolStripMenuItem.Text = "Documento Contabilidade";
            this.DocumentoContabilidadeToolStripMenuItem.Click += new System.EventHandler(this.DocumentoContabilidadeToolStripMenuItem_Click);
            // 
            // outrasExemplosToolStripMenuItem
            // 
            this.outrasExemplosToolStripMenuItem.Name = "outrasExemplosToolStripMenuItem";
            this.outrasExemplosToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.outrasExemplosToolStripMenuItem.Text = "Outros Exemplos";
            this.outrasExemplosToolStripMenuItem.Click += new System.EventHandler(this.outrasExemplosToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 295;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(10, 429);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 296;
            this.label2.Text = "Percurso";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // fApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 621);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label101);
            this.Controls.Add(this.pbCSharp);
            this.Controls.Add(this.txtStatusMsg);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtFicheiroLogErros);
            this.Controls.Add(this.txtPercursoWin);
            this.Controls.Add(this._Label1_0);
            this.Controls.Add(this._Bar1_1);
            this.Controls.Add(this._Bar1_0);
            this.Controls.Add(this.Label66);
            this.Controls.Add(this.Label65);
            this.Controls.Add(this.Label40);
            this.Controls.Add(this.Label39);
            this.Controls.Add(this.Principal_menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(3, 29);
            this.MainMenuStrip = this.Principal_menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fApi";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sage API Launch";
            this.Load += new System.EventHandler(this.fApi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCSharp)).EndInit();
            this.Principal_menuStrip.ResumeLayout(false);
            this.Principal_menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		void ReLoadForm(bool addEvents)
		{
			InitializeBar1();
		}

		void InitializeBar1()
		{
			this.Bar1 = new System.Windows.Forms.Label[2];
			this.Bar1[1] = _Bar1_1;
			this.Bar1[0] = _Bar1_0;
		}
		#endregion

		public System.Windows.Forms.PictureBox pbCSharp;
        public System.Windows.Forms.Label label101;
        private System.Windows.Forms.MenuStrip Principal_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem SageApi_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentoContabilidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentoComercialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentoReciboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GerarDocumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planoDeContasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outrasExemplosToolStripMenuItem;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label2;
    }
}