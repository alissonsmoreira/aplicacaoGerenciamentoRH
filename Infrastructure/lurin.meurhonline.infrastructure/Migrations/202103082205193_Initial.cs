namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlteracaoCadastral",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        CEP = c.String(),
                        UF = c.String(),
                        Cidade = c.String(),
                        Pais = c.String(),
                        Telefone1 = c.String(),
                        Telefone2 = c.String(),
                        Telefone3 = c.String(),
                        Email = c.String(),
                        CategoriaHabilitacao = c.String(),
                        DataVencimentoHabilitacao = c.DateTime(),
                        BancoId = c.Int(),
                        Agencia = c.String(),
                        Conta = c.String(),
                        ContaBancariaTipoId = c.Int(),
                        FotoNome = c.String(),
                        CarteiraHabilitacaoNome = c.String(),
                        ComprovanteResidenciaNome = c.String(),
                        SolicitacaoStatusId = c.Int(nullable: false),
                        DataSolicitacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banco", t => t.BancoId)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.ContaBancariaTipo", t => t.ContaBancariaTipoId)
                .Index(t => t.ColaboradorId)
                .Index(t => t.BancoId)
                .Index(t => t.ContaBancariaTipoId);
            
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colaborador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        ColaboradorTipoId = c.Int(nullable: false),
                        Sexo = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        CEP = c.String(),
                        UF = c.String(),
                        Cidade = c.String(),
                        FotoNome = c.String(),
                        DataNascimento = c.DateTime(),
                        Telefone1 = c.String(),
                        Telefone2 = c.String(),
                        Telefone3 = c.String(),
                        Email = c.String(nullable: false),
                        NomePai = c.String(),
                        NomeMae = c.String(),
                        MatriculaInterna = c.String(),
                        MatriculaeSocial = c.String(),
                        PaisNascimento = c.String(),
                        UFNascimento = c.String(),
                        CidadeNascimento = c.String(),
                        GrauInstrucaoId = c.Int(),
                        EstadoCivilId = c.Int(),
                        ColaboradorStatusId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ColaboradorTipo", t => t.ColaboradorTipoId, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoCivil", t => t.EstadoCivilId)
                .ForeignKey("dbo.GrauInstrucao", t => t.GrauInstrucaoId)
                .Index(t => t.EmpresaId)
                .Index(t => t.ColaboradorTipoId)
                .Index(t => t.GrauInstrucaoId)
                .Index(t => t.EstadoCivilId);
            
            CreateTable(
                "dbo.ColaboradorTipo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CNPJ = c.String(nullable: false),
                        InscricaoEstadual = c.String(),
                        InscricaoMunicipal = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Bairro = c.String(),
                        CEP = c.String(),
                        UF = c.String(),
                        Cidade = c.String(),
                        TelefoneContato1 = c.String(),
                        EmailContato1 = c.String(),
                        TelefoneContato2 = c.String(),
                        EmailContato2 = c.String(),
                        TelefoneContato3 = c.String(),
                        EmailContato3 = c.String(),
                        EmpresaTipoId = c.Int(nullable: false),
                        EmpresaMatrizId = c.Int(),
                        EmpresaStatusId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmpresaTipo", t => t.EmpresaTipoId, cascadeDelete: true)
                .Index(t => t.EmpresaTipoId);
            
            CreateTable(
                "dbo.EmpresaDocumentoAdmissional",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false),
                        DocumentoAdmissionalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaId, t.DocumentoAdmissionalId })
                .ForeignKey("dbo.DocumentoAdmissional", t => t.DocumentoAdmissionalId, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId)
                .Index(t => t.DocumentoAdmissionalId);
            
            CreateTable(
                "dbo.DocumentoAdmissional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpresaEmpresaFuncionalidade",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false),
                        EmpresaFuncionalidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaId, t.EmpresaFuncionalidadeId })
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.EmpresaFuncionalidade", t => t.EmpresaFuncionalidadeId, cascadeDelete: true)
                .Index(t => t.EmpresaId)
                .Index(t => t.EmpresaFuncionalidadeId);
            
            CreateTable(
                "dbo.EmpresaFuncionalidade",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Grupo = c.String(nullable: false),
                        TipoFuncionario = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpresaTipo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstadoCivil",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrauInstrucao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContaBancariaTipo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atestado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        DataAtestado = c.DateTime(nullable: false),
                        HorarioChegada = c.String(nullable: false),
                        HorarioSaida = c.String(nullable: false),
                        QuantidadeDias = c.Int(nullable: false),
                        CID = c.String(),
                        AtestadoNome = c.String(),
                        LancamentoStatusId = c.Int(nullable: false),
                        DataLancamento = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.AvisoFerias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        Estabelecimento = c.String(),
                        CPF = c.String(),
                        Nome = c.String(),
                        Texto = c.String(),
                        LocalData = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.AvisoFeriasLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        LogErro = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Beneficio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        RegraDesconto = c.String(nullable: false),
                        CustoBeneficio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BeneficioTipoId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeneficioTipo", t => t.BeneficioTipoId, cascadeDelete: true)
                .Index(t => t.BeneficioTipoId);
            
            CreateTable(
                "dbo.BeneficioTipo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BeneficioColaborador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        BeneficioId = c.Int(nullable: false),
                        SolicitacaoStatusId = c.Int(nullable: false),
                        DataSolicitacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beneficio", t => t.BeneficioId, cascadeDelete: true)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId)
                .Index(t => t.BeneficioId);
            
            CreateTable(
                "dbo.CargoPlano",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.CargoPlanoUnidade",
                c => new
                    {
                        CargoPlanoId = c.Int(nullable: false),
                        CargoUnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CargoPlanoId, t.CargoUnidadeId })
                .ForeignKey("dbo.CargoPlano", t => t.CargoPlanoId, cascadeDelete: true)
                .ForeignKey("dbo.CargoUnidade", t => t.CargoUnidadeId, cascadeDelete: true)
                .Index(t => t.CargoPlanoId)
                .Index(t => t.CargoUnidadeId);
            
            CreateTable(
                "dbo.CargoUnidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartaoPonto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.CartaoPontoCabecalho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartaoPontoId = c.Int(nullable: false),
                        Estabelecimento = c.String(),
                        Matricula = c.String(),
                        DataInicioPeriodo = c.String(),
                        DataTerminoPeriodo = c.String(),
                        PeriodoBancoHoras = c.String(),
                        HorasPositivas1 = c.String(),
                        HorasNegativas1 = c.String(),
                        SaldoMes1 = c.String(),
                        PeriodoDiaPonte = c.String(),
                        HorasPositivas2 = c.String(),
                        HorasNegativas2 = c.String(),
                        SaldoMes2 = c.String(),
                        CodigoEvento1 = c.String(),
                        DescricaoEvento1 = c.String(),
                        QuantidadeHoras1 = c.String(),
                        HorasPositivasBancoHoras = c.String(),
                        HorasPositivasDiaPonte = c.String(),
                        CodigoEvento2 = c.String(),
                        DescricaoEvento2 = c.String(),
                        QuantidadeHoras2 = c.String(),
                        HorasNegativasBancoHoras = c.String(),
                        HorasNegativasDiaPonte = c.String(),
                        CodigoEvento3 = c.String(),
                        DescricaoEvento3 = c.String(),
                        QuantidadeHoras3 = c.String(),
                        SaldoBancoHoras = c.String(),
                        SaldoDiaPonte = c.String(),
                        CodigoEvento4 = c.String(),
                        DescricaoEvento4 = c.String(),
                        QuantidadeHoras4 = c.String(),
                        HrsPagasBancoHoras = c.String(),
                        HrsPagasDiaPonte = c.String(),
                        CodigoEvento5 = c.String(),
                        DescricaoEvento5 = c.String(),
                        QuantidadeHoras5 = c.String(),
                        HrsDescontadasBancoHoras = c.String(),
                        HrsDescontadasDiaPonte = c.String(),
                        CodigoEvento6 = c.String(),
                        DescricaoEvento6 = c.String(),
                        QuantidadeHoras6 = c.String(),
                        HrsCompensadasBancoHoras = c.String(),
                        HrsCompensadasDiaPonte = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartaoPonto", t => t.CartaoPontoId, cascadeDelete: true)
                .Index(t => t.CartaoPontoId);
            
            CreateTable(
                "dbo.CartaoPontoDetalhe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartaoPontoId = c.Int(nullable: false),
                        Dia = c.String(),
                        DiaSemana = c.String(),
                        NumeroJornada = c.String(),
                        TipoDia = c.String(),
                        Marcacao1 = c.String(),
                        TipoMarcacao1 = c.String(),
                        Marcacao2 = c.String(),
                        TipoMarcacao2 = c.String(),
                        Marcacao3 = c.String(),
                        TipoMarcacao3 = c.String(),
                        Marcacao4 = c.String(),
                        TipoMarcacao4 = c.String(),
                        Marcacao5 = c.String(),
                        TipoMarcacao5 = c.String(),
                        Marcacao6 = c.String(),
                        TipoMarcacao6 = c.String(),
                        Marcacao7 = c.String(),
                        TipoMarcacao7 = c.String(),
                        Marcacao8 = c.String(),
                        TipoMarcacao8 = c.String(),
                        InicioJornada = c.String(),
                        TerminoJornada = c.String(),
                        QuantHoras = c.String(),
                        DescricaoOcorrencia = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartaoPonto", t => t.CartaoPontoId, cascadeDelete: true)
                .Index(t => t.CartaoPontoId);
            
            CreateTable(
                "dbo.CartaoPontoLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false),
                        LogErro = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoriaSalarial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CentroCustoPlano",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.CentroCustoPlanoUnidade",
                c => new
                    {
                        CentroCustoPlanoId = c.Int(nullable: false),
                        CentroCustoUnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CentroCustoPlanoId, t.CentroCustoUnidadeId })
                .ForeignKey("dbo.CentroCustoPlano", t => t.CentroCustoPlanoId, cascadeDelete: true)
                .ForeignKey("dbo.CentroCustoUnidade", t => t.CentroCustoUnidadeId, cascadeDelete: true)
                .Index(t => t.CentroCustoPlanoId)
                .Index(t => t.CentroCustoUnidadeId);
            
            CreateTable(
                "dbo.CentroCustoUnidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UF = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColaboradorDocumentacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        RG = c.String(nullable: false),
                        OrgaoEmissorRG = c.String(),
                        UFEmissaoRG = c.String(),
                        DataEmissaoRG = c.DateTime(),
                        RIC = c.String(),
                        UFEmissaoRIC = c.String(),
                        CidadeEmissaoRIC = c.String(),
                        OrgaoEmissorRIC = c.String(),
                        DataExpedicaoRIC = c.DateTime(),
                        CartaoNacionalSaude = c.String(),
                        NumeroReservista = c.String(),
                        TituloEleitor = c.String(),
                        ZonaEleitoral = c.String(),
                        SecaoEleitoral = c.String(),
                        UFEleitoral = c.String(nullable: false),
                        CidadeEleitoral = c.String(),
                        CarteiraHabilitacao = c.String(),
                        CategoriaHabilitacao = c.String(),
                        DataVencimentoHabilitacao = c.DateTime(),
                        NumeroCTPS = c.String(),
                        SerieCTPS = c.String(),
                        UFCTPS = c.String(),
                        DataEmissaoCTPS = c.DateTime(),
                        PISNITNIS = c.String(),
                        DataEmissaoPISNITNIS = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.ColaboradorDocumentoAdmissional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        DocumentoAdmissionalId = c.Int(nullable: false),
                        DocumentoNome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentoAdmissional", t => t.DocumentoAdmissionalId, cascadeDelete: true)
                .Index(t => t.ColaboradorId)
                .Index(t => t.DocumentoAdmissionalId);
            
            CreateTable(
                "dbo.ColaboradorEmpregador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        CargoUnidadeId = c.Int(nullable: false),
                        CentroCustoUnidadeId = c.Int(nullable: false),
                        LotacaoUnidadeId = c.Int(nullable: false),
                        TipoRegistroId = c.Int(),
                        TipoMaoObraId = c.Int(),
                        UnidadeNegocioId = c.Int(),
                        NumeroCartaoPonto = c.String(),
                        Situacao = c.String(),
                        TurnoId = c.Int(),
                        CategoriaSalarialId = c.Int(),
                        Salario = c.Decimal(precision: 18, scale: 2),
                        DataAdmissao = c.DateTime(),
                        SindicatoId = c.Int(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CargoUnidade", t => t.CargoUnidadeId, cascadeDelete: true)
                .ForeignKey("dbo.CategoriaSalarial", t => t.CategoriaSalarialId)
                .ForeignKey("dbo.CentroCustoUnidade", t => t.CentroCustoUnidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.LotacaoUnidade", t => t.LotacaoUnidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Sindicato", t => t.SindicatoId)
                .ForeignKey("dbo.TipoMaoObra", t => t.TipoMaoObraId)
                .ForeignKey("dbo.TipoRegistro", t => t.TipoRegistroId)
                .ForeignKey("dbo.Turno", t => t.TurnoId)
                .ForeignKey("dbo.UnidadeNegocio", t => t.UnidadeNegocioId)
                .Index(t => t.ColaboradorId)
                .Index(t => t.CargoUnidadeId)
                .Index(t => t.CentroCustoUnidadeId)
                .Index(t => t.LotacaoUnidadeId)
                .Index(t => t.TipoRegistroId)
                .Index(t => t.TipoMaoObraId)
                .Index(t => t.UnidadeNegocioId)
                .Index(t => t.TurnoId)
                .Index(t => t.CategoriaSalarialId)
                .Index(t => t.SindicatoId);
            
            CreateTable(
                "dbo.LotacaoUnidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LotacaoPlanoUnidade",
                c => new
                    {
                        LotacaoPlanoId = c.Int(nullable: false),
                        LotacaoUnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LotacaoPlanoId, t.LotacaoUnidadeId })
                .ForeignKey("dbo.LotacaoPlano", t => t.LotacaoPlanoId, cascadeDelete: true)
                .ForeignKey("dbo.LotacaoUnidade", t => t.LotacaoUnidadeId, cascadeDelete: true)
                .Index(t => t.LotacaoPlanoId)
                .Index(t => t.LotacaoUnidadeId);
            
            CreateTable(
                "dbo.LotacaoPlano",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Sindicato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        DataBase = c.DateTime(nullable: false),
                        Representante = c.String(),
                        TelefoneComercial = c.String(),
                        TelefoneCelular = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoMaoObra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoRegistro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TurnoDetalhe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiaSemana = c.String(nullable: false),
                        HorarioInicial = c.String(nullable: false),
                        HorarioFinal = c.String(nullable: false),
                        TurnoId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Turno", t => t.TurnoId, cascadeDelete: true)
                .Index(t => t.TurnoId);
            
            CreateTable(
                "dbo.UnidadeNegocio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColaboradorEstrangeiro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        Origem = c.String(nullable: false),
                        ColaboradorEstrangeiroTipoVistoId = c.Int(nullable: false),
                        Passaporte = c.String(nullable: false),
                        OrgaoEmissorPassaporte = c.String(),
                        PaisEmissorPassaporte = c.String(),
                        UFPassaporte = c.String(),
                        DataEmissaoPassaporte = c.DateTime(),
                        PortariaNaturalizacao = c.String(),
                        IdentidadeEstrangeira = c.String(),
                        ValidadeIdentidadeEstrangeira = c.String(),
                        AnoChegada = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.ColaboradorEstrangeiroTipoVisto", t => t.ColaboradorEstrangeiroTipoVistoId, cascadeDelete: true)
                .Index(t => t.ColaboradorId)
                .Index(t => t.ColaboradorEstrangeiroTipoVistoId);
            
            CreateTable(
                "dbo.ColaboradorEstrangeiroTipoVisto",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColaboradorPagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        BancoId = c.Int(nullable: false),
                        Agencia = c.String(nullable: false),
                        Conta = c.String(nullable: false),
                        ContaBancariaTipoId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banco", t => t.BancoId, cascadeDelete: true)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.ContaBancariaTipo", t => t.ContaBancariaTipoId, cascadeDelete: true)
                .Index(t => t.ColaboradorId)
                .Index(t => t.BancoId)
                .Index(t => t.ContaBancariaTipoId);
            
            CreateTable(
                "dbo.Dependente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Sexo = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        NomeMae = c.String(nullable: false),
                        GrauDependencia = c.String(nullable: false),
                        DocumentoNome = c.String(),
                        ColaboradorId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Desligamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GestorId = c.Int(nullable: false),
                        ColaboradorId = c.Int(nullable: false),
                        DataSugerida = c.DateTime(nullable: false),
                        DesligamentoTipoId = c.Int(nullable: false),
                        Motivo = c.String(nullable: false),
                        Substituir = c.Boolean(nullable: false),
                        Recontrataria = c.Boolean(nullable: false),
                        SolicitacaoStatusId = c.Int(nullable: false),
                        DataSolicitacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DesligamentoTipo", t => t.DesligamentoTipoId, cascadeDelete: true)
                .Index(t => t.DesligamentoTipoId);
            
            CreateTable(
                "dbo.DesligamentoTipo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Divergencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estabelecimento = c.String(nullable: false),
                        Matricula = c.String(),
                        Nome = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DivergenciaDetalhe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiaSemana = c.String(),
                        Dia = c.String(),
                        Horario1 = c.String(),
                        Horario2 = c.String(),
                        Horario3 = c.String(),
                        Horario4 = c.String(),
                        InicioJornada = c.String(),
                        FimJornada = c.String(),
                        DiferencaHoras = c.String(),
                        Descricao = c.String(),
                        DivergenciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divergencia", t => t.DivergenciaId, cascadeDelete: true)
                .Index(t => t.DivergenciaId);
            
            CreateTable(
                "dbo.DivergenciaLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false),
                        LogErro = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipeGestor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        LotacaoUnidadeInicialId = c.Int(nullable: false),
                        LotacaoUnidadeFinalId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.Ferias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estabelecimento = c.String(nullable: false),
                        Matricula = c.String(nullable: false),
                        Nome = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeriasPeriodo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InicioPeriodo = c.String(nullable: false),
                        FimPeriodo = c.String(),
                        Situacao = c.String(),
                        DiasDireito = c.String(),
                        DiasConcedidos = c.String(),
                        DiasProgramados = c.String(),
                        FeriasId = c.Int(nullable: false),
                        Saldo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ferias", t => t.FeriasId, cascadeDelete: true)
                .Index(t => t.FeriasId);
            
            CreateTable(
                "dbo.FeriasConcessao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InicioFerias = c.String(),
                        DiasGozo = c.String(),
                        DiasAbono = c.String(),
                        DiasLicenca = c.String(),
                        FeriasPeriodoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeriasPeriodo", t => t.FeriasPeriodoId, cascadeDelete: true)
                .Index(t => t.FeriasPeriodoId);
            
            CreateTable(
                "dbo.FeriasLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        LogErro = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Holerite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        Matricula = c.String(),
                        Nome = c.String(),
                        TotalProventos = c.String(),
                        TotalDescontos = c.String(),
                        Liquido = c.String(),
                        SalarioBase = c.String(),
                        SalarioContrINSS = c.String(),
                        BaseCalcFGTS = c.String(),
                        FTGSMes = c.String(),
                        BaseCalcIRRF = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
            CreateTable(
                "dbo.HoleriteEvento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoleriteId = c.Int(nullable: false),
                        Evento = c.String(),
                        Descricao = c.String(),
                        Quantidade = c.String(),
                        ValoresPositivos = c.String(),
                        ValoresNegativos = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Holerite", t => t.HoleriteId, cascadeDelete: true)
                .Index(t => t.HoleriteId);
            
            CreateTable(
                "dbo.HoleriteLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        LogErro = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InformeRendimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ministerio = c.String(nullable: false),
                        TipoDocumento = c.String(nullable: false),
                        Secretaria = c.String(nullable: false),
                        Documento = c.String(nullable: false),
                        Exercicio = c.String(nullable: false),
                        AnoCalendario = c.String(nullable: false),
                        FontePagadora = c.String(nullable: false),
                        Empresa = c.String(nullable: false),
                        CNPJ = c.String(nullable: false),
                        DadosPessoaFisica = c.String(nullable: false),
                        DescricaoCPF = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        DescricaoNome = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        DescricaoNatureza = c.String(nullable: false),
                        Natureza = c.String(nullable: false),
                        TipoRendimento1 = c.String(nullable: false),
                        MoedaRendimento1 = c.String(nullable: false),
                        TipoRendimento2 = c.String(nullable: false),
                        MoedaRendimento2 = c.String(nullable: false),
                        TipoRendimento3 = c.String(nullable: false),
                        MoedaRendimento3 = c.String(nullable: false),
                        TipoRendimento4 = c.String(nullable: false),
                        MoedaRendimento4 = c.String(),
                        Processo = c.String(),
                        NaturezaRendimento = c.String(),
                        InformacoesComplementares = c.String(),
                        DadosResponsavel = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoRendimentoIsentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescricaoTipoEvento = c.String(nullable: false),
                        Valor = c.String(nullable: false),
                        InformeRendimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformeRendimento", t => t.InformeRendimentoId, cascadeDelete: true)
                .Index(t => t.InformeRendimentoId);
            
            CreateTable(
                "dbo.TipoRendimentoReceb",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescricaoTipoEvento = c.String(nullable: false),
                        Valor = c.String(nullable: false),
                        Processo = c.String(),
                        NaturezaRendimento = c.String(),
                        InformeRendimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformeRendimento", t => t.InformeRendimentoId, cascadeDelete: true)
                .Index(t => t.InformeRendimentoId);
            
            CreateTable(
                "dbo.TipoRendimentoSujeitoTrib",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescricaoTipoEvento = c.String(nullable: false),
                        Valor = c.String(nullable: false),
                        InformeRendimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformeRendimento", t => t.InformeRendimentoId, cascadeDelete: true)
                .Index(t => t.InformeRendimentoId);
            
            CreateTable(
                "dbo.TipoRendimentoTributaveis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescricaoTipoEvento = c.String(nullable: false),
                        Valor = c.String(nullable: false),
                        InformeRendimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformeRendimento", t => t.InformeRendimentoId, cascadeDelete: true)
                .Index(t => t.InformeRendimentoId);
            
            CreateTable(
                "dbo.InformeRendimentoLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        LogErro = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JustificativaDivergencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinhaVT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeLinha = c.String(nullable: false),
                        ValorLinha = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperadoraVTId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperadoraVT", t => t.OperadoraVTId, cascadeDelete: true)
                .Index(t => t.OperadoraVTId);
            
            CreateTable(
                "dbo.OperadoraVT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        OperadoraVTBandeiraCartaoId = c.Int(nullable: false),
                        OperadoraVTTarifaTipoId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperadoraVTBandeiraCartao", t => t.OperadoraVTBandeiraCartaoId, cascadeDelete: true)
                .ForeignKey("dbo.OperadoraVTTarifaTipo", t => t.OperadoraVTTarifaTipoId, cascadeDelete: true)
                .Index(t => t.OperadoraVTBandeiraCartaoId)
                .Index(t => t.OperadoraVTTarifaTipoId);
            
            CreateTable(
                "dbo.OperadoraVTBandeiraCartao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperadoraVTTarifaTipo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cpf = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        UsuarioColaboradorId = c.Int(nullable: false),
                        UsuarioColaboradorTipoId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marmitex",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Titulo = c.String(nullable: false),
                        SubTitulo = c.String(nullable: false),
                        SubTituloNivel1 = c.String(),
                        UsuarioPermissao = c.String(nullable: false, maxLength: 1, unicode: false),
                        GestorPermissao = c.String(nullable: false, maxLength: 1, unicode: false),
                        FuncionarioPermissao = c.String(nullable: false, maxLength: 1, unicode: false),
                        Order = c.Int(nullable: false),
                        MenuStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MotivoHoraExtra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Motivo = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovimentacaoContratual",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GestorId = c.Int(nullable: false),
                        ColaboradorId = c.Int(nullable: false),
                        EmpresaId = c.Int(nullable: false),
                        LotacaoUnidadeId = c.Int(nullable: false),
                        CentroCustoUnidadeId = c.Int(nullable: false),
                        CargoUnidadeId = c.Int(nullable: false),
                        TurnoId = c.Int(),
                        UnidadeNegocioId = c.Int(),
                        NumeroCartaoPonto = c.String(),
                        TipoMaoObraId = c.Int(),
                        Salario = c.Decimal(precision: 18, scale: 2),
                        SolicitacaoStatusId = c.Int(nullable: false),
                        DataSolicitacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CargoUnidade", t => t.CargoUnidadeId, cascadeDelete: true)
                .ForeignKey("dbo.CentroCustoUnidade", t => t.CentroCustoUnidadeId, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .ForeignKey("dbo.LotacaoUnidade", t => t.LotacaoUnidadeId, cascadeDelete: true)
                .ForeignKey("dbo.TipoMaoObra", t => t.TipoMaoObraId)
                .ForeignKey("dbo.Turno", t => t.TurnoId)
                .ForeignKey("dbo.UnidadeNegocio", t => t.UnidadeNegocioId)
                .Index(t => t.EmpresaId)
                .Index(t => t.LotacaoUnidadeId)
                .Index(t => t.CentroCustoUnidadeId)
                .Index(t => t.CargoUnidadeId)
                .Index(t => t.TurnoId)
                .Index(t => t.UnidadeNegocioId)
                .Index(t => t.TipoMaoObraId);
            
            CreateTable(
                "dbo.Notificacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificacaoDetalheId = c.Int(nullable: false),
                        NotificacaoStatusLeituraId = c.Int(nullable: false),
                        ById = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotificacaoDetalhe", t => t.NotificacaoDetalheId, cascadeDelete: true)
                .Index(t => t.NotificacaoDetalheId);
            
            CreateTable(
                "dbo.NotificacaoDetalhe",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        API = c.String(nullable: false),
                        MensagemSingular = c.String(nullable: false),
                        MensagemPlural = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReciboFerias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estabelecimento = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Nome = c.String(),
                        InicioPeriodoAquisitivo = c.String(),
                        FImPeriodoAquisitivo = c.String(),
                        InicioPeriodoGozo = c.String(),
                        FimPeriodoGozo = c.String(),
                        DiasGozo = c.String(),
                        InicioPeriodoAbono = c.String(),
                        FimPeriodoAbono = c.String(),
                        InicioPeriodoLicenca = c.String(),
                        FimPeriodoLicenca = c.String(),
                        TotalVencimento = c.String(),
                        TotalDescontos = c.String(),
                        TotalLiquido = c.String(),
                        Texto = c.String(),
                        LocalData = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReciboFeriasDesconto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Evento = c.String(),
                        Descricao = c.String(),
                        BaseCalculo = c.String(),
                        Valor = c.String(),
                        ReciboFeriasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReciboFerias", t => t.ReciboFeriasId, cascadeDelete: true)
                .Index(t => t.ReciboFeriasId);
            
            CreateTable(
                "dbo.ReciboFeriasVencimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Evento = c.String(),
                        Descricao = c.String(),
                        BaseCalculo = c.String(),
                        Valor = c.String(),
                        ReciboFeriasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReciboFerias", t => t.ReciboFeriasId, cascadeDelete: true)
                .Index(t => t.ReciboFeriasId);
            
            CreateTable(
                "dbo.ReciboFeriasLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        LogErro = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UF",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sigla = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Endereco = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        CEP = c.String(),
                        UF = c.String(),
                        Cidade = c.String(),
                        TelefoneResidencial = c.String(),
                        TelefoneCelular = c.String(),
                        TelefoneComercial = c.String(),
                        Email = c.String(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeTransporte",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColaboradorId = c.Int(nullable: false),
                        OperadoraVTId = c.Int(nullable: false),
                        LinhaVTId = c.Int(nullable: false),
                        ValeTransporteUtilizacaoId = c.Int(nullable: false),
                        ValeTransporteSituacaoId = c.Int(nullable: false),
                        SolicitacaoStatusId = c.Int(nullable: false),
                        DataSolicitacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.ValeTransporteSituacao", t => t.ValeTransporteSituacaoId, cascadeDelete: true)
                .ForeignKey("dbo.ValeTransporteUtilizacao", t => t.ValeTransporteUtilizacaoId, cascadeDelete: true)
                .Index(t => t.ColaboradorId)
                .Index(t => t.ValeTransporteUtilizacaoId)
                .Index(t => t.ValeTransporteSituacaoId);
            
            CreateTable(
                "dbo.ValeTransporteSituacao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeTransporteUtilizacao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ValeTransporte", "ValeTransporteUtilizacaoId", "dbo.ValeTransporteUtilizacao");
            DropForeignKey("dbo.ValeTransporte", "ValeTransporteSituacaoId", "dbo.ValeTransporteSituacao");
            DropForeignKey("dbo.ValeTransporte", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.ReciboFeriasVencimento", "ReciboFeriasId", "dbo.ReciboFerias");
            DropForeignKey("dbo.ReciboFeriasDesconto", "ReciboFeriasId", "dbo.ReciboFerias");
            DropForeignKey("dbo.Notificacao", "NotificacaoDetalheId", "dbo.NotificacaoDetalhe");
            DropForeignKey("dbo.MovimentacaoContratual", "UnidadeNegocioId", "dbo.UnidadeNegocio");
            DropForeignKey("dbo.MovimentacaoContratual", "TurnoId", "dbo.Turno");
            DropForeignKey("dbo.MovimentacaoContratual", "TipoMaoObraId", "dbo.TipoMaoObra");
            DropForeignKey("dbo.MovimentacaoContratual", "LotacaoUnidadeId", "dbo.LotacaoUnidade");
            DropForeignKey("dbo.MovimentacaoContratual", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.MovimentacaoContratual", "CentroCustoUnidadeId", "dbo.CentroCustoUnidade");
            DropForeignKey("dbo.MovimentacaoContratual", "CargoUnidadeId", "dbo.CargoUnidade");
            DropForeignKey("dbo.LinhaVT", "OperadoraVTId", "dbo.OperadoraVT");
            DropForeignKey("dbo.OperadoraVT", "OperadoraVTTarifaTipoId", "dbo.OperadoraVTTarifaTipo");
            DropForeignKey("dbo.OperadoraVT", "OperadoraVTBandeiraCartaoId", "dbo.OperadoraVTBandeiraCartao");
            DropForeignKey("dbo.TipoRendimentoTributaveis", "InformeRendimentoId", "dbo.InformeRendimento");
            DropForeignKey("dbo.TipoRendimentoSujeitoTrib", "InformeRendimentoId", "dbo.InformeRendimento");
            DropForeignKey("dbo.TipoRendimentoReceb", "InformeRendimentoId", "dbo.InformeRendimento");
            DropForeignKey("dbo.TipoRendimentoIsentos", "InformeRendimentoId", "dbo.InformeRendimento");
            DropForeignKey("dbo.HoleriteEvento", "HoleriteId", "dbo.Holerite");
            DropForeignKey("dbo.Holerite", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.FeriasPeriodo", "FeriasId", "dbo.Ferias");
            DropForeignKey("dbo.FeriasConcessao", "FeriasPeriodoId", "dbo.FeriasPeriodo");
            DropForeignKey("dbo.EquipeGestor", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.DivergenciaDetalhe", "DivergenciaId", "dbo.Divergencia");
            DropForeignKey("dbo.Desligamento", "DesligamentoTipoId", "dbo.DesligamentoTipo");
            DropForeignKey("dbo.ColaboradorPagamento", "ContaBancariaTipoId", "dbo.ContaBancariaTipo");
            DropForeignKey("dbo.ColaboradorPagamento", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.ColaboradorPagamento", "BancoId", "dbo.Banco");
            DropForeignKey("dbo.ColaboradorEstrangeiro", "ColaboradorEstrangeiroTipoVistoId", "dbo.ColaboradorEstrangeiroTipoVisto");
            DropForeignKey("dbo.ColaboradorEstrangeiro", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.ColaboradorEmpregador", "UnidadeNegocioId", "dbo.UnidadeNegocio");
            DropForeignKey("dbo.ColaboradorEmpregador", "TurnoId", "dbo.Turno");
            DropForeignKey("dbo.TurnoDetalhe", "TurnoId", "dbo.Turno");
            DropForeignKey("dbo.ColaboradorEmpregador", "TipoRegistroId", "dbo.TipoRegistro");
            DropForeignKey("dbo.ColaboradorEmpregador", "TipoMaoObraId", "dbo.TipoMaoObra");
            DropForeignKey("dbo.ColaboradorEmpregador", "SindicatoId", "dbo.Sindicato");
            DropForeignKey("dbo.ColaboradorEmpregador", "LotacaoUnidadeId", "dbo.LotacaoUnidade");
            DropForeignKey("dbo.LotacaoPlanoUnidade", "LotacaoUnidadeId", "dbo.LotacaoUnidade");
            DropForeignKey("dbo.LotacaoPlanoUnidade", "LotacaoPlanoId", "dbo.LotacaoPlano");
            DropForeignKey("dbo.LotacaoPlano", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.ColaboradorEmpregador", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.ColaboradorEmpregador", "CentroCustoUnidadeId", "dbo.CentroCustoUnidade");
            DropForeignKey("dbo.ColaboradorEmpregador", "CategoriaSalarialId", "dbo.CategoriaSalarial");
            DropForeignKey("dbo.ColaboradorEmpregador", "CargoUnidadeId", "dbo.CargoUnidade");
            DropForeignKey("dbo.ColaboradorDocumentoAdmissional", "DocumentoAdmissionalId", "dbo.DocumentoAdmissional");
            DropForeignKey("dbo.ColaboradorDocumentoAdmissional", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.ColaboradorDocumentacao", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.CentroCustoPlano", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.CentroCustoPlanoUnidade", "CentroCustoUnidadeId", "dbo.CentroCustoUnidade");
            DropForeignKey("dbo.CentroCustoPlanoUnidade", "CentroCustoPlanoId", "dbo.CentroCustoPlano");
            DropForeignKey("dbo.CartaoPonto", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.CartaoPontoDetalhe", "CartaoPontoId", "dbo.CartaoPonto");
            DropForeignKey("dbo.CartaoPontoCabecalho", "CartaoPontoId", "dbo.CartaoPonto");
            DropForeignKey("dbo.CargoPlano", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.CargoPlanoUnidade", "CargoUnidadeId", "dbo.CargoUnidade");
            DropForeignKey("dbo.CargoPlanoUnidade", "CargoPlanoId", "dbo.CargoPlano");
            DropForeignKey("dbo.BeneficioColaborador", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.BeneficioColaborador", "BeneficioId", "dbo.Beneficio");
            DropForeignKey("dbo.Beneficio", "BeneficioTipoId", "dbo.BeneficioTipo");
            DropForeignKey("dbo.AvisoFerias", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.Atestado", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.AlteracaoCadastral", "ContaBancariaTipoId", "dbo.ContaBancariaTipo");
            DropForeignKey("dbo.AlteracaoCadastral", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.Colaborador", "GrauInstrucaoId", "dbo.GrauInstrucao");
            DropForeignKey("dbo.Colaborador", "EstadoCivilId", "dbo.EstadoCivil");
            DropForeignKey("dbo.Colaborador", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Empresa", "EmpresaTipoId", "dbo.EmpresaTipo");
            DropForeignKey("dbo.EmpresaEmpresaFuncionalidade", "EmpresaFuncionalidadeId", "dbo.EmpresaFuncionalidade");
            DropForeignKey("dbo.EmpresaEmpresaFuncionalidade", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.EmpresaDocumentoAdmissional", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.EmpresaDocumentoAdmissional", "DocumentoAdmissionalId", "dbo.DocumentoAdmissional");
            DropForeignKey("dbo.Colaborador", "ColaboradorTipoId", "dbo.ColaboradorTipo");
            DropForeignKey("dbo.AlteracaoCadastral", "BancoId", "dbo.Banco");
            DropIndex("dbo.ValeTransporte", new[] { "ValeTransporteSituacaoId" });
            DropIndex("dbo.ValeTransporte", new[] { "ValeTransporteUtilizacaoId" });
            DropIndex("dbo.ValeTransporte", new[] { "ColaboradorId" });
            DropIndex("dbo.ReciboFeriasVencimento", new[] { "ReciboFeriasId" });
            DropIndex("dbo.ReciboFeriasDesconto", new[] { "ReciboFeriasId" });
            DropIndex("dbo.Notificacao", new[] { "NotificacaoDetalheId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "TipoMaoObraId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "UnidadeNegocioId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "TurnoId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "CargoUnidadeId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "CentroCustoUnidadeId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "LotacaoUnidadeId" });
            DropIndex("dbo.MovimentacaoContratual", new[] { "EmpresaId" });
            DropIndex("dbo.OperadoraVT", new[] { "OperadoraVTTarifaTipoId" });
            DropIndex("dbo.OperadoraVT", new[] { "OperadoraVTBandeiraCartaoId" });
            DropIndex("dbo.LinhaVT", new[] { "OperadoraVTId" });
            DropIndex("dbo.TipoRendimentoTributaveis", new[] { "InformeRendimentoId" });
            DropIndex("dbo.TipoRendimentoSujeitoTrib", new[] { "InformeRendimentoId" });
            DropIndex("dbo.TipoRendimentoReceb", new[] { "InformeRendimentoId" });
            DropIndex("dbo.TipoRendimentoIsentos", new[] { "InformeRendimentoId" });
            DropIndex("dbo.HoleriteEvento", new[] { "HoleriteId" });
            DropIndex("dbo.Holerite", new[] { "ColaboradorId" });
            DropIndex("dbo.FeriasConcessao", new[] { "FeriasPeriodoId" });
            DropIndex("dbo.FeriasPeriodo", new[] { "FeriasId" });
            DropIndex("dbo.EquipeGestor", new[] { "ColaboradorId" });
            DropIndex("dbo.DivergenciaDetalhe", new[] { "DivergenciaId" });
            DropIndex("dbo.Desligamento", new[] { "DesligamentoTipoId" });
            DropIndex("dbo.ColaboradorPagamento", new[] { "ContaBancariaTipoId" });
            DropIndex("dbo.ColaboradorPagamento", new[] { "BancoId" });
            DropIndex("dbo.ColaboradorPagamento", new[] { "ColaboradorId" });
            DropIndex("dbo.ColaboradorEstrangeiro", new[] { "ColaboradorEstrangeiroTipoVistoId" });
            DropIndex("dbo.ColaboradorEstrangeiro", new[] { "ColaboradorId" });
            DropIndex("dbo.TurnoDetalhe", new[] { "TurnoId" });
            DropIndex("dbo.LotacaoPlano", new[] { "EmpresaId" });
            DropIndex("dbo.LotacaoPlanoUnidade", new[] { "LotacaoUnidadeId" });
            DropIndex("dbo.LotacaoPlanoUnidade", new[] { "LotacaoPlanoId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "SindicatoId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "CategoriaSalarialId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "TurnoId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "UnidadeNegocioId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "TipoMaoObraId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "TipoRegistroId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "LotacaoUnidadeId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "CentroCustoUnidadeId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "CargoUnidadeId" });
            DropIndex("dbo.ColaboradorEmpregador", new[] { "ColaboradorId" });
            DropIndex("dbo.ColaboradorDocumentoAdmissional", new[] { "DocumentoAdmissionalId" });
            DropIndex("dbo.ColaboradorDocumentoAdmissional", new[] { "ColaboradorId" });
            DropIndex("dbo.ColaboradorDocumentacao", new[] { "ColaboradorId" });
            DropIndex("dbo.CentroCustoPlanoUnidade", new[] { "CentroCustoUnidadeId" });
            DropIndex("dbo.CentroCustoPlanoUnidade", new[] { "CentroCustoPlanoId" });
            DropIndex("dbo.CentroCustoPlano", new[] { "EmpresaId" });
            DropIndex("dbo.CartaoPontoDetalhe", new[] { "CartaoPontoId" });
            DropIndex("dbo.CartaoPontoCabecalho", new[] { "CartaoPontoId" });
            DropIndex("dbo.CartaoPonto", new[] { "ColaboradorId" });
            DropIndex("dbo.CargoPlanoUnidade", new[] { "CargoUnidadeId" });
            DropIndex("dbo.CargoPlanoUnidade", new[] { "CargoPlanoId" });
            DropIndex("dbo.CargoPlano", new[] { "EmpresaId" });
            DropIndex("dbo.BeneficioColaborador", new[] { "BeneficioId" });
            DropIndex("dbo.BeneficioColaborador", new[] { "ColaboradorId" });
            DropIndex("dbo.Beneficio", new[] { "BeneficioTipoId" });
            DropIndex("dbo.AvisoFerias", new[] { "ColaboradorId" });
            DropIndex("dbo.Atestado", new[] { "ColaboradorId" });
            DropIndex("dbo.EmpresaEmpresaFuncionalidade", new[] { "EmpresaFuncionalidadeId" });
            DropIndex("dbo.EmpresaEmpresaFuncionalidade", new[] { "EmpresaId" });
            DropIndex("dbo.EmpresaDocumentoAdmissional", new[] { "DocumentoAdmissionalId" });
            DropIndex("dbo.EmpresaDocumentoAdmissional", new[] { "EmpresaId" });
            DropIndex("dbo.Empresa", new[] { "EmpresaTipoId" });
            DropIndex("dbo.Colaborador", new[] { "EstadoCivilId" });
            DropIndex("dbo.Colaborador", new[] { "GrauInstrucaoId" });
            DropIndex("dbo.Colaborador", new[] { "ColaboradorTipoId" });
            DropIndex("dbo.Colaborador", new[] { "EmpresaId" });
            DropIndex("dbo.AlteracaoCadastral", new[] { "ContaBancariaTipoId" });
            DropIndex("dbo.AlteracaoCadastral", new[] { "BancoId" });
            DropIndex("dbo.AlteracaoCadastral", new[] { "ColaboradorId" });
            DropTable("dbo.ValeTransporteUtilizacao");
            DropTable("dbo.ValeTransporteSituacao");
            DropTable("dbo.ValeTransporte");
            DropTable("dbo.Usuario");
            DropTable("dbo.UF");
            DropTable("dbo.ReciboFeriasLog");
            DropTable("dbo.ReciboFeriasVencimento");
            DropTable("dbo.ReciboFeriasDesconto");
            DropTable("dbo.ReciboFerias");
            DropTable("dbo.NotificacaoDetalhe");
            DropTable("dbo.Notificacao");
            DropTable("dbo.MovimentacaoContratual");
            DropTable("dbo.MotivoHoraExtra");
            DropTable("dbo.Menu");
            DropTable("dbo.Marmitex");
            DropTable("dbo.Login");
            DropTable("dbo.OperadoraVTTarifaTipo");
            DropTable("dbo.OperadoraVTBandeiraCartao");
            DropTable("dbo.OperadoraVT");
            DropTable("dbo.LinhaVT");
            DropTable("dbo.JustificativaDivergencia");
            DropTable("dbo.InformeRendimentoLog");
            DropTable("dbo.TipoRendimentoTributaveis");
            DropTable("dbo.TipoRendimentoSujeitoTrib");
            DropTable("dbo.TipoRendimentoReceb");
            DropTable("dbo.TipoRendimentoIsentos");
            DropTable("dbo.InformeRendimento");
            DropTable("dbo.HoleriteLog");
            DropTable("dbo.HoleriteEvento");
            DropTable("dbo.Holerite");
            DropTable("dbo.FeriasLog");
            DropTable("dbo.FeriasConcessao");
            DropTable("dbo.FeriasPeriodo");
            DropTable("dbo.Ferias");
            DropTable("dbo.EquipeGestor");
            DropTable("dbo.DivergenciaLog");
            DropTable("dbo.DivergenciaDetalhe");
            DropTable("dbo.Divergencia");
            DropTable("dbo.DesligamentoTipo");
            DropTable("dbo.Desligamento");
            DropTable("dbo.Dependente");
            DropTable("dbo.ColaboradorPagamento");
            DropTable("dbo.ColaboradorEstrangeiroTipoVisto");
            DropTable("dbo.ColaboradorEstrangeiro");
            DropTable("dbo.UnidadeNegocio");
            DropTable("dbo.TurnoDetalhe");
            DropTable("dbo.Turno");
            DropTable("dbo.TipoRegistro");
            DropTable("dbo.TipoMaoObra");
            DropTable("dbo.Sindicato");
            DropTable("dbo.LotacaoPlano");
            DropTable("dbo.LotacaoPlanoUnidade");
            DropTable("dbo.LotacaoUnidade");
            DropTable("dbo.ColaboradorEmpregador");
            DropTable("dbo.ColaboradorDocumentoAdmissional");
            DropTable("dbo.ColaboradorDocumentacao");
            DropTable("dbo.Cidade");
            DropTable("dbo.CentroCustoUnidade");
            DropTable("dbo.CentroCustoPlanoUnidade");
            DropTable("dbo.CentroCustoPlano");
            DropTable("dbo.CategoriaSalarial");
            DropTable("dbo.CartaoPontoLog");
            DropTable("dbo.CartaoPontoDetalhe");
            DropTable("dbo.CartaoPontoCabecalho");
            DropTable("dbo.CartaoPonto");
            DropTable("dbo.CargoUnidade");
            DropTable("dbo.CargoPlanoUnidade");
            DropTable("dbo.CargoPlano");
            DropTable("dbo.BeneficioColaborador");
            DropTable("dbo.BeneficioTipo");
            DropTable("dbo.Beneficio");
            DropTable("dbo.AvisoFeriasLog");
            DropTable("dbo.AvisoFerias");
            DropTable("dbo.Atestado");
            DropTable("dbo.ContaBancariaTipo");
            DropTable("dbo.GrauInstrucao");
            DropTable("dbo.EstadoCivil");
            DropTable("dbo.EmpresaTipo");
            DropTable("dbo.EmpresaFuncionalidade");
            DropTable("dbo.EmpresaEmpresaFuncionalidade");
            DropTable("dbo.DocumentoAdmissional");
            DropTable("dbo.EmpresaDocumentoAdmissional");
            DropTable("dbo.Empresa");
            DropTable("dbo.ColaboradorTipo");
            DropTable("dbo.Colaborador");
            DropTable("dbo.Banco");
            DropTable("dbo.AlteracaoCadastral");
        }
    }
}
