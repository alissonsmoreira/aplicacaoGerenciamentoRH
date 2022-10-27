using System.Data.Entity;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.interfaces
{
    public interface IUnitOfWorkCustom : IUnitOfWork
    {
        IDbSet<BeneficioModel> Beneficio { get; set; }
        IDbSet<BeneficioTipoModel> BeneficioTipo { get; set; }
        IDbSet<CargoUnidadeModel> CargoUnidade { get; set; }
        IDbSet<CategoriaSalarialModel> CategoriaSalarial { get; set; }
        IDbSet<MarmitexModel> Marmitex { get; set; }
        IDbSet<TipoRegistroModel> TipoRegistro { get; set; }
        IDbSet<MotivoHoraExtraModel> MotivoHoraExtra { get; set; }
        IDbSet<TipoMaoObraModel> TipoMaoObra { get; set; }
        IDbSet<JustificativaDivergenciaModel> JustificativaDivergencia { get; set; }
        IDbSet<CentroCustoUnidadeModel> CentroCustoUnidade { get; set; }
        IDbSet<TurnoModel> Turno { get; set; }
        IDbSet<UnidadeNegocioModel> UnidadeNegocio { get; set; }
        IDbSet<SindicatoModel> Sindicato { get; set; }
        IDbSet<DocumentoAdmissionalModel> DocumentoAdmissional { get; set; }
        IDbSet<OperadoraVTModel> OperadoraVT { get; set; }
        IDbSet<OperadoraVTBandeiraCartaoModel> OperadoraVTBandeiraCartao { get; set; }
        IDbSet<OperadoraVTTarifaTipoModel> OperadoraVTTarifaTipo { get; set; }
        IDbSet<TurnoDetalheModel> TurnoDetalhe { get; set; }
        IDbSet<LinhaVTModel> LinhaVT { get; set; }
        IDbSet<CargoPlanoModel> CargoPlano{ get; set; }
        IDbSet<CargoPlanoUnidadeModel> CargoPlanoUnidade { get; set; }
        IDbSet<CentroCustoPlanoModel> CentroCustoPlano { get; set; }
        IDbSet<CentroCustoPlanoUnidadeModel> CentroCustoPlanoUnidade { get; set; }
        IDbSet<LotacaoUnidadeModel> LotacaoUnidade { get; set; }
        IDbSet<LotacaoPlanoModel> LotacaoPlano { get; set; }
        IDbSet<LotacaoPlanoUnidadeModel> LotacaoPlanoUnidade { get; set; }
        IDbSet<EmpresaFuncionalidadeModel> EmpresaFuncionalidade { get; set; }
        IDbSet<EmpresaModel> Empresa { get; set; }
        IDbSet<EmpresaTipoModel> EmpresaTipo { get; set; }
        IDbSet<EmpresaDocumentoAdmissionalModel> EmpresaDocumentoAdmissional { get; set; }
        IDbSet<EmpresaEmpresaFuncionalidadeModel> EmpresaEmpresaFuncionalidade { get; set; }
        IDbSet<UsuarioModel> Usuario { get; set; }
        IDbSet<DependenteModel> Dependente { get; set; }
        IDbSet<NotificacaoModel> Notificacao { get; set; }
        IDbSet<NotificacaoDetalheModel> NotificacaoDetalhe { get; set; }
        IDbSet<EstadoCivilModel> EstadoCivil { get; set; }
        IDbSet<GrauInstrucaoModel> GrauInstrucao{ get; set; }
        IDbSet<ColaboradorTipoModel> ColaboradorTipo { get; set; }
        IDbSet<ColaboradorModel> Colaborador { get; set; }
        //IDbSet<ColaboradorFuncionarioModel> ColaboradorFuncionario { get; set; }       
        IDbSet<ColaboradorDocumentacaoModel> ColaboradorDocumentacao { get; set; }
        IDbSet<ColaboradorEmpregadorModel> ColaboradorEmpregador { get; set; }
        IDbSet<ColaboradorPagamentoModel> ColaboradorPagamento { get; set; }
        IDbSet<ColaboradorEstrangeiroTipoVistoModel> ColaboradorEstrangeiroTipoVisto { get; set; }
        IDbSet<ColaboradorEstrangeiroModel> ColaboradorEstrangeiro { get; set; }
        IDbSet<ColaboradorDocumentoAdmissionalModel> ColaboradorDocumentoAdmissional { get; set; }
        IDbSet<ContaBancariaTipoModel> ContaBancariaTipo { get; set; }
        IDbSet<BancoModel> Banco { get; set; }
        IDbSet<LoginModel> Login { get; set; }
        IDbSet<MenuModel> Menu { get; set; }
        IDbSet<EquipeGestorModel> EquipeGestor { get; set; }
        IDbSet<AlteracaoCadastralModel> AlteracaoCadastral { get; set; }
        IDbSet<UFModel> UF { get; set; }
        IDbSet<CidadeModel> Cidade { get; set; }
        IDbSet<MovimentacaoContratualModel> MovimentacaoContratual { get; set; }
        IDbSet<DesligamentoTipoModel> DesligamentoTipo { get; set; }
        IDbSet<DesligamentoModel> Desligamento { get; set; }
        IDbSet<ValeTransporteUtilizacaoModel> ValeTransporteUtilizacao { get; set; }
        IDbSet<ValeTransporteSituacaoModel> ValeTransporteSituacao { get; set; }
        IDbSet<ValeTransporteModel> ValeTransporte { get; set; }
        IDbSet<BeneficioColaboradorModel> BeneficioColaborador { get; set; }
        IDbSet<AtestadoModel> Atestado { get; set; }
        IDbSet<CartaoPontoModel> CartaoPonto { get; set; }
        IDbSet<CartaoPontoDetalheModel> CartaoPontoDetalhe { get; set; }
        IDbSet<CartaoPontoCabecalhoModel> CartaoPontoCabecalho { get; set; }
        IDbSet<CartaoPontoLogModel> CartaoPontoLog { get; set; }
        IDbSet<InformeRendimentoModel> InformeRendimento { get; set; }
        IDbSet<TipoRendimentoTributaveisModel> TipoRendimentoTributaveis { get; set; }
        IDbSet<TipoRendimentoIsentosModel> TipoRendimentoIsentos { get; set; }
        IDbSet<TipoRendimentoSujeitosTribModel> TipoRendimentoSujeitosTrib { get; set; }
        IDbSet<TipoRendimentoRecebModel> TipoRendimentoReceb { get; set; }
        IDbSet<ReciboFeriasModel> ReciboFerias { get; set; }
        IDbSet<ReciboFeriasLogModel> ReciboFeriasLog { get; set; }
        IDbSet<ReciboFeriasVencimentoModel> ReciboFeriasVencimento { get; set; }
        IDbSet<ReciboFeriasDescontoModel> ReciboFeriasDesconto { get; set; }
        IDbSet<DivergenciaModel> Divergencia { get; set; }
        IDbSet<DivergenciaDetalheModel> DivergenciaDetalhe { get; set; }
        IDbSet<DivergenciaLogModel> DivergenciaLog { get; set; }
        IDbSet<AvisoFeriasModel> AvisoFerias { get; set; }
        IDbSet<AvisoFeriasLogModel> AvisoFeriasLog { get; set; }
        IDbSet<FeriasModel> Ferias { get; set; }
        IDbSet<FeriasPeriodoModel> FeriasPeriodo { get; set; }
        IDbSet<FeriasConcessaoModel> FeriasConcessao { get; set; }
        IDbSet<FeriasLogModel> FeriasLog { get; set; }
        IDbSet<HoleriteModel> Holerite { get; set; }
        IDbSet<HoleriteEventoModel> HoleriteEvento { get; set; }
        IDbSet<HoleriteLogModel> HoleriteLog { get; set; }
        IDbSet<BancoHorasModel> BancoHoras { get; set; }
        IDbSet<BancoHorasLogModel> BancoHorasLog { get; set; }
        IDbSet<AbsenteismoModel> Absenteismo { get; set; }
        IDbSet<AbsenteismoLogModel> AbsenteismoLog { get; set; }
        IDbSet<BeneficioDependenteModel> BeneficioDependente { get; set; }
        IDbSet<SolicitacaoHoraExtraModel> SolicitacaoHoraExtra { get; set; }
        IDbSet<SolicitacaoHoraExtraColaboradorModel> SolicitacaoHoraExtraColaborador { get; set; }
    }
}