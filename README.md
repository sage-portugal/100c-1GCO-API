# Exemplo de utilização da API Sage 100c/1GCO

Aplicação Windows Forms em C# que demonstra a utilização da API COM do Sage 100c/1GCO. O projeto permite abrir uma empresa Sage e executar exemplos de manutenção de entidades, criação e alteração de documentos e outras operações disponibilizadas pela API.

> Este repositório contém código de exemplo. Confirme sempre os dados e os efeitos de cada operação num ambiente de demonstração antes de os adaptar a uma instalação de produção.

## Funcionalidades demonstradas

Depois de estabelecer a ligação à empresa, a aplicação disponibiliza exemplos para:

- criar, consultar, alterar e remover artigos;
- criar, consultar, alterar e remover clientes e fornecedores;
- gerir unidades e contas do plano de contas;
- criar, alterar, remover e imprimir documentos comerciais;
- criar, alterar e remover recibos;
- criar, alterar e remover documentos contabilísticos;
- converter e gerar documentos em lote para clientes, fornecedores e armazéns;
- inserir documentos e recibos a partir de XML;
- executar exemplos adicionais, como transferências entre armazéns e integração contabilística.

Os formulários foram concebidos como exemplos de integração e não como uma aplicação de gestão completa.

## Requisitos

- Windows;
- Sage 100c/1GCO ou Business compatível instalado e configurado;
- componentes COM utilizados pelo projeto instalados e registados no Windows;
- .NET Framework 4.8 Developer Pack/Targeting Pack;
- Visual Studio com as ferramentas de desenvolvimento para .NET Framework e Windows Forms;
- compilação para a plataforma **x86**.

O projeto utiliza referências COM, incluindo a API Sage, MSXML e componentes visuais usados pelo Sage. Por esse motivo, uma instalação apenas do SDK moderno do .NET não é suficiente para compilar ou executar o exemplo.

## Configuração da API

Ao iniciar, a aplicação lê o ficheiro `Api.ini` no mesmo diretório do executável. O ficheiro deve conter uma única configuração no formato exato `API=valor`, sem espaços em torno do sinal `=`.

Exemplo para a API atualmente selecionada no repositório:

```ini
API=Sage1GCOApi40
```

Valores reconhecidos pelo código:

| Valor | Classe base COM | Dados predefinidos |
| --- | --- | --- |
| `SageBGCOApi10` | `SageBGCOApi10.BaseBusiness` | Sage Business / empresa `DEMO_BGCO` |
| `Sage1GCOApi30` | `Sage1GCOApi30.Base100C` | Sage 100c / empresa `DEMO_1GCO` |
| `Sage1GCOApi40` | `Sage1GCOApi40.Base100C` | Sage 100c / empresa `DEMO_1GCO` |

O repositório inclui um exemplo em `bin/Api.ini`. Se o ficheiro não for copiado automaticamente durante a compilação, copie-o ou crie-o junto de `ApiLaunch.exe` antes de executar a aplicação.

> Os nomes `DEMO_BGCO`, `DEMO_1GCO` e as credenciais `API`/`API` são apenas valores de demonstração definidos no código. Não reutilize estas credenciais em produção.

## Compilar e executar

1. Confirme que o Sage e todos os componentes COM necessários estão instalados e registados na máquina.
2. Abra `ApiLaunch.sln` no Visual Studio.
3. Selecione a configuração `Debug|x86` ou `Release|x86`.
4. Compile a solução.
5. Confirme que existe um `Api.ini` válido no diretório que contém `ApiLaunch.exe`.
6. Execute a aplicação.

A solução é de um projeto Visual Studio clássico e tem como alvo o .NET Framework 4.8. O executável de arranque é a aplicação Windows Forms `ApiLaunchBusiness.fApi`.

## Utilização

Na janela principal são apresentados os dados necessários para abrir a empresa:

- **diretório Sage**: caminho usado pela propriedade `PercIni` da API;
- **diretório de logs**: caminho usado pela propriedade `PercLOG`;
- **empresa**: sigla da empresa a abrir;
- **utilizador** e **palavra-passe**: credenciais da API.

Fluxo recomendado:

1. Reveja e, se necessário, altere os valores apresentados.
2. Selecione **Iniciar API**.
3. Confirme a mensagem de abertura da empresa. Os menus de exemplos ficam disponíveis após uma ligação bem-sucedida.
4. Abra o exemplo pretendido e execute as operações apenas sobre dados adequados ao teste.
5. Selecione **Terminar API** antes de fechar a aplicação, para terminar a ligação à empresa e libertar os recursos COM.

Quando a inicialização falha, a aplicação apresenta o código devolvido pela API e indica que o ficheiro de log deve ser consultado.

## Estrutura do projeto

| Ficheiro ou grupo | Responsabilidade |
| --- | --- |
| `ApiLaunch.csproj` / `ApiLaunch.sln` | Projeto Windows Forms e configurações de compilação x86 |
| `fApi.cs` | Arranque, configuração da ligação, abertura e fecho da empresa e acesso aos exemplos |
| `Publicas.cs` | Seleção dinâmica da API, criação do objeto COM base e valores de inicialização |
| `fArtigos.cs`, `fClientes.cs`, `fFornecedores.cs`, `fUnidades.cs` | Exemplos de manutenção de entidades |
| `fPlanoContas.cs` | Exemplo de manutenção do plano de contas |
| `fDocumentoComercial.cs`, `fDocumentoRecibo.cs`, `fDocumentoContabilidade.cs` | Exemplos de documentos comerciais, financeiros e contabilísticos |
| `fGerarDocumentos.cs` | Geração de documentos em lote |
| `fOutrosExemplos.cs` | XML, transferências de armazém e outros cenários de integração |

As classes Sage são instanciadas através de identificadores COM (`ProgID`) e usadas como objetos `dynamic`. A API selecionada no `Api.ini` determina os nomes das classes COM usados em tempo de execução. Consequentemente, erros de nome ou componentes não registados podem ocorrer antes de a janela principal conseguir estabelecer a ligação.

## Integrador XML legado

`Program.cs` e `Help.txt` descrevem um segundo fluxo: um integrador que lê ficheiros XML de um diretório, identifica a entidade ou documento, tenta inseri-lo através da API e remove ou renomeia o ficheiro conforme o resultado.

Este integrador **não faz parte do executável Windows Forms atual**: `Program.cs` e `Help.txt` não estão incluídos em `ApiLaunch.csproj`. O seu ficheiro de configuração, `ApiService.Ini`, também é diferente do `Api.ini` usado pela aplicação principal. Estes ficheiros devem ser considerados código e documentação legados de referência, a menos que sejam integrados explicitamente noutro projeto.

## Resolução de problemas

### Erro ao abrir `Api.ini`

Confirme que o ficheiro se chama exatamente `Api.ini`, está no mesmo diretório de `ApiLaunch.exe` e contém uma opção suportada sem espaços, por exemplo `API=Sage1GCOApi40`.

### Classe COM não registada ou objeto COM indisponível

Confirme que a versão Sage correspondente ao valor do `Api.ini` está instalada e que os respetivos componentes COM estão registados. O valor configurado deve corresponder à versão efetivamente disponível na máquina.

### Erros de compilação nas referências COM

Abra o projeto numa máquina com os componentes Sage e restantes bibliotecas COM instalados. Confirme também a instalação do .NET Framework 4.8 Developer Pack e das ferramentas Windows Forms do Visual Studio.

### Incompatibilidade de arquitetura

Utilize `Debug|x86` ou `Release|x86`. O projeto e as referências COM foram configurados para 32 bits; a alteração para `Any CPU` ou x64 pode impedir a criação dos objetos COM.

### Não é possível abrir a empresa

Verifique o diretório Sage, o diretório de logs, a sigla da empresa e as credenciais apresentadas na janela principal. Consulte o ficheiro de log criado no diretório configurado para obter a mensagem detalhada da API.

### Os menus de exemplos estão desativados

Os menus permanecem desativados até a API devolver sucesso ao abrir a empresa. Corrija primeiro a configuração ou o erro indicado no log e volte a selecionar **Iniciar API**.

## Segurança e utilização em produção

- Não inclua palavras-passe reais no código-fonte nem no controlo de versões.
- Substitua todos os dados de demonstração por configurações apropriadas ao ambiente.
- Valide permissões, documentos, séries, impostos e efeitos contabilísticos antes de reutilizar os exemplos.
- Teste alterações num ambiente não produtivo e mantenha cópias de segurança adequadas.
