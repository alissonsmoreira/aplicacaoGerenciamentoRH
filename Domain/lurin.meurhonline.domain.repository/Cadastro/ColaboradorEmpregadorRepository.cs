using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ColaboradorEmpregadorRepository : IColaboradorEmpregadorRepository<ColaboradorEmpregadorModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ColaboradorEmpregadorRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ColaboradorEmpregadorModel GetColaboradorEmpregadorbyId(int id)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.TipoRegistro)
                            .Include(x => x.TipoMaoObra)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.Turno)
                            .Include(x => x.CategoriaSalarial)
                            .Include(x => x.Sindicato)
                            .Where(x => x.Id == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorEmpregadorModel GetColaboradorEmpregadorPreAdmissaobyId(int id)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.TipoRegistro)
                            .Include(x => x.TipoMaoObra)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.Turno)
                            .Include(x => x.CategoriaSalarial)
                            .Include(x => x.Sindicato)
                            .Where(x => x.ColaboradorId == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorEmpregadorModel GetColaboradorEmpregadorEditarById(int id)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.TipoRegistro)
                            .Include(x => x.TipoMaoObra)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.Turno)
                            .Include(x => x.CategoriaSalarial)
                            .Include(x => x.Sindicato)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorEmpregadorModel> GetColaboradorEmpregador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.TipoRegistro)
                            .Include(x => x.TipoMaoObra)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.Turno)
                            .Include(x => x.CategoriaSalarial)
                            .Include(x => x.Sindicato)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorEmpregador.ColaboradorId != 0 ? x.ColaboradorId == colaboradorEmpregador.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => colaboradorEmpregador.CargoUnidadeId != 0 ? x.CargoUnidadeId == colaboradorEmpregador.CargoUnidadeId : x.CargoUnidadeId != 0)
                            .Where(x => colaboradorEmpregador.CentroCustoUnidadeId != 0 ? x.CentroCustoUnidadeId == colaboradorEmpregador.CentroCustoUnidadeId : x.CentroCustoUnidadeId != 0)
                            .Where(x => colaboradorEmpregador.LotacaoUnidadeId != 0 ? x.LotacaoUnidadeId == colaboradorEmpregador.LotacaoUnidadeId : x.LotacaoUnidadeId != 0)
                            .Where(x => colaboradorEmpregador.TipoRegistroId != 0 ? x.TipoRegistroId == colaboradorEmpregador.TipoRegistroId : x.TipoRegistroId == x.TipoRegistroId)
                            .Where(x => colaboradorEmpregador.TipoMaoObraId != 0 ? x.TipoMaoObraId == colaboradorEmpregador.TipoMaoObraId : x.TipoMaoObraId == x.TipoMaoObraId)
                            .Where(x => colaboradorEmpregador.UnidadeNegocioId != 0 ? x.UnidadeNegocioId == colaboradorEmpregador.UnidadeNegocioId : x.UnidadeNegocioId == x.UnidadeNegocioId)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEmpregador.NumeroCartaoPonto) ? x.NumeroCartaoPonto.Contains(colaboradorEmpregador.NumeroCartaoPonto) : x.NumeroCartaoPonto == x.NumeroCartaoPonto)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEmpregador.Situacao) ? x.Situacao.Contains(colaboradorEmpregador.Situacao) : x.Situacao == x.Situacao)
                            .Where(x => colaboradorEmpregador.TurnoId != 0 ? x.TurnoId == colaboradorEmpregador.TurnoId : x.TurnoId == x.TurnoId)
                            .Where(x => colaboradorEmpregador.CategoriaSalarialId != 0 ? x.CategoriaSalarialId == colaboradorEmpregador.CategoriaSalarialId : x.CategoriaSalarialId == x.CategoriaSalarialId)
                            .Where(x => colaboradorEmpregador.Salario != 0 ? x.Salario == colaboradorEmpregador.Salario : x.Salario == x.Salario)
                            .Where(x => colaboradorEmpregador.DataAdmissao != null ? x.DataAdmissao == colaboradorEmpregador.DataAdmissao : x.DataAdmissao == x.DataAdmissao)
                            .Where(x => colaboradorEmpregador.SindicatoId != 0 ? x.SindicatoId == colaboradorEmpregador.SindicatoId : x.SindicatoId == x.SindicatoId)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorEmpregadorModel> GetColaboradorPreAdmissaoEmpregador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.TipoRegistro)
                            .Include(x => x.TipoMaoObra)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.Turno)
                            .Include(x => x.CategoriaSalarial)
                            .Include(x => x.Sindicato)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorEmpregador.ColaboradorId != 0 ? x.ColaboradorId == colaboradorEmpregador.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => colaboradorEmpregador.CargoUnidadeId != 0 ? x.CargoUnidadeId == colaboradorEmpregador.CargoUnidadeId : x.CargoUnidadeId != 0)
                            .Where(x => colaboradorEmpregador.CentroCustoUnidadeId != 0 ? x.CentroCustoUnidadeId == colaboradorEmpregador.CentroCustoUnidadeId : x.CentroCustoUnidadeId != 0)
                            .Where(x => colaboradorEmpregador.LotacaoUnidadeId != 0 ? x.LotacaoUnidadeId == colaboradorEmpregador.LotacaoUnidadeId : x.LotacaoUnidadeId != 0)
                            .Where(x => colaboradorEmpregador.TipoRegistroId != 0 ? x.TipoRegistroId == colaboradorEmpregador.TipoRegistroId : x.TipoRegistroId == x.TipoRegistroId)
                            .Where(x => colaboradorEmpregador.TipoMaoObraId != 0 ? x.TipoMaoObraId == colaboradorEmpregador.TipoMaoObraId : x.TipoMaoObraId == x.TipoMaoObraId)
                            .Where(x => colaboradorEmpregador.UnidadeNegocioId != 0 ? x.UnidadeNegocioId == colaboradorEmpregador.UnidadeNegocioId : x.UnidadeNegocioId == x.UnidadeNegocioId)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEmpregador.NumeroCartaoPonto) ? x.NumeroCartaoPonto.Contains(colaboradorEmpregador.NumeroCartaoPonto) : x.NumeroCartaoPonto == x.NumeroCartaoPonto)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEmpregador.Situacao) ? x.Situacao.Contains(colaboradorEmpregador.Situacao) : x.Situacao == x.Situacao)
                            .Where(x => colaboradorEmpregador.TurnoId != 0 ? x.TurnoId == colaboradorEmpregador.TurnoId : x.TurnoId == x.TurnoId)
                            .Where(x => colaboradorEmpregador.CategoriaSalarialId != 0 ? x.CategoriaSalarialId == colaboradorEmpregador.CategoriaSalarialId : x.CategoriaSalarialId == x.CategoriaSalarialId)
                            .Where(x => colaboradorEmpregador.Salario != 0 ? x.Salario == colaboradorEmpregador.Salario : x.Salario == x.Salario)
                            .Where(x => colaboradorEmpregador.DataAdmissao != null ? x.DataAdmissao == colaboradorEmpregador.DataAdmissao : x.DataAdmissao == x.DataAdmissao)
                            .Where(x => colaboradorEmpregador.SindicatoId != 0 ? x.SindicatoId == colaboradorEmpregador.SindicatoId : x.SindicatoId == x.SindicatoId)
                            .ToList();

            return result;
        }

        public ColaboradorEmpregadorModel GetColaboradorEmpregadorValidation(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            var result = _db.ColaboradorEmpregador
                            .Where(x => colaboradorEmpregador.Id != 0 ? x.Id != colaboradorEmpregador.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == colaboradorEmpregador.ColaboradorId)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorEmpregadorModel GetColaboradorEmpregadorbyColaboradorId(int id)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.Turno)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.TipoMaoObra)
                            .Where(x => x.ColaboradorId == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorEmpregadorModel> GetColaboradorEmpregadorbyColaboradorIdOuTipoRegistro(int? id, int? tipoRegistro, int? empresaId)
        {
            var result = _db.ColaboradorEmpregador
                           .Include(x => x.LotacaoUnidade)
                           .Include(x => x.Colaborador)
                           .Include(x => x.CategoriaSalarial)
                           .Include(x => x.Colaborador.Empresa)
                           .Include(x => x.CentroCustoUnidade)
                           .Include(x => x.CargoUnidade)
                           .Include(x => x.Turno)
                           .Include(x => x.TipoRegistro)
                           .Include(x => x.UnidadeNegocio)
                           .Include(x => x.TipoMaoObra)
                           .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.ATIVO);

            if (empresaId.HasValue && empresaId.Value > 0)
            {
                result = result.Where(x => x.Colaborador.EmpresaId == empresaId || x.Colaborador.Empresa.EmpresaMatrizId == empresaId);
            }
                           
            if (id.HasValue && id.Value > 0)
            {
                result = result.Where(x => x.ColaboradorId == id.Value);
            }

            if (tipoRegistro.HasValue && tipoRegistro.Value > 0)
            {
                result = result.Where(x => x.TipoRegistroId == tipoRegistro.Value);
            }

            return result;
        }

        public IEnumerable<ColaboradorEmpregadorModel> GetColaboradorEmpregadorbyColaboradorIdOuTipoRegistroEUnidadadeLotacao(int? id, int? tipoRegistro, int empresaId, int? matrizId, int codigoLotacaoInicial, int codigoLotacaoFinal)
        {
            var result = _db.ColaboradorEmpregador
                           .Include(x => x.LotacaoUnidade)
                           .Include(x => x.Colaborador)
                           .Include(x => x.CategoriaSalarial)
                           .Include(x => x.Colaborador.Empresa)
                           .Include(x => x.CentroCustoUnidade)
                           .Include(x => x.CargoUnidade)
                           .Include(x => x.Turno)
                           .Include(x => x.TipoRegistro)
                           .Include(x => x.UnidadeNegocio)
                           .Include(x => x.TipoMaoObra)
                           .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.DESLIGADO)
                           .Where(x => (x.Colaborador.Empresa.Id == empresaId || x.Colaborador.Empresa.EmpresaMatrizId == empresaId || (matrizId.HasValue && x.Colaborador.Empresa.Id == matrizId.Value)))
                           .Where(x => x.LotacaoUnidade.Codigo >= codigoLotacaoInicial)
                           .Where(x => x.LotacaoUnidade.Codigo <= codigoLotacaoFinal);


            if (id.HasValue && id.Value > 0)
            {
                result = result.Where(x => x.ColaboradorId == id.Value);
            }

            if (tipoRegistro.HasValue && tipoRegistro.Value > 0)
            {
                result = result.Where(x => x.TipoRegistroId == tipoRegistro.Value);
            }

            return result;
        }

        public IEnumerable<ColaboradorEmpregadorModel> GetColaboradorEmpregadorByNome(string nomeColaborador)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador)
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.Turno)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.TipoMaoObra)
                            .Include(x => x.TipoRegistro)
                            .Include(x => x.Sindicato)
                            .Include(x => x.CategoriaSalarial)
                            .Where(x => !string.IsNullOrEmpty(nomeColaborador) ? x.Colaborador.Nome.Contains(nomeColaborador) : x.Colaborador.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorEmpregadorModel> GetColaboradorEmpregadorByLotacao(int lotacaoUnidadeCodigoInicial, int lotacalUnidadeCodigoFinal, int empresaGestorId, int? empresaMatrizGestorId)
        {
            var result = _db.ColaboradorEmpregador
                            .Include(x => x.Colaborador)
                            .Where(x => x.LotacaoUnidade.Codigo >= lotacaoUnidadeCodigoInicial)
                            .Where(x => x.LotacaoUnidade.Codigo <= lotacalUnidadeCodigoFinal)
                            .Where(x => (x.Colaborador.Empresa.Id == empresaGestorId || x.Colaborador.Empresa.EmpresaMatrizId == empresaGestorId || (empresaMatrizGestorId.HasValue && x.Colaborador.Empresa.EmpresaMatrizId == empresaMatrizGestorId.Value) || (empresaMatrizGestorId.HasValue && x.Colaborador.Empresa.Id == empresaMatrizGestorId.Value)))
                            .ToList();

            return result;
        }
    }
}