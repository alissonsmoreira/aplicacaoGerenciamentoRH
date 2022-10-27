using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class TurnoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultTurno;
        private static dynamic _repoDefaultTurnoDetalhe;
        private static dynamic _repoCustomTurno;
        private static dynamic _repoCustomTurnoDetalhe;

        public TurnoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultTurno = RepositoryFactory.CreateRepository<TurnoModel, Repository<TurnoModel>>(_unitOfWork);
            _repoDefaultTurnoDetalhe = RepositoryFactory.CreateRepository<TurnoDetalheModel, Repository<TurnoDetalheModel>>(_unitOfWork);
            _repoCustomTurno = RepositoryFactory.CreateRepositoryCustom<TurnoModel, TurnoRepository>(_unitOfWork);
            _repoCustomTurnoDetalhe = RepositoryFactory.CreateRepositoryCustom<TurnoDetalheModel, TurnoDetalheRepository>(_unitOfWork);
        }

        public dynamic BuscarTurno(TurnoModel turno)
        {
            try
            {
                var result = _repoCustomTurno.GetTurno(turno);

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

        public dynamic BuscarTudoTurno()
        {
            try
            {
                var result = _repoDefaultTurno.GetAll();

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

        public dynamic BuscarTurnoDetalhePorTurnoId(int id)
        {
            try
            {
                var result = _repoCustomTurno.GetTurnoDetalhebyTurnoId(id);

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

        public dynamic BuscarTurnoDetalhe(TurnoDetalheModel turnoDetalhe)
        {
            try
            {
                var result = _repoCustomTurnoDetalhe.GetTurnoDetalhe(turnoDetalhe);

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

        public dynamic AdicionarTurno(TurnoModel turno)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(turno);
                if (validacaoEntrada.Codigo == 0)
                {
                    turno.DataCadastro = DateTime.Now;
                    _repoDefaultTurno.Add(turno);
                    _unitOfWork.Commit();

                    var result = _repoCustomTurno.GetTurnobyId(turno.Id);

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

        public dynamic AdicionarTurnoDetalhe(TurnoDetalheModel turnoDetalhe)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntradaTurnoDetalhe(turnoDetalhe);
                if (validacaoEntrada.Codigo == 0)
                {
                    turnoDetalhe.DataCadastro = DateTime.Now;
                    _repoDefaultTurnoDetalhe.Add(turnoDetalhe);
                    _unitOfWork.Commit();

                    var result = _repoCustomTurnoDetalhe.GetTurnoDetalhebyId(turnoDetalhe.Id);

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



        public dynamic EditarTurno(TurnoModel turno)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(turno);
                if (validacaoEntrada.Codigo == 0)
                {
                    var TurnoResult = _repoCustomTurno.GetTurnobyId(turno.Id);

                    if (TurnoResult != null)
                    {
                        TurnoResult.Codigo = turno.Codigo;
                        TurnoResult.Descricao = turno.Descricao;

                        _unitOfWork.Commit();

                        result = _repoCustomTurno.GetTurnobyId(TurnoResult.Id);
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

        public dynamic EditarTurnoDetalhe(TurnoDetalheModel turnoDetalhe)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntradaTurnoDetalhe(turnoDetalhe);
                if (validacaoEntrada.Codigo == 0)
                {
                    var TurnoDetalheResult = _repoCustomTurnoDetalhe.GetTurnoDetalhebyId(turnoDetalhe.Id);

                    if (TurnoDetalheResult != null)
                    {
                        TurnoDetalheResult.DiaSemana = turnoDetalhe.DiaSemana;
                        TurnoDetalheResult.HorarioInicial = turnoDetalhe.HorarioInicial;
                        TurnoDetalheResult.HorarioFinal = turnoDetalhe.HorarioFinal;

                        _unitOfWork.Commit();

                        result = _repoCustomTurnoDetalhe.GetTurnoDetalhebyId(turnoDetalhe.Id);
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

        public dynamic ExcluirTurno(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomTurno.GetTurnobyId(id);

                if (result != null)
                {
                    _repoDefaultTurno.Delete(result);
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

        public dynamic ExcluirTurnoDetalhe(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomTurnoDetalhe.GetTurnoDetalhebyId(id);

                if (result != null)
                {
                    _repoDefaultTurnoDetalhe.Delete(result);
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

        private ErrorModel ValidacaoEntrada(TurnoModel turno)
        {
            var erroModel = new ErrorModel();

            if (turno.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código";
            }
            else if (string.IsNullOrEmpty(turno.Descricao))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Descrição";
            }
            else
            {
                var result = _repoCustomTurno.GetTurnoValidation(turno);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoEntradaTurnoDetalhe(TurnoDetalheModel turnoDetalhe)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(turnoDetalhe.DiaSemana))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Dia da Semana";
            }
            else if (string.IsNullOrEmpty(turnoDetalhe.HorarioInicial))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Hora Inicial";
            }
            else if (string.IsNullOrEmpty(turnoDetalhe.HorarioFinal))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Hora Final";
            }
            else
            {
                var result = _repoCustomTurnoDetalhe.GetTurnoDetalheValidation(turnoDetalhe);
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
