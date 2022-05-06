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
    public partial class fDocumentoComercial : Form
    {
        System.Type objType_DocumentoComercial;
        System.Type objType_DocumentosGcLin;
        System.Type objType_LotesLinha;
        System.Type objType_NumSerieLinha;
        System.Type objType_Bancos;
        System.Type objType_DocumentoContabilistico;
        System.Type objType_CamposLivresDoc;

        System.Type objType_DocumentoComercialCab;

        
        private bool isInitializingComponent;

        public fDocumentoComercial()
        {
            isInitializingComponent = true;
            InitializeComponent();
            isInitializingComponent = false;
            Load += new EventHandler(fDocumentoComercial_Load);
            ReLoadForm(false);

            String DocumentoComercial = Publicas.dynamicSageApiName() + ".DocumentoComercial";
            String DocumentosGcLin = Publicas.dynamicSageApiName() + ".DocumentosGcLin";
            String LotesLinha = Publicas.dynamicSageApiName() + ".LotesLinha";
            String NumSerieLinha = Publicas.dynamicSageApiName() + ".NumSerieLinha";
            String Bancos = Publicas.dynamicSageApiName() + ".Bancos";
            String DocumentoContabilistico = Publicas.dynamicSageApiName() + ".DocumentoContabilistico";
            String CamposLivresDoc = Publicas.dynamicSageApiName() + ".CamposLivresDocumentos";

            String DocumentoComercialCab = Publicas.dynamicSageDataName() + ".DLDocumentosGcCab";


            objType_DocumentoComercial = System.Type.GetTypeFromProgID(DocumentoComercial);
            objType_DocumentosGcLin = System.Type.GetTypeFromProgID(DocumentosGcLin);
            objType_LotesLinha = System.Type.GetTypeFromProgID(LotesLinha);
            objType_NumSerieLinha = System.Type.GetTypeFromProgID(NumSerieLinha);
            objType_Bancos = System.Type.GetTypeFromProgID(Bancos);
            objType_DocumentoContabilistico = System.Type.GetTypeFromProgID(DocumentoContabilistico);
            objType_CamposLivresDoc = System.Type.GetTypeFromProgID(CamposLivresDoc);

            objType_DocumentoComercialCab = System.Type.GetTypeFromProgID(DocumentoComercialCab);

            Publicas.listProperties(objType_DocumentoComercial, DocumentoComercial, "Documento Comercial");
            Publicas.listProperties(objType_DocumentoComercialCab, DocumentoComercialCab, "Documento Comercial Cabeçalho");
            Publicas.listProperties(objType_DocumentosGcLin, DocumentosGcLin, "Documento Comercial Linhas");
            Publicas.listProperties(objType_LotesLinha, LotesLinha, "Linha de Lotes");
            Publicas.listProperties(objType_NumSerieLinha, NumSerieLinha, "Linha de Numeros de Série");
            Publicas.listProperties(objType_Bancos, Bancos, "Banco do Documento");
            Publicas.listProperties(objType_DocumentoContabilistico, DocumentoContabilistico, "Documento Contabilistico");

            if (Publicas.dynamicAPIEnum().Equals(Publicas.e_Api.SageBGCOApi10))
            {
                cmdImprimir.Enabled = false;
            }
        }

        private void fDocumentoComercial_Load(object sender, EventArgs e)
        {
            for (int n = 1; n <= oModAdicional.Length - 1; n++)
            {
                fAdicional[n].Visible = false;
                fAdicional[n].Top = 190;
                fAdicional[n].Left = 8;
            }

            oModAdicional[0].Checked = true;

            //   -----------------------------------------------------------------------------
            // e_Entidade.Factura
            txtTpDoc.Text = "FT";
            txtSerie.Text = "1";
            txtNumero.Text = "0";
            txtAno.Text = DateTime.Now.Year.ToString();
            txtData.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtSetor.Text = "ANS";
            Text407.Text = "EUR";
            Text408.Text = "001";
            Text409.Text = "4";

            //Linha 1
            Text410.Text = "AR1";
            Text411.Text = "PEX01";
            Text412.Text = "10";
            Text413.Text = "1";
            Text414.Text = "23";
            txtUn1.Text = "UN";
            txtFactor1.Text = "1";

            //Linha 2
            Text420.Text = "AR1";
            Text421.Text = "CAF01";
            Text422.Text = "20";
            Text423.Text = "2";
            Text424.Text = "13";
            txtUN2.Text = "UN";
            txtFactor2.Text = "1";

            //Linha 1 - Lote 1
            Text450.Text = "A100001";
            Text451.Text = "LT 1/1";
            Text452.Text = DateTime.Now.AddDays(750).ToString("dd-MM-yyyy");
            Text453.Text = "11";

            //Linha 1 - Lote 2
            Text460.Text = "A100002";
            Text461.Text = "LT 2/2";
            Text462.Text = DateTime.Now.AddDays(500).ToString("dd-MM-yyyy");
            Text463.Text = "9";

            //Linha 2 - Numser 1
            Text430.Text = "N1";

            //Linha 2 - Numser 2
            Text440.Text = "N2";

            cmbTpTercDocCom.SelectedIndex = 1;
            cmbTipoPrecoStock.SelectedIndex = cmbTipoPrecoStock.Items.Count - 1;
            cmbOrigem.SelectedIndex = 0;

            panelFinalizado.Visible = false;
            cmdFinalizar.Visible = false;

        }

        //
        // Seleção do Módulo Adicional dos Documentos Comerciais
        //
        private void oModAdicional_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (((RadioButton)eventSender).Checked)
            {
                if (isInitializingComponent)
                {
                    return;
                }
                int Index = Array.IndexOf(oModAdicional, eventSender);

                for (int n = 1; n <= oModAdicional.Length - 1; n++)
                {
                    fAdicional[n].Visible = false;
                }

                switch (Index)
                {
                    case 1:
                        fAdicional[1].Visible = true;
                        break;

                    case 2:
                        fAdicional[2].Visible = true;
                        break;

                    case 3:
                        fAdicional[3].Visible = true;
                        break;
                }
            }
        }

        //
        // Finaliza um documento preparado
        //
        private void IAR_Finalizar()
        {
            if (mApi.my_api.AbreEmpresa == false)               
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta");
                return;
            }
            dynamic objDocumento = null;

            try
            {
                string TipoDoc = String.Empty;
                string Serie = String.Empty;
                int Numdoc = 0;
                int Ano = 0;

                try
                {
                    objDocumento = null;
                
                    TipoDoc = txtTpDoc.Text;
                    Serie = txtSerie.Text;
                    Numdoc = Convert.ToInt32(Double.Parse(txtNumero.Text));
                    Ano = Convert.ToInt32(Double.Parse(txtAno.Text));

                    objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);

                    if (objDocumento.Finalizar((short)Ano, TipoDoc, Serie, Numdoc, DateTime.Parse("00:00:00")) != 0)
                    {
                        //Erro
                        fApi.DefInstance.EscreveMsg(objDocumento.UltimaMensagem());
                    }
                    else
                    {
                        //OK
                        fApi.DefInstance.EscreveMsg(objDocumento.UltimaMensagem());
                    }
                    Marshal.ReleaseComObject(objDocumento);
                    objDocumento = null;
                    return;
                }
                catch (System.Exception excep)
                {
                    fApi.DefInstance.EscreveMsg(excep.Message);
                }
            }
            finally
            {
                if (objDocumento != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objDocumento);
                }

            }
        }

        // -----------------------------------------------------------------------------------------
        //
        // Manutenção de Documentos Comerciais
        //
        // -----------------------------------------------------------------------------------------
        private void IAR_Factura(Publicas.e_Operacao TipoOperacaoApi)
        {

            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta");
                return;
            }

            dynamic objDocumento = null;
            dynamic objLinhas = null;
            dynamic objLotes = null;
            dynamic objNumser = null;
            dynamic objContabDoc = null;
            dynamic objBanco = null;
            dynamic objCamposLivres = null;

            try
            {
                short numeroShort = 0;
                int numeroInt = 0;
                decimal numeroDecimal = 0;

                // Objecto Documento
                objDocumento = null;

                // Objecto Linha
                objLinhas = null;

                // Objecto Lotes
                objLotes = null;

                // Objecto Numeros de Serie
                objNumser = null;

                // Objecto Contabiliadade
                objContabDoc = null;

                // Objecto Bancos para Vendas a Dinheiro
                objBanco = null;

                // objecto para Campos Livre
                objCamposLivres = null;

                int lResult = 0;
                int lResultContab = 0;

                bool bExisteLinha1 = Strings.Len(Text410.Text) != 0;
                bool bExisteLinha2 = Strings.Len(Text420.Text) != 0;

                bool bExisteLote1 = Strings.Len(Text450.Text) != 0;
                bool bExisteLote2 = Strings.Len(Text460.Text) != 0;

                bool bExisteNumser1 = Strings.Len(Text430.Text) != 0;
                bool bExisteNumser2 = Strings.Len(Text440.Text) != 0;

                int iRes = 0;

                if (TipoOperacaoApi != Publicas.e_Operacao.Leitura)
                {

                    if (!bExisteLinha1 && !bExisteLinha2)
                    {
                        fApi.DefInstance.EscreveMsg("Documento sem Linhas");
                        return;
                    }

                    //   * Criação de um novo documento
                    objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);

                    iRes = 0;
                    if (TipoOperacaoApi == Publicas.e_Operacao.Alterar)
                    { //And Text402.Text = 0 Then
                        iRes = objDocumento.Ler(txtTpDoc.Text, Convert.ToInt32(txtNumero.Text), txtSerie.Text, Convert.ToInt16(Double.Parse(txtAno.Text)), "");
                        if (iRes != 0)
                        {
                            fApi.DefInstance.EscreveMsg("O Documento não existe");
                            return;
                        }
                        //Remover as linhas


                        while (objDocumento.Linhas.Count() > 0)
                        {
                            objDocumento.Linhas.Remove(1);
                        };
                        //remover os lotes
                        if (objDocumento.Lotes != null)
                        {

                            while (objDocumento.Lotes.Count() > 0)
                            {
                                objDocumento.Lotes.Remove(1);
                            };
                        }
                        //remover os NS

                        while (objDocumento.NumerosSerie.Count() > 0)
                        {
                            objDocumento.NumerosSerie.Remove(1);
                        };
                    }


                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Preenchimento do Cabeçalho
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    objDocumento.ActivarGrelhasDesconto = false;
                    objDocumento.ActivarLinhasBonus = true;
                    objDocumento.ActivarLinhasPreco = true;

                    objDocumento.cab.TipoDocumento = txtTpDoc.Text;
                    objDocumento.cab.Serie = Convert.ToInt16(txtSerie.Text);

                    if (Int32.TryParse(txtNumero.Text, out numeroInt) == false)
                    {
                        numeroInt = 0;
                    }
                    objDocumento.cab.NossoNoDocumento = numeroInt;
                    objDocumento.cab.Ano = Convert.ToInt16(txtAno.Text);
                    objDocumento.cab.Data = txtData.Text;
                    objDocumento.cab.Sector = txtSetor.Text;
                    objDocumento.cab.Moeda = Text407.Text;
                    objDocumento.cab.TipoTerceiro = (short)(cmbTpTercDocCom.SelectedIndex + 1);
                    objDocumento.cab.Terceiro = Text408.Text;
                    objDocumento.cab.DescontoCabecalho = Convert.ToDecimal(Text409.Text);
                    objDocumento.cab.RegimeIva = objDocumento.Terceiro.REGIVA;

                    objDocumento.cab.IVAIncluido = ((chkIvaIncluido.CheckState == CheckState.Checked) ? ((short)(-1)) : ((short)0));

                    objDocumento.cab.TipoPreco = (short)cmbTipoPrecoStock.SelectedIndex;

                    // Tipo de Sujeito Passivo de Iva
                    objDocumento.cab.SujeitoPassivo_Simplifica = 1;

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Certificação
                    //   * -----------------------------------------------------------------------------------------------
                    //   * IMPORTANTE
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Oficio Circulado 50001/2013
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    objDocumento.cab.SystemEntryDate = this.txtSystemEntryDate.Text;            //SystemEntryDate da Aplicação Integradora
                    objDocumento.cab.HashControl = this.txtHashControl.Text;                //Versão da Chave da Aplicação Integradora

                    if (Int16.TryParse(this.txtHashCertificate.Text, out numeroShort) == false)
                    {
                        numeroShort = 0;
                    }
                    objDocumento.cab.HashCertificate = numeroShort;                    //Certificado da Aplicação Integradora
                    objDocumento.cab.HashSign = this.txtHashSign.Text;                  //Assinatura da Aplicação Integradora
                    objDocumento.cab.InvoiceNo = this.txtInvoiceNo.Text;                 //InvoiceNo da Aplicação Integradora

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Origem dos Documentos
                    //   * -----------------------------------------------------------------------------------------------
                    //   * IMPORTANTE
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    //   *
                    //   * (0) NaoIndicado = Valor por omissão, inibe qualquer operação: Validar ou Inserir
                    //   *
                    //   *
                    //   * (1) NaoAplicavel = Para documentos sem relevância fiscal, Orçamentos e Encomendas
                    //   *                  - Mantêm o funcionamento anterior
                    //   *
                    //   *
                    //   * (2) Finalizado = Documento criado numa outra aplicação de Gestão Comercial
                    //   *                - Deve estar préviamente numerado
                    //   *                - Deve ser indicada uma série definida como "Não Assinada Externa"
                    //   *                - Não permite a utilizar o método "Alterar"
                    //   *
                    //   * objDocumento.cab.NossoNoDocumento = 1000
                    //   *
                    //   *
                    //   * (3) Preparacao = Documento supenso a gravar na Gestão Empresarial, deve ser transformado em definitivo manualmente
                    //   *            - Não pode estar préviamente numerado, numero a indicar deve ser = 0
                    //   *            - Deve ser indicada um série definida como "Assinada Interna"
                    //   *            - Será gravado em modo "Preparação"
                    //   *            - Permite a utilizar o método "Alterar"
                    //   *
                    //   * objDocumento.cab.NossoNoDocumento = 0
                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   *

                    // Atenção: objDocumento.Origem só tem Property Set/Let na API. Não tem Property Get
                    switch (cmbOrigem.SelectedIndex)
                    {
                        case 0:
                            objDocumento.Origem = Publicas.e_OrigemDocumento.NaoIndicado;
                            break;

                        case 1:
                            objDocumento.Origem = Publicas.e_OrigemDocumento.NaoAplicavel;
                            break;

                        case 2:
                            objDocumento.Origem = Publicas.e_OrigemDocumento.Finalizado;
                            break;

                        case 3:
                            objDocumento.Origem = Publicas.e_OrigemDocumento.Preparacao;
                            break;
                    }

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Informações bancárias para as Faturas Simplificadas
                    //   * -----------------------------------------------------------------------------------------------
                    //   * IMPORTANTE
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Se deseja utilizar Vendas a Dinheiro com ligação a Bancos,
                    //   * deve utilizar o segmento de código comentado que se segue :
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    if (objDocumento.cab.TipoDocumento.Equals("FS"))
                    {
                        objDocumento.cab.ModoDePagamento = "CHQ";
                        objBanco = System.Activator.CreateInstance(objType_Bancos);
                        objBanco.DocumentoBancario = "CHR";
                        objDocumento.Bancos = objBanco;
                        objDocumento.Bancos.bancoEmpresa = "BX";
                        objDocumento.Bancos.balcaoEmpresa = "478";
                        objDocumento.Bancos.contaEmpresa = "003500003636400";
                        objDocumento.Bancos.BancoCliente = "BX";
                        objDocumento.Bancos.Praca = "Porto";
                        objDocumento.Bancos.NumeroDocumento = "67891"; // numero documento bancário
                        //

                        objBanco = null;

                    }
                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Linha 1
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    if (bExisteLinha1)
                    {
                        objLinhas = System.Activator.CreateInstance(objType_DocumentosGcLin);
                        //Importante por causa das extensões
                        objLinhas.TipoTerceiro = objDocumento.cab.TipoTerceiro;
                        objLinhas.TipoDeLinha = 1;
                        objLinhas.Armazem = Text410.Text;
                        objLinhas.Artigo = Text411.Text;
                        objLinhas.PrecoUnitario = Decimal.Parse(Text412.Text, NumberStyles.Currency);
                        objLinhas.Quantidade = Decimal.Parse(Text413.Text, NumberStyles.Currency);
                        objLinhas.Unidade = "UN";
                        objLinhas.NumeroDaLinha = 1;
                        objLinhas.IvaLinhas = Decimal.Parse(Text414.Text, NumberStyles.Currency);
                        objLinhas.TaxaIva = Decimal.Parse(Text414.Text, NumberStyles.Currency);
                        objLinhas.DataMvStock = DateTime.Parse(objDocumento.cab.Data).AddDays(15).ToString("d");

                        //        //Extensões....
                        //        If objLinhas.Extendida Then
                        //            Call objLinhas.Extensao.SetValorCampo(objLinhas.Extensao.QuantosCampos, txtL1Ext1.Text)
                        //        End If


                        //Conversao...
                        //Preencher as seguintes propriedados se se pretender importar de originais
                        //objLinhas.Orano = 2011
                        //objLinhas.Ordoc = "GR"
                        //objLinhas.Orserie = "10"
                        //objLinhas.Ornum = 2
                        //objLinhas.LinhaOriginal = 1
                        //
                        //objDocumento.IgnoreOriginals = True

                        //  *
                        //  * -----------------------------------------------------------------------------------------------
                        //  * Importação de Documentos
                        //  * -----------------------------------------------------------------------------------------------
                        //  * IMPORTANTE
                        //  * -----------------------------------------------------------------------------------------------
                        //  * Se deseja efectuar o abatimento a linhas de documentos Originais,
                        //  * como efectua a importação dedocumentos, ORC -> GRM ou GRM-> FTR
                        //  * deve utilizar o segmento de código comentado que se segue :
                        //  * -----------------------------------------------------------------------------------------------
                        //  *
                        //Para abater a linhas de documento Original
                        //       objLinhas.Orano = 2014          //Ano
                        //       objLinhas.Ordoc = "ENF"         //Documento
                        //       objLinhas.Orserie = "1"           //Série Documento
                        //       objLinhas.Ornum = 2             //Numero DOcumento
                        //       objLinhas.LinhaOriginal = 1     //Numero da Linha Original
                        //       objLinhas.OrAreaGestao = 2      //Área de Gestão Original

                        //
                        // Metodo para determinar os campos a sugerir (ou não) da linha do documento
                        //
                        objLinhas.Unidade = txtUn1.Text;

                        if (decimal.TryParse(txtFactor1.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 1;
                        }
                        objLinhas.Factor = numeroDecimal;


                        bool SugereUnidade = false;       //Sugere a Unidade da Ficha do Artigo
                        bool SugereData = true;           //Sugere a Data de Movimentação do Artigo
                        bool SugereDescricao = true;      //Sugere a Descrição da Ficha do Artigo
                        bool SugereQuantidade = false;    //Sugere a Quantidade de Movimentação (Quantidade = 1)
                        bool SugerePrUnit = true;         //Sugere o Preço Unitário do Artigo
                        bool SugereDesconto = true;       //Sugere o Desconto do Artigo
                        bool SugereIva = false;           //Sugere a Taxa de Iva do Artigo

                        objDocumento.SugereValoresLin(ref objLinhas, ref SugereUnidade, ref SugereData, ref SugereDescricao, ref SugereQuantidade, ref SugerePrUnit, ref SugereDesconto, ref SugereIva);
                        //objLinhas.PrecoUnitarioIntroduzido = objLinhas.PrecoUnitario

                        lResult = objDocumento.AdicionaLinha(objLinhas);

                        //--------------------------------------------------------------------
                        //Modulo de Lotes
                        //--------------------------------------------------------------------
                        if (oModAdicional[1].Checked)
                        {

                            if (bExisteLote1)
                            {
                                objLotes = System.Activator.CreateInstance(objType_LotesLinha);

                                objLotes.NumeroLinhaDocComercial = 1;
                                objLotes.QuantidadeMovimentada = Decimal.Parse(Text453.Text, NumberStyles.Currency);

                                objLotes.campos.CodigoLote = Text450.Text;
                                objLotes.campos.VossoLote = Text451.Text;
                                if (objLotes.campos.VossoLote.Trim().Equals(String.Empty))
                                {
                                    objLotes.campos.VossoLote = objLotes.campos.CodigoLote;
                                }
                                objLotes.campos.DataValidade = Text452.Text;
                                //
                                objLotes.campos.Artigo = Text411.Text;
                                objLotes.campos.Armazem = Text410.Text;

                                // Se é uma linha importada de uma Operação Base, actualiza a QuantidadeAnterior,
                                // para não manter a coerência na tabela ARTLOT
                                if (objLinhas.OrAreaGestao == 4)
                                {
                                    objLotes.QuantidadeAnterior = objLotes.QuantidadeMovimentada;
                                }

                                lResult = objDocumento.AdicionaLote(objLotes);

                                objLotes = null;
                            }

                            if (bExisteLote2)
                            {
                                objLotes = System.Activator.CreateInstance(objType_LotesLinha);

                                objLotes.NumeroLinhaDocComercial = 1;
                                objLotes.QuantidadeMovimentada = Decimal.Parse(Text463.Text, NumberStyles.Currency);
                                //
                                objLotes.campos.CodigoLote = Text460.Text;
                                objLotes.campos.VossoLote = Text461.Text;
                                if (objLotes.campos.VossoLote.Trim().Equals(String.Empty))
                                {
                                    objLotes.campos.VossoLote = objLotes.campos.CodigoLote;
                                }
                                objLotes.campos.DataValidade = Text462.Text;
                                //
                                objLotes.campos.Artigo = Text411.Text;
                                objLotes.campos.Armazem = Text410.Text;

                                // Se é uma linha importada de uma Operação Base, actualiza a QuantidadeAnterior,
                                // para não manter a coerência na tabela ARTLOT
                                if (objLinhas.OrAreaGestao == 4)
                                {
                                    objLotes.QuantidadeAnterior = objLotes.QuantidadeMovimentada;
                                }

                                lResult = objDocumento.AdicionaLote(objLotes);

                                objLotes = null;
                            }
                            objLinhas = null;
                        }

                        //--------------------------------------------------------------------
                        //Modulo de NumSer
                        //--------------------------------------------------------------------
                        if (oModAdicional[2].Checked)
                        {

                            if (bExisteNumser1)
                            {
                                objNumser = System.Activator.CreateInstance(objType_NumSerieLinha);
                                objNumser.NumeroLinhaDocComercial = 1;
                                objNumser.campos.Artigo = Text411.Text;
                                objNumser.campos.Armazem = Text410.Text;
                                objNumser.campos.Noserie = Text430.Text;
                                objNumser.TipoDeLinha = 1; // Nova
                                lResult = objDocumento.AdicionaNumeroSerie(objNumser);

                                objNumser = null;
                            }

                            if (bExisteNumser2)
                            {
                                objNumser = System.Activator.CreateInstance(objType_NumSerieLinha);
                                objNumser.NumeroLinhaDocComercial = 1;
                                objNumser.campos.Artigo = Text411.Text;
                                objNumser.campos.Armazem = Text410.Text;
                                objNumser.campos.Noserie = Text440.Text;
                                objNumser.TipoDeLinha = 1; // Nova
                                lResult = objDocumento.AdicionaNumeroSerie(objNumser);

                                objNumser = null;
                            }

                        }

                        //--------------------------------------------------------------------
                        //Modulo de Cores e tamanhos
                        //--------------------------------------------------------------------
                        if (oModAdicional[2].Checked)
                        {
                        }
                    }
                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Linha 2
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    if (bExisteLinha2)
                    {
                        objLinhas = System.Activator.CreateInstance(objType_DocumentosGcLin);

                        //Importante por causa das extensões
                        objLinhas.TipoTerceiro = objDocumento.cab.TipoTerceiro;
                        objLinhas.TipoDeLinha = 1;
                        objLinhas.Armazem = Text420.Text;
                        objLinhas.Artigo = Text421.Text;
                        objLinhas.PrecoUnitario = Decimal.Parse(Text422.Text, NumberStyles.Currency);
                        objLinhas.Quantidade = Decimal.Parse(Text423.Text, NumberStyles.Currency);
                        objLinhas.Unidade = "UN";
                        //objLinhas.NumeroDaLinha = 2
                        //objLinhas.IvaLinhas = Text424.Text
                        objLinhas.TaxaIva = Decimal.Parse(Text424.Text, NumberStyles.Currency);
                        objLinhas.DataMvStock = DateTime.Parse(objDocumento.cab.Data).AddDays(30).ToString("d");

                        //
                        // Metodo para determinar os campos a sugerir (ou não) da linha do documento
                        //
                        bool SugereUnidade = false;       //Sugere a Unidade da Ficha do Artigo
                        bool SugereData = true;           //Sugere a Data de Movimentação do Artigo
                        bool SugereDescricao = true;      //Sugere a Descrição da Ficha do Artigo
                        bool SugereQuantidade = false;    //Sugere a Quantidade de Movimentação (Quantidade = 1)
                        bool SugerePrUnit = true;         //Sugere o Preço Unitário do Artigo
                        bool SugereDesconto = false;      //Sugere o Desconto do Artigo
                        bool SugereIva = false;           //Sugere a Taxa de Iva do Artigo
                        objDocumento.SugereValoresLin(ref objLinhas, ref SugereUnidade, ref SugereData, ref SugereDescricao, ref SugereQuantidade, ref SugerePrUnit, ref SugereDesconto, ref SugereIva);

                        objLinhas.Unidade = txtUN2.Text;
                        if (decimal.TryParse(txtFactor1.Text, out numeroDecimal) == false)
                        {
                            numeroDecimal = 1;
                        }
                        objLinhas.Factor = numeroDecimal;

                        //   *
                        //   * -----------------------------------------------------------------------------------------------
                        //   * Importação de Documentos
                        //   * -----------------------------------------------------------------------------------------------
                        //   * IMPORTANTE
                        //   * -----------------------------------------------------------------------------------------------
                        //   * Se deseja efectuar o abatimento a linhas de documentos Originais,
                        //   * como efectua a importação dedocumentos, ORC -> GRM ou GRM-> FTR
                        //   * deve utilizar o segmento de código comentado que se segue :
                        //   * -----------------------------------------------------------------------------------------------
                        //   *
                        //        objLinhas.Orano = 2006          //Ano
                        //        objLinhas.Ordoc = "GR"          //Documento
                        //        objLinhas.Orserie = "1"           //Série Documento
                        //        objLinhas.Ornum = 2             //Numero DOcumento
                        //        objLinhas.LinhaOriginal = 2     //Numero da Linha Original
                        //        objLinhas.OrAreaGestao = 4      //Área de Gestão da Linha Original
                        //
                        lResult = objDocumento.AdicionaLinha(objLinhas);
                        objLinhas.Ordenacao = objLinhas.NumeroDaLinha;

                        objLinhas = null;

                        //        //Preecnhimento dos campos de extensão
                        //        If objLinhas.Extendida Then
                        //            Call objLinhas.Extensao.SetValorCampo(objLinhas.Extensao.QuantosCampos, txtL1Ext1.Text)
                        //        End If
                    }

                    if (TipoOperacaoApi != Publicas.e_Operacao.Leitura)
                    {
                        if (objDocumento.Validar((short)((int)TipoOperacaoApi)) != 0)
                        {
                            fApi.DefInstance.EscreveMsg(objDocumento.AllLogFileMessages);
                            return;
                        }
                    }

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Campos Livres
                    //   * -----------------------------------------------------------------------------------------------
                    //   * IMPORTANTE
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Se deseja utilizar os Campos Livres dos Documentos,
                    //   * deve utilizar o segmento de código que se segue :
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    objDocumento.Mycamposlivres = System.Activator.CreateInstance(objType_CamposLivresDoc);
                    objDocumento.Mycamposlivres.Cl01 = "Expedição";
                    objDocumento.Mycamposlivres.Cl02 = "-1";
                    objDocumento.Mycamposlivres.Cl03 = "Cliente Espeial";
                    objDocumento.Mycamposlivres.Cl04 = "500";
                    objDocumento.Mycamposlivres.Cl05 = "XPTO Express";
                    //   * -----------------------------------------------------------------------------------------------
                }

                switch (TipoOperacaoApi)
                {
                    case Publicas.e_Operacao.Inserir:
                        lResult = objDocumento.Inserir();
                        if (lResult == 0)
                        {
                            MessageBox.Show("Documento inserido com sucesso !", Application.ProductName);
                        }
                        break;

                    case Publicas.e_Operacao.Alterar:
                        lResult = objDocumento.Alterar();
                        if (lResult == 0)
                        {
                            MessageBox.Show("Documento alterado com sucesso !", Application.ProductName);
                        }
                        break;

                    case Publicas.e_Operacao.Remover:
                        //antes de remover deve-se efectuar uma leitura para carregar correctamente todas estruturas 
                        lResult = objDocumento.Ler(objDocumento.cab.TipoDocumento, objDocumento.cab.NossoNoDocumento, objDocumento.cab.Serie, objDocumento.cab.Ano, "");

                        if (lResult == 0)
                        {
                            lResult = objDocumento.Remover();
                            if (lResult == 0)
                            {
                                MessageBox.Show("Documento removido com sucesso !", Application.ProductName);
                            }
                        }
                        break;

                    case Publicas.e_Operacao.Leitura:                       
                        objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);
                        lResult = objDocumento.Ler(txtTpDoc.Text, Convert.ToInt32(Double.Parse(txtNumero.Text)), Convert.ToInt16(Double.Parse(txtSerie.Text)), Convert.ToInt16(Double.Parse(txtAno.Text)), "");
                        if (lResult == 0)
                        {

                            oModAdicional[0].Checked = true;

                            //Preencher
                            txtTpDoc.Text = objDocumento.cab.TipoDocumento;
                            txtSerie.Text = objDocumento.cab.Serie;
                            txtNumero.Text = objDocumento.cab.NossoNoDocumento.ToString();
                            txtAno.Text = objDocumento.cab.Ano.ToString();
                            txtData.Text = objDocumento.cab.Data;
                            txtSetor.Text = objDocumento.cab.Sector;
                            Text407.Text = objDocumento.cab.Moeda;
                            cmbTpTercDocCom.SelectedIndex = objDocumento.cab.TipoTerceiro - 1;
                            Text408.Text = objDocumento.cab.NomeVd;
                            Text409.Text = objDocumento.cab.DescontoCabecalho.ToString();
                            chkIvaIncluido.CheckState = (objDocumento.cab.IVAIncluido == -1) ? CheckState.Checked : CheckState.Unchecked;
                            //entidade

                            if (Strings.Len(objDocumento.cab.NomeVd) == 0)
                            {
                                Text408.Text = objDocumento.cab.Terceiro;
                            }

                            //
                            // Preencher Linhas
                            //
                            if (objDocumento.Linhas.Count() > 0)
                            {                                
                                foreach (dynamic item in objDocumento.Linhas)
                                    {
                                    objLinhas = item;

                                    //Linha 1
                                    if (objLinhas.Ordenacao == 1)
                                    {
                                        Text410.Text = objLinhas.Armazem;
                                        Text411.Text = objLinhas.Artigo;
                                        Text412.Text = objLinhas.PrecoUnitario.ToString();
                                        Text413.Text = objLinhas.Quantidade.ToString();
                                        Text414.Text = objLinhas.IvaLinhas.ToString();
                                        txtL1Ext1.Text = "";
                                        if (objLinhas.Extendida && objLinhas.Extensao.QuantosCampos > 0)
                                        {
                                            txtL1Ext1.Text = objLinhas.Extensao.ValorCampo(objLinhas.Extensao.QuantosCampos);
                                        }
                                    }

                                    //Linha 2
                                    if (objLinhas.Ordenacao == 2)
                                    {
                                        Text420.Text = objLinhas.Armazem;
                                        Text421.Text = objLinhas.Artigo;
                                        Text422.Text = objLinhas.PrecoUnitario.ToString();
                                        Text423.Text = objLinhas.Quantidade.ToString();
                                        Text424.Text = objLinhas.IvaLinhas.ToString();
                                        txtL2Ext1.Text = "";
                                        if (objLinhas.Extendida && objLinhas.Extensao.QuantosCampos > 0)
                                        {
                                            txtL2Ext1.Text = objLinhas.Extensao.ValorCampo(objLinhas.Extensao.QuantosCampos);
                                        }
                                    }

                                    //Linha 3 e superiores
                                    if (objLinhas.Ordenacao == 3)
                                    {
                                        break;
                                    }
                                }
                            }

                            if (objDocumento.Linhas.Count() > 2)
                            {
                                MessageBox.Show("Este documento tem " + objDocumento.Linhas.Count().ToString() + " linhas. Apenas 2 serão apresentadas", "Api", MessageBoxButtons.OK);
                            }

                            //
                            // Preencher lotes
                            //
                            int contadorLotes = 0;
                            objLotes = System.Activator.CreateInstance(objType_LotesLinha);
                            if (objDocumento.Lotes.Count() > 0)
                            {
                                oModAdicional[1].Checked = true;
                                foreach (dynamic item in objDocumento.Lotes)
                                    {
                                    objLotes = item;

                                    contadorLotes++;

                                    // Lote 1
                                    if (contadorLotes == 1)
                                    {
                                        Text450.Text = objLotes.campos.CodigoLote;
                                        Text451.Text = objLotes.campos.VossoLote;
                                        Text452.Text = objLotes.campos.DataValidade;
                                        Text453.Text = objLotes.QuantidadeMovimentada.ToString();
                                    }
                                    // Lote 2
                                    if (contadorLotes == 2)
                                    {
                                        Text460.Text = objLotes.campos.CodigoLote;
                                        Text461.Text = objLotes.campos.VossoLote;
                                        Text462.Text = objLotes.campos.DataValidade;
                                        Text463.Text = objLotes.QuantidadeMovimentada.ToString();
                                    }
                                    if (contadorLotes == 3)
                                    {
                                        break;
                                    }
                                }
                                objLotes = null;
                            }

                            //
                            // Números de série
                            //
                            int contadorNumser = 0;
                            if (objDocumento.NumerosSerie.Count() > 0)
                            {
                                oModAdicional[2].Checked = true;
                                foreach (dynamic item in objDocumento.NumerosSerie)
                                {
                                    objNumser = item;
                                    contadorNumser++;

                                    if (contadorNumser == 1)
                                    {
                                        Text411.Text = objNumser.campos.Artigo;
                                        Text410.Text = objNumser.campos.Armazem;
                                        Text430.Text = objNumser.campos.Noserie;
                                    }
                                    if (contadorNumser == 2)
                                    {
                                        Text411.Text = objNumser.campos.Artigo;
                                        Text410.Text = objNumser.campos.Armazem;
                                        Text440.Text = objNumser.campos.Noserie;
                                    }
                                    if (contadorNumser == 3)
                                    {
                                        break;
                                    }
                                }
                                objNumser = null;
                            }

                            if (lResult == 0)
                            {
                                MessageBox.Show("Documento lido com sucesso!", Application.ProductName);
                            }
                        }
                        break;
                }
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
                if (lResult == 0)
                {
                    if (LigGaCom.CheckState == CheckState.Checked)
                    {
                        objContabDoc = System.Activator.CreateInstance(objType_DocumentoContabilistico);
                        objContabDoc.DocumentoComercial(ref objDocumento);

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
                //   * -----------------------------------------------------------------------------------------------

                if (lResult != 0)
                { // Aconteceu ERRO na operação
                    MessageBox.Show("Erro ao executar a acção !", Application.ProductName);
                }

                string sMsg = String.Empty;
                sMsg = objDocumento.AllLogFileMessages;
                if (sMsg.Length > 0)
                {
                    fApi.DefInstance.EscreveMsg(objDocumento.AllLogFileMessages);
                }
            }
            finally
            {

                if (objNumser != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objNumser);
                }

                if (objLotes != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objLotes);
                }

                if (objLinhas != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objLinhas);
                }

                if (objDocumento != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objDocumento);
                }

                if (objContabDoc != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objContabDoc);
                }


                if (objBanco != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objBanco);
                }
            }
        }


        //
        // Carregou em Botão "Limpar" nas linhas dos Documentos Comerciais
        //
        private void _cmdClearFT_0_Click(object sender, EventArgs e)
        {
            Text410.Text = "";
            Text411.Text = "";
            Text412.Text = "";
            Text413.Text = "";
            Text414.Text = "";
            txtL1Ext1.Text = "";
            txtL1Ext1.Text = "";
            txtUn1.Text = "UN";
            txtFactor1.Text = "1";
        }

        private void _cmdClearFT_1_Click(object sender, EventArgs e)
        {
            Text420.Text = "";
            Text421.Text = "";
            Text422.Text = "";
            Text423.Text = "";
            Text424.Text = "";
            txtL2Ext1.Text = "";
            txtUN2.Text = "UN";
            txtFactor2.Text = "1";
        }


        private void _cmdClearFT_6_Click(object sender, EventArgs e)
        {
            Text430.Text = "";
        }

        private void _cmdClearFT_7_Click(object sender, EventArgs e)
        {
            Text440.Text = "";
        }


        private void _cmdClearFT_4_Click(object sender, EventArgs e)
        {
            Text450.Text = "";
            Text451.Text = "";
            Text452.Text = "";
            Text453.Text = "";
        }

        private void _cmdClearFT_5_Click(object sender, EventArgs e)
        {
            Text460.Text = "";
            Text461.Text = "";
            Text462.Text = "";
            Text463.Text = "";
        }

        private void _cmdClearFT_8_Click(object sender, EventArgs e)
        {
            txtCor1.Text = "";
        }

        private void _cmdClearFT_9_Click(object sender, EventArgs e)
        {
            txtTam1.Text = "";            
        }

        //
        // Carregou em Botão "Finalizar Documento Preparado"
        //
        private void cmdFinalizar_Click(object sender, EventArgs e)
        {
            IAR_Finalizar();
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            IAR_Factura(Publicas.e_Operacao.Inserir);
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            IAR_Factura(Publicas.e_Operacao.Leitura);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            IAR_Factura(Publicas.e_Operacao.Remover);
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            IAR_Factura(Publicas.e_Operacao.Alterar);
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelFinalizado.Visible = cmbOrigem.SelectedItem.ToString().Equals("Finalizado");
        }

        private void Text402_TextChanged(object sender, EventArgs e)
        {
            cmdFinalizar.Visible = txtSerie.Text.ToString().Equals("0");
        }

        private void Label94_Click(object sender, EventArgs e)
        {

        }

        private void IAR_Imprimir(int mNumVias, String mModelo) {
            dynamic objDocumento = null;
            objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);

            short ano = Convert.ToInt16(Double.Parse(txtAno.Text));
            String tpDoc = txtTpDoc.Text;
            String serie = txtSerie.Text;
            int numero = Convert.ToInt32(txtNumero.Text);


            // ano, tpdoc, serie, numdoc, nvias, modeloimpressao
            if (!objDocumento.ImprimirDocumentoComercial(ano,tpDoc,serie,numero, mNumVias, mModelo)){         
                if (objDocumento.UltimaMensagem.Equals(String.Empty)){ 
                    fApi.DefInstance.EscreveMsg(objDocumento.UltimaMensagem());
                }
            }

            objDocumento = null;
        }

        /*
        * Impressão de Documentos em Crystal Reports 2016
        * Apenas para Sage1GCOApi
        */
        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            fPrintDialog newApiFormImprime = new fPrintDialog();
            newApiFormImprime.ShowDialog(); // Shows Form
            if (!newApiFormImprime.Cancelou)
            {
                String m = newApiFormImprime.Modelo;
                short n = newApiFormImprime.NumVias;

                IAR_Imprimir(newApiFormImprime.NumVias, newApiFormImprime.Modelo);

            }

        }
    }
}
