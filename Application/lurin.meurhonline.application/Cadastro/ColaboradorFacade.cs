using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.infrastructure.IO;
using System.Globalization;
using lurin.meurhonline.infrastructure.mail;
using System.Data.Entity;
using System.Linq;
using lurin.meurhonline.domain.Constantes;

namespace lurin.meurhonline.application
{
    public class ColaboradorFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static LoginFacade _loginFacade;        

        private static dynamic _repoDefaultColaboradorDadoPrincipal;
        private static dynamic _repoCustomColaboradorDadoPrincipal;
        private static dynamic _repoDefaultColaboradorTipo;
        private static dynamic _repoCustomColaboradorEmpregador;
        private static dynamic _repoDefaultLogin;
        private static dynamic _repoDefaultColaborador;
        private static dynamic _repoCustomLogin;
        private static dynamic _repoCustomEmpresaEmpresaFuncionalidade;

        public ColaboradorFacade()
        {
            _unitOfWork = new UnitOfWork();            

            _repoDefaultColaboradorDadoPrincipal = RepositoryFactory.CreateRepository<ColaboradorModel, Repository<ColaboradorModel>>(_unitOfWork);
            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);
            _repoDefaultColaboradorTipo = RepositoryFactory.CreateRepository<ColaboradorTipoModel, Repository<ColaboradorTipoModel>>(_unitOfWork);
            _repoCustomColaboradorEmpregador = RepositoryFactory.CreateRepositoryCustom<ColaboradorEmpregadorModel, ColaboradorEmpregadorRepository>(_unitOfWork);
            _repoDefaultLogin = RepositoryFactory.CreateRepository<LoginModel, Repository<LoginModel>>(_unitOfWork);
            _repoCustomLogin = RepositoryFactory.CreateRepositoryCustom<LoginModel, LoginRepository>(_unitOfWork);
            _repoDefaultColaborador = RepositoryFactory.CreateRepository<ColaboradorModel, Repository<ColaboradorModel>>(_unitOfWork);
            _repoCustomEmpresaEmpresaFuncionalidade = RepositoryFactory.CreateRepositoryCustom<EmpresaEmpresaFuncionalidadeModel, EmpresaEmpresaFuncionalidadeRepository>(_unitOfWork);

            _loginFacade = new LoginFacade();            
        }

        public dynamic BuscarColaboradorDadoPrincipal(ColaboradorModel colaborador)
        {
            try
            {
                var resultRepo = _repoCustomColaboradorDadoPrincipal.GetColaborador(colaborador);

                var result = new List<ColaboradorModel>();
                foreach (var resultFor in resultRepo)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = resultFor.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor.ColaboradorStatusId);

                    resultFor.ColaboradorStatus = colaboradorStatus;
                    
                    resultFor.Senha = BuscarSenhaColaborador(resultFor.Id);

                    result.Add(resultFor);
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
        public dynamic BuscarColaboradorPorIdOuTipoDeRegistro(int? Id, int? tipoRegistro, int? colaboradorId)
        {
            List<ColaboradorFuncionarioModel> colaboradoresLista = new List<ColaboradorFuncionarioModel>();
            ColaboradorFuncionarioModel colaborador = new ColaboradorFuncionarioModel();
            IEnumerable<ColaboradorEmpregadorModel> result = new List<ColaboradorEmpregadorModel>();
            ColaboradorModel colaboradorAtual = new ColaboradorModel();
           
            try
            {
                if (colaboradorId.HasValue)
                {
                    colaboradorAtual = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorId.Value);
                }
                else
                {
                    colaboradorAtual = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(Id);
                }
                
                var ehPerfilRh = EhPerfilRH(colaboradorAtual);

                if (!ehPerfilRh && colaboradorAtual != null)
                {
                    List<ColaboradorEmpregadorModel> colaboradorEmpregadorModels = new List<ColaboradorEmpregadorModel>();

                    EquipeGestorFacade equipeGestor = new EquipeGestorFacade();
                    var resultEquipeRepo = equipeGestor.BuscarEquipeGestorPorGestorId(colaboradorAtual.Id);

                    foreach (var resultEquipeFor in resultEquipeRepo)
                    {
                        var resultColaboradorRepo = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorbyColaboradorIdOuTipoRegistroEUnidadadeLotacao(Id, tipoRegistro, colaboradorAtual.EmpresaId, colaboradorAtual.Empresa.EmpresaMatrizId, resultEquipeFor.LotacaoUnidadeInicial.Codigo, resultEquipeFor.LotacaoUnidadeFinal.Codigo);
                        foreach (var resultColaboradorFor in resultColaboradorRepo)
                        {
                            colaboradorEmpregadorModels.Add(resultColaboradorFor);
                        }

                    }

                    result = colaboradorEmpregadorModels;
                }
                else
                {
                     result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorbyColaboradorIdOuTipoRegistro(Id, tipoRegistro, null);
                }

                var podeVerSalario = ehPerfilRh || GestorEmpresaPodeVerSalario(colaboradorAtual.EmpresaId);

                foreach (ColaboradorEmpregadorModel item in result)
                {
                    colaborador = new ColaboradorFuncionarioModel()
                    {
                        Cargo = item.CargoUnidade != null ? item.CargoUnidade.Nome : string.Empty,
                        Salario = item.Salario.Equals(decimal.Zero) || !podeVerSalario ? string.Empty : item.Salario.ToString("C2", CultureInfo.CurrentCulture),
                        DataAdmissao = item.DataAdmissao.HasValue ? item.DataAdmissao.Value.ToString("dd/MM/yyyy") : string.Empty,
                        CentroDeCusto = item.CentroCustoUnidade != null ? item.CentroCustoUnidade.Nome : string.Empty,
                        NomeColaborador = item.Colaborador != null ? item.Colaborador.Nome : string.Empty,
                        Id = item.Id,
                        NomeEmpresa = item.Colaborador != null ? item.Colaborador.Empresa != null ? item.Colaborador.Empresa.Nome : string.Empty : string.Empty,
                        TipoRegistro = item.TipoRegistro != null ? item.TipoRegistro.Nome : string.Empty,
                        Turno = item.Turno != null ? item.Turno.Descricao : string.Empty,
                        UnidadeDeLotacao = item.LotacaoUnidade != null ? item.LotacaoUnidade.Nome : string.Empty,
                        UnidadeDeNegocio = item.UnidadeNegocio != null ? item.UnidadeNegocio.Nome : string.Empty
                    };
                    colaboradoresLista.Add(colaborador);
                }

                return colaboradoresLista;              
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


        private string BuscarSenhaColaborador(int IdColaborador)
        {
            var senha = string.Empty;

            LoginFacade loginFacade = new LoginFacade();            
            var login = loginFacade.BuscarLoginColaboradorById(IdColaborador);
            if (login != null)
                senha = login.Senha;

            return senha;
        }

        public dynamic BuscarDadoPrincipalColaboradorPreAdmissao(ColaboradorModel colaborador)
        {
            try
            {
                var resultRepo = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissao(colaborador);

                var result = new List<ColaboradorModel>();
                foreach (var resultFor in resultRepo)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = resultFor.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor.ColaboradorStatusId);

                    resultFor.Senha = BuscarSenhaColaborador(resultFor.Id);
                    resultFor.ColaboradorStatus = colaboradorStatus;

                    result.Add(resultFor);
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

        public dynamic BuscarColaboradorDadoPrincipalPorId(int Id)
        {
            try
            {
                var result = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(Id);
                
                if (result != null)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = result.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)result.ColaboradorStatusId);
                    result.ColaboradorStatus = colaboradorStatus;
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
        public dynamic BuscarColaboradorDadoPrincipalPreAdmissaoPorId(int Id)
        {
            try
            {
                var result = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(Id);

                if (result != null)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = result.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)result.ColaboradorStatusId);
                    result.ColaboradorStatus = colaboradorStatus;
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

        public dynamic BuscarColaboradorPorNome(string nomeColaborador)
        {
            try
            {
                var resultRepo = _repoCustomColaboradorDadoPrincipal.GetColaboradorByNome(nomeColaborador);

                var result = new List<ColaboradorModel>();
                foreach (var resultFor in resultRepo)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = resultFor.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor.ColaboradorStatusId);

                    resultFor.ColaboradorStatus = colaboradorStatus;

                    result.Add(resultFor);
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

        public dynamic BuscarColaboradorDadoPrincipalPorCpf(string cpf)
        {
            try
            {
                var result = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyCPF(cpf);

                if (result != null)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = result.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)result.ColaboradorStatusId);
                    result.ColaboradorStatus = colaboradorStatus;
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

        public dynamic BuscarColaboradorPreAdmissaoPorNome(string nomeColaborador)
        {
            try
            {
                var resultRepo = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaoByNome(nomeColaborador);

                var result = new List<ColaboradorModel>();
                foreach (var resultFor in resultRepo)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = resultFor.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor.ColaboradorStatusId);

                    resultFor.ColaboradorStatus = colaboradorStatus;

                    result.Add(resultFor);
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

        public dynamic BuscarGestorPorNome(string nomeGestor)
        {
            try
            {
                var resultRepo = _repoCustomColaboradorDadoPrincipal.GetGestorByNome(nomeGestor);

                var result = new List<ColaboradorModel>();
                foreach (var resultFor in resultRepo)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = resultFor.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor.ColaboradorStatusId);

                    resultFor.ColaboradorStatus = colaboradorStatus;

                    result.Add(resultFor);
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

        public dynamic BuscarColaboradorPorGestorId(int id)
        {
            try
            {
                var result = new List<ColaboradorModel>();

                ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();
                var resultColaboradorEmpregador = colaboradorEmpregadorFacade.BuscarColaboradorEmpregadorPorGestorId(id);

                foreach(var resultFor in resultColaboradorEmpregador)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = resultFor.Colaborador.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor.Colaborador.ColaboradorStatusId);
                    resultFor.Colaborador.ColaboradorStatus = colaboradorStatus;
                    result.Add(resultFor.Colaborador);
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

        public dynamic BuscarColaboradorPorMatricula(string matricula)
        {
            try
            {
                var result = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyMatricula(matricula);

                if (result != null)
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = result.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)result.ColaboradorStatusId);
                    result.ColaboradorStatus = colaboradorStatus;
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

        public dynamic BuscarTudoColaboradorTipo()
        {
            try
            {
                var result = _repoDefaultColaboradorTipo.GetAll();
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

        public dynamic BuscarTudoColaboradorStatus()
        {
            try
            {

                var result = new List<ColaboradorStatusModel>();
                foreach (var resultFor in Enum.GetValues(typeof(ColaboradorStatusEnum)))
                {
                    var colaboradorStatus = new ColaboradorStatusModel();
                    if (resultFor.ToString() != "PRE_ADMISSAO")
                    {
                        colaboradorStatus.Id = (int)resultFor;
                        colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)resultFor);
                    }

                    result.Add(colaboradorStatus);
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
        public dynamic AdicionarColaboradorDadoPrincipal(ColaboradorModel colaborador)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaborador);
                if (validacaoEntrada.Codigo == 0)
                {
                    var fotoNome = SalvarFoto(colaborador);
                    colaborador.FotoNome = fotoNome;
                    colaborador.DataCadastro = DateTime.Now;
                    _repoDefaultColaboradorDadoPrincipal.Add(colaborador);
                    _unitOfWork.Commit();

                    _loginFacade.AdicionarLogin(colaborador.CPF, colaborador.Id, (int)UsuarioColaboradorTipoEnum.COLABORADOR, colaborador.Nome, colaborador.Email);

                    var result = new ColaboradorModel();
                    if (colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                        result = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaborador.Id);
                    else
                        result = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaborador.Id); 

                    var colaboradorStatus = new ColaboradorStatusModel();
                    colaboradorStatus.Id = result.ColaboradorStatusId;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((ColaboradorStatusEnum)result.ColaboradorStatusId);
                    result.ColaboradorStatus = colaboradorStatus;
                    result.FotoBase64 = null;

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

        public bool EnviarEmailColaborador(string email, string nome, string mensagem, string cpf)
        {
            bool toEmailValidade = Mail.MailValide(email);

            if (toEmailValidade)
            {
                LoginModel login = _repoCustomLogin.GetLoginByCpf(cpf);

                string emailMessage = Mail.GetTemplateHtml(MailType.TemplateEmailReenvio);
                emailMessage = emailMessage.Replace("#ReceiverName#", nome);
                emailMessage = emailMessage.Replace("#Message#", mensagem);
                emailMessage = emailMessage.Replace("#Senha#", string.Concat("Sua senha é: " , login.Senha));
                emailMessage = emailMessage.Replace("#Url#", string.Concat(Mail.GetMailUrl()));
                try
                {
                    Mail.SendEmail(email, "Bem-vindo ao MeuRHOnline!", emailMessage, true);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            } 
        }

        public dynamic AprovarColaboradorPreAdmissao(int colaboradorId)
        {
            dynamic result;

            try
            {
                var colaboradorResult = new ColaboradorModel();

                colaboradorResult = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaboradorId);

                if (colaboradorResult != null)
                {
                    colaboradorResult.ColaboradorStatusId = (int)ColaboradorStatusEnum.ATIVO;
                    _unitOfWork.Commit();
                }
                else
                    result = "Registro não encontrado";

                return colaboradorResult;               
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

        public dynamic EditarColaboradorDadoPrincipal(ColaboradorModel colaborador)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntradaEditar(colaborador);
                if (validacaoEntrada.Codigo == 0)
                {
                    var colaboradorResult = new ColaboradorModel();

                    if (colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                        colaboradorResult = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaborador.Id);
                    else
                        colaboradorResult = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaborador.Id);                    

                    if (colaboradorResult != null)
                    {
                        colaboradorResult.FotoBase64 = colaborador.FotoBase64;
                        var fotoNome = AtualizarFoto(colaboradorResult);

                        colaboradorResult.Nome = colaborador.Nome;
                        colaboradorResult.EmpresaId = colaborador.EmpresaId;
                        colaboradorResult.ColaboradorTipoId = colaborador.ColaboradorTipoId;
                        colaboradorResult.CPF = colaborador.CPF;
                        colaboradorResult.Sexo = colaborador.Sexo;
                        colaboradorResult.Endereco = colaborador.Endereco;
                        colaboradorResult.Numero = colaborador.Numero;
                        colaboradorResult.Complemento = colaborador.Complemento;
                        colaboradorResult.Bairro = colaborador.Bairro;
                        colaboradorResult.CEP = colaborador.CEP;
                        colaboradorResult.UF = colaborador.UF;
                        colaboradorResult.Cidade = colaborador.Cidade;
                        colaboradorResult.DataNascimento = colaborador.DataNascimento;
                        colaboradorResult.Telefone1 = colaborador.Telefone1;
                        colaboradorResult.Telefone2 = colaborador.Telefone2;
                        colaboradorResult.Telefone3 = colaborador.Telefone3;
                        colaboradorResult.Email = colaborador.Email;
                        colaboradorResult.NomePai = colaborador.NomePai;
                        colaboradorResult.NomeMae = colaborador.NomeMae;
                        colaboradorResult.MatriculaInterna = colaborador.MatriculaInterna;
                        colaboradorResult.MatriculaeSocial = colaborador.MatriculaeSocial;
                        colaboradorResult.PaisNascimento = colaborador.PaisNascimento;
                        colaboradorResult.UFNascimento = colaborador.UFNascimento;
                        colaboradorResult.CidadeNascimento = colaborador.CidadeNascimento;
                        colaboradorResult.FotoNome = fotoNome;
                        colaboradorResult.GrauInstrucaoId = colaborador.GrauInstrucaoId;
                        colaboradorResult.EstadoCivilId = colaborador.EstadoCivilId;
                        colaboradorResult.ColaboradorStatusId = colaborador.ColaboradorStatusId;

                        _unitOfWork.Commit();                      
                        
                        if (colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            result = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaboradorResult.Id);
                        else
                            result = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorResult.Id);
                    }
                    else
                        result = "Registro não encontrado";

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

        private string SalvarFoto(ColaboradorModel colaborador)
        {
            string fotoNome = string.Empty;
            if (!string.IsNullOrEmpty(colaborador.FotoBase64))
            {
                var fileName = Guid.NewGuid().ToString();
                fotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorFoto.Value, colaborador.FotoBase64, fileName);
            }

            return fotoNome;
        }

        private string AtualizarFoto(ColaboradorModel colaborador)
        {
            string novoFotoNome = colaborador.FotoNome;
            if (!string.IsNullOrEmpty(colaborador.FotoBase64))
            {
                if (!string.IsNullOrEmpty(colaborador.FotoNome))
                    FileOperation.ExcluirDocumentoImagem(FileType.PathColaboradorFoto.Value, colaborador.FotoNome);

                var fileName = Guid.NewGuid().ToString();
                novoFotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorFoto.Value, colaborador.FotoBase64, fileName);
            }

            return novoFotoNome;
        }

        public dynamic BuscarFoto(int id)
        {
            dynamic result;

            var resultColaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(id);

            if (resultColaborador != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorFoto.Value, resultColaborador.FotoNome);
                if (!string.IsNullOrEmpty(imageBase64))
                {
                    result = imageBase64;
                }
                else
                {
                    result = "Documento não encontrado";
                }
            }
            else
            {
                result = "Registro não encontrado";
            }

            return result;

        }

        private void ExcluirFoto(ColaboradorModel colaborador)
        {
            if (!string.IsNullOrEmpty(colaborador.FotoNome))
                FileOperation.ExcluirDocumentoImagem(FileType.PathColaboradorFoto.Value, colaborador.FotoNome);
        }

        public void AlteracaoCadastralColaboradorDadoPrincipal(AlteracaoCadastralModel alteracaoCadastral)
        {
            try
            {
                var colaboradorResult = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(alteracaoCadastral.ColaboradorId);

                if (colaboradorResult != null)
                {
                    ExcluirFoto(colaboradorResult);

                    colaboradorResult.Nome = alteracaoCadastral.Nome;
                    colaboradorResult.Endereco = alteracaoCadastral.Endereco;
                    colaboradorResult.Numero = alteracaoCadastral.Numero;
                    colaboradorResult.Complemento = alteracaoCadastral.Complemento;
                    colaboradorResult.Bairro = alteracaoCadastral.Bairro;
                    colaboradorResult.CEP = alteracaoCadastral.CEP;
                    colaboradorResult.UF = alteracaoCadastral.UF;
                    colaboradorResult.Cidade = alteracaoCadastral.Cidade;
                    colaboradorResult.Telefone1 = alteracaoCadastral.Telefone1;
                    colaboradorResult.Telefone2 = alteracaoCadastral.Telefone2;
                    colaboradorResult.Telefone3 = alteracaoCadastral.Telefone3;
                    colaboradorResult.Email = alteracaoCadastral.Email;
                    colaboradorResult.FotoNome = alteracaoCadastral.FotoNome;
                    _unitOfWork.Commit();
                }
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

        public void MovimentacaoContratualColaboradorDadoPrincipal(MovimentacaoContratualModel movimentacaoContratual)
        {
            try
            {
                var colaboradorResult = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(movimentacaoContratual.ColaboradorId);

                if (colaboradorResult != null)
                {
                    colaboradorResult.EmpresaId = movimentacaoContratual.EmpresaId;
                    _unitOfWork.Commit();
                }
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
        public bool ExcluirDadoPrincipalColaboradorPreAdmissao(int id)
        {
            try
            {
                var result = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(id);
                if (result != null)
                {
                    _repoCustomLogin.DeleteLoginByIdUsuarioColaborador(result.Id, result.ColaboradorTipoId);
                    _repoDefaultColaboradorDadoPrincipal.Delete(result);
                    _unitOfWork.Commit();
                }
                return true;
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

        public void AtualizarDesligamentoColaborador(int id)
        {
            try
            {
                ColaboradorModel colaboradorResult = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(id);

                if (colaboradorResult != null)
                {
                    colaboradorResult.ColaboradorStatusId = (int)ColaboradorStatusEnum.DESLIGADO;
                    _unitOfWork.Commit();
                }
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

        private ErrorModel ValidacaoEntrada(ColaboradorModel colaborador)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(colaborador.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else if (colaborador.EmpresaId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Empresa";
            }
            else if (colaborador.ColaboradorTipoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Tipo";
            }
            else if (string.IsNullOrEmpty(colaborador.CPF))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o CPF";
            }
            else if (string.IsNullOrEmpty(colaborador.Email))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Email";
            }
            else
            {
                var result = _repoCustomColaboradorDadoPrincipal.GetColaboradorValidation(colaborador);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoEntradaEditar(ColaboradorModel colaborador)
        {
            var erroModel = new ErrorModel();

            if (colaborador.EmpresaId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Empresa";
            }
            else if (colaborador.ColaboradorTipoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Tipo";
            }
            else if (string.IsNullOrEmpty(colaborador.CPF))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o CPF";
            }
            else if (string.IsNullOrEmpty(colaborador.Email))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Email";
            }

            return erroModel;
        }

        private bool GestorEmpresaPodeVerSalario(int empresaId)
        {
            var funcionalidadesEmpresa = (List<EmpresaEmpresaFuncionalidadeModel>)_repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(empresaId);

            return funcionalidadesEmpresa.Any(x => x.EmpresaFuncionalidadeId == Constantes.FUNCIONALIDADE_EMPRESA_VER_SALARIO);
        }

        private bool EhPerfilRH(ColaboradorModel colaborador)
        {
            var login = _loginFacade.RecuperaLoginByIdUsuarioColaborador(colaborador.Id, (int)UsuarioColaboradorTipoEnum.USUARIO);
            return login != null;
        }
    }
}
