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
using Microsoft.VisualBasic;
using System.Globalization;

namespace ApiLaunchBusiness
{
    public partial class fGerarDocumentos : Form
    {

        public static string[] VectorClientes = null;
        public static string[] VectorFornecedores = null;
        public static string[] VectorArtigos = null;

        public static int numeroFicheiro = 0;
        public static string nomeFicheiro = String.Empty;
        public static bool continuarProcesso = false;

        System.Type objType_DocumentoComercial;
        System.Type objType_DocumentosGcLin;
        System.Type objType_LotesLinha;
        System.Type objType_NumSerieLinha;
        System.Type objType_Clientes;
        System.Type objType_Fornecedores;
        System.Type objType_Artigos;

        public fGerarDocumentos()
        {
            InitializeComponent();
            Load += new EventHandler(fGerarDocumentos_Load);


            String DocumentoComercial = Publicas.dynamicSageApiName() + ".DocumentoComercial";
            String DocumentosGcLin = Publicas.dynamicSageApiName() + ".DocumentosGcLin";
            String LotesLinha = Publicas.dynamicSageApiName() + ".LotesLinha";
            String NumSerieLinha = Publicas.dynamicSageApiName() + ".NumSerieLinha";
            String Bancos = Publicas.dynamicSageApiName() + ".Bancos";
            String Clientes = Publicas.dynamicSageApiName() + ".Clientes";
            String Fornecedores = Publicas.dynamicSageApiName() + ".Fornecedores";
            String Artigo = Publicas.dynamicSageApiName() + ".Artigos";

            objType_DocumentoComercial = System.Type.GetTypeFromProgID(DocumentoComercial);
            objType_DocumentosGcLin = System.Type.GetTypeFromProgID(DocumentosGcLin);
            objType_LotesLinha = System.Type.GetTypeFromProgID(LotesLinha);
            objType_NumSerieLinha = System.Type.GetTypeFromProgID(NumSerieLinha);
            objType_Clientes = System.Type.GetTypeFromProgID(Clientes);
            objType_Fornecedores = System.Type.GetTypeFromProgID(Fornecedores);
            objType_Artigos = System.Type.GetTypeFromProgID(Artigo);
        }


        //
        // Key Press
        //
        private void fGerarDocumentos_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = Strings.Asc(eventArgs.KeyChar);

            if (KeyAscii == ((int)Keys.Escape))
            {

                    continuarProcesso = false;
                    KeyAscii = 0;
               
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        //
        // DANGER
        //

        public void cmdTAR_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            if (MessageBox.Show("Gerar transferência agora ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GerarDocumentos_Armazens();
            }
            this.Cursor = Cursors.Default;
        }

        private void cmdGDGerarDocs_Click(Object eventSender, EventArgs eventArgs)
        {
            Publicas.e_TiposDocumentos TpDoc = Publicas.e_TiposDocumentos.EncomendaCliente;

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            if (MessageBox.Show("Gerar documentos agora ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                TpDoc = (Publicas.e_TiposDocumentos)cmbGDTipoDoc.SelectedIndex;
                switch (TpDoc)
                {
                    case Publicas.e_TiposDocumentos.EncomendaCliente:
                        GerarDocumentos_Clientes();
                        break;
                    case Publicas.e_TiposDocumentos.CompraFornecedor:
                        GerarDocumentos_Fornecedores();
                        break;
                }

            }
            this.Cursor = Cursors.Default;

        }
        private void fGerarDocumentos_Load(object sender, EventArgs e)
        {

            txtGDNumDoc.Text = "20";
            txtGDSerie.Text = "1";
            txtGDSector.Text = "ANS";
            txtGDDataDoc.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtGDLinhasPorDocumento.Text = "40";
            chkCcfToGr.CheckState = CheckState.Checked;
            this.KeyPreview = true;
            VectorArtigos = new string[] { String.Empty };
            VectorClientes = new string[] { String.Empty };
            VectorFornecedores = new string[] { String.Empty };
            GerarDocumentos_CarregarTipoDocumentos();

        
        }
        //
        // Load de Fornecedores para Array
        //
        private bool GerarDocumentos_CarregarFornecedoresEmMemoria()
        {
            
            dynamic oEntidade = null;
            try
            {
                
                string Codigo = String.Empty;
                bool IsActivo = false;
                bool Segue = false;
                int Indice = 0;

                bool Retorno = false;
                if (mApi.my_api != null)
                {
                    VectorFornecedores = new string[] { String.Empty };

                    oEntidade = System.Activator.CreateInstance(objType_Fornecedores);

                    Segue = (oEntidade.NavegarPrimeiro() >= 0);
                    while (Segue)
                    {
                        if (oEntidade.Codigo != null)
                        {
                            Codigo = oEntidade.Codigo;
                            IsActivo = ~oEntidade.INACTI != 0;
                            if (IsActivo)
                            {
                                if (Codigo.Trim().Length > 0)
                                {
                                    System.Array.Resize(ref VectorFornecedores, Indice + 1);
                                    VectorFornecedores[Indice] = oEntidade.Codigo;
                                    GerarDocumentos_Report("Fornecedor: " + oEntidade.Codigo, false);
                                    Indice++;
                                    Retorno = true;
                                }
                            }
                        }
                        Segue = (oEntidade.NavegarProximo() >= 0);
                    }
                    oEntidade = null;
                }
                else
                {
                    fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta.");
                }
                return Retorno;
            }
            finally
            {
                if (oEntidade != null)
                {
                    Marshal.ReleaseComObject(oEntidade);
                }
            }
        }
        //
        // Load de Artigos para Array
        //
        private bool GerarDocumentos_CarregarArtigosEmMemoria(bool CarregarDescritores = true)
        {
            dynamic oEntidade = null;

            try
            {
                string Codigo = String.Empty;
                bool IsActivo = false;
                bool IsDescritor = false;
                bool IsArtigo = false;
                string Taxa = String.Empty;
                bool Segue = false;
                int Indice = 0;

                bool Retorno = false;
                if (mApi.my_api != null)
                {
                    VectorArtigos = new string[] { String.Empty };

                    oEntidade = System.Activator.CreateInstance(objType_Artigos);

                    Segue = (oEntidade.NavegarPrimeiro() >= 0);
                    while (Segue)
                    {
                        if (oEntidade.Codigo != null)
                        {
                            Codigo = oEntidade.Codigo;

                            IsDescritor = (oEntidade.ARTOUD == -1);
                            IsArtigo = (oEntidade.ARTOUD == 0);

                            IsActivo = ~oEntidade.INACTI != 0;
                            Taxa = oEntidade.Taxa.Trim();
                            if (IsActivo)
                            {
                                if (Taxa.Length == 0)
                                {
                                    if (Codigo.Trim().Length > 0)
                                    {
                                        if (IsArtigo || (IsDescritor && CarregarDescritores))
                                        {
                                            System.Array.Resize(ref VectorArtigos, Indice + 1);
                                            VectorArtigos[Indice] = oEntidade.Codigo;
                                            GerarDocumentos_Report("Artigo: " + oEntidade.Codigo, false);

                                            Indice++;
                                            Retorno = true;
                                        }

                                    }
                                }
                            }

                        }
                        Segue = (oEntidade.NavegarProximo() >= 0);
                    }
                    oEntidade = null;
                }
                else
                {
                    fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta.");
                }
                return Retorno;
            }
            finally
            {

                if (oEntidade != null)
                {
                    Marshal.ReleaseComObject(oEntidade);
                }
            }
        }

        //
        // Validar Gerar Documentos de Clientes em BATCH
        //
        private bool GerarDocumentos_Clientes_IsTudoOk()
        {

            bool Retorno = false;
            if (cmbGDTipoDoc.Text.Trim().Length > 0)
            {
                if ((Convert.ToInt32(txtGDNumDoc.Text)) > 0)
                {
                    if (txtGDSerie.Text.Trim().Length > 0)
                    {
                        if (txtGDSector.Text.Trim().Length > 0)
                        {
                            if (Information.IsDate(txtGDDataDoc.Text))
                            {
                                if ((Convert.ToInt32(txtGDLinhasPorDocumento.Text)) > 0)
                                {
                                    if (VectorClientes[0].Trim().Length > 0)
                                    {
                                        if (VectorArtigos[0].Trim().Length > 0)
                                        {
                                            Retorno = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Não existem artigos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existem clientes.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Número de linhas por documento inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Data inválida.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sector inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Série inválida.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Número do documento inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Tipo de documento inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return Retorno;

        }

        //
        // Validar Gerar Documentos de Armazens em BATCH
        //
        private void GerarDocumentos_Armazens()
        {

            dynamic objDocumento = null;
            dynamic objLinhas = null;

            try
            {
                string TipoDoc = String.Empty;


                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                
                if (mApi.my_api != null)
                {

                    objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);
                    objLinhas = System.Activator.CreateInstance(objType_DocumentosGcLin);

                    TipoDoc = "TAR";

                    objDocumento.cab.Data = DateTime.Today.ToString("d");
                    objDocumento.cab.Serie = 1;
                    objDocumento.cab.TipoDocumento = TipoDoc;
                    objDocumento.cab.Terceiro = "AR2";
                    objDocumento.cab.Sector = "ANS";
                    objDocumento.cab.Moeda = "EUR";
                    objDocumento.cab.RegimeIva = "NAC";
                    objDocumento.cab.TipoTerceiro = 4;
                    objDocumento.cab.TipoPreco = 6;
                    objDocumento.cab.DataLancamento = DateTime.Today.ToString("d");

                    objLinhas.TipoDocumento = TipoDoc;
                    objLinhas.NumeroDaLinha = 1;
                    objLinhas.TipoDeLinha = 1;
                    objLinhas.Ano = (short)DateTime.Now.Year;
                    objLinhas.Armazem = "AR1";
                    objLinhas.Artigo = "FAT03";
                    objLinhas.PrecoUnitario = 49.3005m;
                    objLinhas.Quantidade = 10;
                    objLinhas.Unidade = "UN";

                    bool tempRefParam = true;
                    bool tempRefParam2 = true;
                    bool tempRefParam3 = true;
                    bool tempRefParam4 = false;
                    bool tempRefParam5 = false;
                    bool tempRefParam6 = false;
                    bool tempRefParam7 = true;
                    objDocumento.SugereValoresLin(ref objLinhas, ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6, ref tempRefParam7);
                    if (objDocumento.AdicionaLinha(objLinhas) == 0)
                    {

                        if (objDocumento.Validar() == 0)
                        {
                            if (objDocumento.Inserir() == 0)
                            {
                                Application.DoEvents();
                                MessageBox.Show("Transferência criada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                fApi.DefInstance.EscreveMsg("Não foi possível inserir o documento");
                            }
                        }
                        else
                        {
                            fApi.DefInstance.EscreveMsg("Não foi possível validar o documento");
                        }
                    }
                    else
                    {
                        fApi.DefInstance.EscreveMsg("Não foi possível adicionar a linha ao documento");
                    }
                }
                else
                {
                    fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta.");
                }


                Cursor.Current = Cursors.Default;
            }
            finally
            {

                if (objLinhas != null)
                {
                    Marshal.ReleaseComObject(objLinhas);
                }

                if (objDocumento != null)
                {
                    Marshal.ReleaseComObject(objDocumento);
                }
            }

        }

        //
        // Gerar Documentos de Fornecedoers em BATCH
        //
        private void GerarDocumentos_Fornecedores()
        {

            dynamic objDocumento = null;
            dynamic objLinhas = null;
            dynamic objNumser = null;
            dynamic objLotes = null;
            dynamic objArtigos = null;

            try
            {

                int NrDoc = 0;
                int TotalLinhas = 0;
                int TotalArtigos = 0;
                int TotalClientes = 0;
                int TotalFornecedores = 0;
                int NrLin = 0;
                int Preço = 0;
                int Quantidade = 0;
                int lResult = 0;

                string Cliente = String.Empty;
                string Fornecedor = String.Empty;
                string Artigo = String.Empty;
                string TipoDoc = String.Empty;
                string Serie = String.Empty;
                string Sector = String.Empty;
                string DataDoc = String.Empty;
                string Armazem = String.Empty;


                Random aleatorio = new Random();

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (GerarDocumentos_CarregarArtigosEmMemoria(false))
                {
                    if (GerarDocumentos_CarregarClientesEmMemoria())
                    {
                        if (GerarDocumentos_CarregarFornecedoresEmMemoria())
                        {
                            if (GerarDocumentos_Fornecedores_IsTudoOk())
                            {

                                numeroFicheiro = FileSystem.FreeFile();
                                nomeFicheiro = Path.GetDirectoryName(Application.ExecutablePath) + "\\GD_CCF_Geradas.txt";
                                FileSystem.FileOpen(numeroFicheiro, nomeFicheiro, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                                GerarDocumentos_BlockAll(true);
                                lstGDDocs.Items.Clear();
                                TotalArtigos = VectorArtigos.GetUpperBound(0) + 1;
                                TotalClientes = VectorClientes.GetUpperBound(0 + 1);
                                TotalFornecedores = VectorFornecedores.GetUpperBound(0) + 1;

                                Cliente = VectorClientes[Convert.ToInt32((float)(aleatorio.Next(0, VectorClientes.GetUpperBound(0))))];
                                Fornecedor = VectorFornecedores[Convert.ToInt32((float)(aleatorio.Next(0, VectorFornecedores.GetUpperBound(0))))];
                                TotalLinhas = Convert.ToInt32(txtGDLinhasPorDocumento.Text);
                                TipoDoc = "CCF";
                                NrDoc = Convert.ToInt32(txtGDNumDoc.Text);
                                Serie = txtGDSerie.Text.Trim();
                                Sector = txtGDSector.Text.Trim();
                                DataDoc = txtGDDataDoc.Text.Trim();
                                Armazem = "AR1";
                                NrLin = 0;


                                continuarProcesso = true;

                                while (continuarProcesso)
                                {
                                    objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);

                                    Preço = Convert.ToInt32((float)aleatorio.Next(1, 99));
                                    Artigo = VectorArtigos[Convert.ToInt32((float)(aleatorio.Next(0, VectorArtigos.GetUpperBound(0))))];
                                    Quantidade = Convert.ToInt32((float)aleatorio.Next(1, 99));
                                    NrLin++;
                                    // Cabeçalho ...
                                    if (NrLin > TotalLinhas)
                                    {

                                        objDocumento.cab.TipoDocumento = TipoDoc;
                                        objDocumento.cab.TipoTerceiro = 1;
                                        objDocumento.cab.NossoNoDocumento = NrDoc;
                                        objDocumento.cab.Serie = Convert.ToInt16(Double.Parse(Serie));
                                        objDocumento.cab.Ano = (short)DateTime.Parse(DataDoc).Year;
                                        objDocumento.cab.Data = DataDoc;
                                        objDocumento.cab.Sector = Sector;
                                        objDocumento.cab.Terceiro = Fornecedor;
                                        objDocumento.cab.DescontoCabecalho = ((decimal)aleatorio.Next(0, 99));
                                        lResult = objDocumento.Validar();
                                        if (lResult == 0)
                                        {
                                            lResult = objDocumento.Inserir();
                                            if (lResult == 0)
                                            {
                                                GerarDocumentos_Report("Documento de " + TotalLinhas.ToString() + " linhas gerado : " + TipoDoc + "/" + NrDoc.ToString() + "/" + Serie + "/" + DateTime.Parse(DataDoc).Year.ToString(), true);
                                                // Criar a guia de remessa ...
                                                if (chkCcfToGr.CheckState == CheckState.Checked)
                                                {
                                                    objDocumento.cab.TipoDocumento = "GR";
                                                    objDocumento.cab.TipoTerceiro = 2;
                                                    objDocumento.cab.Terceiro = Cliente;
                                                    lResult = objDocumento.Validar(0);
                                                    if (lResult == 0)
                                                    {
                                                        lResult = objDocumento.Inserir();
                                                        if (lResult == 0)
                                                        {
                                                            GerarDocumentos_Report("Documento convertido para : " + objDocumento.cab.TipoDocumento + "/" + NrDoc.ToString() + "/" + Serie + "/" + DateTime.Parse(DataDoc).Year.ToString(), true);
                                                        }
                                                        Application.DoEvents();
                                                    }
                                                }
                                            }
                                        }
                                        Application.DoEvents();
                                        NrLin = 1;
                                        NrDoc++;
                                        Cliente = VectorClientes[Convert.ToInt32((float)(aleatorio.Next(0,VectorClientes.GetUpperBound(0))))];
                                        Fornecedor = VectorFornecedores[Convert.ToInt32((float)(aleatorio.Next(0, VectorFornecedores.GetUpperBound(0))))];

                                        objDocumento = null;

                                    }

                                    // Linhas ...     
                                    objLinhas = System.Activator.CreateInstance(objType_DocumentosGcLin);
                                    objArtigos = System.Activator.CreateInstance(objType_Artigos);

                                    if (objArtigos.Ler(Artigo, "") == 0)
                                    {
                                        objLinhas.TipoDocumento = TipoDoc;
                                        objLinhas.TipoDeLinha = 1;
                                        objLinhas.Estado = 1;
                                        objLinhas.Ano = (short)DateTime.Parse(DataDoc).Year;
                                        objLinhas.Armazem = Armazem;
                                        objLinhas.Artigo = Artigo;
                                        objLinhas.PrecoUnitario = Preço;
                                        //
                                        objLinhas.Desconto = (aleatorio.Next(0, 99).ToString());
                                        objLinhas.TaxaDesconto = Convert.ToDecimal(objLinhas.Desconto);
                                        //
                                        objLinhas.Quantidade = Quantidade;
                                        objLinhas.Unidade = "UN";
                                        objLinhas.NumeroDaLinha = (short)NrLin;
                                        bool tempRefParam = false;
                                        bool tempRefParam2 = true;
                                        bool tempRefParam3 = true;
                                        bool tempRefParam4 = false;
                                        bool tempRefParam5 = true;
                                        bool tempRefParam6 = true;
                                        bool tempRefParam7 = false;
                                        objDocumento.SugereValoresLin(ref objLinhas, ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6, ref tempRefParam7);
                                        lResult = objDocumento.AdicionaLinha(objLinhas);
                                        if (lResult == 0)
                                        {
                                            if (objArtigos.TemLote != 0)
                                            {
                                                objLotes = System.Activator.CreateInstance(objType_LotesLinha);
                                                objLotes.NumeroLinhaDocComercial = (short)NrLin;
                                                objLotes.QuantidadeMovimentada = Quantidade;
                                                objLotes.campos.CodigoLote = "LT:D" + String.Format("{0:000}", NrDoc) + ":L" + String.Format("{0:000}", NrLin);
                                                objLotes.campos.VossoLote = "LT " + NrDoc.ToString() + "/" + NrLin.ToString();
                                                if (objLotes.campos.VossoLote.Trim() == "")
                                                {
                                                    objLotes.campos.VossoLote = objLotes.campos.CodigoLote;
                                                }
                                                objLotes.campos.DataValidade = DateTime.Today.AddDays(365).ToString("d");
                                                objLotes.campos.Artigo = Artigo;
                                                objLotes.campos.Armazem = Armazem;
                                                objDocumento.AdicionaLote(objLotes);
                                                objLotes = null;
                                            }
                                            else if (objArtigos.TemNumeroSerie != 0)
                                            {
                                                objNumser = System.Activator.CreateInstance(objType_NumSerieLinha);
                                                objNumser.NumeroLinhaDocComercial = (short)NrLin;
                                                objNumser.campos.Artigo = Artigo;
                                                objNumser.campos.Armazem = Armazem;
                                                objNumser.campos.Noserie = "SN" + String.Format("{0:0000}{1:0000}{2:0000}", NrDoc, NrLin, NrDoc);
                                                objNumser.TipoDeLinha = 1;
                                                objDocumento.AdicionaNumeroSerie(objNumser);
                                                objNumser = null;
                                            }
                                        }
                                    }
                                    Application.DoEvents();
                                }


                                FileSystem.FileClose(numeroFicheiro);
                                GerarDocumentos_BlockAll(false);
                                objDocumento = null;
                                objLinhas = null;
                                objNumser = null;
                                objLotes = null;
                                objArtigos = null;
                                if (VectorArtigos != null)
                                {
                                    Array.Clear(VectorArtigos, 0, VectorArtigos.Length);
                                    VectorArtigos = null;
                                }

                                if (VectorClientes != null)
                                {
                                    Array.Clear(VectorClientes, 0, VectorClientes.Length);
                                    VectorClientes = null;
                                }

                                if (VectorFornecedores != null)
                                {
                                    Array.Clear(VectorFornecedores, 0, VectorFornecedores.Length);
                                    VectorFornecedores = null;
                                }
                                VectorArtigos = new string[] { String.Empty };
                                VectorClientes = new string[] { String.Empty };
                                VectorFornecedores = new string[] { String.Empty };
                                MessageBox.Show("Processo terminado." + Environment.NewLine + "Ficheiro gerado : " + Environment.NewLine + nomeFicheiro, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            finally
            {

                if (objArtigos != null)
                {
                    Marshal.ReleaseComObject(objArtigos);
                }

                if (objLotes != null)
                {
                    Marshal.ReleaseComObject(objLotes);
                }

                if (objNumser != null)
                {
                    Marshal.ReleaseComObject(objNumser);
                }

                if (objLinhas != null)
                {
                    Marshal.ReleaseComObject(objLinhas);
                }

                if (objDocumento != null)
                {
                    Marshal.ReleaseComObject(objDocumento);
                }

            }

        }
	
        //
        // Load deClientes para Array
        //
        private bool GerarDocumentos_CarregarClientesEmMemoria()
        {
           
            dynamic oEntidade = null;
            try
            {
                oEntidade = null;
                string Codigo = String.Empty;
                bool IsActivo = false;
                bool Segue = false;
                int Indice = 0;

                bool Retorno = false;
                if (mApi.my_api != null)
                {
                    VectorClientes = new string[] { String.Empty };
                   
                    oEntidade = System.Activator.CreateInstance(objType_Clientes);
                    Segue = (oEntidade.NavegarPrimeiro() >= 0);
                    while (Segue)
                    {
                        if (oEntidade.Codigo != null)
                        {
                            Codigo = oEntidade.Codigo;
                            IsActivo = ~oEntidade.INACTI != 0;
                            if (IsActivo)
                            {
                                if (Codigo.Trim().Length > 0)
                                {

                                    System.Array.Resize(ref VectorClientes, Indice + 1);
                                    VectorClientes[Indice] = oEntidade.Codigo;
                                    GerarDocumentos_Report("Cliente: " + oEntidade.Codigo, false);
                                    Indice++;
                                    Retorno = true;
                                }
                            }
                        }
                        Segue = (oEntidade.NavegarProximo() >= 0);
                    }
                    oEntidade = null;
                }
                else
                {
                    fApi.DefInstance.EscreveMsg("Nenhuma empresa aberta.");
                }
                return Retorno;
            }
            finally
            {
                if (oEntidade != null)
                {
                    Marshal.ReleaseComObject(oEntidade);
                }

            }

        }
        //
        // Carregar Tipos de Documento
        //
        private void GerarDocumentos_CarregarTipoDocumentos()
        {
            cmbGDTipoDoc.Items.Clear();
            cmbGDTipoDoc.Items.Insert(0, "ENC");
            cmbGDTipoDoc.Items.Insert(1, "CCF");
            cmbGDTipoDoc.SelectedIndex = 0;
        }

        //
        // Enviar para Report
        //
        public void GerarDocumentos_Report(string Mensagem, bool SendtoFile)
        {

            if (Mensagem.Trim().Length > 0)
            {
                if (SendtoFile)
                {
                    FileSystem.PrintLine(numeroFicheiro, Mensagem);
                }

                if (lstGDDocs.Items.Count > 32700)
                {
                    lstGDDocs.Items.Clear();
                }

                lstGDDocs.Items.Add(Mensagem);
                lstGDDocs.SelectedIndex = lstGDDocs.Items.Count - 1;
                Application.DoEvents();
            }

        }
        //
        // Bloquear Campos
        //
        private void GerarDocumentos_BlockAll(bool ToBlock)
        {
            cmbGDTipoDoc.Enabled = !ToBlock;
            txtGDNumDoc.Enabled = !ToBlock;
            txtGDSerie.Enabled = !ToBlock;
            txtGDSector.Enabled = !ToBlock;
            txtGDDataDoc.Enabled = !ToBlock;
            txtGDLinhasPorDocumento.Enabled = !ToBlock;
            chkCcfToGr.Enabled = !ToBlock;
            cmdGDGerarDocs.Enabled = !ToBlock;
            fraGDDocs.Enabled = !ToBlock;
        }

        //
        // Gerar Documentos de Clientes em BATCH
        //
        private void GerarDocumentos_Clientes()
        {
            dynamic objDocumento = null;
            dynamic objLinhas = null;
            try
            {
                int lResult = 0;
                int TotalClientes = 0;
                int TotalArtigos = 0;
                int TotalLins = 0;
                string TipoDoc = String.Empty;
                string Cliente = String.Empty;
                string Armazem = String.Empty;
                string Serie = String.Empty;
                string Sector = String.Empty;
                string DataDoc = String.Empty;
                int Preço = 0;
                int Quantidade = 0;
                int IVA = 0;
                string Artigo = String.Empty;
                int NrDoc = 0;
                int NrLin = 0;
                Random aleatorio = new Random();

                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();

                if (GerarDocumentos_CarregarArtigosEmMemoria(false))
                {
                    if (GerarDocumentos_CarregarClientesEmMemoria())
                    {
                        if (GerarDocumentos_Clientes_IsTudoOk())
                        {

                            numeroFicheiro = FileSystem.FreeFile();
                            nomeFicheiro = Path.GetDirectoryName(Application.ExecutablePath) + "\\GD_ENC_Geradas.txt";
                            FileSystem.FileOpen(numeroFicheiro, nomeFicheiro, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);


                            lstGDDocs.Items.Clear();
                            TotalClientes = VectorClientes.GetUpperBound(0) + 1;
                            TotalArtigos = VectorArtigos.GetUpperBound(0) + 1;
                            TotalLins = Convert.ToInt32(txtGDLinhasPorDocumento.Text);
                            Cliente = VectorClientes[Convert.ToInt32((float)(aleatorio.Next(0, VectorClientes.GetUpperBound(0))))];

                            TipoDoc = "ENC";
                            NrDoc = Convert.ToInt32(txtGDNumDoc.Text);
                            Serie = txtGDSerie.Text.Trim();
                            Sector = txtGDSector.Text.Trim();
                            DataDoc = txtGDDataDoc.Text.Trim();
                            Armazem = "AR1";
                            IVA = 23;
                            NrLin = 0;
                            GerarDocumentos_BlockAll(true);
                            continuarProcesso = true;

                            objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);

                            while (continuarProcesso)
                            {
                                
                                if (NrLin > TotalLins)
                                {
                                    objDocumento.cab.TipoDocumento = TipoDoc;
                                    objDocumento.cab.NossoNoDocumento = NrDoc;
                                    objDocumento.cab.Serie = Convert.ToInt16(Double.Parse(Serie));
                                    objDocumento.cab.Ano = (short)DateTime.Parse(DataDoc).Year;
                                    objDocumento.cab.Data = DataDoc;
                                    objDocumento.cab.Sector = Sector;
                                    objDocumento.cab.Moeda = "EUR";
                                    objDocumento.cab.Terceiro = Cliente;
                                    objDocumento.cab.DescontoCabecalho = ((decimal)aleatorio.Next(0, 99));
                                    objDocumento.cab.RegimeIva = "NAC";

                                    objDocumento.Origem = Publicas.e_OrigemDocumento.NaoAplicavel;

                                    lResult = objDocumento.Validar();
                                    if (lResult == 0)
                                    {
                                        lResult = objDocumento.Inserir();
                                        if (lResult == 0)
                                        {

                                            GerarDocumentos_Report("Documento de " + TotalLins.ToString() + " linhas gerado : " + TipoDoc + "/" + NrDoc.ToString() + "/" + Serie + "/" + DateTime.Parse(DataDoc).Year.ToString(), true);                                           
                                        }
                                        else
                                        {
                                            GerarDocumentos_Report(objDocumento.UltimaMensagem(), true);
                                        }
                                    }

                                    Application.DoEvents();
                                    NrLin = 1;
                                    NrDoc++;
                                    Cliente = VectorClientes[Convert.ToInt32((float)(aleatorio.Next(0, VectorClientes.GetUpperBound(0))))];

                                    objDocumento = System.Activator.CreateInstance(objType_DocumentoComercial);
                                }

                                NrLin++;
                                Preço = Convert.ToInt32((float)aleatorio.Next(1, 99));
                                Artigo = VectorArtigos[Convert.ToInt32((float)(aleatorio.Next(0, VectorArtigos.GetUpperBound(0))))];
                                Quantidade = Convert.ToInt32((float)aleatorio.Next(1, 99));

                                objLinhas = System.Activator.CreateInstance(objType_DocumentosGcLin);

                                objLinhas.TipoDeLinha = 1;
                                objLinhas.Armazem = Armazem;
                                objLinhas.Artigo = Artigo;
                                objLinhas.PrecoUnitario = Preço;
                                //
                                objLinhas.Desconto = (aleatorio.Next(0, 99).ToString());
                                objLinhas.TaxaDesconto = Convert.ToDecimal(objLinhas.Desconto);
                                //
                                objLinhas.Quantidade = Quantidade;
                                objLinhas.Unidade = "UN";

                                objLinhas.NumeroDaLinha = (short)NrLin;
                                objLinhas.IvaLinhas = IVA;
                                bool tempRefParam = false;
                                bool tempRefParam2 = false;
                                bool tempRefParam3 = true;
                                bool tempRefParam4 = false;
                                bool tempRefParam5 = false;
                                bool tempRefParam6 = false;
                                bool tempRefParam7 = false;
                                objDocumento.SugereValoresLin(ref objLinhas, ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6, ref tempRefParam7);
                               
                                lResult = objDocumento.AdicionaLinha(objLinhas);
                                objLinhas.Ordenacao = objLinhas.NumeroDaLinha;
                                Application.DoEvents();
                            }

                            FileSystem.FileClose(numeroFicheiro);
                            GerarDocumentos_BlockAll(false);
                            objDocumento = null;
                            objLinhas = null;
                            if (VectorArtigos != null)
                            {
                                Array.Clear(VectorArtigos, 0, VectorArtigos.Length);
                                VectorArtigos = null;
                            }
                            if (VectorClientes != null)
                            {
                                Array.Clear(VectorClientes, 0, VectorClientes.Length);
                                VectorArtigos = null;
                            }
                            VectorArtigos = new string[] { String.Empty };
                            VectorClientes = new string[] { String.Empty };
                            MessageBox.Show("Processo terminado." + Environment.NewLine + "Ficheiro gerado : " + Environment.NewLine + nomeFicheiro, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            finally
            {

                if (objLinhas != null)
                {
                    Marshal.ReleaseComObject(objLinhas);
                }

                if (objDocumento != null)
                {
                    Marshal.ReleaseComObject(objDocumento);
                }

            }

        }
        //
        // Validar Gerar Documentos de Fornecedores em BATCH
        //
        private bool GerarDocumentos_Fornecedores_IsTudoOk()
        {

            bool Retorno = false;
            if (cmbGDTipoDoc.Text.Trim().Length > 0)
            {
                if (Convert.ToInt32(txtGDNumDoc.Text) > 0)
                {
                    if (txtGDSerie.Text.Trim().Length > 0)
                    {
                        if (txtGDSector.Text.Trim().Length > 0)
                        {
                            if (Information.IsDate(txtGDDataDoc.Text))
                            {
                                if (Convert.ToInt32((txtGDLinhasPorDocumento.Text)) > 0)
                                {
                                    if (VectorClientes[0].Trim().Length > 0)
                                    {
                                        if (VectorFornecedores[0].Trim().Length > 0)
                                        {
                                            if (VectorArtigos[0].Trim().Length > 0)
                                            {
                                                Retorno = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Não existem artigos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Não existem fornecedores.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não existem clientes.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Número de linhas por documento inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Data inválida.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sector inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Série inválida.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Número do documento inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Tipo de documento inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return Retorno;

        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
