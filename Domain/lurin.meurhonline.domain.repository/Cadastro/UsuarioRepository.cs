using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class UsuarioRepository : IUsuarioRepository<UsuarioModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public UsuarioRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public UsuarioModel GetUsuariobyId(int id)
        {
            var result = _db.Usuario
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<UsuarioModel> GetUsuario(UsuarioModel usuario)
        {
            var result = _db.Usuario
                            .Where(x => !string.IsNullOrEmpty(usuario.Nome) ? x.Nome.Contains(usuario.Nome) : x.Nome != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(usuario.CPF) ? x.CPF.Contains(usuario.CPF) : x.CPF != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(usuario.Email) ? x.Email.Contains(usuario.Email) : x.Email != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(usuario.Endereco) ? x.Endereco.Contains(usuario.Endereco) : x.Endereco == x.Endereco)
                            .Where(x => !string.IsNullOrEmpty(usuario.Complemento) ? x.Complemento.Contains(usuario.Complemento) : x.Complemento == x.Complemento)
                            .Where(x => !string.IsNullOrEmpty(usuario.Bairro) ? x.Bairro.Contains(usuario.Bairro) : x.Bairro == x.Bairro)
                            .Where(x => !string.IsNullOrEmpty(usuario.CEP) ? x.CEP.Contains(usuario.CEP) : x.CEP == x.CEP)
                            .Where(x => !string.IsNullOrEmpty(usuario.UF) ? x.UF.Contains(usuario.UF) : x.UF == x.UF)
                            .Where(x => !string.IsNullOrEmpty(usuario.Cidade) ? x.Cidade.Contains(usuario.Cidade) : x.Cidade == x.Cidade)
                            .Where(x => !string.IsNullOrEmpty(usuario.TelefoneResidencial) ? x.TelefoneResidencial.Contains(usuario.TelefoneResidencial) : x.TelefoneResidencial == x.TelefoneResidencial)
                            .Where(x => !string.IsNullOrEmpty(usuario.TelefoneCelular) ? x.TelefoneCelular.Contains(usuario.TelefoneCelular) : x.TelefoneCelular == x.TelefoneCelular)
                            .Where(x => !string.IsNullOrEmpty(usuario.TelefoneComercial) ? x.TelefoneComercial.Contains(usuario.TelefoneComercial) : x.TelefoneComercial == x.TelefoneComercial)
                            .ToList();

            return result;
        }

        public UsuarioModel GetUsuarioById(int id)
        {
            var result = _db.Usuario
                            .Where(x => x.Id == id)                            
                            .FirstOrDefault();

            return result;
        }        

        public UsuarioModel GetUsuarioValidation(UsuarioModel usuario)
        {
            var result = _db.Usuario
                            .Where(x => usuario.Id != 0 ? x.Id != usuario.Id : x.Id != 0)
                            .Where(x => x.CPF == usuario.CPF)
                            .FirstOrDefault();

            return result;
        }
    }
}