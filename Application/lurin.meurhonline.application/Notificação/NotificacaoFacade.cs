using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class NotificacaoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _domainNotificacao;

        private static dynamic _repoDefaultNotificacao;
        private static dynamic _repoCustomNotificacao;        

        public NotificacaoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainNotificacao = DomainFactory.CreateDomain<NotificacaoModel, Notificacao>(_unitOfWork);

            _repoDefaultNotificacao = RepositoryFactory.CreateRepository<NotificacaoModel, Repository<NotificacaoModel>>(_unitOfWork);
            _repoCustomNotificacao = RepositoryFactory.CreateRepositoryCustom<NotificacaoModel, NotificacaoRepository>(_unitOfWork);            
        }

        public dynamic BuscarNotificacao(int idUsuarioColaborador, int idUsuarioColaboradorTipo)
        {
            try
            {
                var colaborador = new ColaboradorModel();
                bool validaFuncionalidade = false;

                if (idUsuarioColaboradorTipo == (int)UsuarioColaboradorTipoEnum.COLABORADOR)
                {
                    var colaboradorFacade = new ColaboradorFacade();
                    colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(idUsuarioColaborador);

                    //APROVAÇÃO DE HORA EXTRA GESTOR
                    var loginFacade = new LoginFacade();
                    validaFuncionalidade = loginFacade.ValidaMenuGestorFuncionalidadeEmpresa(colaborador.EmpresaId, 69, 6);
                }

                var result = _domainNotificacao.BuscarNotificacao(idUsuarioColaborador, idUsuarioColaboradorTipo, colaborador, validaFuncionalidade);

                return result;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
        }

        public dynamic AdicionarNotificacao(NotificacaoModel notificacao)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(notificacao);
                if (validacaoEntrada.Codigo == 0)
                {                    
                    notificacao.DataCadastro = DateTime.Now;
                    _repoDefaultNotificacao.Add(notificacao);
                    _unitOfWork.Commit();

                    var result = _repoCustomNotificacao.GetNotificacaoById(notificacao.Id);

                    return result;
                }
                else
                    return validacaoEntrada;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
        }

        public async Task<dynamic> AtualizarStatusLeituraAsync(int idNotificacaoDetalhe)
        {
            dynamic result;

            try
            {
                result = _repoCustomNotificacao.GetNotificacaoByNotificacaoDetalheId(idNotificacaoDetalhe);

                if (result != null)
                {
                    //ATUALIZA TODOS OS ITENS PARA LIDO
                    ((List<NotificacaoModel>)result).Select(s => { s.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.LIDO; return s; }).ToList();                                      

                    await _unitOfWork.CommitAsync();                    
                }
                else
                    result = "Registro não encontrado";

                return result;
                
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
        }


        private ErrorModel ValidacaoEntrada(NotificacaoModel notificacao)
        {
            var erroModel = new ErrorModel();

            if (notificacao.NotificacaoDetalheId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Tipo de Notificação";
            }
            else if (notificacao.NotificacaoStatusLeituraId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Status de Leitura";
            }

            return erroModel;
        }
    }
}
