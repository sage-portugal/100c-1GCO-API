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
    public partial class fClientes : Form
    {

        System.Type objType_Clientes;

        public fClientes()
        {
            InitializeComponent();
            Load += new EventHandler(fClientes_Load);
            String Clientes = Publicas.dynamicAPI() + ".Clientes";
            objType_Clientes = System.Type.GetTypeFromProgID(Clientes);
        }


        private void fClientes_Load(object sender, EventArgs e)
        {
			// e_Entidade.Cliente
			Text201.Text = "001";
			Text202.Text = "Manuel Soares";
			Text203.Text = "NAC";
			Text204.Text = "VND1";
			Text205.Text = "EUR";
			Text206.Text = "PRT";
			Text207.Text = "PT";
			Text208.Text = "Para exportação";
        }

        // -----------------------------------------------------------------------------------------
        //
        // Manutenção de Clientes
        //
        // -----------------------------------------------------------------------------------------
        private void Manutencao_Clientes(Publicas.e_Operacao TipoOperacaoApi)
        {
            if (mApi.my_api.AbreEmpresa == false)
            {
                fApi.DefInstance.EscreveMsg("API não Iniciada");
                return;
            }

            dynamic oCliente = null;
            try
            {
                int lResult = 0;

                switch (TipoOperacaoApi)
                {
                    // Leitura
                    case Publicas.e_Operacao.Leitura:
                        oCliente = System.Activator.CreateInstance(objType_Clientes);

                        lResult = oCliente.Ler(Text201.Text);
                        if (String.IsNullOrEmpty(oCliente.Codigo))
                        {
                            Text202.Text = "";
                            Text203.Text = "";
                            Text204.Text = "";
                            Text205.Text = "";
                            Text206.Text = "";
                            Text207.Text = "";
                            Text208.Text = "";
                            fApi.DefInstance.EscreveMsg("Cliente não existe!");
                        }
                        else
                        {
                            Text201.Text = oCliente.Codigo;
                            Text202.Text = oCliente.Nome;
                            Text203.Text = oCliente.REGIVA;
                            Text204.Text = oCliente.VENDED;
                            Text205.Text = oCliente.Moeda;
                            Text206.Text = oCliente.ZONAGE;
                            Text207.Text = oCliente.PAIS;
                            Text208.Text = oCliente.OBSERV;
                            fApi.DefInstance.EscreveMsg("Cliente lido com sucesso!");
                        }
                        break;

                    // Inserir
                    case Publicas.e_Operacao.Inserir:
                        oCliente = System.Activator.CreateInstance(objType_Clientes);
                        oCliente.Codigo = Text201.Text;
                        oCliente.Nome = Text202.Text;
                        oCliente.REGIVA = Text203.Text;
                        oCliente.VENDED = Text204.Text;
                        oCliente.Moeda = Text205.Text;
                        oCliente.ZONAGE = Text206.Text;
                        oCliente.PAIS = Text207.Text;
                        oCliente.OBSERV = Text208.Text;

                        lResult = oCliente.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oCliente.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oCliente.Inserir();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Cliente inserido com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oCliente.UltimaMensagem());
                            }
                        }

                        break;

                    // Alterar
                    case Publicas.e_Operacao.Alterar:
                        oCliente = System.Activator.CreateInstance(objType_Clientes);

                        oCliente.Codigo = Text201.Text;
                        oCliente.Nome = Text202.Text;
                        oCliente.REGIVA = Text203.Text;
                        oCliente.VENDED = Text204.Text;
                        oCliente.Moeda = Text205.Text;
                        oCliente.ZONAGE = Text206.Text;
                        oCliente.PAIS = Text207.Text;
                        oCliente.OBSERV = Text208.Text;
                        lResult = oCliente.Validar();
                        if (lResult != (int)Publicas.e_Result.Success)
                        {
                            fApi.DefInstance.EscreveMsg(oCliente.UltimaMensagem());
                        }
                        else
                        {
                            lResult = oCliente.Alterar();
                            if (lResult == (int)Publicas.e_Result.Success)
                            {
                                fApi.DefInstance.EscreveMsg("Cliente alterado com sucesso!");
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg(oCliente.UltimaMensagem());
                            }
                        }
                        break;

                    // Remover
                    case Publicas.e_Operacao.Remover:
                        oCliente = System.Activator.CreateInstance(objType_Clientes);
                        oCliente.Ler(Text201.Text);
                        lResult = oCliente.Remover();
                        if (lResult == (int)Publicas.e_Result.Success)
                        {
                            Text201.Text = "";
                            Text202.Text = "";
                            Text203.Text = "";
                            Text204.Text = "";
                            Text205.Text = "";
                            Text206.Text = "";
                            Text207.Text = "";
                            Text208.Text = "";
                            fApi.DefInstance.EscreveMsg("Cliente removido com sucesso!");
                        }
                        else
                        {
                            fApi.DefInstance.EscreveMsg(oCliente.UltimaMensagem());
                        }
                        break;
                }

                oCliente = null;
            }
            finally
            {
                if (oCliente != null)
                {
                    // Destruir objeto
                    Marshal.ReleaseComObject(oCliente);
                }
            }
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdLer_Click(object sender, EventArgs e)
        {
            Manutencao_Clientes(Publicas.e_Operacao.Leitura);
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
          Manutencao_Clientes(Publicas.e_Operacao.Remover);
        }

        private void cmdUpd_Click(object sender, EventArgs e)
        {
            Manutencao_Clientes(Publicas.e_Operacao.Alterar);
        }

        private void cmdIns_Click(object sender, EventArgs e)
        {
            Manutencao_Clientes(Publicas.e_Operacao.Inserir);
        }
    }
}
