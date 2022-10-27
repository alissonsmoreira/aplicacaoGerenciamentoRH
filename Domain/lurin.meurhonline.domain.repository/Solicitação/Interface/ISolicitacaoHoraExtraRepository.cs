using System;
using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ISolicitacaoHoraExtraRepository<T> : IRepositoryCustom<T>
    {
        T GetSolicitacaoHoraExtraId(int id);
        IEnumerable<SolicitacaoHoraExtraColaboradorModel> GetSolicitacaoHoraExtraColaboradorbySolicitacaoHoraExtraId(int solicitacaoHoraExtraId);
        IEnumerable<T> GetSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra);
        IEnumerable<T> GetSolicitacaoHoraExtrabyGestorId(int gestorId, DateTime? data);
        T GetSolicitacaoHoraExtraValidation(SolicitacaoHoraExtraModel solicitacaoHoraExtra);
        SolicitacaoHoraExtraColaboradorModel GetSolicitacaoHoraExtraColaborador(SolicitacaoHoraExtraColaboradorModel solicitacaoHoraExtraColaborador);
    }
}