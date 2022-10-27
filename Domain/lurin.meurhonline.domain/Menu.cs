using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.interfaces;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain
{
    public class Menu : IBeneficio<MenuModel>
    {
        private static dynamic _repoCustomMenu;

        private static dynamic _repoCustomColaborador;
        private static dynamic _repoCustomEmpresaEmpresaFuncionalidade;

        public Menu(IUnitOfWork unitOfWork)
        {           
            _repoCustomMenu = RepositoryFactory.CreateRepositoryCustom<MenuModel, MenuRepository>(unitOfWork);

            _repoCustomColaborador = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(unitOfWork);
            _repoCustomEmpresaEmpresaFuncionalidade = RepositoryFactory.CreateRepositoryCustom<EmpresaEmpresaFuncionalidadeModel, EmpresaEmpresaFuncionalidadeRepository>(unitOfWork);
        }

        public LoginModel MontarMenu(LoginModel result, dynamic token)
        {
            result.UsuarioColaboradorTipo = new UsuarioColaboradorTipoModel();
            result.UsuarioColaboradorTipo.Id = result.UsuarioColaboradorTipoId;
            result.UsuarioColaboradorTipo.Nome = Utils.GetEnumDescription((UsuarioColaboradorTipoEnum)result.UsuarioColaboradorTipoId);

            result.Token = new TokenModel();
            result.Token.AccessToken = token.AccessToken;

            var lstMenu = new List<MenuModel>();
            if (result.UsuarioColaboradorTipoId == (int)UsuarioColaboradorTipoEnum.USUARIO)
                lstMenu = _repoCustomMenu.GetMenuUsuario();
            else if (result.UsuarioColaboradorTipoId == (int)UsuarioColaboradorTipoEnum.COLABORADOR)
                MenuColaborador(result, lstMenu, out result, out lstMenu);

            result.Menu = new List<MenuModel>();
            foreach (MenuModel menu in lstMenu)
            {
                menu.MenuStatus = new MenuStatusModel();
                menu.MenuStatus.Id = menu.MenuStatusId;
                menu.MenuStatus.Nome = Utils.GetEnumDescription((MenuStatusEnum)menu.MenuStatusId);

                result.Menu.Add(menu);
            }

            return result;
        }

        public bool ValidaMenuGestorFuncionalidadeEmpresa(int EmpresaId, int menu, int funcionalidadeId)
        {
            var lstMenu = _repoCustomMenu.GetMenuGestor();           
            var lstFuncionalidade = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(EmpresaId);

            var funcExist = false;                    
            foreach (MenuModel menuFor in lstMenu)
            {
                if (menuFor.Id == menu)
                {
                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == funcionalidadeId)
                            funcExist = true;
                }
            }

            return funcExist;
        }

        private void MenuColaborador(LoginModel result, List<MenuModel> lstMenu, out LoginModel resultRet, out List<MenuModel> lstMenuRet)
        {
            result.ColaboradorTipo = new ColaboradorTipoModel();
            result.ColaboradorStatus = new ColaboradorStatusModel();

            var resultColaboradorPreAdm = _repoCustomColaborador.GetColaboradorPreAdmissaobyId(result.UsuarioColaboradorId);
            if (resultColaboradorPreAdm != null) //PRÉ ADMISSÃO
            {
                lstMenu = _repoCustomMenu.GetMenuPreAdmissao();

                result.ColaboradorTipo.Id = resultColaboradorPreAdm.ColaboradorTipo.Id;
                result.ColaboradorTipo.Nome = resultColaboradorPreAdm.ColaboradorTipo.Nome;

                result.ColaboradorStatus.Id = resultColaboradorPreAdm.ColaboradorStatusId;
                result.ColaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultColaboradorPreAdm.ColaboradorStatusId);
            }
            else
            {
                var resultColaborador = _repoCustomColaborador.GetColaboradorbyId(result.UsuarioColaboradorId);
                var lstMenuRepo = new List<MenuModel>();
                if (resultColaborador.ColaboradorTipo.Id == 1) //GESTOR
                {
                    lstMenuRepo = _repoCustomMenu.GetMenuGestor();
                    
                    lstMenu = MontaMenuGestorPorFuncionalidadeEmpresa(lstMenuRepo, resultColaborador.EmpresaId);
                }
                else if (resultColaborador.ColaboradorTipo.Id == 2) //FUNCIONÁRIO
                {
                    lstMenuRepo = _repoCustomMenu.GetMenuFuncionario();
                    
                    lstMenu = MontaMenuFuncionarioPorFuncionalidadeEmpresa(lstMenuRepo, resultColaborador.EmpresaId);
                }

                result.ColaboradorTipo.Id = resultColaborador.ColaboradorTipo.Id;
                result.ColaboradorTipo.Nome = resultColaborador.ColaboradorTipo.Nome;

                result.ColaboradorStatus.Id = resultColaborador.ColaboradorStatusId;
                result.ColaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultColaborador.ColaboradorStatusId);
            }

            resultRet = result;
            lstMenuRet = lstMenu;
        }

        private List<MenuModel> MontaMenuGestorPorFuncionalidadeEmpresa(List<MenuModel> lstMenu, int EmpresaId)
        {
            var lstFuncionalidade = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(EmpresaId);

            var lstMenuRet = new List<MenuModel>(lstMenu);
            var lstMenuNaoExistente = new List<MenuModel>();            
            foreach (MenuModel menuFor in lstMenu)
            {
                var funcExistente = true;

                //SOLICITAÇÃO DE BENEFÍCIO E BENEFÍCIO DEPENDENTE
                if (menuFor.Id == 43 || menuFor.Id == 47)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 1)
                            funcExistente = true;                    
                }

                //SOLICITAÇÃO DE VALE TRANSPORTE 
                if (menuFor.Id == 44)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)                    
                        if (funcionalidade.EmpresaFuncionalidadeId == 2)
                            funcExistente = true;
                }

                //CADASTRO DE DEPENDENTE
                if (menuFor.Id == 12)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 3)
                            funcExistente = true;
                }

                //MANUTENÇÃO DE DIVERGÊNCIA
                if (menuFor.Id == 67)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 5)
                            funcExistente = true;
                }

                //SOLICITAÇÃO E APROVAÇÃO DE HORA EXTRA
                if (menuFor.Id == 46 || menuFor.Id == 69)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 6)
                            funcExistente = true;
                }

                //APROVAÇÃO DE CARTÃO DE PONTO
                if (menuFor.Id == 66)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 7)
                            funcExistente = true;
                }

                //LANÇAMENTO DE ATESTADO
                if (menuFor.Id == 120)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 8)
                            funcExistente = true;
                }

                //APROVAÇÃO DE HORA EXTRA
                if (menuFor.Id == 69)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 9)
                            funcExistente = true;
                }

                //SOLICITAÇÃO DE FÉRIAS
                if (menuFor.Id == 45)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 11)
                            funcExistente = true;
                }

                //PROGRAMAÇÃO DE FÉRIAS
                if (menuFor.Id == 140)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 12)
                            funcExistente = true;
                }

                //VISUALIZAÇÃO DO HOLERITE
                if (menuFor.Id == 102)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 13)
                            funcExistente = true;
                }

                //SOLICITAÇÃO DE DESLIGAMENTO
                if (menuFor.Id == 40)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 14)
                            funcExistente = true;
                }

                if (!funcExistente)
                    lstMenuNaoExistente.Add(menuFor);
            }

            foreach (MenuModel menuNaoExistente in lstMenuNaoExistente)
                lstMenuRet.Remove(menuNaoExistente);

            return lstMenuRet;
        }

        private List<MenuModel> MontaMenuFuncionarioPorFuncionalidadeEmpresa(List<MenuModel> lstMenu, int EmpresaId)
        {
            var lstFuncionalidade = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(EmpresaId);

            var lstMenuRet = new List<MenuModel>(lstMenu);
            var lstMenuNaoExistente = new List<MenuModel>();
            foreach (MenuModel menuFor in lstMenu)
            {
                var funcExistente = true;

                //SOLICITAÇÃO DE BENEFÍCIO E BENEFÍCIO DEPENDENTE
                if (menuFor.Id == 43 || menuFor.Id == 46 || menuFor.Id == 47)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 1)
                            funcExistente = true;
                }

                //SOLICITAÇÃO DE VALE TRANSPORTE 
                if (menuFor.Id == 44)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 2)
                            funcExistente = true;
                }

                //CADASTRO DE DEPENDENTE
                if (menuFor.Id == 12)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 3)
                            funcExistente = true;
                }

                //APROVAÇÃO DE CARTÃO DE PONTO
                if (menuFor.Id == 66)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 7)
                            funcExistente = true;
                }

                //APROVAÇÃO DE HORA EXTRA
                if (menuFor.Id == 69)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 9)
                            funcExistente = true;
                }

                //LANÇAMENTO DE ATESTADO
                if (menuFor.Id == 120)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 8)
                            funcExistente = true;
                }

                //PROGRAMAÇÃO DE FÉRIAS
                if (menuFor.Id == 140)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 12)
                            funcExistente = true;
                }

                //VISUALIZAÇÃO DO HOLERITE
                if (menuFor.Id == 102)
                {
                    funcExistente = false;

                    foreach (EmpresaEmpresaFuncionalidadeModel funcionalidade in lstFuncionalidade)
                        if (funcionalidade.EmpresaFuncionalidadeId == 13)
                            funcExistente = true;
                }

                if (!funcExistente)
                    lstMenuNaoExistente.Add(menuFor);
            }

            foreach (MenuModel menuNaoExistente in lstMenuNaoExistente)
                lstMenuRet.Remove(menuNaoExistente);

            return lstMenuRet;
        }
    }    
}