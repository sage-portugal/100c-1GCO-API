using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ApiLaunchBusiness
{
    public partial class fComunicarSerieAF : Form
    {
        private const string ApiSuportada = "Sage1GCOApi40";
        private const string ProgIdComunicacaoSeries = "Sage1GCOApi40.WSComunicacaoSeriesAT";

        public fComunicarSerieAF()
        {
            InitializeComponent();

            txtSerie.Text = "10082026";
            txtTipoDocumentoAplicacao.Text = "FCA";
            txtTipoDocumentoSaft.Text = "FT";
            txtTipoSerie.Text = "A";
            txtMeioProcessamento.Text = "PI";
            numNumeroInicial.Value = 1;
            dtpDataInicio.Value = DateTime.Now;
            cmbTipoEntidade.SelectedItem = "FN";
            txtNifEntidade.Text = "123456789";
        }

        private void cmdComunicar_Click(object sender, EventArgs e)
        {
            string mensagemValidacao = ValidarDados();
            if (!String.IsNullOrEmpty(mensagemValidacao))
            {
                MessageBox.Show(mensagemValidacao, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ApiEstaDisponivel())
            {
                return;
            }

            string serie = txtSerie.Text.Trim().ToUpperInvariant();
            string tipoDocumentoAplicacao = txtTipoDocumentoAplicacao.Text.Trim().ToUpperInvariant();
            string tipoDocumentoSaft = txtTipoDocumentoSaft.Text.Trim().ToUpperInvariant();
            string tipoSerie = txtTipoSerie.Text.Trim().ToUpperInvariant();
            string meioProcessamento = txtMeioProcessamento.Text.Trim().ToUpperInvariant();
            int numeroInicial = Decimal.ToInt32(numNumeroInicial.Value);
            string dataInicio = dtpDataInicio.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            string tipoEntidade = cmbTipoEntidade.Text.Trim().ToUpperInvariant();
            string nifEntidade = txtNifEntidade.Text.Trim();
            string paisEstrangeiro = txtPaisEstrangeiro.Text.Trim().ToUpperInvariant();
            string nomeEstrangeiro = txtNomeEstrangeiro.Text.Trim();

            StringBuilder confirmacao = new StringBuilder();
            confirmacao.AppendLine("Esta operação comunica realmente a série à Autoridade Tributária.");
            confirmacao.AppendLine();
            confirmacao.AppendLine("Série: " + serie);
            confirmacao.AppendLine("Tipo de documento da aplicação: " + tipoDocumentoAplicacao);
            confirmacao.AppendLine("Tipo de documento SAF-T: " + tipoDocumentoSaft);
            confirmacao.AppendLine("Tipo de série: " + tipoSerie);
            confirmacao.AppendLine("Meio de processamento: " + meioProcessamento);
            confirmacao.AppendLine("Número inicial: " + numeroInicial.ToString(CultureInfo.InvariantCulture));
            confirmacao.AppendLine("Data de início: " + dataInicio);
            confirmacao.AppendLine("Tipo de entidade: " + tipoEntidade);
            confirmacao.AppendLine("NIF/identificação fiscal: " + nifEntidade);
            confirmacao.AppendLine("País estrangeiro: " + ValorOuVazio(paisEstrangeiro));
            confirmacao.AppendLine("Nome estrangeiro: " + ValorOuVazio(nomeEstrangeiro));
            confirmacao.AppendLine();
            confirmacao.Append("Pretende continuar?");

            if (MessageBox.Show(confirmacao.ToString(), "Confirmar comunicação à AT", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            ComunicarSerie(tipoDocumentoAplicacao, serie, tipoDocumentoSaft, tipoSerie, meioProcessamento,
                numeroInicial, dataInicio, tipoEntidade, nifEntidade, paisEstrangeiro, nomeEstrangeiro);
        }

        private bool ApiEstaDisponivel()
        {
            if (!String.Equals(Publicas.dynamicSageApiName(), ApiSuportada, StringComparison.Ordinal))
            {
                MessageBox.Show("Este exemplo está disponível apenas para Sage1GCOApi40.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                if (mApi.my_api.AbreEmpresa == false)
                {
                    MessageBox.Show("Nenhuma empresa está aberta. Inicie primeiro a API.", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Não foi possível confirmar o estado da API: " + excep.Message,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private string ValidarDados()
        {
            if (String.IsNullOrWhiteSpace(txtSerie.Text))
                return "Indique a série.";
            if (String.IsNullOrWhiteSpace(txtTipoDocumentoAplicacao.Text))
                return "Indique o tipo de documento da aplicação.";
            if (String.IsNullOrWhiteSpace(txtTipoDocumentoSaft.Text))
                return "Indique o tipo de documento SAF-T.";
            if (String.IsNullOrWhiteSpace(txtTipoSerie.Text))
                return "Indique o tipo de série.";
            if (String.IsNullOrWhiteSpace(txtMeioProcessamento.Text))
                return "Indique o meio de processamento.";
            string meioProcessamento = txtMeioProcessamento.Text.Trim().ToUpperInvariant();
            if (meioProcessamento != "PI" && meioProcessamento != "PF" && meioProcessamento != "OM")
                return "O meio de processamento deve ser PI, PF ou OM.";
            if (numNumeroInicial.Value < 1)
                return "O número inicial deve ser superior a zero.";
            if (cmbTipoEntidade.SelectedIndex < 0)
                return "Selecione o tipo de entidade (FN, FE ou CE).";
            if (String.IsNullOrWhiteSpace(txtNifEntidade.Text))
                return "Indique o NIF ou a identificação fiscal da entidade.";

            string tipoEntidade = cmbTipoEntidade.Text.Trim().ToUpperInvariant();
            if (tipoEntidade == "FN" && !NifPortuguesValido(txtNifEntidade.Text.Trim()))
                return "O NIF nacional deve conter nove algarismos e um dígito de controlo válido.";

            if ((tipoEntidade == "FE" || tipoEntidade == "CE") &&
                (String.IsNullOrWhiteSpace(txtPaisEstrangeiro.Text) ||
                 String.IsNullOrWhiteSpace(txtNomeEstrangeiro.Text)))
            {
                return "Para entidades estrangeiras, indique o país ISO alpha-2 e o nome da entidade.";
            }

            string pais = txtPaisEstrangeiro.Text.Trim();
            if (!String.IsNullOrEmpty(pais) &&
                (pais.Length != 2 || !Char.IsLetter(pais[0]) || !Char.IsLetter(pais[1])))
            {
                return "O país estrangeiro deve conter duas letras (código ISO alpha-2).";
            }

            return String.Empty;
        }

        private static bool NifPortuguesValido(string nif)
        {
            if (nif.Length != 9)
                return false;

            bool todosIguais = true;
            int soma = 0;
            for (int indice = 0; indice < nif.Length; indice++)
            {
                if (!Char.IsDigit(nif[indice]))
                    return false;

                if (indice > 0 && nif[indice] != nif[0])
                    todosIguais = false;

                if (indice < 8)
                    soma += (nif[indice] - '0') * (9 - indice);
            }

            if (todosIguais)
                return false;

            int digitoControlo = 11 - (soma % 11);
            if (digitoControlo >= 10)
                digitoControlo = 0;

            return digitoControlo == nif[8] - '0';
        }

        private void ComunicarSerie(string tipoDocumentoAplicacao, string serie, string tipoDocumentoSaft,
            string tipoSerie, string meioProcessamento, int numeroInicial, string dataInicio,
            string tipoEntidade, string nifEntidade, string paisEstrangeiro, string nomeEstrangeiro)
        {
            dynamic comunicacao = null;
            cmdComunicar.Enabled = false;
            UseWaitCursor = true;
            txtResultado.Text = "A aguardar resposta do serviço da AT...";
            Refresh();

            try
            {
                Type tipoComunicacao = Type.GetTypeFromProgID(ProgIdComunicacaoSeries);
                if (tipoComunicacao == null)
                    throw new COMException("A classe COM " + ProgIdComunicacaoSeries + " não está registada.");

                comunicacao = Activator.CreateInstance(tipoComunicacao);
                bool resultado = Convert.ToBoolean(comunicacao.WSComunicarSerieAF_ExternalAPI(
                    tipoDocumentoAplicacao,
                    serie,
                    tipoDocumentoSaft,
                    tipoSerie,
                    meioProcessamento,
                    numeroInicial,
                    dataInicio,
                    tipoEntidade,
                    nifEntidade,
                    paisEstrangeiro,
                    nomeEstrangeiro));

                string codigoRetorno = Convert.ToString(comunicacao.CodRetornoAT, CultureInfo.InvariantCulture);
                string codigoValidacao = Convert.ToString(comunicacao.CodValidacaoAT, CultureInfo.InvariantCulture);
                string mensagemRetorno = Convert.ToString(comunicacao.MsgRetornoAT, CultureInfo.InvariantCulture);

                txtResultado.Text =
                    "Resultado Boolean: " + resultado.ToString() + Environment.NewLine +
                    "Código de retorno AT: " + ValorOuVazio(codigoRetorno) + Environment.NewLine +
                    "Código de validação AT: " + ValorOuVazio(codigoValidacao) + Environment.NewLine +
                    "Mensagem da AT: " + ValorOuVazio(mensagemRetorno);

                string mensagemConclusao = "A chamada terminou. Confirme o código e a mensagem devolvidos pela AT.";
                if (!resultado && (!String.IsNullOrEmpty(codigoRetorno) ||
                                   !String.IsNullOrEmpty(codigoValidacao) ||
                                   !String.IsNullOrEmpty(mensagemRetorno)))
                {
                    mensagemConclusao += Environment.NewLine + Environment.NewLine +
                        "Foi recebida informação da AT, mas o resultado global é False. " +
                        "Consulte os logs, pois a gravação local da série pode ter falhado.";
                }

                MessageBox.Show(mensagemConclusao,
                    Application.ProductName, MessageBoxButtons.OK,
                    resultado ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception excep)
            {
                txtResultado.Text = "A chamada não foi concluída." + Environment.NewLine +
                    excep.GetType().Name + ": " + excep.Message;
                MessageBox.Show("Erro ao comunicar a série à AT: " + excep.Message +
                    Environment.NewLine + Environment.NewLine +
                    "Confirme a instalação da API, as credenciais WSE e a ligação ao serviço.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (comunicacao != null && Marshal.IsComObject(comunicacao))
                    Marshal.ReleaseComObject(comunicacao);

                comunicacao = null;
                UseWaitCursor = false;
                cmdComunicar.Enabled = true;
            }
        }

        private static string ValorOuVazio(string valor)
        {
            return String.IsNullOrEmpty(valor) ? "(vazio)" : valor;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
