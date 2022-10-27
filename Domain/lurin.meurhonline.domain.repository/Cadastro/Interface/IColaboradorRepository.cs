using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IColaboradorRepository<T> : IRepositoryCustom<T>
    {
        T GetColaboradorbyId(int? id);
        T GetColaboradorbyCPF(string cpf); 
        IEnumerable<T> GetColaborador(T colaborador);
        IEnumerable<T> GetColaboradorPreAdmissao(T colaborador);
        T GetColaboradorValidation(T colaborador);
        IEnumerable<T> GetColaboradorByNome(string nomeColaborador);
        IEnumerable<T> GetColaboradorPreAdmissaoByNome(string nomeColaborador);
        IEnumerable<T> GetGestorByNome(string nomeGestor);
        T GetColaboradorbyMatricula(string matricula);
        T GetColaboradorbyMatriculaEmpresa(string matricula, int EmpresaId);
    }
}