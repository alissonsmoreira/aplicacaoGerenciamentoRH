using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class MenuRepository : IMenuRepository<MenuModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public MenuRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public IEnumerable<MenuModel> GetMenuUsuario()
        {
            var result = _db.Menu
                            .Where(x => x.UsuarioPermissao == "S")
                            .Where(x => x.MenuStatusId == (int)MenuStatusEnum.ATIVO)
                            .OrderBy(x => x.Order)
                            .ToList();

            return result;
        }

        public IEnumerable<MenuModel> GetMenuGestor()
        {
            var result = _db.Menu
                            .Where(x => x.GestorPermissao == "S")
                            .Where(x => x.MenuStatusId == (int)MenuStatusEnum.ATIVO)
                            .OrderBy(x => x.Order)
                            .ToList();

            return result;
        }

        public IEnumerable<MenuModel> GetMenuFuncionario()
        {
            var result = _db.Menu
                            .Where(x => x.FuncionarioPermissao == "S")
                            .Where(x => x.MenuStatusId == (int)MenuStatusEnum.ATIVO)
                            .OrderBy(x => x.Order)
                            .ToList();

            return result;
        }

        public IEnumerable<MenuModel> GetMenuPreAdmissao()
        {
            var result = _db.Menu
                            .Where(x => x.PreAdmissaoPermissao == "S")
                            .Where(x => x.MenuStatusId == (int)MenuStatusEnum.ATIVO)
                            .OrderBy(x => x.Order)
                            .ToList();

            return result;
        }
    }
}