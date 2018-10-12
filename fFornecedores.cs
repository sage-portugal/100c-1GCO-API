using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ApiLaunchBusiness
{
    public partial class fFornecedores : Form
    {

        System.Type objType_Fornecedores;


        public fFornecedores()
        {
            InitializeComponent();
            Load += new EventHandler(fFornecedores_Load);
            String Fornecedores = Publicas.dynamicAPI() + ".Fornecedores";
            objType_Fornecedores = System.Type.GetTypeFromProgID(Fornecedores);

            Publicas.listProperties(objType_Fornecedores, Fornecedores);
        }

        private void fFornecedores_Load(object sender, EventArgs e)
        {
			// e_Entidade.Fornecedor
			Text301.Text = "001";
			Text302.Text = "Joaquim Soares";
			Text303.Text = "NAC";
			Text304.Text = "5000";
			Text305.Text = "EUR";
			Text306.Text = "PRT";
			Text307.Text = "PT";
			Text308.Text = "Para exportação";
        }

        // -----------------------------------------------------------------------------------------
        //
        // Manutenção de Fornecedores
        //
        // -----------------------------------------------------------------------------------------
        private void Manutencao_Fornecedores(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta!");
                return;
            }
     
            dynamic oFornecedor = null;
            //
            int lResult = 0;

            try
            {
                switch (TipoOperacaoApi)
                {
                    //Leitura
                    case Publicas.e_Operacao.Leitura:
                        
                        oFornecedor = System.Activator.CreateInstance(objType_Fornecedores);

                        lResult = oFornecedor.Ler(Text301.Text);
                        if (String.IsNullOrEmpty(oFornecedor.Codigo))
                        {
                            Text302.Text = "";
                            Text303.Text = "";
                            Text304.Text = "";
                            Text305.Text = "";
                            Text306.Text = "";
                            Text307.Text = "";
                            Text308.Text = "";
                            fApi.DefInstance.EscreveMsg("Fornecedor não existe!");
                        }
                        else
                        {
                            Text301.Text = oFornecedor.Codigo;
                            Text302.Text = oFornecedor.Nome;
                            Text303.Text = oFornecedor.REGIVA;
                            Text304.Text = Convert.ToString(oFornecedor.PLAFON);
                            Text305.Text = oFornecedor.Moeda;
                            Text306.Text = oFornecedor.ZONA;
                            Text307.Text = oFornecedor.PAIS;
                            Text308.Text = oFornecedor.OBSERV;
                            fApi.DefInstance.EscreveMsg("Fornecedor lido com sucesso!");
                        }
                        break;

                    //Inserir
                    case Publicas.e_Operacao.Inserir:

                        oFornecedor = System.Activator.CreateInstance(objType_Fornecedores);
                        oFornecedor.Codigo = Text301.Text;
                        oFornecedor.Nome = Text302.Text;
                        oFornecedor.REGIVA = Text303.Text;
                        oFornecedor.PLAFON = Decimal.Parse(Text304.Text, NumberStyles.Currency);
                        oFornecedor.Moeda = Text305.Text;
                        oFornecedor.ZONA = Text306.Text;
                        oFornecedor.PAÍS = Text307.Text;
                        oFornecedor.OBSERV = Text308.Text;

                        lResult = oFornecedor.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oFornecedor.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oFornecedor.Inserir();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Fornecedor inserido com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oFornecedor.UltimaMensagem());
                            }
                        }
                        break;

                    //Alterar
                    case Publicas.e_Operacao.Alterar:
                        oFornecedor = System.Activator.CreateInstance(objType_Fornecedores);

                        oFornecedor.Codigo = Text301.Text;
                        oFornecedor.Nome = Text302.Text;
                        oFornecedor.REGIVA = Text303.Text;
                        oFornecedor.PLAFON = Decimal.Parse(Text304.Text, NumberStyles.Currency);
                        oFornecedor.Moeda = Text305.Text;
                        oFornecedor.ZONA = Text306.Text;
                        oFornecedor.PAÍS = Text307.Text;
                        oFornecedor.OBSERV = Text308.Text;
                        lResult = oFornecedor.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oFornecedor.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oFornecedor.Alterar();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Fornecedor alterado com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oFornecedor.UltimaMensagem());
                            }
                        }
                        break;

                    //Remover
                    case Publicas.e_Operacao.Remover:
                        oFornecedor = System.Activator.CreateInstance(objType_Fornecedores);
                        oFornecedor.Ler(Text301.Text);

                        lResult = oFornecedor.Remover();
                        if (lResult == (int)Publicas.e_Result.Success)
                        {
                            Text301.Text = "";
                            Text302.Text = "";
                            Text303.Text = "";
                            Text304.Text = "";
                            Text305.Text = "";
                            Text306.Text = "";
                            Text307.Text = "";
                            Text308.Text = "";
                            fApi.DefInstance.EscreveMsg("Fornecedor removido com sucesso!");
                        }
                        else
                        {
                            fApi.DefInstance.EscreveMsg(oFornecedor.UltimaMensagem());
                        }
                        break;
                }

                oFornecedor = null;
            }
            finally
            {
                if (oFornecedor != null)
                {
                    // Destruir objeto
                    Marshal.ReleaseComObject(oFornecedor);
                }
            }
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            Manutencao_Fornecedores(Publicas.e_Operacao.Inserir);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            Manutencao_Fornecedores(Publicas.e_Operacao.Remover);
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            Manutencao_Fornecedores(Publicas.e_Operacao.Leitura);
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            Manutencao_Fornecedores(Publicas.e_Operacao.Alterar);
        }
    }
}
