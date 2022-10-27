using System;
using System.Configuration;
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
using lurin.meurhonline.infrastructure.mail;
using lurin.meurhonline.infrastructure.invoke;
using lurin.meurhonline.infrastructure.invoke.interfaces;

namespace lurin.meurhonline.application
{
    public class LoginFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _domainMenu;

        private static dynamic _repoDefaultLogin;
        private static dynamic _repoCustomLogin;

        private static dynamic _repoCustomUsuario;
        private static dynamic _repoCustomColaborador;

        public LoginFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainMenu = DomainFactory.CreateDomain<MenuModel, Menu>(_unitOfWork);

            _repoDefaultLogin = RepositoryFactory.CreateRepository<LoginModel, Repository<LoginModel>>(_unitOfWork);
            _repoCustomLogin = RepositoryFactory.CreateRepositoryCustom<LoginModel, LoginRepository>(_unitOfWork);

            _repoCustomUsuario = RepositoryFactory.CreateRepositoryCustom<UsuarioModel, UsuarioRepository>(_unitOfWork);
            _repoCustomColaborador = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);
        }

        public dynamic BuscarLogin(string cpf, string senha)
        {            
            try
            {
                var result = new LoginModel();

                result = _repoCustomLogin.GetLogin(cpf, senha);
                if (result != null)
                {
                    if (result.UsuarioColaboradorTipoId == (int)UsuarioColaboradorTipoEnum.COLABORADOR)
                    {
                        ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                        var colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorCpf(cpf);

                        if (colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.DESLIGADO)
                        {
                            result = new LoginModel();
                            result.Erro = new ErrorModel();
                            result.Erro.Codigo = 600;
                            result.Erro.Descricao = "Usuário Desligado";

                            return result;
                        }
                    }

                    var token = BuscarToken(result.UsuarioColaboradorId);
                    if (token.Error != null)
                    {
                        result = new LoginModel();
                        result.Erro = new ErrorModel();
                        result.Erro.Codigo = 600;
                        result.Erro.Descricao = token.Error;
                    }
                    else
                        result = _domainMenu.MontarMenu(result, token);
                }
                else
                {
                    result = new LoginModel();
                    result.Erro = new ErrorModel();
                    result.Erro.Codigo = 600;
                    result.Erro.Descricao = "Login inválido";
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

        public dynamic RecuperaLoginByIdUsuarioColaborador(int idUsuarioColaborador, int idUsuarioColaboradorTipo)
        {
            try
            {
                var result = _repoCustomLogin.GetLoginByIdUsuarioColaborador(idUsuarioColaborador, idUsuarioColaboradorTipo);

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

        public dynamic ValidaMenuGestorFuncionalidadeEmpresa(int EmpresaId, int menu, int funcionalidadeId)
        {
            try
            {
                var result = _domainMenu.ValidaMenuGestorFuncionalidadeEmpresa(EmpresaId, menu, funcionalidadeId);

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

        private dynamic BuscarToken(int colaboradorId)
        {
            IApiInvoke apiInvoke = new ApiInvoke();

            var token = apiInvoke.PostReturn<TokenModel>(colaboradorId);

            return token;
        }

        public dynamic BuscarLoginColaboradorById(int IdColaborador)
        {
            try
            {
                var result = _repoCustomLogin.GetLoginByIdUsuarioColaborador(IdColaborador, (int)UsuarioColaboradorTipoEnum.COLABORADOR);

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

        public dynamic AdicionarLogin(string cpf, int usuarioColaboradorId, int usuarioColaboradorTipoId, string nome, string email)
        {
            try
            {
                var result = new LoginModel();

                var validacaoEntrada = ValidacaoEntrada(cpf, usuarioColaboradorId, usuarioColaboradorTipoId);
                if (validacaoEntrada.Codigo == 0)
                {
                    LoginModel login = new LoginModel();
                    login.Cpf = cpf;                    
                    login.Senha = GeradorSenha();
                    login.UsuarioColaboradorId = usuarioColaboradorId;
                    login.UsuarioColaboradorTipoId = usuarioColaboradorTipoId;
                    login.DataCadastro = DateTime.Now;                    

                    _repoDefaultLogin.Add(login);
                    _unitOfWork.Commit();                                                            

                    result = _repoCustomLogin.GetLoginById(login.Id);

                    EnviarEmailNovoUsuario(email, nome, result.Senha);
                }
                else
                {
                    result.Erro = new ErrorModel();
                    result.Erro.Codigo = validacaoEntrada.Codigo;
                    result.Erro.Descricao = validacaoEntrada.Descricao;
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

        public dynamic RecuperarSenha(string cpf)
        {            
            try
            {
                var result = new LoginModel();
                
                if (!string.IsNullOrEmpty(cpf))
                {
                    result = _repoCustomLogin.GetLoginByCpf(cpf);

                    if (result != null)
                    {
                        if (result.UsuarioColaboradorTipoId == (int)UsuarioColaboradorTipoEnum.USUARIO)
                        {
                            var resultUsuario = _repoCustomUsuario.GetUsuariobyId(result.UsuarioColaboradorId);

                            EnviarEmailRecuperarSenha(resultUsuario.Email, resultUsuario.Nome, result.Senha);

                        }
                        else if (result.UsuarioColaboradorTipoId == (int)UsuarioColaboradorTipoEnum.COLABORADOR)
                        {                            
                            var resultColaborador = _repoCustomColaborador.GetColaboradorbyId(result.UsuarioColaboradorId);

                            EnviarEmailRecuperarSenha(resultColaborador.Email, resultColaborador.Nome, result.Senha);
                        }                                                                        
                    }
                    else
                    {
                        result = new LoginModel();
                        result.Erro = new ErrorModel();
                        result.Erro.Codigo = 600;
                        result.Erro.Descricao = "Informações inválidas";
                    }
                }
                else
                {
                    result.Erro = new ErrorModel();
                    result.Erro.Codigo = 600;
                    result.Erro.Descricao = "Informe o Cpf";
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

        public dynamic AlterarSenha(string cpf, string senha, string novaSenha)
        {
            try
            {
                var result = new LoginModel();

                if (!string.IsNullOrEmpty(cpf) && !string.IsNullOrEmpty(senha) && !string.IsNullOrEmpty(novaSenha))
                {
                    result = _repoCustomLogin.GetLoginByCpfAndSenha(cpf, senha);

                    if (result != null)
                    {
                        result.Senha = novaSenha;

                        _unitOfWork.Commit();
                    }
                    else
                    {
                        result = new LoginModel();
                        result.Erro = new ErrorModel();
                        result.Erro.Codigo = 600;
                        result.Erro.Descricao = "Informações inválidas";
                    }
                }
                else
                {
                    result.Erro = new ErrorModel();
                    result.Erro.Codigo = 600;
                    result.Erro.Descricao = "Informações inválidas";
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


        public dynamic ExcluirLogin(int idUsuarioColaborador, int idUsuarioColaboradorTipoId)
        {
            var result = new LoginModel();

            try
            {
                result = _repoCustomLogin.GetLoginByIdUsuarioColaborador(idUsuarioColaborador, idUsuarioColaboradorTipoId);
                if (result != null)
                {
                    _repoDefaultLogin.Delete(result);
                    _unitOfWork.Commit();
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

        private ErrorModel ValidacaoEntrada(string cpf, int usuarioColaboradorId, int usuarioColaboradorTipoId)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(cpf))            
                erroModel.Descricao = "Informe o Cpf";            
            else if (usuarioColaboradorId == 0)            
                erroModel.Descricao = "Informe o Id do Usuário/Colaborador";            
            else if (usuarioColaboradorTipoId == 0)            
                erroModel.Descricao = "Informe o Tipo do Usuário/Colaborador";            

            return erroModel;
        }

        private string GeradorSenha()
        {           
            string chars = "abcdefghjkmnpqrstuvwxyz023456789";
            string pass = "";

            // Gera uma senha com 6 caracteres entre numeros e letras
            Random random = new Random();
            for (int f = 0; f < 6; f++)            
                pass += chars.Substring(random.Next(0, chars.Length - 1), 1);            

            return pass;
        }

        public static void EnviarEmailNovoUsuario(string email, string nome, string senha)
        {            
            bool toEmailValidade = Mail.MailValide(email);

            if (toEmailValidade)
            {
                string emailMessage = Mail.GetTemplateHtml(MailType.NovoUsuario);
                emailMessage = emailMessage.Replace("#ReceiverName#", nome);
                emailMessage = emailMessage.Replace("#Message#", "Bem vindo ao MeuRHOnline.");
                emailMessage = emailMessage.Replace("#Description#", string.Concat("Sua senha é: ", senha));
                emailMessage = emailMessage.Replace("#Description1#", "Informe o seu Cpf e a senha recebida para acessar o sistema.");
                emailMessage = emailMessage.Replace("#Url#", string.Concat(Mail.GetMailUrl()));

                Mail.SendEmail(email, "Bem-vindo ao MeuRHOnline!", emailMessage, true);
            }
        }

        private static void EnviarEmailRecuperarSenha(string email, string nome, string senha)
        {
            bool toEmailValidade = Mail.MailValide(email);

            if (toEmailValidade)
            {
                string emailMessage = Mail.GetTemplateHtml(MailType.RecuperarSenha);
                emailMessage = emailMessage.Replace("#ReceiverName#", nome);                
                emailMessage = emailMessage.Replace("#Message#", string.Concat("Sua senha para acessar o sistema é: ", senha));
                emailMessage = emailMessage.Replace("#Url#", string.Concat(Mail.GetMailUrl()));

                Mail.SendEmail(email, "MeuRHOnline - Recuperação de Senha", emailMessage, true);
            }
        }
    }
}
