using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ApiLaunchBusiness
{
    public partial class fPlanoContas : Form
    {

        System.Type objType_PlanodeContas;

        public fPlanoContas()
        {
            InitializeComponent();
            Load += new EventHandler(fPlanoContas_Load);
            String PlanodeContas = Publicas.dynamicAPI() + ".PlanodeContas";
            objType_PlanodeContas = System.Type.GetTypeFromProgID(PlanodeContas);

            Publicas.listProperties(objType_PlanodeContas, PlanodeContas);
        }

        private void fPlanoContas_Load(object sender, EventArgs e)
        {
            Text10.Text = "211110001";
            Text11.Text = "Gomes & Gomes, Lda.";

            cmbTpTerc.Items.Insert(0, "Não Aplicavél");
            cmbTpTerc.Items.Insert(1, "Fornecedores");
            cmbTpTerc.Items.Insert(2, "Clientes");
            cmbTpTerc.Items.Insert(3, "Tesouraria");
            cmbTpTerc.SelectedIndex = 0;

            Text13.Text = "";
            Text14.Text = "";
            Text15.Text = "";
            Text16.Text = "";
            Text17.Text = "";
            Text18.Text = "";
            Text19.Text = "";
            Text20.Text = "";
            Text21.Text = "";
            Text22.Text = "030";
        }

        //
        // Manutenção de Plano de Contas
        //
        private void Manutencao_PlanoContas(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta.");
                return;
            }

            dynamic oPlano = null;
            //
            short numero = 0;
            int lResult = 0;

            try
            {
                switch (TipoOperacaoApi)
                {

                    case Publicas.e_Operacao.Leitura:
                        oPlano = System.Activator.CreateInstance(objType_PlanodeContas);

                        lResult = oPlano.Ler(Text10.Text);
                        if (String.IsNullOrEmpty(oPlano.Conta))
                        {
                            Text11.Text = "";
                            Text19.Text = "";
                            Text15.Text = "";
                            Text20.Text = "";
                            Text22.Text = "";
                            Text21.Text = "";
                            Text13.Text = "";
                            Text14.Text = "";
                            Text16.Text = "";
                            Text17.Text = "";
                            Text18.Text = "";
                            fApi.DefInstance.EscreveMsg("Conta não existe!");
                        }
                        else
                        {
                            Text10.Text = oPlano.Conta;
                            Text11.Text = oPlano.Descricao;
                            Text19.Text = Convert.ToString(oPlano.NoDigitos);
                            Text15.Text = oPlano.RubricaOrcamental;
                            cmbTpTerc.Text = "";
                            Text20.Text = Convert.ToString(oPlano.NivelIntegracao);
                            Text22.Text = oPlano.Terceiro;
                            Text21.Text = Convert.ToString(oPlano.IntAnterior);
                            Text13.Text = oPlano.CodigoIva;
                            Text14.Text = oPlano.CodigoFluxo;
                            Text16.Text = oPlano.CentroCusteio;
                            Text17.Text = oPlano.ContaCorrespA;
                            Text18.Text = oPlano.ContaCorrespB;
                            fApi.DefInstance.EscreveMsg("Conta lida com sucesso!");
                        }
                        break;

                    //Inserir
                    case Publicas.e_Operacao.Inserir:
                        oPlano = System.Activator.CreateInstance(objType_PlanodeContas);

                        oPlano.Conta = Text10.Text;
                        oPlano.Descricao = Text11.Text;

                        if (Int16.TryParse(Text19.Text, out numero) == false)
                        {
                            numero = 0;
                        }
                        oPlano.NoDigitos = numero;

                        oPlano.RubricaOrcamental = Text15.Text;
                        oPlano.TipoTerceiro = (short)cmbTpTerc.SelectedIndex;

                        if (Int16.TryParse(Text20.Text, out numero) == false)
                        {
                            numero = 0;
                        }
                        oPlano.NivelIntegracao = numero;


                        oPlano.Terceiro = Text22.Text;


                        if (Int16.TryParse(Text21.Text, out numero) == false)
                        {
                            numero = 0;
                        }
                        oPlano.IntAnterior = numero;

                        oPlano.CodigoIva = Text13.Text;
                        oPlano.CodigoFluxo = Text14.Text;
                        oPlano.CentroCusteio = Text16.Text;
                        oPlano.ContaCorrespA = Text17.Text;
                        oPlano.ContaCorrespB = Text18.Text;

                        lResult = oPlano.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oPlano.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oPlano.Inserir();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Conta inserida com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oPlano.UltimaMensagem());
                            }
                        }
                        break;

                    case Publicas.e_Operacao.Alterar:
                        oPlano = System.Activator.CreateInstance(objType_PlanodeContas);

                        oPlano.Conta = Text10.Text;
                        oPlano.Descricao = Text11.Text;

                        if (Int16.TryParse(Text19.Text, out numero) == false)
                        {
                            numero = 0;
                        }
                        oPlano.NoDigitos = numero;

                        oPlano.RubricaOrcamental = Text15.Text;
                        oPlano.TipoTerceiro = (short)cmbTpTerc.SelectedIndex;

                        if (Int16.TryParse(Text20.Text, out numero) == false)
                        {
                            numero = 0;
                        }
                        oPlano.NivelIntegracao = numero;


                        oPlano.Terceiro = Text22.Text;


                        if (Int16.TryParse(Text21.Text, out numero) == false)
                        {
                            numero = 0;
                        }
                        oPlano.IntAnterior = numero;

                        oPlano.CodigoIva = Text13.Text;
                        oPlano.CodigoFluxo = Text14.Text;
                        oPlano.CentroCusteio = Text16.Text;
                        oPlano.ContaCorrespA = Text17.Text;
                        oPlano.ContaCorrespB = Text18.Text;


                        lResult = oPlano.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oPlano.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oPlano.Alterar();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Conta alterado com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oPlano.UltimaMensagem());
                            }
                        }
                        break;

                    case Publicas.e_Operacao.Remover:
                        oPlano = System.Activator.CreateInstance(objType_PlanodeContas);                    
                        oPlano.Ler(Text10.Text);

                        lResult = oPlano.Remover();
                        if (lResult == (int)Publicas.e_Result.Success)
                        {
                            Text10.Text = "";
                            Text11.Text = "";
                            Text19.Text = "";
                            Text15.Text = "";
                            Text20.Text = "";
                            Text22.Text = "";
                            Text21.Text = "";
                            Text13.Text = "";
                            Text14.Text = "";
                            Text16.Text = "";
                            Text17.Text = "";
                            Text18.Text = "";
                            fApi.DefInstance.EscreveMsg("Conta removida com sucesso!");
                        }
                        else
                        {
                            fApi.DefInstance.EscreveMsg(oPlano.UltimaMensagem());
                        }
                        break;
                }
                oPlano = null;
            }
            finally
            {
                if (oPlano != null)
                {
                    // Destruir objeto
                    Marshal.ReleaseComObject(oPlano);
                }
            }

        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            Manutencao_PlanoContas(Publicas.e_Operacao.Alterar);
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            Manutencao_PlanoContas(Publicas.e_Operacao.Inserir);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            Manutencao_PlanoContas(Publicas.e_Operacao.Remover);
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            Manutencao_PlanoContas(Publicas.e_Operacao.Leitura);
        }


    }
}
