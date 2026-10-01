namespace ApiLaunchBusiness
{
    partial class fComunicarSerie
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
            this.txtTipoDocumentoAplicacao = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtTipoDocumentoSaft = new System.Windows.Forms.TextBox();
            this.cmbTipoSerie = new System.Windows.Forms.ComboBox();
            this.txtMeioProcessamento = new System.Windows.Forms.TextBox();
            this.numNumeroInicial = new System.Windows.Forms.NumericUpDown();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
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
            this.tableParametros.Controls.Add(CriarLabel("Tipo de documento da aplicação"), 0, 0);
            this.tableParametros.Controls.Add(this.txtTipoDocumentoAplicacao, 1, 0);
            this.tableParametros.Controls.Add(CriarLabel("Série"), 0, 1);
            this.tableParametros.Controls.Add(this.txtSerie, 1, 1);
            this.tableParametros.Controls.Add(CriarLabel("Tipo de documento SAF-T"), 0, 2);
            this.tableParametros.Controls.Add(this.txtTipoDocumentoSaft, 1, 2);
            this.tableParametros.Controls.Add(CriarLabel("Tipo de série"), 0, 3);
            this.tableParametros.Controls.Add(this.cmbTipoSerie, 1, 3);
            this.tableParametros.Controls.Add(CriarLabel("Meio de processamento"), 0, 4);
            this.tableParametros.Controls.Add(this.txtMeioProcessamento, 1, 4);
            this.tableParametros.Controls.Add(CriarLabel("Número inicial da sequência"), 0, 5);
            this.tableParametros.Controls.Add(this.numNumeroInicial, 1, 5);
            this.tableParametros.Controls.Add(CriarLabel("Data de início de utilização"), 0, 6);
            this.tableParametros.Controls.Add(this.dtpDataInicio, 1, 6);
            this.tableParametros.Location = new System.Drawing.Point(12, 12);
            this.tableParametros.Name = "tableParametros";
            this.tableParametros.RowCount = 7;
            for (int indice = 0; indice < 7; indice++)
                this.tableParametros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParametros.Size = new System.Drawing.Size(710, 224);
            this.tableParametros.TabIndex = 0;
            //
            // campos
            //
            this.txtTipoDocumentoAplicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTipoDocumentoAplicacao.Name = "txtTipoDocumentoAplicacao";
            this.txtSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerie.Name = "txtSerie";
            this.txtTipoDocumentoSaft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTipoDocumentoSaft.Name = "txtTipoDocumentoSaft";
            this.cmbTipoSerie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTipoSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSerie.Items.AddRange(new object[] { "N", "R" });
            this.cmbTipoSerie.Name = "cmbTipoSerie";
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
            //
            // lblAviso
            //
            this.lblAviso.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAviso.Location = new System.Drawing.Point(12, 245);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(710, 37);
            this.lblAviso.Text = "Atenção: este teste comunica realmente uma série à AT e, em caso de sucesso, atualiza o respetivo registo em NOMSERIE.";
            //
            // grpResultado
            //
            this.grpResultado.Controls.Add(this.txtResultado);
            this.grpResultado.Location = new System.Drawing.Point(12, 294);
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
            this.cmdComunicar.Location = new System.Drawing.Point(510, 461);
            this.cmdComunicar.Name = "cmdComunicar";
            this.cmdComunicar.Size = new System.Drawing.Size(130, 30);
            this.cmdComunicar.Text = "Comunicar à AT";
            this.cmdComunicar.UseVisualStyleBackColor = true;
            this.cmdComunicar.Click += new System.EventHandler(this.cmdComunicar_Click);
            //
            // cmdFechar
            //
            this.cmdFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdFechar.Location = new System.Drawing.Point(647, 461);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(75, 30);
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            //
            // fComunicarSerie
            //
            this.AcceptButton = this.cmdComunicar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdFechar;
            this.ClientSize = new System.Drawing.Size(734, 503);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmdComunicar);
            this.Controls.Add(this.grpResultado);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.tableParametros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fComunicarSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comunicar série à AT";
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
        private System.Windows.Forms.TextBox txtTipoDocumentoAplicacao;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtTipoDocumentoSaft;
        private System.Windows.Forms.ComboBox cmbTipoSerie;
        private System.Windows.Forms.TextBox txtMeioProcessamento;
        private System.Windows.Forms.NumericUpDown numNumeroInicial;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.GroupBox grpResultado;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button cmdComunicar;
        private System.Windows.Forms.Button cmdFechar;
    }
}
