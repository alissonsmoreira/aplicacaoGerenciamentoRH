using System.Data.Entity;
using System.Threading.Tasks;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.persistence.mapper;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.infrastructure.persistence
{
    public class UnitOfWork : DbContext, IUnitOfWorkCustom
    {
        public virtual IDbSet<BeneficioModel> Beneficio { get; set; }
        public virtual IDbSet<BeneficioTipoModel> BeneficioTipo { get; set; }
        public virtual IDbSet<CargoUnidadeModel> CargoUnidade { get; set; }
        public virtual IDbSet<CategoriaSalarialModel> CategoriaSalarial { get; set; }
        public virtual IDbSet<MarmitexModel> Marmitex { get; set; }
        public virtual IDbSet<TipoRegistroModel> TipoRegistro { get; set; }
        public virtual IDbSet<MotivoHoraExtraModel> MotivoHoraExtra { get; set; }
        public virtual IDbSet<TipoMaoObraModel> TipoMaoObra { get; set; }
        public virtual IDbSet<JustificativaDivergenciaModel> JustificativaDivergencia { get; set; }
        public virtual IDbSet<CentroCustoUnidadeModel> CentroCustoUnidade { get; set; }
        public virtual IDbSet<TurnoModel> Turno { get; set; }
        public virtual IDbSet<UnidadeNegocioModel> UnidadeNegocio { get; set; }
        public virtual IDbSet<SindicatoModel> Sindicato { get; set; }
        public virtual IDbSet<DocumentoAdmissionalModel> DocumentoAdmissional { get; set; }
        public virtual IDbSet<OperadoraVTModel> OperadoraVT { get; set; }
        public virtual IDbSet<OperadoraVTBandeiraCartaoModel> OperadoraVTBandeiraCartao { get; set; }
        public virtual IDbSet<OperadoraVTTarifaTipoModel> OperadoraVTTarifaTipo { get; set; }
        public virtual IDbSet<TurnoDetalheModel> TurnoDetalhe { get; set; }
        public virtual IDbSet<LinhaVTModel> LinhaVT { get; set; }
        public virtual IDbSet<CargoPlanoModel> CargoPlano { get; set; }
        public virtual IDbSet<CargoPlanoUnidadeModel> CargoPlanoUnidade { get; set; }
        public virtual IDbSet<CentroCustoPlanoModel> CentroCustoPlano { get; set; }
        public virtual IDbSet<CentroCustoPlanoUnidadeModel> CentroCustoPlanoUnidade { get; set; }
        public virtual IDbSet<LotacaoUnidadeModel> LotacaoUnidade { get; set; }
        public virtual IDbSet<LotacaoPlanoModel> LotacaoPlano { get; set; }
        public virtual IDbSet<LotacaoPlanoUnidadeModel> LotacaoPlanoUnidade { get; set; }
        public virtual IDbSet<EmpresaFuncionalidadeModel> EmpresaFuncionalidade { get; set; }
        public virtual IDbSet<EmpresaModel> Empresa { get; set; }
        public virtual IDbSet<EmpresaTipoModel> EmpresaTipo { get; set; }
        public virtual IDbSet<EmpresaDocumentoAdmissionalModel> EmpresaDocumentoAdmissional { get; set; }
        public virtual IDbSet<EmpresaEmpresaFuncionalidadeModel> EmpresaEmpresaFuncionalidade { get; set; }
        public virtual IDbSet<UsuarioModel> Usuario { get; set; }
        public virtual IDbSet<DependenteModel> Dependente { get; set; }
        public virtual IDbSet<NotificacaoModel> Notificacao { get; set; }
        public virtual IDbSet<NotificacaoDetalheModel> NotificacaoDetalhe { get; set; }
        public virtual IDbSet<EstadoCivilModel> EstadoCivil { get; set; }
        public virtual IDbSet<GrauInstrucaoModel> GrauInstrucao { get; set; }
        public virtual IDbSet<ColaboradorTipoModel> ColaboradorTipo { get; set; }
        //public virtual IDbSet<ColaboradorFuncionarioModel> ColaboradorFuncionario { get; set; }
        public virtual IDbSet<ColaboradorModel> Colaborador { get; set; }
        public virtual IDbSet<ColaboradorDocumentacaoModel> ColaboradorDocumentacao { get; set; }
        public virtual IDbSet<ColaboradorEmpregadorModel> ColaboradorEmpregador { get; set; }
        public virtual IDbSet<ColaboradorPagamentoModel> ColaboradorPagamento { get; set; }
        public virtual IDbSet<ColaboradorEstrangeiroTipoVistoModel> ColaboradorEstrangeiroTipoVisto { get; set; }
        public virtual IDbSet<ColaboradorEstrangeiroModel> ColaboradorEstrangeiro { get; set; }
        public virtual IDbSet<LoginModel> Login { get; set; }
        public virtual IDbSet<ColaboradorDocumentoAdmissionalModel> ColaboradorDocumentoAdmissional { get; set; }
        public virtual IDbSet<ContaBancariaTipoModel> ContaBancariaTipo { get; set; }
        public virtual IDbSet<BancoModel> Banco { get; set; }
        public virtual IDbSet<MenuModel> Menu { get; set; }
        public virtual IDbSet<EquipeGestorModel> EquipeGestor { get; set; }
        public virtual IDbSet<AlteracaoCadastralModel> AlteracaoCadastral { get; set; }
        public virtual IDbSet<UFModel> UF { get; set; }
        public virtual IDbSet<CidadeModel> Cidade { get; set; }
        public virtual IDbSet<MovimentacaoContratualModel> MovimentacaoContratual { get; set; }
        public virtual IDbSet<InformeRendimentoModel> InformeRendimento { get; set; }
        public virtual IDbSet<InformeRendimentoLogModel> InformeRendimentoLog { get; set; }
        public virtual IDbSet<TipoRendimentoTributaveisModel> TipoRendimentoTributaveis { get; set; }
        public virtual IDbSet<TipoRendimentoIsentosModel> TipoRendimentoIsentos { get; set; }
        public virtual IDbSet<TipoRendimentoSujeitosTribModel> TipoRendimentoSujeitosTrib { get; set; }
        public virtual IDbSet<TipoRendimentoRecebModel> TipoRendimentoReceb { get; set; }

        public virtual IDbSet<DesligamentoTipoModel> DesligamentoTipo { get; set; }
        public virtual IDbSet<DesligamentoModel> Desligamento { get; set; }
        public virtual IDbSet<ValeTransporteUtilizacaoModel> ValeTransporteUtilizacao { get; set; }
        public virtual IDbSet<ValeTransporteSituacaoModel> ValeTransporteSituacao { get; set; }
        public virtual IDbSet<ValeTransporteModel> ValeTransporte { get; set; }
        public virtual IDbSet<BeneficioColaboradorModel> BeneficioColaborador { get; set; }
        public virtual IDbSet<AtestadoModel> Atestado { get; set; }
        public virtual IDbSet<CartaoPontoModel> CartaoPonto { get; set; }
        public virtual IDbSet<CartaoPontoDetalheModel> CartaoPontoDetalhe { get; set; }
        public virtual IDbSet<CartaoPontoCabecalhoModel> CartaoPontoCabecalho { get; set; }
        public virtual IDbSet<CartaoPontoLogModel> CartaoPontoLog { get; set; }
        public virtual IDbSet<ReciboFeriasModel> ReciboFerias { get; set; }
        public virtual IDbSet<ReciboFeriasLogModel> ReciboFeriasLog { get; set; }
        public virtual IDbSet<ReciboFeriasVencimentoModel> ReciboFeriasVencimento { get; set; }
        public virtual IDbSet<ReciboFeriasDescontoModel> ReciboFeriasDesconto { get; set; }
        public virtual IDbSet<DivergenciaModel> Divergencia { get; set; }
        public virtual IDbSet<DivergenciaDetalheModel> DivergenciaDetalhe { get; set; }
        public virtual IDbSet<DivergenciaLogModel> DivergenciaLog { get; set; }
        public virtual IDbSet<AvisoFeriasModel> AvisoFerias { get; set; }
        public virtual IDbSet<AvisoFeriasLogModel> AvisoFeriasLog { get; set; }
        public virtual IDbSet<FeriasModel> Ferias { get; set; }
        public virtual IDbSet<FeriasPeriodoModel> FeriasPeriodo { get; set; }
        public virtual IDbSet<FeriasConcessaoModel> FeriasConcessao { get; set; }
        public virtual IDbSet<FeriasLogModel> FeriasLog { get; set; }
        public virtual IDbSet<HoleriteModel> Holerite { get; set; }
        public virtual IDbSet<HoleriteEventoModel> HoleriteEvento { get; set; }
        public virtual IDbSet<HoleriteLogModel> HoleriteLog { get; set; }
        public virtual IDbSet<BancoHorasModel> BancoHoras { get; set; }
        public virtual IDbSet<BancoHorasLogModel> BancoHorasLog { get; set; }
        public virtual IDbSet<AbsenteismoModel> Absenteismo { get; set; }
        public virtual IDbSet<AbsenteismoLogModel> AbsenteismoLog { get; set; }
        public virtual IDbSet<BeneficioDependenteModel> BeneficioDependente { get; set; }
        public virtual IDbSet<SolicitacaoHoraExtraModel> SolicitacaoHoraExtra { get; set; }
        public virtual IDbSet<SolicitacaoHoraExtraColaboradorModel> SolicitacaoHoraExtraColaborador { get; set; }

        public UnitOfWork() : base("MeuRHOnline")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public void Commit()
        {
            SaveChanges();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }


        public void CloseConn()
        {
            Dispose();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BeneficioMap());
            modelBuilder.Configurations.Add(new BeneficioTipoMap());
            modelBuilder.Configurations.Add(new CargoUnidadeMap());
            modelBuilder.Configurations.Add(new CategoriaSalarialMap());
            modelBuilder.Configurations.Add(new MarmitexMap());
            modelBuilder.Configurations.Add(new TipoRegistroMap());
            modelBuilder.Configurations.Add(new MotivoHoraExtraMap());
            modelBuilder.Configurations.Add(new TipoMaoObraMap());
            modelBuilder.Configurations.Add(new JustificativaDivergenciaMap());
            modelBuilder.Configurations.Add(new CentroCustoUnidadeMap());
            modelBuilder.Configurations.Add(new TurnoMap());
            modelBuilder.Configurations.Add(new UnidadeNegocioMap());
            modelBuilder.Configurations.Add(new SindicatoMap());
            modelBuilder.Configurations.Add(new DocumentoAdmissionalMap());
            modelBuilder.Configurations.Add(new OperadoraVTMap());
            modelBuilder.Configurations.Add(new OperadoraVTBandeiraCartaoMap());
            modelBuilder.Configurations.Add(new OperadoraVTTarifaTipoMap());
            modelBuilder.Configurations.Add(new TurnoDetalheMap());
            modelBuilder.Configurations.Add(new LinhaVTMap());
            modelBuilder.Configurations.Add(new CargoPlanoMap());
            modelBuilder.Configurations.Add(new CargoPlanoUnidadeMap());
            modelBuilder.Configurations.Add(new CentroCustoPlanoMap());
            modelBuilder.Configurations.Add(new CentroCustoPlanoUnidadeMap());
            modelBuilder.Configurations.Add(new LotacaoUnidadeMap());
            modelBuilder.Configurations.Add(new LotacaoPlanoMap());
            modelBuilder.Configurations.Add(new LotacaoPlanoUnidadeMap());
            modelBuilder.Configurations.Add(new EmpresaFuncionalidadeMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new EmpresaDocumentoAdmissionaleMap());
            modelBuilder.Configurations.Add(new EmpresaEmpresaFuncionalidadeMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new DependenteMap());
            modelBuilder.Configurations.Add(new NotificacaoMap());
            modelBuilder.Configurations.Add(new NotificacaoDetalheMap());
            modelBuilder.Configurations.Add(new EmpresaTipoMap());
            modelBuilder.Configurations.Add(new EstadoCivilMap());
            modelBuilder.Configurations.Add(new GrauInstrucaoMap());
            modelBuilder.Configurations.Add(new ColaboradorTipoMap());
            modelBuilder.Configurations.Add(new ColaboradorMap());
            modelBuilder.Configurations.Add(new ColaboradorDocumentacaoMap());
            modelBuilder.Configurations.Add(new ColaboradorEmpregadorMap());
            modelBuilder.Configurations.Add(new ColaboradorPagamentoMap());
            modelBuilder.Configurations.Add(new ColaboradorEstrangeiroTipoVistoMap());
            modelBuilder.Configurations.Add(new ColaboradorEstrangeiroMap());         
            modelBuilder.Configurations.Add(new LoginMap());
            modelBuilder.Configurations.Add(new ColaboradorDocumentoAdmissionalMap());
            modelBuilder.Configurations.Add(new ContaBancariaTipoMap());
            modelBuilder.Configurations.Add(new BancoMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new EquipeGestorMap());
            modelBuilder.Configurations.Add(new AlteracaoCadastralMap());
            modelBuilder.Configurations.Add(new UFMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new MovimentacaoContratualMap());
            modelBuilder.Configurations.Add(new DesligamentoTipoMap());
            modelBuilder.Configurations.Add(new DesligamentoMap());
            modelBuilder.Configurations.Add(new ValeTransporteUtilizacaoMap());
            modelBuilder.Configurations.Add(new ValeTransporteSituacaoMap());
            modelBuilder.Configurations.Add(new ValeTransporteMap());
            modelBuilder.Configurations.Add(new BeneficioColaboradorMap());
            modelBuilder.Configurations.Add(new AtestadoMap());
            modelBuilder.Configurations.Add(new CartaoPontoMap());
            modelBuilder.Configurations.Add(new CartaoPontoDetalheMap());
            modelBuilder.Configurations.Add(new CartaoPontoCabecalhoMap());
            modelBuilder.Configurations.Add(new CartaoPontoLogMap());
            modelBuilder.Configurations.Add(new InformeRendimentoMap());
            modelBuilder.Configurations.Add(new InformeRendimentoLogMap());
            modelBuilder.Configurations.Add(new TipoRendimentoTributaveisMap());
            modelBuilder.Configurations.Add(new TipoRendimentoIsentosMap());
            modelBuilder.Configurations.Add(new TipoRendimentoSujeitoTribMap());
            modelBuilder.Configurations.Add(new TipoRendimentoRecebMap());
            modelBuilder.Configurations.Add(new ReciboFeriasMap());
            modelBuilder.Configurations.Add(new ReciboFeriasLogMap());
            modelBuilder.Configurations.Add(new ReciboFeriasVencimentoMap());
            modelBuilder.Configurations.Add(new ReciboFeriasDescontoMap());
            modelBuilder.Configurations.Add(new DivergenciaMap());
            modelBuilder.Configurations.Add(new DivergenciaDetalheMap());
            modelBuilder.Configurations.Add(new DivergenciaLogMap());
            modelBuilder.Configurations.Add(new AvisoFeriasMap());
            modelBuilder.Configurations.Add(new AvisoFeriasLogMap());
            modelBuilder.Configurations.Add(new FeriasMap());
            modelBuilder.Configurations.Add(new FeriasPeriodoMap());
            modelBuilder.Configurations.Add(new FeriasConcessaoMap());
            modelBuilder.Configurations.Add(new FeriasLogMap());
            modelBuilder.Configurations.Add(new HoleriteMap());
            modelBuilder.Configurations.Add(new HoleriteEventoMap());
            modelBuilder.Configurations.Add(new HoleriteLogMap());
            modelBuilder.Configurations.Add(new BancoHorasMap());
            modelBuilder.Configurations.Add(new BancoHorasLogMap());
            modelBuilder.Configurations.Add(new AbsenteismoMap());
            modelBuilder.Configurations.Add(new AbsenteismoLogMap());
            modelBuilder.Configurations.Add(new BeneficioDependenteMap());
            modelBuilder.Configurations.Add(new SolicitacaoHoraExtraMap());
            modelBuilder.Configurations.Add(new SolicitacaoHoraExtraColaboradorMap());
        }
    }
}