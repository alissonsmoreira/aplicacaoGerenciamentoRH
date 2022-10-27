using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.interfaces
{
    public interface INotificacao<T> : IOperation<T>
    {
        List<T> BuscarNotificacao(int idUsuarioColaborador, int idUsuarioColaboradorTipo, ColaboradorModel colaborador, bool validaFuncionalidade);
    }
}