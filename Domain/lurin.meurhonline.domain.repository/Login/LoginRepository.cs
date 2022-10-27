using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class LoginRepository : ILoginRepository<LoginModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public LoginRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }
        
        public LoginModel GetLoginById(int id)
        {
            var result = _db.Login
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public LoginModel GetLoginByCpf(string cpf)
        {
            var result = _db.Login
                            .Where(x => x.Cpf == cpf)
                            .FirstOrDefault();

            return result;
        }

        public LoginModel GetLoginByCpfAndSenha(string cpf, string senha)
        {
            var result = _db.Login
                            .Where(x => x.Cpf == cpf && x.Senha == senha)
                            .FirstOrDefault();

            return result;
        }

        public LoginModel GetLoginByIdUsuarioColaborador(int idUsuarioColaborador, int idUsuarioColaboradorTipoId)
        {
            var result = _db.Login
                            .Where(x => x.UsuarioColaboradorId == idUsuarioColaborador && x.UsuarioColaboradorTipoId == idUsuarioColaboradorTipoId)
                            .FirstOrDefault();

            return result;
        }

        public LoginModel GetLogin(string cpf, string senha)
        {
            var result = _db.Login
                            .Where(x => x.Cpf == cpf && x.Senha == senha)
                            .FirstOrDefault();

            return result;
        }

        public void DeleteLoginByIdUsuarioColaborador(int idUsuarioColaborador, int idUsuarioColaboradorTipoId)
        {
            ((DbSet<LoginModel>)_db.Login).RemoveRange(
                            _db.Login
                                .Where(x => x.UsuarioColaboradorId == idUsuarioColaborador && x.UsuarioColaboradorTipoId == idUsuarioColaboradorTipoId)
            );
        }
    }
}