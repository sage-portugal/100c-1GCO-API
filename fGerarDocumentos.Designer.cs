namespace ApiLaunchBusiness
{
    partial class fGerarDocumentos
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
            this.cmdTAR = new System.Windows.Forms.Button();
            this.chkCcfToGr = new System.Windows.Forms.CheckBox();
            this.fraGDDocs = new System.Windows.Forms.GroupBox();
            this.lstGDDocs = new System.Windows.Forms.ListBox();
            this.cmdGDGerarDocs = new System.Windows.Forms.Button();
            this.cmbGDTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtGDLinhasPorDocumento = new System.Windows.Forms.TextBox();
            this.txtGDNumDoc = new System.Windows.Forms.TextBox();
            this.txtGDSerie = new System.Windows.Forms.TextBox();
            this.txtGDSector = new System.Windows.Forms.TextBox();
            this.txtGDDataDoc = new System.Windows.Forms.TextBox();
            this.Label93 = new System.Windows.Forms.Label();
            this.Label92 = new System.Windows.Forms.Label();
            this.Label91 = new System.Windows.Forms.Label();
            this.Label90 = new System.Windows.Forms.Label();
            this.Label89 = new System.Windows.Forms.Label();
            this.Label88 = new System.Windows.Forms.Label();
            this.cmdSair = new System.Windows.Forms.Button();
            this.fraGDDocs.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdTAR
            // 
            this.cmdTAR.BackColor = System.Drawing.SystemColors.Control;
            this.cmdTAR.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdTAR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdTAR.Location = new System.Drawing.Point(202, 189);
            this.cmdTAR.Name = "cmdTAR";
            this.cmdTAR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdTAR.Size = new System.Drawing.Size(66, 21);
            this.cmdTAR.TabIndex = 253;
            this.cmdTAR.Text = "TAR";
            this.cmdTAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdTAR.UseVisualStyleBackColor = false;
            this.cmdTAR.Click += new System.EventHandler(this.cmdTAR_Click);
            // 
            // chkCcfToGr
            // 
            this.chkCcfToGr.BackColor = System.Drawing.SystemColors.Control;
            this.chkCcfToGr.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkCcfToGr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCcfToGr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCcfToGr.Location = new System.Drawing.Point(12, 164);
            this.chkCcfToGr.Name = "chkCcfToGr";
            this.chkCcfToGr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCcfToGr.Size = new System.Drawing.Size(161, 16);
            this.chkCcfToGr.TabIndex = 252;
            this.chkCcfToGr.Text = "Converter CCF em GR";
            this.chkCcfToGr.UseVisualStyleBackColor = false;
            // 
            // fraGDDocs
            // 
            this.fraGDDocs.BackColor = System.Drawing.SystemColors.Control;
            this.fraGDDocs.Controls.Add(this.lstGDDocs);
            this.fraGDDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraGDDocs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraGDDocs.Location = new System.Drawing.Point(287, -1);
            this.fraGDDocs.Name = "fraGDDocs";
            this.fraGDDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraGDDocs.Size = new System.Drawing.Size(366, 266);
            this.fraGDDocs.TabIndex = 251;
            this.fraGDDocs.TabStop = false;
            this.fraGDDocs.Text = "Documentos Gerados : ";
            // 
            // lstGDDocs
            // 
            this.lstGDDocs.BackColor = System.Drawing.SystemColors.Window;
            this.lstGDDocs.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstGDDocs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstGDDocs.IntegralHeight = false;
            this.lstGDDocs.Location = new System.Drawing.Point(10, 20);
            this.lstGDDocs.Name = "lstGDDocs";
            this.lstGDDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstGDDocs.Size = new System.Drawing.Size(346, 237);
            this.lstGDDocs.TabIndex = 226;
            // 
            // cmdGDGerarDocs
            // 
            this.cmdGDGerarDocs.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGDGerarDocs.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGDGerarDocs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGDGerarDocs.Location = new System.Drawing.Point(202, 164);
            this.cmdGDGerarDocs.Name = "cmdGDGerarDocs";
            this.cmdGDGerarDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGDGerarDocs.Size = new System.Drawing.Size(66, 21);
            this.cmdGDGerarDocs.TabIndex = 225;
            this.cmdGDGerarDocs.Text = "Gerar";
            this.cmdGDGerarDocs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdGDGerarDocs.UseVisualStyleBackColor = false;
            this.cmdGDGerarDocs.Click += new System.EventHandler(this.cmdGDGerarDocs_Click);
            // 
            // cmbGDTipoDoc
            // 
            this.cmbGDTipoDoc.BackColor = System.Drawing.SystemColors.Window;
            this.cmbGDTipoDoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbGDTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGDTipoDoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGDTipoDoc.Location = new System.Drawing.Point(157, 9);
            this.cmbGDTipoDoc.Name = "cmbGDTipoDoc";
            this.cmbGDTipoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbGDTipoDoc.Size = new System.Drawing.Size(113, 21);
            this.cmbGDTipoDoc.TabIndex = 219;
            // 
            // txtGDLinhasPorDocumento
            // 
            this.txtGDLinhasPorDocumento.AcceptsReturn = true;
            this.txtGDLinhasPorDocumento.BackColor = System.Drawing.SystemColors.Window;
            this.txtGDLinhasPorDocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGDLinhasPorDocumento.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGDLinhasPorDocumento.Location = new System.Drawing.Point(157, 136);
            this.txtGDLinhasPorDocumento.MaxLength = 0;
            this.txtGDLinhasPorDocumento.Name = "txtGDLinhasPorDocumento";
            this.txtGDLinhasPorDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGDLinhasPorDocumento.Size = new System.Drawing.Size(114, 20);
            this.txtGDLinhasPorDocumento.TabIndex = 224;
            // 
            // txtGDNumDoc
            // 
            this.txtGDNumDoc.AcceptsReturn = true;
            this.txtGDNumDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtGDNumDoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGDNumDoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGDNumDoc.Location = new System.Drawing.Point(157, 34);
            this.txtGDNumDoc.MaxLength = 0;
            this.txtGDNumDoc.Name = "txtGDNumDoc";
            this.txtGDNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGDNumDoc.Size = new System.Drawing.Size(114, 20);
            this.txtGDNumDoc.TabIndex = 220;
            // 
            // txtGDSerie
            // 
            this.txtGDSerie.AcceptsReturn = true;
            this.txtGDSerie.BackColor = System.Drawing.SystemColors.Window;
            this.txtGDSerie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGDSerie.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGDSerie.Location = new System.Drawing.Point(157, 60);
            this.txtGDSerie.MaxLength = 0;
            this.txtGDSerie.Name = "txtGDSerie";
            this.txtGDSerie.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGDSerie.Size = new System.Drawing.Size(114, 20);
            this.txtGDSerie.TabIndex = 221;
            // 
            // txtGDSector
            // 
            this.txtGDSector.AcceptsReturn = true;
            this.txtGDSector.BackColor = System.Drawing.SystemColors.Window;
            this.txtGDSector.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGDSector.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGDSector.Location = new System.Drawing.Point(157, 84);
            this.txtGDSector.MaxLength = 0;
            this.txtGDSector.Name = "txtGDSector";
            this.txtGDSector.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGDSector.Size = new System.Drawing.Size(114, 20);
            this.txtGDSector.TabIndex = 222;
            // 
            // txtGDDataDoc
            // 
            this.txtGDDataDoc.AcceptsReturn = true;
            this.txtGDDataDoc.BackColor = System.Drawing.SystemColors.Window;
            this.txtGDDataDoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGDDataDoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGDDataDoc.Location = new System.Drawing.Point(157, 109);
            this.txtGDDataDoc.MaxLength = 0;
            this.txtGDDataDoc.Name = "txtGDDataDoc";
            this.txtGDDataDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGDDataDoc.Size = new System.Drawing.Size(114, 20);
            this.txtGDDataDoc.TabIndex = 223;
            // 
            // Label93
            // 
            this.Label93.BackColor = System.Drawing.Color.Transparent;
            this.Label93.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label93.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label93.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label93.Location = new System.Drawing.Point(12, 136);
            this.Label93.Name = "Label93";
            this.Label93.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label93.Size = new System.Drawing.Size(140, 19);
            this.Label93.TabIndex = 250;
            this.Label93.Text = "Linhas por Documento";
            // 
            // Label92
            // 
            this.Label92.BackColor = System.Drawing.Color.Transparent;
            this.Label92.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label92.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label92.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label92.Location = new System.Drawing.Point(12, 9);
            this.Label92.Name = "Label92";
            this.Label92.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label92.Size = new System.Drawing.Size(140, 19);
            this.Label92.TabIndex = 249;
            this.Label92.Text = "Tipo de Documento";
            // 
            // Label91
            // 
            this.Label91.BackColor = System.Drawing.Color.Transparent;
            this.Label91.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label91.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label91.Location = new System.Drawing.Point(12, 34);
            this.Label91.Name = "Label91";
            this.Label91.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label91.Size = new System.Drawing.Size(140, 19);
            this.Label91.TabIndex = 248;
            this.Label91.Text = "Nr. Documento Inicial";
            // 
            // Label90
            // 
            this.Label90.BackColor = System.Drawing.Color.Transparent;
            this.Label90.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label90.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label90.Location = new System.Drawing.Point(12, 59);
            this.Label90.Name = "Label90";
            this.Label90.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label90.Size = new System.Drawing.Size(140, 19);
            this.Label90.TabIndex = 247;
            this.Label90.Text = "Serie";
            // 
            // Label89
            // 
            this.Label89.BackColor = System.Drawing.Color.Transparent;
            this.Label89.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label89.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label89.Location = new System.Drawing.Point(12, 84);
            this.Label89.Name = "Label89";
            this.Label89.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label89.Size = new System.Drawing.Size(140, 19);
            this.Label89.TabIndex = 246;
            this.Label89.Text = "Sector";
            // 
            // Label88
            // 
            this.Label88.BackColor = System.Drawing.Color.Transparent;
            this.Label88.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label88.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label88.Location = new System.Drawing.Point(12, 109);
            this.Label88.Name = "Label88";
            this.Label88.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label88.Size = new System.Drawing.Size(140, 19);
            this.Label88.TabIndex = 245;
            this.Label88.Text = "Data do Documento";
            // 
            // cmdSair
            // 
            this.cmdSair.Location = new System.Drawing.Point(647, 299);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(75, 25);
            this.cmdSair.TabIndex = 254;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // fGerarDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 336);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdTAR);
            this.Controls.Add(this.chkCcfToGr);
            this.Controls.Add(this.Label92);
            this.Controls.Add(this.fraGDDocs);
            this.Controls.Add(this.Label88);
            this.Controls.Add(this.cmdGDGerarDocs);
            this.Controls.Add(this.Label89);
            this.Controls.Add(this.cmbGDTipoDoc);
            this.Controls.Add(this.Label90);
            this.Controls.Add(this.txtGDLinhasPorDocumento);
            this.Controls.Add(this.Label91);
            this.Controls.Add(this.txtGDNumDoc);
            this.Controls.Add(this.Label93);
            this.Controls.Add(this.txtGDSerie);
            this.Controls.Add(this.txtGDDataDoc);
            this.Controls.Add(this.txtGDSector);
            this.Name = "fGerarDocumentos";
            this.Text = "GerarDocumentos";
            this.fraGDDocs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cmdTAR;
        public System.Windows.Forms.CheckBox chkCcfToGr;
        public System.Windows.Forms.GroupBox fraGDDocs;
        public System.Windows.Forms.ListBox lstGDDocs;
        public System.Windows.Forms.Button cmdGDGerarDocs;
        public System.Windows.Forms.ComboBox cmbGDTipoDoc;
        public System.Windows.Forms.TextBox txtGDLinhasPorDocumento;
        public System.Windows.Forms.TextBox txtGDNumDoc;
        public System.Windows.Forms.TextBox txtGDSerie;
        public System.Windows.Forms.TextBox txtGDSector;
        public System.Windows.Forms.TextBox txtGDDataDoc;
        public System.Windows.Forms.Label Label93;
        public System.Windows.Forms.Label Label92;
        public System.Windows.Forms.Label Label91;
        public System.Windows.Forms.Label Label90;
        public System.Windows.Forms.Label Label89;
        public System.Windows.Forms.Label Label88;
        public System.Windows.Forms.Button cmdSair;
    }
}