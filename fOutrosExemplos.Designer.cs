namespace ApiLaunchBusiness
{
    partial class fOutrosExemplos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdInserirDocumentosXML = new System.Windows.Forms.Button();
            this.cmdInserirRecibosXML = new System.Windows.Forms.Button();
            this.CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
            this.NewDocContab = new System.Windows.Forms.Button();
            this.ChangeDocContab = new System.Windows.Forms.Button();
            this._btnTrfArm_1 = new System.Windows.Forms.Button();
            this._btnTrfArm_0 = new System.Windows.Forms.Button();
            this.LigGaCom = new System.Windows.Forms.CheckBox();
            this.cmbTipoPrecoStock = new System.Windows.Forms.ComboBox();
            this.Label98 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(647, 299);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(75, 25);
            this.cmdSair.TabIndex = 255;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdInserirDocumentosXML
            // 
            this.cmdInserirDocumentosXML.Location = new System.Drawing.Point(12, 12);
            this.cmdInserirDocumentosXML.Name = "cmdInserirDocumentosXML";
            this.cmdInserirDocumentosXML.Size = new System.Drawing.Size(248, 23);
            this.cmdInserirDocumentosXML.TabIndex = 297;
            this.cmdInserirDocumentosXML.Text = "Inserir Documentos Comerciais  via XML";
            this.cmdInserirDocumentosXML.Click += new System.EventHandler(this.cmdInserirDocumentosXML_Click);
            // 
            // cmdInserirRecibosXML
            // 
            this.cmdInserirRecibosXML.Location = new System.Drawing.Point(12, 41);
            this.cmdInserirRecibosXML.Name = "cmdInserirRecibosXML";
            this.cmdInserirRecibosXML.Size = new System.Drawing.Size(248, 23);
            this.cmdInserirRecibosXML.TabIndex = 298;
            this.cmdInserirRecibosXML.Text = "Inserir Recibos via XML";
            this.cmdInserirRecibosXML.Click += new System.EventHandler(this.cmdInserirRecibosXML_Click);
            // 
            // NewDocContab
            // 
            this.NewDocContab.BackColor = System.Drawing.SystemColors.Control;
            this.NewDocContab.Cursor = System.Windows.Forms.Cursors.Default;
            this.NewDocContab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewDocContab.Location = new System.Drawing.Point(12, 143);
            this.NewDocContab.Name = "NewDocContab";
            this.NewDocContab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NewDocContab.Size = new System.Drawing.Size(248, 21);
            this.NewDocContab.TabIndex = 300;
            this.NewDocContab.Text = "Gerar Documento Contabilistico";
            this.NewDocContab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewDocContab.UseVisualStyleBackColor = false;
            this.NewDocContab.Click += new System.EventHandler(this.NewDocContab_Click);
            // 
            // ChangeDocContab
            // 
            this.ChangeDocContab.BackColor = System.Drawing.SystemColors.Control;
            this.ChangeDocContab.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChangeDocContab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChangeDocContab.Location = new System.Drawing.Point(12, 119);
            this.ChangeDocContab.Name = "ChangeDocContab";
            this.ChangeDocContab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChangeDocContab.Size = new System.Drawing.Size(248, 21);
            this.ChangeDocContab.TabIndex = 299;
            this.ChangeDocContab.Text = "Alterar Documento Contabilistico";
            this.ChangeDocContab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ChangeDocContab.UseVisualStyleBackColor = false;
            this.ChangeDocContab.Click += new System.EventHandler(this.ChangeDocContab_Click);
            // 
            // _btnTrfArm_1
            // 
            this._btnTrfArm_1.Location = new System.Drawing.Point(12, 254);
            this._btnTrfArm_1.Name = "_btnTrfArm_1";
            this._btnTrfArm_1.Size = new System.Drawing.Size(159, 23);
            this._btnTrfArm_1.TabIndex = 301;
            this._btnTrfArm_1.Text = "Alterar Transferência Armazém";
            this._btnTrfArm_1.Click += new System.EventHandler(this._btnTrfArm_1_Click);
            // 
            // _btnTrfArm_0
            // 
            this._btnTrfArm_0.Location = new System.Drawing.Point(12, 225);
            this._btnTrfArm_0.Name = "_btnTrfArm_0";
            this._btnTrfArm_0.Size = new System.Drawing.Size(159, 23);
            this._btnTrfArm_0.TabIndex = 302;
            this._btnTrfArm_0.Text = "Inserir Transferência Armazém";
            this._btnTrfArm_0.Click += new System.EventHandler(this._btnTrfArm_0_Click);
            // 
            // LigGaCom
            // 
            this.LigGaCom.BackColor = System.Drawing.SystemColors.Control;
            this.LigGaCom.Cursor = System.Windows.Forms.Cursors.Default;
            this.LigGaCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LigGaCom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LigGaCom.Location = new System.Drawing.Point(189, 244);
            this.LigGaCom.Name = "LigGaCom";
            this.LigGaCom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LigGaCom.Size = new System.Drawing.Size(185, 33);
            this.LigGaCom.TabIndex = 303;
            this.LigGaCom.Text = "Ligação á Contabilidade";
            this.LigGaCom.UseVisualStyleBackColor = false;
            // 
            // cmbTipoPrecoStock
            // 
            this.cmbTipoPrecoStock.BackColor = System.Drawing.SystemColors.Window;
            this.cmbTipoPrecoStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbTipoPrecoStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPrecoStock.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTipoPrecoStock.Items.AddRange(new object[] {
            "Não definido",
            "Última entrada",
            "Custo médio Fixo",
            "Standard",
            "Manual",
            "Ficha de composição",
            "Custo médio flutuante"});
            this.cmbTipoPrecoStock.Location = new System.Drawing.Point(296, 225);
            this.cmbTipoPrecoStock.Name = "cmbTipoPrecoStock";
            this.cmbTipoPrecoStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbTipoPrecoStock.Size = new System.Drawing.Size(141, 21);
            this.cmbTipoPrecoStock.TabIndex = 304;
            // 
            // Label98
            // 
            this.Label98.BackColor = System.Drawing.SystemColors.Control;
            this.Label98.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label98.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label98.Location = new System.Drawing.Point(188, 229);
            this.Label98.Name = "Label98";
            this.Label98.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label98.Size = new System.Drawing.Size(109, 13);
            this.Label98.TabIndex = 305;
            this.Label98.Text = "Tipo preço stock:";
            // 
            // fOutrosExemplos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 336);
            this.Controls.Add(this.cmbTipoPrecoStock);
            this.Controls.Add(this.Label98);
            this.Controls.Add(this.LigGaCom);
            this.Controls.Add(this._btnTrfArm_1);
            this.Controls.Add(this._btnTrfArm_0);
            this.Controls.Add(this.NewDocContab);
            this.Controls.Add(this.ChangeDocContab);
            this.Controls.Add(this.cmdInserirRecibosXML);
            this.Controls.Add(this.cmdInserirDocumentosXML);
            this.Controls.Add(this.cmdSair);
            this.Name = "fOutrosExemplos";
            this.Text = "Outros Exemplos";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button cmdSair;
        public System.Windows.Forms.Button cmdInserirDocumentosXML;
        public System.Windows.Forms.Button cmdInserirRecibosXML;
        private System.Windows.Forms.OpenFileDialog CommonDialog1Open;
        public System.Windows.Forms.Button NewDocContab;
        public System.Windows.Forms.Button ChangeDocContab;
        private System.Windows.Forms.Button _btnTrfArm_1;
        private System.Windows.Forms.Button _btnTrfArm_0;
        public System.Windows.Forms.CheckBox LigGaCom;
        public System.Windows.Forms.ComboBox cmbTipoPrecoStock;
        public System.Windows.Forms.Label Label98;
    }
}