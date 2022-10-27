using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;
using System;

namespace lurin.meurhonline.domain.repository
{
    public class SolicitacaoHoraExtraRepository : ISolicitacaoHoraExtraRepository<SolicitacaoHoraExtraModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public SolicitacaoHoraExtraRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public SolicitacaoHoraExtraModel GetSolicitacaoHoraExtraId(int id)
        {
            var result = _db.SolicitacaoHoraExtra
                            .Include(x => x.Gestor)
                            .Include(x => x.Marmitex)
                            .Include(x => x.SolicitacaoHoraExtraColaborador)
                            .Include(x => x.Empresa)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<SolicitacaoHoraExtraColaboradorModel> GetSolicitacaoHoraExtraColaboradorbySolicitacaoHoraExtraId(int solicitacaoHoraExtraId)
        {
            var result = _db.SolicitacaoHoraExtraColaborador
                            .Include(x => x.Colaborador)
                            .Where(x => x.SolicitacaoHoraExtraId == solicitacaoHoraExtraId)
                            .ToList();

            return result;
        }

        public IEnumerable<SolicitacaoHoraExtraModel> GetSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            var result = _db.SolicitacaoHoraExtra
                            .Include(x => x.Gestor)
                            .Include(x => x.Marmitex)
                            .Include(x => x.SolicitacaoHoraExtraColaborador)
                            .Include(x => x.Empresa)
                            .ToList();

            return result;
        }

        public IEnumerable<SolicitacaoHoraExtraModel> GetSolicitacaoHoraExtrabyGestorId(int gestorId, DateTime? data)
        {
            var result = _db.SolicitacaoHoraExtra
                            .Include(x => x.Marmitex)
                            .Include(x => x.Gestor)
                            .Include(x => x.Empresa)
                            .Where(x => x.GestorId == gestorId)
                            .Where(x => data != null ? x.Data == data : x.Data == x.Data)
                            .OrderByDescending(x => x.Data)
                            .ToList();

            return result;
        }

        public IEnumerable<SolicitacaoHoraExtraModel> GetSolicitacaoHoraExtrabyEmpresaIdDataSolicitacao(int empresaId, DateTime? dataSolicitacao)
        {
            var result = _db.SolicitacaoHoraExtra
                            .Include(x => x.Marmitex)
                            .Include(x => x.Gestor)
                            .Include(x => x.Empresa)
                            .Where(x => x.EmpresaId == empresaId)
                            .Where(x => dataSolicitacao != null ? DbFunctions.TruncateTime(x.DataSolicitacao) == DbFunctions.TruncateTime(dataSolicitacao) : x.DataSolicitacao == x.DataSolicitacao)
                            .OrderByDescending(x => x.DataSolicitacao)
                            .ToList();

            return result;
        }

        public IEnumerable<SolicitacaoHoraExtraColaboradorModel> GetSolicitacaoHoraExtraColaboradorbyColaboradorId(int colaboradorId)
        {
            var result = _db.SolicitacaoHoraExtraColaborador
                            .Include(x => x.Colaborador)
                            .Include(x => x.SolicitacaoHoraExtra)
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .OrderByDescending(x => x.DataConclusao)
                            .ToList();

            return result;
        }

        public SolicitacaoHoraExtraModel GetSolicitacaoHoraExtraValidation(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            var result = _db.SolicitacaoHoraExtra
                            .Where(x => x.Data == solicitacaoHoraExtra.Data)
                            .Where(x => x.HoraInicio == solicitacaoHoraExtra.HoraInicio)
                            .Where(x => x.HoraFim == solicitacaoHoraExtra.HoraFim)
                            .Where(x => x.GestorId == solicitacaoHoraExtra.GestorId)
                            .FirstOrDefault();

            return result;
        }

        public SolicitacaoHoraExtraColaboradorModel GetSolicitacaoHoraExtraColaborador(SolicitacaoHoraExtraColaboradorModel solicitacaoHoraExtraColaborador)
        {
            var result = _db.SolicitacaoHoraExtraColaborador
                            .Where(x => x.SolicitacaoHoraExtraId == solicitacaoHoraExtraColaborador.SolicitacaoHoraExtraId)
                            .Where(x => x.ColaboradorId == solicitacaoHoraExtraColaborador.ColaboradorId)
                            .Include(x => x.Colaborador)
                            .FirstOrDefault();

            return result;
        }
    }
}