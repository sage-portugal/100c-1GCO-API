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
    public partial class fUnidades : Form
    {

        System.Type objType_Unidades;
       
        public fUnidades()
        {
            InitializeComponent();
            Load += new EventHandler(fUnidades_Load);
            String Unidades = Publicas.dynamicAPI() + ".Unidades";
            objType_Unidades = System.Type.GetTypeFromProgID(Unidades);
        }


        private void fUnidades_Load(object sender, EventArgs e)
        {
            Text7.Text = "UN";
            Text8.Text = "Unidades";
            Text9.Text = "UN";
        }
        // -----------------------------------------------------------------------------------------
        //
        // Manutenção de Unidades
        //
        // -----------------------------------------------------------------------------------------
        private void Manutencao_Unidades(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta");
                return;
            }

            dynamic oUnidade = null;
            try
            {
                int lResult = 0;

                switch (TipoOperacaoApi)
                {
                    //Leitura
                    case Publicas.e_Operacao.Leitura:
                        oUnidade = System.Activator.CreateInstance(objType_Unidades);
                        lResult = oUnidade.Ler(Text7.Text);
                        if (String.IsNullOrEmpty(oUnidade.Codigo))
                        {
                            Text8.Text = "";
                            Text9.Text = "";
                            fApi.DefInstance.EscreveMsg("Unidade não existe!");
                        }
                        else
                        {
                            Text7.Text = oUnidade.Codigo;
                            Text8.Text = oUnidade.Descricao;
                            Text9.Text = oUnidade.CodigoISO;
                            fApi.DefInstance.EscreveMsg("Unidade lida com sucesso!");
                        }

                        break;

                    // Inserir
                    case Publicas.e_Operacao.Inserir:
                        oUnidade = System.Activator.CreateInstance(objType_Unidades);
                        oUnidade.Codigo = Text7.Text;
                        oUnidade.Descricao = Text8.Text;
                        oUnidade.CodigoISO = Text9.Text;

                        lResult = oUnidade.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oUnidade.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oUnidade.Inserir();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Unidade inserida com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oUnidade.UltimaMensagem());
                            }
                        }

                        break;

                    //Alterar
                    case Publicas.e_Operacao.Alterar:
                        oUnidade = System.Activator.CreateInstance(objType_Unidades);
                        oUnidade.Codigo = Text7.Text;
                        oUnidade.Descricao = Text8.Text;
                        oUnidade.CodigoISO = Text9.Text;

                        lResult = oUnidade.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oUnidade.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oUnidade.Alterar();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Unidade alterada com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oUnidade.UltimaMensagem());
                            }
                        }

                        break;

                    //Remover
                    case Publicas.e_Operacao.Remover:
                        oUnidade = System.Activator.CreateInstance(objType_Unidades);
                        oUnidade.Ler(Text7.Text);
                        lResult = oUnidade.Remover();
                        if (lResult == (int)Publicas.e_Result.Success)
                        {
                            Text7.Text = "";
                            Text8.Text = "";
                            Text9.Text = "";
                            fApi.DefInstance.EscreveMsg("Unidade removida com sucesso!");
                        }
                        else
                        {
                            fApi.DefInstance.EscreveMsg(oUnidade.UltimaMensagem());
                        }

                        break;
                }

                oUnidade = null;

            }
            finally
            {
                if (oUnidade != null)
                {
                    // Destruir objeto
                    Marshal.ReleaseComObject(oUnidade);
                }
            }

        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            Manutencao_Unidades(Publicas.e_Operacao.Inserir);
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            Manutencao_Unidades(Publicas.e_Operacao.Alterar);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            Manutencao_Unidades(Publicas.e_Operacao.Remover);
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            Manutencao_Unidades(Publicas.e_Operacao.Leitura);
        }

    }
}

