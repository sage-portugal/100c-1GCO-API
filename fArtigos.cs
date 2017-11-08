using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ApiLaunchBusiness
{
    public partial class fArtigos : Form
    {

        System.Type objType_Artigos;
        
        public fArtigos()
        {
            InitializeComponent();
            Load += new EventHandler(fArtigos_Load);
            String Artigos = Publicas.dynamicAPI() + ".Artigos";
            objType_Artigos = System.Type.GetTypeFromProgID(Artigos);
        }

        private void fArtigos_Load(object sender, EventArgs e)
        {
            // e_Entidade.Artigo
            txtCodigo.Text = "A1";
            txtAbreviatura.Text = "Abra1";
            txtNome.Text = "Abraçadeiras 2x1";
            txtPeso.Text = "123,000";
            txtPesoLiq.Text = "0,000";
            txtVolume.Text = "0,000";

            cmbIva.Items.Insert(0, "");
            cmbIva.Items.Insert(1, "0%");
            cmbIva.Items.Insert(2, "8%");
            cmbIva.Items.Insert(3, "13%");
            cmbIva.Items.Insert(4, "23%");
            cmbIva.SelectedIndex = 4;

            cmbUnidades.Sorted = true;
            cmbUnidades.Items.Insert(0, "UN");
            cmbUnidades.Items.Insert(1, "CX");
            cmbUnidades.Items.Insert(2, "MT");
            cmbUnidades.SelectedIndex = 1;

            cmbGrupo.Sorted = true;
            cmbGrupo.Items.Insert(0, "Ferramentas");
            cmbGrupo.Items.Insert(1, "Peças");
            cmbGrupo.Items.Insert(2, "Acessórios");
            cmbGrupo.SelectedIndex = 2;

            cmbFamilia.Sorted = true;
            cmbFamilia.Items.Insert(0, "Aço");
            cmbFamilia.Items.Insert(1, "Niquel");
            cmbFamilia.Items.Insert(2, "Bronze");
            cmbFamilia.SelectedIndex = 2;

            cmbSubFamilia.Sorted = true;
            cmbSubFamilia.Items.Insert(0, "Profissional");
            cmbSubFamilia.Items.Insert(1, "Amador");
            cmbSubFamilia.Items.Insert(2, "Industrial");
            cmbSubFamilia.SelectedIndex = 2;

            txtObservacoes.Text = "Fixação Horizontal";
            
        }
        // -----------------------------------------------------------------------------------------
        //
        // Manutenção de Artigos
        //
        // -----------------------------------------------------------------------------------------
        private void Manutencao_Artigos(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta!");
                return;
            }

            dynamic oArtigo = null;
            //
            int lResult = 0;
            int resultIndex = -1;
            //
            decimal numeroDecimal;

            try
            {
                switch (TipoOperacaoApi)
                {                      
                    // Leitura
                    case Publicas.e_Operacao.Leitura:
                        oArtigo = System.Activator.CreateInstance(objType_Artigos);

                        lResult = oArtigo.Ler(txtCodigo.Text);
                        if (String.IsNullOrEmpty(oArtigo.Codigo))
                        {
                            txtAbreviatura.Text = "";
                            txtNome.Text = "";
                            txtPeso.Text = "";
                            txtPesoLiq.Text = "";
                            txtVolume.Text = "";
                            cmbIva.Text = "";
                            cmbUnidades.Text = "";
                            cmbGrupo.Text = "";
                            cmbFamilia.Text = "";
                            cmbSubFamilia.Text = "";
                            txtObservacoes.Text = "";
                            fApi.DefInstance.EscreveMsg("Artigo não existe!");
                        }
                        else
                        {
                            // inserir novos grupos na Combo
                            resultIndex = cmbGrupo.FindStringExact(oArtigo.Grupo);
                            if (resultIndex == -1)
                            {                             
                                cmbGrupo.Items.Insert(cmbGrupo.Items.Count, oArtigo.Grupo);
                            }

                            // inserir novas familias na Combo
                            resultIndex = cmbFamilia.FindStringExact(oArtigo.Famili);
                            if (resultIndex == -1)
                            {
                                cmbFamilia.Items.Insert(cmbFamilia.Items.Count, oArtigo.Famili);
                            }

                            // inserir novos Subfamilias na Combo
                            resultIndex = cmbSubFamilia.FindStringExact(oArtigo.SubFam);
                            if (resultIndex == -1)
                            {
                                cmbSubFamilia.Items.Insert(cmbSubFamilia.Items.Count, oArtigo.SubFam);
                            }

                            // inserir novas Unidades na Combo
                            resultIndex = cmbUnidades.FindStringExact(oArtigo.UNBASE);
                            if (resultIndex == -1)
                            {
                                cmbUnidades.Items.Insert(cmbUnidades.Items.Count, oArtigo.UNBASE);
                            }
                            txtCodigo.Text = oArtigo.Codigo;
                            txtAbreviatura.Text = oArtigo.ABREV;
                            txtNome.Text = oArtigo.Nome;

                            txtPeso.Text = string.Format("{0:0.000}", oArtigo.Peso);
                            txtPesoLiq.Text = string.Format("{0:0.000}",oArtigo.PESOLIQ);
                            txtVolume.Text = string.Format("{0:0.000}", oArtigo.Volume);

                            cmbIva.SelectedIndex = oArtigo.IVA;
                            cmbUnidades.Text = oArtigo.UNBASE;
                            cmbGrupo.Text = oArtigo.Grupo;
                            cmbFamilia.Text = oArtigo.Famili;
                            cmbSubFamilia.Text = oArtigo.SubFam;
                            txtObservacoes.Text = oArtigo.OBSERV;
                            fApi.DefInstance.EscreveMsg("Artigo lido com sucesso!");
                        }

                        break;

                    // Inserir
                    case Publicas.e_Operacao.Inserir:
                        oArtigo = System.Activator.CreateInstance(objType_Artigos);
                        oArtigo.Codigo = txtCodigo.Text;
                        oArtigo.ABREV = txtAbreviatura.Text;
                        oArtigo.Nome = txtNome.Text;
                        if (Decimal.TryParse(txtPeso.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 0;
                        }
                        else
                        {
                            Decimal.Parse(txtPeso.Text, NumberStyles.Currency);
                        }
                        oArtigo.Peso = numeroDecimal;
                        txtPeso.Text = string.Format("{0:0.000}", numeroDecimal);

                        if (Decimal.TryParse(txtPesoLiq.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 0;
                        }
                        else
                        {
                            Decimal.Parse(txtPesoLiq.Text, NumberStyles.Currency);
                        }
                        oArtigo.PESOLIQ = numeroDecimal;
                        txtPesoLiq.Text = string.Format("{0:0.000}", numeroDecimal);

                        if (Decimal.TryParse(txtVolume.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 0;
                        }
                        else
                        {
                            Decimal.Parse(txtVolume.Text, NumberStyles.Currency);
                        }
                        oArtigo.Volume = numeroDecimal;
                        txtVolume.Text = string.Format("{0:0.000}", numeroDecimal);
                        
                        oArtigo.IVA = (short)cmbIva.SelectedIndex;
                        oArtigo.TpBem = Convert.ToInt16(Double.Parse("1")); // 1- Mercadorias; 2- Outros Bens e serviços; 3- Imobilizado
                        oArtigo.UNBASE = cmbUnidades.Text;
                        oArtigo.OBSERV = txtObservacoes.Text;
                        oArtigo.Grupo = cmbGrupo.Text;
                        oArtigo.Famili = cmbFamilia.Text;
                        oArtigo.SubFam = cmbSubFamilia.Text;

                        lResult = oArtigo.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oArtigo.UltimaMensagem());
                            return;
                        }
                        else
                        {
                            lResult = oArtigo.Inserir();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Artigo inserido com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oArtigo.UltimaMensagem());
                            }
                        }
                        break;

                     // Alterar
                    case Publicas.e_Operacao.Alterar:
                        oArtigo = System.Activator.CreateInstance(objType_Artigos);
                        oArtigo.Codigo = txtCodigo.Text;
                        oArtigo.ABREV = txtAbreviatura.Text;
                        oArtigo.Nome = txtNome.Text;
                        if (Decimal.TryParse(txtPeso.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 0;
                        }
                        else
                        {
                            Decimal.Parse(txtPeso.Text, NumberStyles.Currency);
                        }

                        oArtigo.Peso = numeroDecimal;
                        txtPeso.Text = string.Format("{0:0.000}", numeroDecimal);

                        if (Decimal.TryParse(txtPesoLiq.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 0;
                        }
                        else
                        {
                            Decimal.Parse(txtPesoLiq.Text, NumberStyles.Currency);
                        }
                        oArtigo.PESOLIQ = numeroDecimal;
                        txtPesoLiq.Text = string.Format("{0:0.000}", numeroDecimal);
                        
                        if (Decimal.TryParse(txtVolume.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 0;
                        }
                        else
                        {
                            Decimal.Parse(txtVolume.Text, NumberStyles.Currency);
                        }
                        oArtigo.Volume = numeroDecimal;
                        txtVolume.Text = string.Format("{0:0.000}", numeroDecimal);

                        oArtigo.IVA = (short)cmbIva.SelectedIndex;
                        oArtigo.TpBem = Convert.ToInt16(Double.Parse("1")); // 1- Mercadorias; 2- Outros Bens e serviços; 3- Imobilizado
                        oArtigo.UNBASE = cmbUnidades.Text;
                        oArtigo.OBSERV = txtObservacoes.Text;
                        oArtigo.Grupo = cmbGrupo.Text;
                        oArtigo.Famili = cmbFamilia.Text;
                        oArtigo.SubFam = cmbSubFamilia.Text;

                        lResult = oArtigo.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oArtigo.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oArtigo.Alterar();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Artigo alterado com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oArtigo.UltimaMensagem());
                            }
                        }
                        break;

                    // Remover
                    case Publicas.e_Operacao.Remover:
                        oArtigo = System.Activator.CreateInstance(objType_Artigos);
                        oArtigo.Ler(txtCodigo.Text);
                        lResult = oArtigo.Remover();

                        if (lResult == (int)Publicas.e_Result.Success)
                        {
                            txtCodigo.Text = String.Empty;
                            txtAbreviatura.Text = String.Empty;
                            txtNome.Text = String.Empty;
                            txtPeso.Text = String.Empty;
                            txtPesoLiq.Text = String.Empty;
                            txtVolume.Text = String.Empty;
                            cmbIva.Text = String.Empty;
                            cmbUnidades.Text = String.Empty;
                            txtObservacoes.Text = String.Empty;
                            cmbGrupo.Text = String.Empty;
                            cmbFamilia.Text = String.Empty;
                            cmbSubFamilia.Text = String.Empty;
                            fApi.DefInstance.EscreveMsg("Artigo removido com sucesso!");
                        }
                        else
                        {
                            // Aconteceu ERRO na operação
                            fApi.DefInstance.EscreveMsg(oArtigo.UltimaMensagem());
                        }
                        break;
                }
                oArtigo = null;
            }
            finally
            {
                if (oArtigo != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oArtigo);
                }
            }
        }


        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdLer_Click(object sender, EventArgs e)
        {
            Manutencao_Artigos(Publicas.e_Operacao.Leitura);
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            Manutencao_Artigos(Publicas.e_Operacao.Inserir);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            Manutencao_Artigos(Publicas.e_Operacao.Remover);
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            Manutencao_Artigos(Publicas.e_Operacao.Alterar);
        }

    }
}
