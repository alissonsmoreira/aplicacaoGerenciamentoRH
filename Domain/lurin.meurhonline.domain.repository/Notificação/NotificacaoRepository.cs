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
    public class NotificacaoRepository : INotificacaoRepository<NotificacaoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public NotificacaoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public async Task<NotificacaoModel> GetNotificacaoByIdAsync(int id)
        {
            var result = _db.Notificacao
                            .Include(x => x.NotificacaoDetalhe)                            
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            return await result;
        }

        public NotificacaoModel GetNotificacaoById(int id)
        {
            var result = _db.Notificacao
                            .Include(x => x.NotificacaoDetalhe)                            
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<NotificacaoModel> GetNotificacaoUsuario(int NotificacaoStatusLeituraId)
        {            
            var result = _db.Notificacao
                            .Include(x => x.NotificacaoDetalhe)                                
                            .Where(x => x.NotificacaoStatusLeituraId == NotificacaoStatusLeituraId)
                            .Where(x => x.NotificacaoDetalhe.UsuarioPermissao.ToUpper().Equals("S"))
                            .ToList();          

            return result;
        }

        public IEnumerable<NotificacaoModel> GetNotificacaoGestor(int NotificacaoStatusLeituraId)
        {
            var result = _db.Notificacao
                            .Include(x => x.NotificacaoDetalhe)
                            .Where(x => x.NotificacaoStatusLeituraId == NotificacaoStatusLeituraId)
                            .Where(x => x.NotificacaoDetalhe.GestorPermissao.ToUpper().Equals("S"))
                            .ToList();

            return result;
        }

        public IEnumerable<NotificacaoModel> GetNotificacaoByNotificacaoDetalheId(int id)
        {
            var result = _db.Notificacao                            
                            .Where(x => x.NotificacaoDetalheId == id)
                            .Where(x => x.NotificacaoStatusLeituraId == (int)NotificacaoStatusLeituraEnum.NAO_LIDO)
                            .ToList();

            return result;
        }
    }
}