using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ColaboradorPagamentoRepository : IColaboradorPagamentoRepository<ColaboradorPagamentoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ColaboradorPagamentoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ColaboradorPagamentoModel GetColaboradorPagamentobyId(int id)
        {
            var result = _db.ColaboradorPagamento
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.Id == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorPagamentoModel GetColaboradorPagamentoPreAdmissaobyId(int id)
        {
            var result = _db.ColaboradorPagamento
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.ColaboradorId == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorPagamentoModel GetColaboradorPagamentoEditarById(int id)
        {
            var result = _db.ColaboradorPagamento
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.Id == id)                            
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorPagamentoModel> GetColaboradorPagamento(ColaboradorPagamentoModel colaboradorPagamento)
        {
            var result = _db.ColaboradorPagamento
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorPagamento.ColaboradorId != 0 ? x.ColaboradorId == colaboradorPagamento.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => colaboradorPagamento.BancoId != 0 ? x.BancoId == colaboradorPagamento.BancoId : x.BancoId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorPagamento.Agencia) ? x.Agencia.Contains(colaboradorPagamento.Agencia) : x.Agencia == x.Agencia)
                            .Where(x => !string.IsNullOrEmpty(colaboradorPagamento.Conta) ? x.Conta.Contains(colaboradorPagamento.Conta) : x.Conta == x.Conta)
                            .Where(x => colaboradorPagamento.ContaBancariaTipoId != 0 ? x.ContaBancariaTipoId == colaboradorPagamento.ContaBancariaTipoId : x.ContaBancariaTipoId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorPagamentoModel> GetColaboradorPreAdmissaoPagamento(ColaboradorPagamentoModel colaboradorPagamento)
        {
            var result = _db.ColaboradorPagamento
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorPagamento.ColaboradorId != 0 ? x.ColaboradorId == colaboradorPagamento.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => colaboradorPagamento.BancoId != 0 ? x.BancoId == colaboradorPagamento.BancoId : x.BancoId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorPagamento.Agencia) ? x.Agencia.Contains(colaboradorPagamento.Agencia) : x.Agencia == x.Agencia)
                            .Where(x => !string.IsNullOrEmpty(colaboradorPagamento.Conta) ? x.Conta.Contains(colaboradorPagamento.Conta) : x.Conta == x.Conta)
                            .Where(x => colaboradorPagamento.ContaBancariaTipoId != 0 ? x.ContaBancariaTipoId == colaboradorPagamento.ContaBancariaTipoId : x.ContaBancariaTipoId != 0)
                            .ToList();

            return result;
        }

        public ColaboradorPagamentoModel GetColaboradorPagamentoValidation(ColaboradorPagamentoModel colaboradorPagamento)
        {
            var result = _db.ColaboradorPagamento
                            .Where(x => colaboradorPagamento.Id != 0 ? x.Id != colaboradorPagamento.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == colaboradorPagamento.ColaboradorId)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorPagamentoModel GetColaboradorPagamentobyColaboradorId(int id)
        {
            var result = _db.ColaboradorPagamento
                            .Include(x => x.Banco)
                            .Include(x => x.ContaBancariaTipo)
                            .Where(x => x.ColaboradorId == id)
                            .FirstOrDefault();

            return result;
        }
    }
}