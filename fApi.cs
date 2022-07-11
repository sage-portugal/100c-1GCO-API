using Microsoft.VisualBasic;
using System;
using Microsoft.CSharp;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;

//
//---*--------------------------------------------------------------------------
//   *
//   * 2005 - Jorge Nobre - Sage Portugal
//   * 2008 - Jorge Ferreira - Sage Portugal
//   * 2014 - Jorge Nobre - Sage Portugal
//   * 2017 - Jorge Nobre - Sage Portugal
//---*--------------------------------------------------------------------------
//   *
//   * 2005 - Exemplo de Utilização da Api : SageBGCOApi10.Dll em Visual Basic
//   * 2014 - Exemplo de Utilização da Api : SageBGCOApi10.Dll em C#
//   * 2017 - Exemplo de Utilização da Api : SageBGCOApi10.Dll como dynamic Object
//---*--------------------------------------------------------------------------
//

namespace ApiLaunchBusiness
{
  

    internal partial class fApi: System.Windows.Forms.Form
	{

        //
        // Main
        // Lançar o Projeto Exemplo API
        //

        public Publicas.tp_DadosInicializacao ini;

        [STAThread]
        static void Main()
        {
            Application.Run(CreateInstance());
        }

        private void fApi_Load(object sender, EventArgs e)
        {
            fApi_EnableMenu(false);
            Boolean ok = Publicas.readConfiguration();
            ini = Publicas.tp_DadosInicializacao.CreateInstance();
            Form_Load();
            if (!ok)
            {
                Environment.Exit(0);
            }
        }

        //
        // Load do Form
        //
        private void Form_Load()
        {
            txtStatusMsg.Text = "";
            txtPercursoWin.Text = ini.PercursoBusinessWin;
            txtFicheiroLogErros.Text = ini.FicheiroLogErros;
            txtCompany.Text = ini.Empresa;
            txtUser.Text = ini.Utilizador;
            txtPwd.Text = ini.Password;
        }


        private void fApi_EnableMenu(Boolean Activate)
        {
                unidadesToolStripMenuItem.Enabled = Activate;
                artigosToolStripMenuItem.Enabled = Activate;
                clientesToolStripMenuItem.Enabled = Activate;
                fornecedoresToolStripMenuItem.Enabled = Activate;
                planoDeContasToolStripMenuItem.Enabled = Activate;
                DocumentoContabilidadeToolStripMenuItem.Enabled = Activate;
                GerarDocumentosToolStripMenuItem.Enabled = Activate;
                DocumentoReciboToolStripMenuItem.Enabled = Activate;
                DocumentoComercialToolStripMenuItem.Enabled = Activate;
                entidadesToolStripMenuItem.Enabled = Activate;
                outrasExemplosToolStripMenuItem.Enabled = Activate;
        }

        //
        // Entidades
        //
        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fUnidades newApiForm = new fUnidades();
            newApiForm.Show(); // Shows Form
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fArtigos newApiForm = new fArtigos();
            newApiForm.Show(); // Shows Form
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fClientes newApiForm = new fClientes();
            newApiForm.Show(); // Shows Form
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fFornecedores newApiForm = new fFornecedores();
            newApiForm.Show(); // Shows Form
        }

        private void planoDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPlanoContas newApiForm = new fPlanoContas();
            newApiForm.Show(); // Shows Form
        }

        //
        // Documentos
        //
        private void documentoComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDocumentoComercial newApiForm = new fDocumentoComercial();
            newApiForm.Show(); // Shows Form
        }

        private void DocumentoReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDocumentoRecibo newApiForm = new fDocumentoRecibo();
            newApiForm.Show(); // Shows Form
        }
        private void GerarDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fGerarDocumentos newApiForm = new fGerarDocumentos();
            newApiForm.Show(); // Shows Form
        }

        private void DocumentoContabilidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDocumentoContabilidade newApiForm = new fDocumentoContabilidade();
            newApiForm.Show(); // Shows Form
        }
        //
        // Outros Exemplos
        //
        private void outrasExemplosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fOutrosExemplos newApiForm = new fOutrosExemplos();
            newApiForm.Show(); // Shows Form
        }

        //
        // Outros
        //
        private void SageApi_toolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //
        // Sair do Projeto Exemplo API
        //
        private void fimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mApi.my_api.AbreEmpresa == true)
            {
                Processo_API_Terminar();
            }

            // Destruir Objeto
            Marshal.ReleaseComObject(mApi.my_api);

            Environment.Exit(0);

        }
        //
        // Carregou em Botão "Iniciar Api"
        //
        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Processo_API_Iniciar();
        }

        //
        // Terminar a API
        //
        private void terminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Processo_API_Terminar();
        }

		//
		// Inicialização da API
        //
		public fApi(): base()
		{
            if (m_FormDefInstance == null)
			{
				if (m_InitializingDefInstance)
				{
                    m_FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
                            m_FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}

			//This call is required by the Windows Form Designer.

			InitializeComponent();

			ReLoadForm(false);
		}

		//
        // Iniciar a API
        //
		private void Processo_API_Iniciar()
		{

            //Publicas.tp_DadosInicializacao ini = Publicas.tp_DadosInicializacao.CreateInstance();
            int lResult = 0;

            // Nenhuma empresa aberta
            if (mApi.my_api.AbreEmpresa == false)
			{

                //txtPercursoBusinessWin.Text = ini.PercursoBusinessWin;
                //txtFicheiroLogErros.Text = ini.FicheiroLogErros;
                //txtCompany.Text = ini.Empresa;
                //txtUser.Text = ini.Utilizador;
                //txtPwd.Text = ini.Password;

                mApi.my_api.PercLOG = txtFicheiroLogErros.Text;
                mApi.my_api.PercIni = txtPercursoWin.Text;
                mApi.my_api.Empresa = txtCompany.Text;
                mApi.my_api.Login = txtUser.Text;
                mApi.my_api.Password = txtPwd.Text;


                //.Api_Debug = True     
                // Utilizar para que sejam enviadas mensagens para o EventViewer com o
                // Trace do precurso do código na classe do documento comercial.
                // Pode em vez disto ser criado um ficheiro Debug.API na directoria do Busines.win

                lResult = mApi.my_api.Iniciar();

			    if (lResult == 0)
			    {
    				EscreveMsg("Empresa aberta com sucesso!");
                    fApi_EnableMenu(true);
			    }
			    else
                {
	    			EscreveMsg("Erro [" + lResult.ToString() + "] ao abrir a empresa! Consulte p.f. o ficheiro de log");
                    mApi.my_api.AbreEmpresa = false;
			    }
			}
			else
			{
			  EscreveMsg("Já se encontra uma empresa aberta!");
			}			
		}

        //
        // Terminar a API
        //
		private void Processo_API_Terminar()
		{
            mApi.my_api.PercLOG = String.Empty;
            mApi.my_api.PercIni = String.Empty;
            mApi.my_api.Empresa = String.Empty;
            mApi.my_api.Login = String.Empty;
            mApi.my_api.Password = String.Empty;
            mApi.my_api.AbreEmpresa = false;

            // Termina connection
            mApi.my_api.Terminar();

            EscreveMsg("Empresa Fechada!");
            fApi_EnableMenu (false);
		}

		//
		// Escreve mensagens 
		// 
		public void EscreveMsg(string sMsg)
		{
			
            txtStatusMsg.Text = sMsg;
			MessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}