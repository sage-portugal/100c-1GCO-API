namespace ApiLaunchBusiness
{
    partial class fPrintDialog
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

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbModelo;
        private System.Windows.Forms.TextBox tbNumeroVias;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ComboBox cbImpressoras;
        private System.Windows.Forms.Label lblImpressora;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblNumeroDe;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbModelo = new System.Windows.Forms.TextBox();
            this.tbNumeroVias = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.cbImpressoras = new System.Windows.Forms.ComboBox();
            this.lblImpressora = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblNumeroDe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbModelo
            // 
            this.tbModelo.Location = new System.Drawing.Point(102, 12);
            this.tbModelo.Name = "tbModelo";
            this.tbModelo.Size = new System.Drawing.Size(193, 20);
            this.tbModelo.TabIndex = 7;
            this.tbModelo.Text = "SQLFACTCLIRTF.RPT";
            // 
            // tbNumeroVias
            // 
            this.tbNumeroVias.Location = new System.Drawing.Point(102, 42);
            this.tbNumeroVias.Name = "tbNumeroVias";
            this.tbNumeroVias.Size = new System.Drawing.Size(55, 20);
            this.tbNumeroVias.TabIndex = 5;
            this.tbNumeroVias.Text = "1";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(216, 72);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(81, 25);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "C&ancelar";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(126, 72);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(81, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "&Confirmar";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cbImpressoras
            // 
            this.cbImpressoras.Location = new System.Drawing.Point(66, 84);
            this.cbImpressoras.Name = "cbImpressoras";
            this.cbImpressoras.Size = new System.Drawing.Size(199, 21);
            this.cbImpressoras.TabIndex = 3;
            this.cbImpressoras.Visible = false;
            // 
            // lblImpressora
            // 
            this.lblImpressora.Location = new System.Drawing.Point(6, 84);
            this.lblImpressora.Name = "lblImpressora";
            this.lblImpressora.Size = new System.Drawing.Size(54, 13);
            this.lblImpressora.TabIndex = 2;
            this.lblImpressora.Text = "Impressora:";
            this.lblImpressora.Visible = false;
            // 
            // lblModelo
            // 
            this.lblModelo.Location = new System.Drawing.Point(12, 12);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(54, 13);
            this.lblModelo.TabIndex = 6;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblNumeroDe
            // 
            this.lblNumeroDe.Location = new System.Drawing.Point(12, 42);
            this.lblNumeroDe.Name = "lblNumeroDe";
            this.lblNumeroDe.Size = new System.Drawing.Size(77, 13);
            this.lblNumeroDe.TabIndex = 4;
            this.lblNumeroDe.Text = "Numero de vias:";
            // 
            // PrintDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 105);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbModelo);
            this.Controls.Add(this.tbNumeroVias);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.cbImpressoras);
            this.Controls.Add(this.lblImpressora);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblNumeroDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Imprimir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}