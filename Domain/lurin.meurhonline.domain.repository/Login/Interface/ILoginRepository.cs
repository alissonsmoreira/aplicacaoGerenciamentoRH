using System.Collections.Generic;
using System.Threading.Tasks;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ILoginRepository<T> : IRepositoryCustom<T>
    {
        T GetLoginById(int id);
        T GetLogin(string cpf, string senha);
        T GetLoginByCpf(string cpf);
        T GetLoginByCpfAndSenha(string cpf, string senha);
        T GetLoginByIdUsuarioColaborador(int idUsuarioColaborador, int idUsuarioColaboradorTipoId);
        void DeleteLoginByIdUsuarioColaborador(int idUsuarioColaborador, int idUsuarioColaboradorTipoId);
    }
}