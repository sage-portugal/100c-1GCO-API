using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using Sage1GCOUtil10;

namespace ApiLaunchBusiness
{
    public partial class fOutrosExemplos : Form
    {
        System.Type objType_DocumentoComercial;
        System.Type objType_DocumentoFinanceiro;
        System.Type objType_MovimentosCtb2;
        System.Type objType_DocumentoContabilistico;
        System.Type objType_DocumentosGcLin;
        System.Type objType_LotesLinha;

        public fOutrosExemplos()
        {
            InitializeComponent();
            Load += new EventHandler(fOutrosExemplos_Load);

            String DocumentoComercial = Publicas.dynamicAPI() + ".DocumentoComercial";
            String DocumentoFinanceiro = Publicas.dynamicAPI() + ".DocumentoFinanceiro";
            String MovimentosCtb2 = Publicas.dynamicAPI() + ".MovimentosCtb2";
            String DocumentoContabilistico = Publicas.dynamicAPI() + ".DocumentoContabilistico";
            String DocumentosGcLin = Publicas.dynamicAPI() + ".DocumentosGcLin";
            String LotesLinha = Publicas.dynamicAPI() + ".LotesLinha";

            objType_DocumentoComercial = System.Type.GetTypeFromProgID(DocumentoComercial);
            objType_DocumentoFinanceiro = System.Type.GetTypeFromProgID(DocumentoFinanceiro);
            objType_MovimentosCtb2 = System.Type.GetTypeFromProgID(MovimentosCtb2);
            objType_DocumentoContabilistico = System.Type.GetTypeFromProgID(DocumentoContabilistico);
            objType_DocumentosGcLin = System.Type.GetTypeFromProgID(DocumentosGcLin);
            objType_LotesLinha = System.Type.GetTypeFromProgID(LotesLinha);

        }


        private void fOutrosExemplos_Load(object sender, EventArgs e)
        {

            cmbTipoPrecoStock.SelectedIndex = cmbTipoPrecoStock.Items.Count - 1;
        }
        //
        // Inserir Documento via XML
        //
        private void cmdInserirDocumentosXML_Click(object sender, EventArgs e)
        {
            dynamic oDoc = null;

            try
            {
                string sXml = String.Empty;

                try
                {

                    CommonDialog1Open.Filter = "Documento XML (*.xml)|*.xml|Todos os ficheiros (*.*)|*.*";
                    CommonDialog1Open.DefaultExt = "xml";

                    CommonDialog1Open.ShowDialog();
                    sXml = CommonDialog1Open.FileName;

                    if (File.Exists(sXml))
                    {

                        oDoc = System.Activator.CreateInstance(objType_DocumentoComercial);
                        oDoc.Ler("", 0, 0, 0, sXml); 
                                if (oDoc.Validar() == 0)
                                {
                                    oDoc.Inserir();
                                } 
                                MessageBox.Show(oDoc.AllLogFileMessages, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                                oDoc = null; 

                    }
                    else
                    {
                        if (sXml.ToString() != "")
                        {
                            MessageBox.Show("O ficheiro [" + sXml + "] não existe.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                   }
                    return;
                }
                catch
                {



                }
            }
            finally
            {
                if (oDoc != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oDoc);
                }
            }
        }
        //
        // Inserir Recibo via XML
        //
        private void cmdInserirRecibosXML_Click(object sender, EventArgs e)
        {

            dynamic oRecibo = null;

            try
            {
                string sXml = String.Empty;

                try
                {

                    CommonDialog1Open.Filter = "Documento XML (*.xml)|*.xml|Todos os ficheiros (*.*)|*.*";
                    CommonDialog1Open.DefaultExt = "xml";

                    CommonDialog1Open.ShowDialog();
                    sXml = CommonDialog1Open.FileName;

                    if (File.Exists(sXml))
                    {
                        oRecibo = System.Activator.CreateInstance(objType_DocumentoFinanceiro);

                        oRecibo.Ler("", 0, 0, 0, sXml);
                        if (oRecibo.Validar() == 0)
                        {
                            oRecibo.Inserir();
                        }
                        MessageBox.Show(oRecibo.AllLogFileMessages, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oRecibo = null; 
                    }
                    else
                    {
                        if (sXml.ToString() != "")
                        {
                            MessageBox.Show("O ficheiro [" + sXml + "] não existe.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    return;
                }
                catch
                {
    

                    }
                }
                finally
                {

                    if (oRecibo != null)
                    {
                        // Destruir Objeto
                        Marshal.ReleaseComObject(oRecibo);
                    }
                }
        }




        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }



           //
        // Alterar Documento Contabilistico Existente
        //
        private void ChangeDocContab_Click(Object eventSender, EventArgs eventArgs)
        {
            dynamic oLinha = null;
            dynamic oLinhaClone = null;
            dynamic oDocCtb = null;
            dynamic oDocCom = null;


            try
            {
                oLinha = null;

                //remover o documento contabilistico existente
                oDocCtb = System.Activator.CreateInstance(objType_DocumentoContabilistico);

                oDocCtb.Ler("CCF", 3, 1, 2014, "");
                oDocCtb.Remover();
                oDocCtb = null;

                //ler o documento comercial
                oDocCom = System.Activator.CreateInstance(objType_DocumentoComercial);
                oDocCom.Ler("CCF", 3, 1, 2014, "");

                //criar novo documento contabilistico
                oDocCtb = System.Activator.CreateInstance(objType_DocumentoContabilistico);
                oDocCtb.DocumentoComercial(ref oDocCom);

                //Validar para calcular movimentos automáticos
                decimal nValor = 0;
                oLinhaClone = null;
                oLinha = System.Activator.CreateInstance(objType_DocumentosGcLin);

                if (oDocCtb.Validar() == 0)
                {
                    // Carregar a ultima linha contabilistica
                    foreach (dynamic item in oDocCtb.Linhas)
                        {
                        oLinha = item;
                        if (oLinha.CentroCustoOrcam == "COMS")
                        {
                            nValor = oLinha.Valor;
                            break;
                        }
                    }
                    //Dividir a linha por 2 centros de custo 70%/30%

                    //Corrigir a 1ª linha do centro de custo - 70% valor
                    oLinha.Valor = (decimal)Math.Round((double)(((double)nValor) * 0.7d), 2);
                    oLinha.CentroCustoOrcam = "COMS"; //Centro de custo
                    oLinha.CentroCusteio = "VND-MC"; //Rúbrica
                    oLinha.RubricaOrcamental = "VND-MC";
                    oLinha.Descricao = "Divisão 1/2 70%";
                    oLinha.LinhaDoCDeCusto = 1;
                    oLinha.ErrosCtb = null; //Reset ao erro para forçar validar novamente.

                    //Inserir uma nova com o valor restante...
                    oLinhaClone = System.Activator.CreateInstance(objType_MovimentosCtb2);
                    oLinha.Clona(ref oLinhaClone); //Clonar a linha anterior
                    oLinhaClone.Valor = nValor - oLinha.Valor;
                    oLinhaClone.CentroCustoOrcam = "ADM"; //Centro de custo
                    oLinhaClone.CentroCusteio = "VND-MC"; //Rúbrica
                    oLinhaClone.RubricaOrcamental = "VND-MC";
                    oLinhaClone.Descricao = "Divisão 2/2 - 30%";
                    oLinhaClone.NumLinha = (short)(oLinha.NumLinha + 1);
                    oLinhaClone.LinhaDoCDeCusto = 2;

                    //Necessário adicionar a linha nova à colecção
                    oDocCtb.Linhas.Add(oLinhaClone);

                    bool bValidou = false;
                    //Validar sem recalcular com base no documento comercial (equivalente a validar para alterar)
                    if (oDocCtb.Validar() == 0)
                    {
                        bValidou = true;
                        if (oDocCtb.Inserir() == 0)
                        {
                            bValidou = true;
                            fApi.DefInstance.EscreveMsg("Documento inserido com sucesso.");
                        }

                    }

                    if (bValidou == false)
                    {
                        MessageBox.Show(oDocCtb.UltimaMensagem(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            finally
            {
                if (oLinha != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oLinha);
                }
                if (oLinhaClone != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oLinhaClone);
                }
                if (oDocCom != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oDocCom);
                }
                if (oDocCtb != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oDocCtb);
                }


            }
        }
        //
        // Gravar Novo Documento Contabilistico
        //
        private void NewDocContab_Click(object sender, EventArgs eventArgs)
        {

            //Criar um documento Contabilisticonovo de raíz
            dynamic oLinha = null;
            dynamic oDocCtb = null;
            dynamic withVar = null;

            try
            {

                if (oDocCtb == null)
                {
                    oDocCtb = System.Activator.CreateInstance(objType_DocumentoContabilistico);

                    withVar = oDocCtb.cab;
                    withVar.TipoDocumento = "CCF";
                    withVar.Numero = 2;
                    withVar.Serie = 1;
                    withVar.Sector = "ANS";
                    withVar.Data = DateTime.Today.ToString("d");
                    withVar.TotalCredito = 13.54m;
                    withVar.TotalDebito = 13.54m;
                    withVar.Utilizador = "INF";

                    withVar.Natureza = "2";       // 1-Abertura 2-Normal 3-regularizações 4-apuramentos 5-fecho
                    withVar.StatusAcumulado = 1;  // 1-suspensos 2-efectivos 3-extra contabilisticos 4-excluidos
                    withVar.Status = "0";         // auditoria
                }

                oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);
                oLinha.Conta = "211110023";
                oLinha.Valor = 13.54m;
                oLinha.Movimentacao = 1;
                oLinha.Descricao = "API - Conta do cliente";
                oLinha.ValorCredito = 0;
                oLinha.ValorDebito = oLinha.Valor;
                oLinha.NumLinha = 1;
                oLinha.Exercicio = 2011;
                oDocCtb.Linhas.Add(oLinha);

                oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);
                oLinha.Conta = "2433111";
                oLinha.Valor = 0.77m;
                oLinha.Movimentacao = 2;
                oLinha.Descricao = "API - Liq. Merc. Red. Liq";
                oLinha.ValorCredito = oLinha.Valor;
                oLinha.ValorDebito = 0;
                oLinha.NumLinha = 2;
                oLinha.Exercicio = 2011;
                oDocCtb.Linhas.Add(oLinha);

                oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);
                oLinha.Conta = "321";
                oLinha.Valor = 3.2m;
                oLinha.Movimentacao = 2;
                oLinha.Descricao = "API - Merc. em Armazém";
                oLinha.ValorCredito = oLinha.Valor;
                oLinha.ValorDebito = 0;
                oLinha.NumLinha = 3;
                oLinha.Exercicio = 2011;
                oDocCtb.Linhas.Add(oLinha);

                oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);
                oLinha.Conta = "611";
                oLinha.Valor = 3.2m;
                oLinha.Movimentacao = 1;
                oLinha.Descricao = "API - CMVC Merc.";
                oLinha.ValorCredito = 0;
                oLinha.ValorDebito = oLinha.Valor;
                oLinha.NumLinha = 4;
                oLinha.Exercicio = 2011;
                oDocCtb.Linhas.Add(oLinha);

                oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);
                oLinha.Conta = "71111";
                oLinha.Valor = 6.77m;
                oLinha.CentroCustoOrcam = "COMS";
                oLinha.CentroCusteio = "VND-MC";
                oLinha.RubricaOrcamental = "VND-MC";
                oLinha.Movimentacao = 2;
                oLinha.Descricao = "API - Merc. Nac. Red (Continente) (1)";
                oLinha.NumLinha = 5;
                oLinha.LinhaDoCDeCusto = 1;
                oLinha.Exercicio = 2011;
                oDocCtb.Linhas.Add(oLinha);

                oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);
                oLinha.Conta = "71111";
                oLinha.Valor = 6;
                oLinha.CentroCustoOrcam = "ADM";
                oLinha.CentroCusteio = "VND-MC";
                oLinha.RubricaOrcamental = "VND-MC";
                oLinha.Movimentacao = 2;
                oLinha.Descricao = "API - Merc. Nac. Red (Continente) (2)";
                oLinha.NumLinha = 6;
                oLinha.LinhaDoCDeCusto = 2;
                oLinha.Exercicio = 2011;
                oDocCtb.Linhas.Add(oLinha);


                if (oDocCtb.Validar() == 0)
                {
                    oDocCtb.Inserir();
                }
                else
                {
                    MessageBox.Show(oDocCtb.UltimaMensagem(), Application.ProductName);
                }
            }
            finally
            {
                if (oDocCtb != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oDocCtb);
                }

                if (oLinha != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(oLinha);
                }
            }
        }

        private void _btnTrfArm_0_Click(object sender, EventArgs e)
        {
            FazTransferenciaArm(Publicas.e_Operacao.Inserir);
        }

        private void _btnTrfArm_1_Click(object sender, EventArgs e)
        {
            FazTransferenciaArm(Publicas.e_Operacao.Alterar);
        }

        //
        //Transferências de Armazém
        //
        private void FazTransferenciaArm(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta");
                return;
            }


            dynamic objDocumento = null;
            dynamic objLinhas = null;
            dynamic objContabDoc = null;
            dynamic objLotes = null;

            try
            {

                int lResult = 0;
                int lResultContab = 0;

                try
                {

                    //   * Criação de um novo documento
                    objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);

                    objLotes = System.Activator.CreateInstance(objType_LotesLinha);

                    switch (TipoOperacaoApi)
                    {
                        //Novo
                        case Publicas.e_Operacao.Inserir : 
                            //   * 
                            //   * ----------------------------------------------------------------------------------------------- 
                            //   * Preenchimento do Cabeçalho 
                            //   * ----------------------------------------------------------------------------------------------- 
                            //   * 
                            objDocumento.ActivarGrelhasDesconto = false; 
                            objDocumento.ActivarLinhasBonus = true; 
                            objDocumento.ActivarLinhasPreco = true; 

                            objDocumento.cab.TipoDocumento = "TAR"; 
                            objDocumento.cab.Serie = 2; 
                            objDocumento.cab.NossoNoDocumento = 2; 
                            objDocumento.cab.Ano = 2011; 
                            objDocumento.cab.Data = DateTime.Today.ToString("d"); 
                            objDocumento.cab.Sector = "ANS"; 
                            objDocumento.cab.Moeda = "EUR";
                            objDocumento.cab.TipoTerceiro = ((short) etb_TERCEIRO.Cliente); 
                            objDocumento.cab.Terceiro = "AR2"; 
                            objDocumento.cab.DescontoCabecalho = 0; 
                            objDocumento.cab.RegimeIva = "NAC";  							 
                            objDocumento.cab.IVAIncluido = ((short) 0);

                            //   * ----------------------------------------------------------------------------------------------- 
                            //   * Preencher o TIPO DE PREÇO: 
                            //   * ----------------------------------------------------------------------------------------------- 
                            //   * UE     1   Ultima Entrada 
                            //   * PMPC   2   Custo Médio Fixo 
                            //   * STND   3   Standard 
                            //   * MNL    4   Manual 
                            //   * FCOMP  5   Ficha Composição 
                            //   * PMPM   6   Custo Médio Flutuante 
                            //   * PAra todos os efeitos: PMPM=PMPC 
                            //   * Usar    enum     etb_TPPRE 
                            //   * ----------------------------------------------------------------------------------------------- 
                            objDocumento.cab.TipoPreco = (short) cmbTipoPrecoStock.SelectedIndex; 

                            //ALTERAR 
                            break;


                        case Publicas.e_Operacao.Alterar: 

                            objDocumento.Ler("TAR", 47, 1, 2011, "");

                            objDocumento.Origem = Publicas.e_OrigemDocumento.NaoAplicavel;

                            //Adicionar 2 a cada Quantidade da Linha
                            foreach (dynamic item in objDocumento.Linhas)
                                {
                                objLinhas = item;
                                objLinhas.Quantidade += 2; 
                            }

                            int i = 1;
                            foreach (dynamic item in objDocumento.Lotes)
                                {
                                i++;
                                if (i%2 == 0)
                                {
                                    objLotes = item;
                                    objLotes.QuantidadeMovimentada += 2;
                                }
                            }

                            if (objDocumento.Validar(1) == 0)
                            {
                                objDocumento.Alterar();
                            }
                            else
                            {
                                MessageBox.Show("Documento inválido." + Environment.NewLine + objDocumento.AllLogFileMessages, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            } 
                            objDocumento = null; 
                            return; 

                        default:
                            MessageBox.Show("Tipo de transferência não implementado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                            break;
                    }

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Linha 1
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    objLinhas = System.Activator.CreateInstance(objType_DocumentosGcLin);

                    //Importante por causa das extensões
                    objLinhas.TipoTerceiro = objDocumento.cab.TipoTerceiro;
                    objLinhas.TipoDeLinha = 1;
                    objLinhas.Armazem = "AR1";
                    objLinhas.Artigo = "ARS";
                    if (cmbTipoPrecoStock.SelectedIndex == 4)
                    {
                        //Tipo de preço manual
                        objLinhas.PrecoUnitario = 9.95m;
                    }
                    else
                    {
                        objLinhas.PrecoUnitario = 0;
                    }
                    objLinhas.Quantidade = 2;
                    objLinhas.Unidade = "CX";
                    objLinhas.NumeroDaLinha = 1;

                    objLinhas.TaxaIva = 23;
                    objLinhas.DataMvStock = DateTime.Parse(objDocumento.cab.Data).AddDays(15).ToString("d");

                    bool SugereUnidade = false;       //Sugere a Unidade da Ficha do Artigo
                    bool SugereData = true;           //Sugere a Data de Movimentação do Artigo
                    bool SugereDescricao = true;      //Sugere a Descrição da Ficha do Artigo
                    bool SugereQuantidade = false;    //Sugere a Quantidade de Movimentação (Quantidade = 1)
                    bool SugerePrUnit = true;         //Sugere o Preço Unitário do Artigo
                    bool SugereDesconto = true;       //Sugere o Desconto do Artigo
                    bool SugereIva = false;           //Sugere a Taxa de Iva do Artigo
                    objDocumento.SugereValoresLin(ref objLinhas, ref SugereUnidade, ref SugereData, ref SugereDescricao, ref SugereQuantidade, ref SugerePrUnit, ref SugereDesconto, ref SugereIva);

                    lResult = objDocumento.AdicionaLinha(objLinhas);

                    objLinhas = null;

                    objDocumento.Origem = Publicas.e_OrigemDocumento.NaoAplicavel;

                    if (objDocumento.Validar((short)TipoOperacaoApi) != 0)
                    {
                        fApi.DefInstance.EscreveMsg(objDocumento.AllLogFileMessages);
                        objDocumento = null;
                        return;
                    }

                    if (TipoOperacaoApi == Publicas.e_Operacao.Inserir)
                    {
                        lResult = objDocumento.Inserir();
                    }
                    else
                    {
                        lResult = objDocumento.Alterar();
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

                    if (objDocumento != null)
                    {
                        // Destruir Objeto
                        Marshal.ReleaseComObject(objDocumento);
                    }


                    return;
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            finally
            {

                if (objContabDoc != null)
                {
                    // Destruir Objeto
                    Marshal.ReleaseComObject(objContabDoc);
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

            }
        }

    }

}
