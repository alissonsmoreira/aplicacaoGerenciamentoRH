using System.Linq;
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
    public class Notificacao : INotificacao<NotificacaoModel>
    {
        private static dynamic _repoDefaultNotificacao;
        private static dynamic _repoCustomNotificacao;

        private static dynamic _repoCustomColaborador;
        private static dynamic _repoCustomEmpresaEmpresaFuncionalidade;

        public Notificacao(IUnitOfWork unitOfWork)
        {
            _repoDefaultNotificacao = RepositoryFactory.CreateRepository<NotificacaoModel, Repository<NotificacaoModel>>(unitOfWork);
            _repoCustomNotificacao = RepositoryFactory.CreateRepositoryCustom<NotificacaoModel, NotificacaoRepository>(unitOfWork);

            _repoCustomColaborador = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(unitOfWork);
            _repoCustomEmpresaEmpresaFuncionalidade = RepositoryFactory.CreateRepositoryCustom<EmpresaEmpresaFuncionalidadeModel, EmpresaEmpresaFuncionalidadeRepository>(unitOfWork);
        }

        public List<NotificacaoModel> BuscarNotificacao(int idUsuarioColaborador, int idUsuarioColaboradorTipo, ColaboradorModel colaborador, bool validaFuncionalidade)
        {
            var result = new List<NotificacaoModel>();

            var dictCountMsg = new Dictionary<int, int>();
            var keyDictMsg = 0;

            var resultRepo = new List<NotificacaoModel>();
            if (idUsuarioColaboradorTipo == (int)UsuarioColaboradorTipoEnum.USUARIO)
                resultRepo = _repoCustomNotificacao.GetNotificacaoUsuario((int)NotificacaoStatusLeituraEnum.NAO_LIDO);
            else if (idUsuarioColaboradorTipo == (int)UsuarioColaboradorTipoEnum.COLABORADOR)
            {                                
                //GESTOR
                if (colaborador.ColaboradorTipoId == 1)
                    resultRepo = _repoCustomNotificacao.GetNotificacaoGestor((int)NotificacaoStatusLeituraEnum.NAO_LIDO);
            }

            foreach (var resultFor in resultRepo)
            {
                var resultDetalheExist = result.Where(x => x.NotificacaoDetalheId == resultFor.NotificacaoDetalheId).ToList();

                if (resultDetalheExist.Count > 0)
                {
                    dictCountMsg.Add(keyDictMsg, resultFor.NotificacaoDetalheId);
                    keyDictMsg += 1;

                    var valorCountMsg = dictCountMsg.Where(x => x.Value == resultFor.NotificacaoDetalheId).ToList();

                    //ATUALIZA A PROPRIEDADE MENSAGEM DA LISTA COM A MENSAGEM NO PLURAL E QUANTIDADE
                    result.Where(x => x.NotificacaoDetalheId == resultFor.NotificacaoDetalheId).Select(s => { s.NotificacaoDetalhe.Mensagem = string.Concat(valorCountMsg.Count + 1, " ", resultFor.NotificacaoDetalhe.MensagemPlural); return s; }).ToList();
                }
                else
                {
                    if (idUsuarioColaboradorTipo == (int)UsuarioColaboradorTipoEnum.COLABORADOR)
                    {
                        //APROVAÇÃO DE HORA EXTRA GESTOR
                        if (resultFor.NotificacaoDetalheId == 7 && !validaFuncionalidade)
                            continue;
                    } 
                    else if (idUsuarioColaboradorTipo == (int)UsuarioColaboradorTipoEnum.USUARIO)
                    {
                        //APROVAÇÃO DE HORA EXTRA GESTOR
                        if (resultFor.NotificacaoDetalheId == 7)
                            continue;
                    }

                    var notificacaoStatusLeitura = new NotificacaoStatusLeituraModel();
                    notificacaoStatusLeitura.Id = resultFor.NotificacaoStatusLeituraId;
                    notificacaoStatusLeitura.Nome = Utils.GetEnumDescription((NotificacaoStatusLeituraEnum)resultFor.NotificacaoStatusLeituraId);
                    resultFor.NotificacaoStatusLeitura = notificacaoStatusLeitura;

                    var notificacaoDetalheStatus = new NotificacaoDetalheStatusModel();
                    notificacaoDetalheStatus.Id = resultFor.NotificacaoDetalhe.NotificacaoDetalheStatusId;
                    notificacaoDetalheStatus.Nome = Utils.GetEnumDescription((NotificacaoDetalheStatusEnum)resultFor.NotificacaoDetalhe.NotificacaoDetalheStatusId);
                    resultFor.NotificacaoDetalhe.NotificacaoDetalheStatus = notificacaoDetalheStatus;

                    resultFor.NotificacaoDetalhe.Mensagem = string.Concat("1 ", resultFor.NotificacaoDetalhe.MensagemSingular);

                    result.Add(resultFor);
                }
            }

            return result;            
        }
    }
}