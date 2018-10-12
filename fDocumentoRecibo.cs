using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;



namespace ApiLaunchBusiness
{
    public partial class fDocumentoRecibo : Form
    {
        System.Type objType_DocumentosCcLin;
        System.Type objType_DocumentoContabilistico;
        System.Type objType_DocumentoFinanceiro;

        public fDocumentoRecibo()
        {
            InitializeComponent();
            Load += new EventHandler(fRecibos_Load);

            String DocumentoFinanceiro = Publicas.dynamicAPI() + ".DocumentoFinanceiro";
            String DocumentosCcLin = Publicas.dynamicAPI() + ".DocumentosCcLin";
            String DocumentoContabilistico = Publicas.dynamicAPI() + ".DocumentoContabilistico";

            objType_DocumentoFinanceiro = System.Type.GetTypeFromProgID(DocumentoFinanceiro);
            objType_DocumentosCcLin = System.Type.GetTypeFromProgID(DocumentosCcLin);
            objType_DocumentoContabilistico = System.Type.GetTypeFromProgID(DocumentoContabilistico);        

            Publicas.listProperties(objType_DocumentoFinanceiro, DocumentoFinanceiro);
            Publicas.listProperties(objType_DocumentosCcLin, DocumentosCcLin);
            Publicas.listProperties(objType_DocumentoContabilistico, DocumentoContabilistico);

        }

        private void fRecibos_Load(object sender, EventArgs e)
        {


            //   -----------------------------------------------------------------------------
            // e_Entidade.Recibo
            Text501.Text = "REC";
            Text502.Text = "1";
            Text503.Text = "0";
            Text504.Text = DateTime.Now.Year.ToString();
            Text505.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Text506.Text = "ANS";
            Text507.Text = "EUR";
            Text508.Text = "001";
            Text509.Text = "NUM";

            Text510.Text = "FT";
            Text511.Text = "25";
            Text512.Text = "1";
            Text513.Text = DateTime.Now.Year.ToString();
            Text514.Text = "10";

            Text520.Text = "FT";
            Text521.Text = "26";
            Text522.Text = "1";
            Text523.Text = DateTime.Now.Year.ToString();
            Text524.Text = "15";

            cmbRecPeg.SelectedIndex = 0;
        }
        //
        // Manutenção de Recibos
        //
        private void IAR_Recibo(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta");
                return;
            }
            dynamic objLinhas = null;
            dynamic objContabDoc = null;
            dynamic objDocumento = null;

            try
            {

                // Objecto Linha Gestão Empresarial
                objLinhas = null;


                // Objecto Contabiliadade
                objContabDoc = null;

                int lResult = 0;


                //Insere o Documento na Gestão Empresarial
                objDocumento = System.Activator.CreateInstance(objType_DocumentoFinanceiro);

                if (TipoOperacaoApi == Publicas.e_Operacao.Remover)
                {
                    objDocumento.Ler(Text501.Text, Convert.ToInt32(Double.Parse(Text503.Text)), Convert.ToInt16(Double.Parse(Text502.Text)), Convert.ToInt16(Double.Parse(Text504.Text)), "");
                    if (objDocumento.cab.NumeroDocumento != 0)
                    {
                        lResult = objDocumento.Remover();
                        if (lResult == 0)
                        {
                            fApi.DefInstance.EscreveMsg("Documento removido com sucesso!");
                        }
                        else
                        {
                            fApi.DefInstance.EscreveMsg(objDocumento.AllLogFileMessages);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O recibo indicado não existe.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    objDocumento = null;
                    return;
                }
                else
                {
                    if (TipoOperacaoApi == Publicas.e_Operacao.Alterar)
                    {
                        objDocumento.Ler(Text501.Text, Convert.ToInt32(Double.Parse(Text503.Text)), Convert.ToInt16(Double.Parse(Text502.Text)), Convert.ToInt16(Double.Parse(Text504.Text)), "");
                        if (objDocumento.cab.NumeroDocumento > 0)
                        {

                            while (objDocumento.Linhas.Count() > 0)
                            {
                                objDocumento.RetiraLinha(1);
                            };
                        }
                    }
                    //
                    objDocumento.cab.TipoDocumento = Text501.Text;
                    objDocumento.cab.Serie = Convert.ToInt16(Double.Parse(Text502.Text));
                    objDocumento.cab.NumeroDocumento = Convert.ToInt32(Double.Parse(Text503.Text));
                    objDocumento.cab.Ano = Convert.ToInt16(Double.Parse(Text504.Text));
                    objDocumento.cab.Data = Text505.Text;
                    objDocumento.cab.Sector = Text506.Text;
                    objDocumento.cab.Moeda = Text507.Text;
                    //Fornecedor=1; Cliente=2
                    if (cmbRecPeg.SelectedIndex == 0)
                    {
                        objDocumento.cab.TipoTerceiro = 2;
                    }
                    else
                    {
                        objDocumento.cab.TipoTerceiro = 1;
                    }
                    objDocumento.cab.Terceiro = Text508.Text;
                    objDocumento.cab.ModoDePagamento = Text509.Text;
                    //
                    if (TipoOperacaoApi == Publicas.e_Operacao.Inserir)
                    {
                        //   *
                        //   * -----------------------------------------------------------------------------------------------
                        //   * Ligação a Bancos
                        //   * -----------------------------------------------------------------------------------------------
                        //   * IMPORTANTE
                        //   * -----------------------------------------------------------------------------------------------
                        //   * Se deseja utilizar a Ligação á Bancos , é aconselhavel a indicação da informação Bancária,
                        //   * deve utilizar o segmento de código que se segue :
                        //   * -----------------------------------------------------------------------------------------------
                        //   *
                        objDocumento.cab.BancoEmpresa = "BK";
                        objDocumento.cab.AgenciaEmpresa = "478";
                        objDocumento.cab.ContaBncEmpresa = "003500003636400";
                        objDocumento.cab.NoDocBancario = "0123";
                        objDocumento.cab.PracaBanco = "Porto";
                        objDocumento.cab.Banco = "BK";
                    }
                }

                //Se for um valor por conta....
                decimal nValorPorConta = Convert.ToInt32(txtValorPorConta.Text);
                if (nValorPorConta > 0)
                {
                    //Remover as linhas

                    while (objDocumento.Linhas.Count() > 0)
                    {
                        objDocumento.Linhas.Remove(0);
                    };
                    //
                    objDocumento.cab.ValorRegularizado = nValorPorConta;
                }
                else
                {
                    //LINHAS
                    if (Strings.Len(Text510.Text) > 0)
                    {
                        objLinhas = System.Activator.CreateInstance(objType_DocumentosCcLin);

                        objLinhas.TipoDocumentoLiq = Text510.Text;
                        objLinhas.NumeroDocumentoLiq = Convert.ToInt32(Double.Parse(Text511.Text));
                        objLinhas.SerieDoLiquidado = Convert.ToInt16(Double.Parse(Text512.Text));
                        objLinhas.Anol = Convert.ToInt16(Double.Parse(Text513.Text));
                        objLinhas.ValorPago = Convert.ToInt32(Text514.Text);
                        lResult = objDocumento.AdicionaLinha(objLinhas);
                        objLinhas = null;
                    }

                    if (Strings.Len(Text521.Text) > 0)
                    {
                        objLinhas = System.Activator.CreateInstance(objType_DocumentosCcLin);
                        objLinhas.TipoDocumentoLiq = Text520.Text;
                        objLinhas.NumeroDocumentoLiq = Convert.ToInt32(Double.Parse(Text521.Text));
                        objLinhas.SerieDoLiquidado = Convert.ToInt16(Double.Parse(Text522.Text));
                        objLinhas.Anol = Convert.ToInt16(Double.Parse(Text523.Text));
                        objLinhas.ValorPago = Convert.ToInt32(Text524.Text);
                        lResult = objDocumento.AdicionaLinha(objLinhas);
                        objLinhas = null;
                    }
                }

                if (objDocumento.Validar((short)((int)TipoOperacaoApi)) != 0)
                {
                    fApi.DefInstance.EscreveMsg(objDocumento.UltimaMensagem());
                    objDocumento = null;
                    return;
                }

                switch (TipoOperacaoApi)
                {
                    case Publicas.e_Operacao.Inserir:
                        lResult = objDocumento.Inserir();
                        if (lResult == 0)
                        {
                            fApi.DefInstance.EscreveMsg("Documento inserido com sucesso!" + Environment.NewLine + objDocumento.AllLogFileMessages);
                        }
                        break;
                    case Publicas.e_Operacao.Alterar:
                        lResult = objDocumento.Alterar();
                        if (lResult == 0)
                        {
                            fApi.DefInstance.EscreveMsg("Documento alterado com sucesso!" + Environment.NewLine + objDocumento.AllLogFileMessages);
                        }
                        break;
                    case Publicas.e_Operacao.Remover:
                        lResult = objDocumento.Remover();
                        if (lResult == 0)
                        {
                            fApi.DefInstance.EscreveMsg("Documento removido com sucesso!" + Environment.NewLine + objDocumento.AllLogFileMessages);
                        }
                        break;
                }

                Text503.Text = objDocumento.cab.NumeroDocumento.ToString();

                //   *
                //   * -----------------------------------------------------------------------------------------------
                //   * Ligação á Contabiliade
                //   * -----------------------------------------------------------------------------------------------
                //   * IMPORTANTE
                //   * -----------------------------------------------------------------------------------------------
                //   * Se deseja utilizar a Ligação á Contabiliade ,
                //   * deve utilizar o segmento de código que se segue :
                //   * -----------------------------------------------------------------------------------------------
                //   *
                int lResultContab = 0;
                if (lResult == 0)
                {
                    if (LigGaFin.CheckState == CheckState.Checked)
                    {

                        //
                        // Atenção, é obrigatório voltar a ler o Documento acabado de gravar para a integração na Contabilidade
                        //
                        lResult = objDocumento.Ler(Text501.Text, Convert.ToInt32(Double.Parse(Text503.Text)), Convert.ToInt16(Double.Parse(Text502.Text)), Convert.ToInt16(Double.Parse(Text504.Text)), "");

                        if (lResult == 0)
                        {
                            objContabDoc = System.Activator.CreateInstance(objType_DocumentoContabilistico);

                            lResultContab = objContabDoc.DocumentoFinanceiro(ref objDocumento);

                            lResultContab = objContabDoc.Validar();
                            if (lResultContab == 0)
                            {

                                lResultContab = objContabDoc.Inserir();
                            }

                            if (lResultContab != 0)
                            {
                                fApi.DefInstance.EscreveMsg(objContabDoc.UltimaMensagem());
                            }
                            objContabDoc = null;
                        }
                    }
                }
                //   * -----------------------------------------------------------------------------------------------

                if (lResult != 0)
                {   // Aconteceu ERRO na operação
                    fApi.DefInstance.EscreveMsg(objDocumento.AllLogFileMessages);
                }
                Text503.Text = "0";
            }
            finally
            {

                if (objDocumento != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objDocumento);
                }

                if (objLinhas != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objLinhas);
                }


            }

        }


        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            IAR_Recibo(Publicas.e_Operacao.Alterar);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            IAR_Recibo(Publicas.e_Operacao.Remover);
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            IAR_Recibo(Publicas.e_Operacao.Leitura);
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            IAR_Recibo(Publicas.e_Operacao.Inserir);
        }

        private void cmdClear_1_Click(object sender, EventArgs e)
        {
                    Text510.Text = ""; 
					Text511.Text = ""; 
					Text512.Text = ""; 
					Text513.Text = ""; 
					Text514.Text = ""; 
        }

        private void cmdClear2_Click(object sender, EventArgs e)
        {
            		Text520.Text = ""; 
					Text521.Text = ""; 
					Text522.Text = ""; 
					Text523.Text = ""; 
					Text524.Text = ""; 
        }

        //
        // Seleção de tipo de Recibo
        //
        private void cmbRecPeg_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            switch (cmbRecPeg.SelectedIndex)
            {
                case 0:
                    Label35.Text = "Cliente";
//                    SSTabEntidade.TabPages[4].Text = "Recibo";
                    Text510.Text = "FT";
                    Text520.Text = "FT";
                    break;
                case 1:
                    Label35.Text = "Fornecedor";
  //                  SSTabEntidade.TabPages[4].Text = "Pagamento";
                    Text510.Text = "CCF";
                    Text520.Text = "CCF";
                    break;
            }
        }


    }
}

