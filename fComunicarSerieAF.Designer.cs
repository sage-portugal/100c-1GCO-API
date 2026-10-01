namespace ApiLaunchBusiness
{
    partial class fComunicarSerieAF
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableParametros = new System.Windows.Forms.TableLayoutPanel();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtTipoDocumentoAplicacao = new System.Windows.Forms.TextBox();
            this.txtTipoDocumentoSaft = new System.Windows.Forms.TextBox();
            this.txtTipoSerie = new System.Windows.Forms.TextBox();
            this.txtMeioProcessamento = new System.Windows.Forms.TextBox();
            this.numNumeroInicial = new System.Windows.Forms.NumericUpDown();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbTipoEntidade = new System.Windows.Forms.ComboBox();
            this.txtNifEntidade = new System.Windows.Forms.TextBox();
            this.txtPaisEstrangeiro = new System.Windows.Forms.TextBox();
            this.txtNomeEstrangeiro = new System.Windows.Forms.TextBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.grpResultado = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.cmdComunicar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.tableParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroInicial)).BeginInit();
            this.grpResultado.SuspendLayout();
            this.SuspendLayout();
            //
            // tableParametros
            //
            this.tableParametros.ColumnCount = 2;
            this.tableParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableParametros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableParametros.Controls.Add(CriarLabel("Série"), 0, 0);
            this.tableParametros.Controls.Add(this.txtSerie, 1, 0);
            this.tableParametros.Controls.Add(CriarLabel("Tipo de documento da aplicação"), 0, 1);
            this.tableParametros.Controls.Add(this.txtTipoDocumentoAplicacao, 1, 1);
            this.tableParametros.Controls.Add(CriarLabel("Tipo de documento SAF-T"), 0, 2);
            this.tableParametros.Controls.Add(this.txtTipoDocumentoSaft, 1, 2);
            this.tableParametros.Controls.Add(CriarLabel("Tipo de série"), 0, 3);
            this.tableParametros.Controls.Add(this.txtTipoSerie, 1, 3);
            this.tableParametros.Controls.Add(CriarLabel("Meio de processamento"), 0, 4);
            this.tableParametros.Controls.Add(this.txtMeioProcessamento, 1, 4);
            this.tableParametros.Controls.Add(CriarLabel("Número inicial da sequência"), 0, 5);
            this.tableParametros.Controls.Add(this.numNumeroInicial, 1, 5);
            this.tableParametros.Controls.Add(CriarLabel("Data de início de utilização"), 0, 6);
            this.tableParametros.Controls.Add(this.dtpDataInicio, 1, 6);
            this.tableParametros.Controls.Add(CriarLabel("Tipo de entidade"), 0, 7);
            this.tableParametros.Controls.Add(this.cmbTipoEntidade, 1, 7);
            this.tableParametros.Controls.Add(CriarLabel("NIF / identificação fiscal"), 0, 8);
            this.tableParametros.Controls.Add(this.txtNifEntidade, 1, 8);
            this.tableParametros.Controls.Add(CriarLabel("País estrangeiro (ISO alpha-2)"), 0, 9);
            this.tableParametros.Controls.Add(this.txtPaisEstrangeiro, 1, 9);
            this.tableParametros.Controls.Add(CriarLabel("Nome da entidade estrangeira"), 0, 10);
            this.tableParametros.Controls.Add(this.txtNomeEstrangeiro, 1, 10);
            this.tableParametros.Location = new System.Drawing.Point(12, 12);
            this.tableParametros.Name = "tableParametros";
            this.tableParametros.RowCount = 11;
            for (int indice = 0; indice < 11; indice++)
                this.tableParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParametros.Size = new System.Drawing.Size(710, 352);
            this.tableParametros.TabIndex = 0;
            //
            // campos
            //
            this.txtSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerie.Name = "txtSerie";
            this.txtTipoDocumentoAplicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTipoDocumentoAplicacao.Name = "txtTipoDocumentoAplicacao";
            this.txtTipoDocumentoSaft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTipoDocumentoSaft.Name = "txtTipoDocumentoSaft";
            this.txtTipoSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTipoSerie.Name = "txtTipoSerie";
            this.txtMeioProcessamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMeioProcessamento.Name = "txtMeioProcessamento";
            this.numNumeroInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numNumeroInicial.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            this.numNumeroInicial.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNumeroInicial.Name = "numNumeroInicial";
            this.dtpDataInicio.CustomFormat = "dd-MM-yyyy";
            this.dtpDataInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.cmbTipoEntidade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTipoEntidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEntidade.Items.AddRange(new object[] { "FN", "FE", "CE" });
            this.cmbTipoEntidade.Name = "cmbTipoEntidade";
            this.txtNifEntidade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNifEntidade.Name = "txtNifEntidade";
            this.txtPaisEstrangeiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaisEstrangeiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaisEstrangeiro.MaxLength = 2;
            this.txtPaisEstrangeiro.Name = "txtPaisEstrangeiro";
            this.txtNomeEstrangeiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNomeEstrangeiro.Name = "txtNomeEstrangeiro";
            //
            // lblAviso
            //
            this.lblAviso.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAviso.Location = new System.Drawing.Point(12, 373);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(710, 45);
            this.lblAviso.Text = "Atenção: este teste comunica realmente com a AT. Na implementação atual da API, o tipo de série, o meio de processamento e os dados da entidade estrangeira não são encaminhados ao serviço ADS.";
            //
            // grpResultado
            //
            this.grpResultado.Controls.Add(this.txtResultado);
            this.grpResultado.Location = new System.Drawing.Point(12, 422);
            this.grpResultado.Name = "grpResultado";
            this.grpResultado.Size = new System.Drawing.Size(710, 155);
            this.grpResultado.TabStop = false;
            this.grpResultado.Text = "Resposta da API / AT";
            //
            // txtResultado
            //
            this.txtResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //
            // cmdComunicar
            //
            this.cmdComunicar.Location = new System.Drawing.Point(510, 589);
            this.cmdComunicar.Name = "cmdComunicar";
            this.cmdComunicar.Size = new System.Drawing.Size(130, 30);
            this.cmdComunicar.Text = "Comunicar à AT";
            this.cmdComunicar.UseVisualStyleBackColor = true;
            this.cmdComunicar.Click += new System.EventHandler(this.cmdComunicar_Click);
            //
            // cmdFechar
            //
            this.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdFechar.Location = new System.Drawing.Point(647, 589);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(75, 30);
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            //
            // fComunicarSerieAF
            //
            this.AcceptButton = this.cmdComunicar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdFechar;
            this.ClientSize = new System.Drawing.Size(734, 631);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmdComunicar);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.tableParametros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fComunicarSerieAF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comunicar série de autofaturação à AT";
            this.tableParametros.ResumeLayout(false);
            this.tableParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroInicial)).EndInit();
            this.grpResultado.ResumeLayout(false);
            this.grpResultado.PerformLayout();
            this.ResumeLayout(false);
        }

        private static System.Windows.Forms.Label CriarLabel(string texto)
        {
            return new System.Windows.Forms.Label
            {
                AutoSize = true,
                Anchor = System.Windows.Forms.AnchorStyles.Left,
                Text = texto
            };
        }

        private System.Windows.Forms.TableLayoutPanel tableParametros;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtTipoDocumentoAplicacao;
        private System.Windows.Forms.TextBox txtTipoDocumentoSaft;
        private System.Windows.Forms.TextBox txtTipoSerie;
        private System.Windows.Forms.TextBox txtMeioProcessamento;
        private System.Windows.Forms.NumericUpDown numNumeroInicial;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.ComboBox cmbTipoEntidade;
        private System.Windows.Forms.TextBox txtNifEntidade;
        private System.Windows.Forms.TextBox txtPaisEstrangeiro;
        private System.Windows.Forms.TextBox txtNomeEstrangeiro;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.GroupBox grpResultado;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button cmdComunicar;
        private System.Windows.Forms.Button cmdFechar;
    }
}
