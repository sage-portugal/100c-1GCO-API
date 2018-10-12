using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace ApiSage100cConnect
{
    class Service
    {
        private const string cOptionFile = "ApiService.Ini";
        private const string cUnderscore = "_";
        private const string cDot = ".";
        private const string cWildCard = "*";
        private const string cXmlExtension = "xml";
        private const string cErrExtensiom = "err";
        //
        private const string cIOerrorExtention = "IO.error.txt";
        private const string cAPIerrorExtention = "API.error.txt";
        private const string cAccountingIOerrorExtention = "IO.Accounting.error.txt";
        private const string cAccountingAPIerrorExtention = "API.Accounting.error.txt";
        //
        private static string iApiPercIni;
        private static string iApiPercLog;
        private static string iApiPercXml;
        private static string iApiLogin;
        private static string iApiPwd;
        private static string iApiSigla;


        private static String dynamicApi = "Sage1GCOApi10";

        private static String Base = dynamicApi + ".Base100C";
        private static System.Type objType_my_api = System.Type.GetTypeFromProgID(Base);
        private static dynamic myApi = System.Activator.CreateInstance(objType_my_api);


        // Origem do Documento
        internal enum eOrigemDocumento
        {
            NaoIndicado = 0,
            NaoAplicavel = 1,
            Finalizado = 2,
            Preparacao = 3
        }

        // XML Element Entity
        internal enum eXmlEntity
        {
            UNKNOWN = 0,
            TPDOCUM,
            TPDOC,
            CLIENTE,
            FORNECEDOR,
            ARTIGO
        }


        // Object Entity
        internal enum eObjectEntity
        {
            UnKnown,
            DocumentoComercial,
            DocumentoFinanceiro,
            Clientes,
            Fornecedores,
            Artigos,
            DocumentoContabilistico
        }


        /*
        *
        * Map XML files to object types
        * 
        */
        private static eObjectEntity convertXml2Object(eXmlEntity x)
        {
            eObjectEntity e;

            switch (x)
            {
                case eXmlEntity.TPDOCUM:
                    e = eObjectEntity.DocumentoComercial;
                    break;
                case eXmlEntity.TPDOC:
                    e = eObjectEntity.DocumentoFinanceiro;
                    break;
                case eXmlEntity.CLIENTE:
                    e = eObjectEntity.Clientes;
                    break;
                case eXmlEntity.FORNECEDOR:
                    e = eObjectEntity.Fornecedores;
                    break;
                case eXmlEntity.ARTIGO:
                    e = eObjectEntity.Artigos;
                    break;
                default:
                    e = eObjectEntity.UnKnown;
                    break;
            }
            return e;
        }

        /*
        *
        * integrate XML files
        * 
        */
        private static void integrateXML()
        {

            if (myApi.AbreEmpresa == false)
            {
                return;
            }

             // No files, bad luck
            while (true)
            {

                // Get list of XML files
                IEnumerable<string> fileList = Directory.EnumerateFiles(@iApiPercXml, cWildCard + cDot + cXmlExtension, SearchOption.TopDirectoryOnly);

                if (fileList.Count() == 0)
                {
                    break;
                }

                // Call EnumerateFiles in a foreach-loop.
                foreach (string file in fileList)
                {

                    String fileAbsoluteName = Path.GetFileNameWithoutExtension(file);

                    if (fileAbsoluteName.Substring(0, 1).Equals(cUnderscore))
                    {
                        continue;
                    }

                    eXmlEntity type = identifyXML(file);

                    System.Threading.Thread.Sleep(1000);

                    // XML file type
                    switch (type)
                    {
                        case eXmlEntity.TPDOCUM:
                        case eXmlEntity.TPDOC:
                            insertDocuments(file, fileAbsoluteName, convertXml2Object(type));
                            break;

                        case eXmlEntity.CLIENTE:
                        case eXmlEntity.FORNECEDOR:
                        case eXmlEntity.ARTIGO:
                            insertEntity(file, fileAbsoluteName, convertXml2Object(type));
                            break;

                        default:
                            continue;

                    }

                }

            }
        }

        private static void insertDocuments(string file, string qualXml, eObjectEntity entidade)
        {

            System.Type objType_Document = System.Type.GetTypeFromProgID(dynamicApi + cDot + entidade.ToString());
            System.Type objType_Accounting = System.Type.GetTypeFromProgID(dynamicApi + cDot + eObjectEntity.DocumentoContabilistico.ToString());


            dynamic objDocumento = null;
            dynamic objContabDoc = null;


            try
            {

                //  Criação de um novo documento
                objDocumento = System.Activator.CreateInstance(objType_Document);

                //objDocumento.Origem = eOrigemDocumento.Finalizado;

                if (objDocumento.Ler("", 0, 0, 0, file) == 0)
                {

                    //   *;
                    //   * -----------------------------------------------------------------------------------------------;
                    //   * Validar & Inserir;
                    //   * -----------------------------------------------------------------------------------------------;
                    //   *;
                    if (objDocumento.Validar == 0 && objDocumento.Inserir == 0)
                    {

                        System.Threading.Thread.Sleep(1000);

                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Ligação a Contabiliade;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;
                        try
                        {
                            objContabDoc = System.Activator.CreateInstance(objType_Accounting);
                            objContabDoc.DocumentoComercial(ref objDocumento);
                            if (!(objContabDoc.Validar() == 0 && objContabDoc.Inserir() == 0))
                            {
                                //   *;
                                //   * -----------------------------------------------------------------------------------------------;
                                //   * Error Report;
                                //   * -----------------------------------------------------------------------------------------------;
                                //   *;

                                System.IO.File.WriteAllText(@iApiPercXml + qualXml + cDot + cAccountingAPIerrorExtention, objContabDoc.UltimaMensagem);


                            }
                            objContabDoc = null;
                        }
                        catch (Exception e)
                        {
                            System.IO.File.WriteAllText(@iApiPercXml + qualXml + cDot + cAccountingAPIerrorExtention, e.Message);

                        }
                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Apagar;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;
                        File.Delete(file);

                    }
                    else
                    {

                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Error Report;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;
                        System.IO.File.WriteAllText(@iApiPercXml + qualXml + cDot + cAPIerrorExtention, objDocumento.UltimaMensagem);

                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Renomear;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;

                        System.IO.File.Move(file, iApiPercXml + cUnderscore + qualXml + cDot + cErrExtensiom);

                    }

                    objDocumento = null;
                }
            }
            catch (Exception e)
            {
                System.IO.File.WriteAllText(@iApiPercXml + qualXml + cDot + cIOerrorExtention, e.Message);

            }
        }

        private static void insertEntity(string file, string qualXml, eObjectEntity entidade)
        {

            System.Type objType = System.Type.GetTypeFromProgID(dynamicApi + cDot + entidade.ToString());

            dynamic objEntity = null;

            try
            {

                //  Criação de uma nova entidade
                objEntity = System.Activator.CreateInstance(objType);

                if (objEntity.Ler("", file) == 0)
                {

                    //   *;
                    //   * -----------------------------------------------------------------------------------------------;
                    //   * Validar & Inserir;
                    //   * -----------------------------------------------------------------------------------------------;
                    //   *;
                    if (objEntity.Validar == 0 && objEntity.Inserir == 0)
                    {
                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Apagar;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;
                        File.Delete(file);

                    }
                    else
                    {

                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Error Report;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;
                        System.IO.File.WriteAllText(@iApiPercXml + qualXml + cDot + cAPIerrorExtention, objEntity.UltimaMensagem);

                        //   *;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   * Renomear;
                        //   * -----------------------------------------------------------------------------------------------;
                        //   *;

                        System.IO.File.Move(file, iApiPercXml + cUnderscore + qualXml + cDot + cErrExtensiom);

                    }

                    objEntity = null;
                }
            }
            catch (Exception e)
            {
                System.IO.File.WriteAllText(@iApiPercXml + qualXml + cDot + cIOerrorExtention, e.Message);

            }
        }


        /*
        *
        * Test Document Entity Type
        * 
        */
        private static eXmlEntity identifyXML(string filename)
        {

            eXmlEntity type = eXmlEntity.UNKNOWN;
            XmlNodeList xmlNode;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            foreach (eXmlEntity entidade in Enum.GetValues(typeof(eXmlEntity)))
            {
                if (entidade.Equals(eXmlEntity.UNKNOWN))
                {
                    continue;
                }

                xmlNode = xmlDoc.GetElementsByTagName(entidade.ToString());
                if (xmlNode.Count != 0)
                {
                    type = entidade;
                    break;
                }
            }

            xmlDoc = null;
            xmlNode = null;
            GC.Collect();               // force garbage collerctor
            return type;


        }


        /*
        *
        * Main cycle
        * 
        */
        private static void Main()
        {

            loadDefaultValues();

            loadConfiguration();

            startApi();

            integrateXML();

            stopApi();

        }


        /*
        *
        * Stop API
        * 
        */
        private static void stopApi()
        {

            if (myApi.AbreEmpresa == true)
            {
                // Termina connection
                myApi.Terminar();
            }

            // Destruir Objeto
            Marshal.ReleaseComObject(myApi);

            Environment.Exit(0);

        }

        /*
        *
        * Start API
        * 
        */
        private static void startApi()
        {
            long lResult;

            if (myApi.AbreEmpresa == false)
            {

                myApi.PercLOG = iApiPercLog;
                myApi.PercIni = iApiPercIni;
                myApi.Empresa = iApiSigla;
                myApi.Login = iApiLogin;
                myApi.Password = iApiPwd;

                lResult = myApi.Iniciar();

                if (lResult != 0)
                {
                    myApi.AbreEmpresa = false;
                }
            }
        }


        /*
         *
         * Load default configuration
         * 
         */
        private static void loadDefaultValues()
        {

            iApiPercIni = "C:\\ProgramData\\Sage\\2070\\100C\\";
            iApiPercLog = "C:\\Temp\\";
            iApiPercXml = "C:\\Sage Data\\Sage 100c\\Documento\\";
            iApiLogin = "API";
            iApiPwd = "API";
            iApiSigla = "DEMO_1GCO";
        }

        /*
         * Load configuration file
         * 
         */
        private static void loadConfiguration()
        {

            int middlePos;
            string location;
            string itemToken;
            string itemValue;


            location = Directory.GetCurrentDirectory() + "\\" + cOptionFile;


            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            try
            {

                string[] lines = System.IO.File.ReadAllLines(@location);

                foreach (string line in lines)
                {

                    middlePos = line.IndexOf("=");
                    if (middlePos != -1)
                    {

                        itemValue = line.Substring(middlePos + 1, line.Length - middlePos - 1).ToUpper().Trim();
                        itemToken = line.Substring(0, middlePos).Trim().ToUpper();

                        switch (itemToken)
                        {

                            case "PERCINI":
                                iApiPercIni = itemValue;
                                break;

                            case "PERCLOG":
                                iApiPercLog = itemValue;
                                break;

                            case "PERCXML":
                                iApiPercXml = itemValue;
                                break;

                            case "LOGIN":
                                iApiLogin = itemValue;
                                break;

                            case "PWD":
                                iApiPwd = itemValue;
                                break;

                            case "SIGLA":
                                iApiSigla = itemValue;
                                break;

                            default:
                                break;
                        }

                    }

                }

            }
            catch (Exception e)
            {
                System.IO.File.WriteAllText(@iApiPercXml + "ConfigIOerror.txt", e.Message);
            }
        }
    }





}






















