using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ApiLaunchBusiness
{
    public partial class fDocumentoContabilidade : Form
    {

        System.Type objType_MovimentosCtb2;
        System.Type objType_DocumentoContabilistico;

        public fDocumentoContabilidade()
        {
            InitializeComponent();
            Load += new EventHandler(fDocumentoContabilidade_Load);
            ReLoadForm(false);

            String MovimentosCtb2 = Publicas.dynamicSageApiName() + ".MovimentosCtb2";
            String DocumentoContabilistico = Publicas.dynamicSageApiName() + ".DocumentoContabilistico";

            objType_MovimentosCtb2 = System.Type.GetTypeFromProgID(MovimentosCtb2);
            objType_DocumentoContabilistico = System.Type.GetTypeFromProgID(DocumentoContabilistico);
        }
        private void fDocumentoContabilidade_Load(object sender, EventArgs e)
        {

            Text25.Text = "CCF";
            Text26.Text = "10";
            Text27.Text = "1";
            Text28.Text = "ANS";
            Text29.Text = DateTime.Now.ToString("d");

            Text12[0].Text = "111";
            Text23[0].Text = "Caixa";
            Text24[0].Text = "1000";
            Text30[0].Text = "0";

            Text12[1].Text = "21110001";
            Text23[1].Text = "Cliente";
            Text24[1].Text = "0";
            Text30[1].Text = "900";

            Text12[2].Text = "7111";
            Text23[2].Text = "Caixa";
            Text24[2].Text = "0";
            Text30[2].Text = "100";
        }

        // -----------------------------------------------------------------------------------------
        //
        // Manutenção de Documento Contabilistico
        //
        // ----------------------------------------------------------------------------------------- 
        private void IAR_MovContabilistico(Publicas.e_Operacao TipoOperacaoApi)
        {

            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta");
                return;
            }

            dynamic oLinha = null;
            dynamic objContabDoc = null;


            try
            {

                objContabDoc = null;
                oLinha = null;

                int lResult = 0;

                if (TipoOperacaoApi == Publicas.e_Operacao.Leitura)
                {
                    if (objContabDoc == null)
                    {
                        objContabDoc = System.Activator.CreateInstance(objType_DocumentoContabilistico);

                        objContabDoc.Ler(Text25.Text, Convert.ToInt32(Double.Parse(Text26.Text)), Text27.Text, (short)DateTime.Parse(Text29.Text).Year, "");
                       
                        oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);


                        //
                        // Apresentação do Movimemnto Contabilistico
                        //
                        Text25.Text = objContabDoc.cab.TipoDocumento;
                        Text26.Text = objContabDoc.cab.Numero.ToString();
                        Text27.Text = objContabDoc.cab.Serie;
                        Text28.Text = objContabDoc.cab.Sector;
                        Text29.Text = objContabDoc.cab.Data;

                        for (int j = 0; j <= 2; j++)
                        {
                            Text12[j].Text = null;
                            Text23[j].Text = null;
                            Text24[j].Text = null;
                            Text30[j].Text = null;
                        }


                        int i = 0;
                        foreach (dynamic item in objContabDoc.Linhas)
                        {
                            oLinha = item;


                            Text12[i].Text = oLinha.Conta;
                            Text23[i].Text = oLinha.Descricao;
                            if (oLinha.Movimentacao == 1)
                            {
                                Text24[i].Text = oLinha.Valor.ToString();
                                Text30[i].Text = "0";
                            }
                            else
                            {
                                Text24[i].Text = "0";
                                Text30[i].Text = oLinha.Valor.ToString();
                            }
                            i++;
                        }


                  
                    }
                }


                if (TipoOperacaoApi != Publicas.e_Operacao.Leitura)
                {
                    objContabDoc = System.Activator.CreateInstance(objType_DocumentoContabilistico);
                    
                    objContabDoc.cab.TipoDocumento = Text25.Text;
                    objContabDoc.cab.Numero = Convert.ToInt32(Text26.Text);
                    objContabDoc.cab.Serie = Text27.Text;
                    objContabDoc.cab.Sector = Text28.Text;
                    objContabDoc.cab.Data = Text29.Text;
                    objContabDoc.cab.TotalCredito = Decimal.Parse(Text30[0].Text, NumberStyles.Currency) + Decimal.Parse(Text30[1].Text, NumberStyles.Currency) + Decimal.Parse(Text30[2].Text, NumberStyles.Currency);
                    objContabDoc.cab.TotalDebito = Decimal.Parse(Text24[0].Text, NumberStyles.Currency) + Decimal.Parse(Text24[1].Text, NumberStyles.Currency) + Decimal.Parse(Text24[2].Text, NumberStyles.Currency);
                    objContabDoc.cab.Utilizador = fApi.DefInstance.txtUser.Text;

                    objContabDoc.cab.Natureza = "2";       // 1-Abertura 2-Normal 3-regularizações 4-apuramentos 5-fecho
                    objContabDoc.cab.StatusAcumulado = 1;  // 1-suspensos 2-efectivos 3-extra contabilisticos 4-excluidos
                    objContabDoc.cab.Status = "0";         // auditoria

                    // objContabDoc.cab.Referencia = ""
                    // objContabDoc.cab.Diario = ""
                    // objContabDoc.cab.NumeroDiario = 0
                    // objContabDoc.cab.Notas = ""
                    // objContabDoc.cab.Estado = 0

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Linha 1
                    //   * -----------------------------------------------------------------------------------------------
                    //   *

                    oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);

                    oLinha.Conta = Text12[0].Text;
                    if (Decimal.Parse(Text30[0].Text, NumberStyles.Currency) != 0)
                    {
                        oLinha.Valor = Decimal.Parse(Text30[0].Text, NumberStyles.Currency);
                        oLinha.Movimentacao = 2;
                    }
                    else
                    {
                        oLinha.Valor = Decimal.Parse(Text24[0].Text, NumberStyles.Currency);
                        oLinha.Movimentacao = 1;
                    }
                    oLinha.Descricao = Text23[0].Text;
                    oLinha.ValorCredito = Decimal.Parse(Text30[0].Text, NumberStyles.Currency);
                    oLinha.ValorDebito = Decimal.Parse(Text24[0].Text, NumberStyles.Currency);

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Campos da Linha de movimento não obrigatórios
                    //   * Devem ser preenchidos conforme a necessidade ou complexidade do documento
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    //        .Sector = ""
                    //        .Serie = ""
                    //        .Ano = ""
                    //        .Mes = ""
                    //        .TipoDocumento = ""
                    //        .NumeroDocumento = ""
                    //        .DataDoDocumento = ""
                    //        .Operador = "
                    //        .Natureza = 2           // 1-Abertura 2-Normal 3-regularizações 4-apuramentos 5-fecho
                    //        .StatusAcumulados = 1   // 1-suspensos 2-efectivos 3-extra contabilisticos 4-excluidos
                    //        .Diario = ""
                    //        .Origem = 0
                    //        .RubricaOrcamental = ""
                    //        .CentroCustoOrcam = ""
                    //        .Ligado = 0
                    //        .NumeroDoDiario = 0
                    //        .ContaDoBanco = ""
                    //        .LinhaComercial = 0
                    //        .ManualAutomatico = 0
                    //        .ErrosCtb = ""
                    //        .Terceiro = ""
                    //        .TipoTerceiro = 0
                    //        .Nocontribuinte = ""
                    //        .CodigoIva = ""
                    //        .CodigoFluxo = ""
                    //        .CentroCusteio = ""
                    //        .Referencia = ""
                    //        .Status = 0
                    //        .Modelo = ""
                    //        .DescAutomatica = ""
                    //        .ControloEspecifico = 0
                    //        .Movdesc = ""
                    //        .LinhaDoCDeCusto = 0
                    //        .Justificativo = ""
                    //        .DataDeCriacao = ""
                    //        .DataDeAlteracao = ""

                    objContabDoc.AdicionaLinha(oLinha);

                    oLinha = null;

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Linha 2
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);

                    oLinha.Conta = Text12[1].Text;
                    if (Decimal.Parse(Text30[1].Text, NumberStyles.Currency) != 0)
                    {
                        oLinha.Valor = Decimal.Parse(Text30[1].Text, NumberStyles.Currency);
                        oLinha.Movimentacao = 2;
                    }
                    else
                    {
                        oLinha.Valor = Decimal.Parse(Text24[1].Text, NumberStyles.Currency);
                        oLinha.Movimentacao = 1;
                    }
                    oLinha.Descricao = Text23[1].Text;
                    oLinha.ValorCredito = Decimal.Parse(Text30[1].Text, NumberStyles.Currency);
                    oLinha.ValorDebito = Decimal.Parse(Text24[1].Text, NumberStyles.Currency);

                    objContabDoc.AdicionaLinha(oLinha);

                    oLinha = null;

                    //   *
                    //   * -----------------------------------------------------------------------------------------------
                    //   * Linha 3
                    //   * -----------------------------------------------------------------------------------------------
                    //   *
                    oLinha = System.Activator.CreateInstance(objType_MovimentosCtb2);

                    oLinha.Conta = Text12[2].Text;
                    if (Decimal.Parse(Text30[2].Text, NumberStyles.Currency) != 0)
                    {
                        oLinha.Valor = Decimal.Parse(Text30[2].Text, NumberStyles.Currency);
                        oLinha.Movimentacao = 2;
                    }
                    else
                    {
                        oLinha.Valor = Decimal.Parse(Text24[2].Text, NumberStyles.Currency);
                        oLinha.Movimentacao = 1;
                    }
                    oLinha.Descricao = Text23[2].Text;
                    oLinha.ValorCredito = Decimal.Parse(Text30[2].Text, NumberStyles.Currency);
                    oLinha.ValorDebito = Decimal.Parse(Text24[2].Text, NumberStyles.Currency);

                    objContabDoc.AdicionaLinha(oLinha);

                    oLinha = null;
                }
                //   *
                //   * -----------------------------------------------------------------------------------------------
                //   * Validação
                //   * -----------------------------------------------------------------------------------------------
                //   *
                if (TipoOperacaoApi != Publicas.e_Operacao.Leitura)
                {
                    if (objContabDoc.Validar() == 0)
                    {
                        switch (TipoOperacaoApi)
                        {
                            case Publicas.e_Operacao.Inserir:
                                lResult = objContabDoc.Inserir();
                                if (lResult == 0)
                                {
                                    fApi.DefInstance.EscreveMsg("Documento contabilistico inserido com sucesso!");
                                }  // SUCESSO 
                                break;

                            case Publicas.e_Operacao.Alterar:
                                lResult = objContabDoc.Alterar();
                                if (lResult == 0)
                                {
                                    fApi.DefInstance.EscreveMsg("Documento contabilistico alterado com sucesso!");
                                }  // SUCESSO 
                                break;

                            case Publicas.e_Operacao.Remover:
                                lResult = objContabDoc.Remover();
                                if (lResult == 0)
                                {
                                    fApi.DefInstance.EscreveMsg("Documento contabilistico removido com sucesso!");
                                }  // SUCESSO 
                                break;
                        }

                        if (lResult != 0)
                        { // Aconteceu ERRO na operação
                            fApi.DefInstance.EscreveMsg(objContabDoc.UltimaMensagem());
                        }

                        objContabDoc = null;

                    }
                    else
                    {
                        fApi.DefInstance.EscreveMsg(objContabDoc.UltimaMensagem());
                        objContabDoc = null;
                    }
                }
            }
            finally
            {

                if (oLinha != null)
                {
                    // Destruir objeto
                    Marshal.ReleaseComObject(oLinha);
                }

                if (objContabDoc != null)
                {
                    // Destruir objeto
                    Marshal.ReleaseComObject(objContabDoc);
                }

            }
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            IAR_MovContabilistico(Publicas.e_Operacao.Leitura); 
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            IAR_MovContabilistico(Publicas.e_Operacao.Alterar); 
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            IAR_MovContabilistico(Publicas.e_Operacao.Remover); 
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            IAR_MovContabilistico(Publicas.e_Operacao.Inserir); 
        }

        private void Text25_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
