using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class UsuarioFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static LoginFacade _loginFacade;

        private static dynamic _repoDefaultUsuario;
        private static dynamic _repoCustomUsuario;                          

        public UsuarioFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultUsuario = RepositoryFactory.CreateRepository<UsuarioModel, Repository<UsuarioModel>>(_unitOfWork);
            _repoCustomUsuario = RepositoryFactory.CreateRepositoryCustom<UsuarioModel, UsuarioRepository>(_unitOfWork);

            _loginFacade = new LoginFacade();            
        }

        public dynamic BuscarUsuario(UsuarioModel usuario)
        {
            try
            {
                var result = _repoCustomUsuario.GetUsuario(usuario);                                

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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic BuscarUsuarioPorId(int Id)
        {
            try
            {
                var result = _repoCustomUsuario.GetUsuarioById(Id);

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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }        

        public dynamic AdicionarUsuario(UsuarioModel usuario)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(usuario);
                if (validacaoEntrada.Codigo == 0)
                {                    
                    usuario.DataCadastro = DateTime.Now;
                    _repoDefaultUsuario.Add(usuario);
                    _unitOfWork.Commit();

                    _loginFacade.AdicionarLogin(usuario.CPF, usuario.Id, (int)UsuarioColaboradorTipoEnum.USUARIO, usuario.Nome, usuario.Email);                    

                    var result = _repoCustomUsuario.GetUsuariobyId(usuario.Id);                                        
                    
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
                if (ex.InnerException == null)
                {
                    var erroModel = new ErrorModel();
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Problemas ao enviar email";

                    return erroModel;
                }
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic EditarUsuario(UsuarioModel usuario)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(usuario);
                if (validacaoEntrada.Codigo == 0)
                {
                    var usuarioResult = _repoCustomUsuario.GetUsuariobyId(usuario.Id);

                    if (usuarioResult != null)
                    {
                        usuarioResult.Nome = usuario.Nome;
                        usuarioResult.CPF = usuario.CPF;
                        usuarioResult.Endereco = usuario.Endereco;
                        usuarioResult.Complemento = usuario.Complemento;
                        usuarioResult.Bairro = usuario.Bairro;
                        usuarioResult.CEP = usuario.CEP;
                        usuarioResult.UF = usuario.UF;
                        usuarioResult.Cidade = usuario.Cidade;
                        usuarioResult.TelefoneResidencial = usuario.TelefoneResidencial;
                        usuarioResult.TelefoneCelular = usuario.TelefoneCelular;
                        usuarioResult.TelefoneComercial = usuario.TelefoneComercial;
                        usuarioResult.Email = usuario.Email;

                        _unitOfWork.Commit();

                        result = _repoCustomUsuario.GetUsuariobyId(usuarioResult.Id);
                    }
                    else
                    {
                        result = "Registro não encontrado";
                    }

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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic ExcluirUsuario(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomUsuario.GetUsuariobyId(id);

                if (result != null)
                {
                    _repoDefaultUsuario.Delete(result);

                    ExcluirLogin(result.Id);

                    _unitOfWork.Commit();
                }
                else
                {
                    result = "Registro não encontrado";
                }

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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        private void ExcluirLogin(int idUsuarioColaborador)
        {            
            LoginFacade login = new LoginFacade();

            login.ExcluirLogin(idUsuarioColaborador, (int)UsuarioColaboradorTipoEnum.USUARIO);
        }

        private ErrorModel ValidacaoEntrada(UsuarioModel usuario)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(usuario.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else if (string.IsNullOrEmpty(usuario.CPF))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o CPF";
            }
            else if (string.IsNullOrEmpty(usuario.Email))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Email";
            }
            else
            {
                var result = _repoCustomUsuario.GetUsuarioValidation(usuario);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }
    }
}
