using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ColaboradorDocumentacaoRepository : IColaboradorDocumentacaoRepository<ColaboradorDocumentacaoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ColaboradorDocumentacaoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ColaboradorDocumentacaoModel GetColaboradorDocumentacaobyId(int id)
        {
            var result = _db.ColaboradorDocumentacao
                            .Include(x => x.Colaborador.Empresa)
                            .Where(x => x.Id == id)
                            //.Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorDocumentacaoModel GetColaboradorDocumentacaoPreAdmissaobyId(int id)
        {
            var result = _db.ColaboradorDocumentacao
                            .Include(x => x.Colaborador.Empresa)
                            .Where(x => x.ColaboradorId == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorDocumentacaoModel GetColaboradorDocumentacaoEditarById(int id)
        {
            var result = _db.ColaboradorDocumentacao
                            .Include(x => x.Colaborador.Empresa)
                            .Where(x => x.Id == id)                            
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorDocumentacaoModel> GetColaboradorDocumentacao(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            var result = _db.ColaboradorDocumentacao
                            .Include(x => x.Colaborador.Empresa)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorDocumentacao.ColaboradorId != 0 ? x.ColaboradorId == colaboradorDocumentacao.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.RG) ? x.RG.Contains(colaboradorDocumentacao.RG) : x.RG != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.OrgaoEmissorRG) ? x.OrgaoEmissorRG.Contains(colaboradorDocumentacao.OrgaoEmissorRG) : x.OrgaoEmissorRG == x.OrgaoEmissorRG)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFEmissaoRG) ? x.UFEmissaoRG.Contains(colaboradorDocumentacao.UFEmissaoRG) : x.UFEmissaoRG == x.UFEmissaoRG)
                            .Where(x => colaboradorDocumentacao.DataEmissaoRG != null ? x.DataEmissaoRG == colaboradorDocumentacao.DataEmissaoRG : x.DataEmissaoRG == x.DataEmissaoRG)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.RIC) ? x.RIC.Contains(colaboradorDocumentacao.RIC) : x.RIC == x.RIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFEmissaoRIC) ? x.UFEmissaoRIC.Contains(colaboradorDocumentacao.UFEmissaoRIC) : x.UFEmissaoRIC == x.UFEmissaoRIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CidadeEmissaoRIC) ? x.CidadeEmissaoRIC.Contains(colaboradorDocumentacao.CidadeEmissaoRIC) : x.CidadeEmissaoRIC == x.CidadeEmissaoRIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.OrgaoEmissorRIC) ? x.OrgaoEmissorRIC.Contains(colaboradorDocumentacao.OrgaoEmissorRIC) : x.OrgaoEmissorRIC == x.OrgaoEmissorRIC)
                            .Where(x => colaboradorDocumentacao.DataExpedicaoRIC != null ? x.DataExpedicaoRIC == colaboradorDocumentacao.DataExpedicaoRIC : x.DataExpedicaoRIC == x.DataExpedicaoRIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.ZonaEleitoral) ? x.ZonaEleitoral.Contains(colaboradorDocumentacao.RIC) : x.ZonaEleitoral == x.ZonaEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.SecaoEleitoral) ? x.SecaoEleitoral.Contains(colaboradorDocumentacao.SecaoEleitoral) : x.SecaoEleitoral == x.SecaoEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFEleitoral) ? x.UFEleitoral.Contains(colaboradorDocumentacao.UFEleitoral) : x.UFEleitoral == x.UFEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CidadeEleitoral) ? x.CidadeEleitoral.Contains(colaboradorDocumentacao.CidadeEleitoral) : x.CidadeEleitoral == x.CidadeEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CarteiraHabilitacao) ? x.CarteiraHabilitacao.Contains(colaboradorDocumentacao.CarteiraHabilitacao) : x.CarteiraHabilitacao == x.CarteiraHabilitacao)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CategoriaHabilitacao) ? x.CategoriaHabilitacao.Contains(colaboradorDocumentacao.CategoriaHabilitacao) : x.CategoriaHabilitacao == x.CategoriaHabilitacao)
                            .Where(x => colaboradorDocumentacao.DataVencimentoHabilitacao != null ? x.DataVencimentoHabilitacao == colaboradorDocumentacao.DataVencimentoHabilitacao : x.DataVencimentoHabilitacao == x.DataVencimentoHabilitacao)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.NumeroCTPS) ? x.NumeroCTPS.Contains(colaboradorDocumentacao.NumeroCTPS) : x.NumeroCTPS == x.NumeroCTPS)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.SerieCTPS) ? x.SerieCTPS.Contains(colaboradorDocumentacao.SerieCTPS) : x.SerieCTPS == x.SerieCTPS)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFCTPS) ? x.UFCTPS.Contains(colaboradorDocumentacao.UFCTPS) : x.UFCTPS == x.UFCTPS)
                            .Where(x => colaboradorDocumentacao.DataEmissaoCTPS != null ? x.DataEmissaoCTPS == colaboradorDocumentacao.DataEmissaoCTPS : x.DataEmissaoCTPS == x.DataEmissaoCTPS)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.PISNITNIS) ? x.PISNITNIS.Contains(colaboradorDocumentacao.PISNITNIS) : x.PISNITNIS == x.PISNITNIS)
                            .Where(x => colaboradorDocumentacao.DataEmissaoPISNITNIS != null ? x.DataEmissaoPISNITNIS == colaboradorDocumentacao.DataEmissaoPISNITNIS : x.DataEmissaoPISNITNIS == x.DataEmissaoPISNITNIS)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorDocumentacaoModel> GetColaboradorPreAdmissaoDocumentacao(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            var result = _db.ColaboradorDocumentacao
                            .Include(x => x.Colaborador.Empresa)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorDocumentacao.ColaboradorId != 0 ? x.ColaboradorId == colaboradorDocumentacao.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.RG) ? x.RG.Contains(colaboradorDocumentacao.RG) : x.RG != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.OrgaoEmissorRG) ? x.OrgaoEmissorRG.Contains(colaboradorDocumentacao.OrgaoEmissorRG) : x.OrgaoEmissorRG == x.OrgaoEmissorRG)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFEmissaoRG) ? x.UFEmissaoRG.Contains(colaboradorDocumentacao.UFEmissaoRG) : x.UFEmissaoRG == x.UFEmissaoRG)
                            .Where(x => colaboradorDocumentacao.DataEmissaoRG != null ? x.DataEmissaoRG == colaboradorDocumentacao.DataEmissaoRG : x.DataEmissaoRG == x.DataEmissaoRG)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.RIC) ? x.RIC.Contains(colaboradorDocumentacao.RIC) : x.RIC == x.RIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFEmissaoRIC) ? x.UFEmissaoRIC.Contains(colaboradorDocumentacao.UFEmissaoRIC) : x.UFEmissaoRIC == x.UFEmissaoRIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CidadeEmissaoRIC) ? x.CidadeEmissaoRIC.Contains(colaboradorDocumentacao.CidadeEmissaoRIC) : x.CidadeEmissaoRIC == x.CidadeEmissaoRIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.OrgaoEmissorRIC) ? x.OrgaoEmissorRIC.Contains(colaboradorDocumentacao.OrgaoEmissorRIC) : x.OrgaoEmissorRIC == x.OrgaoEmissorRIC)
                            .Where(x => colaboradorDocumentacao.DataExpedicaoRIC != null ? x.DataExpedicaoRIC == colaboradorDocumentacao.DataExpedicaoRIC : x.DataExpedicaoRIC == x.DataExpedicaoRIC)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.ZonaEleitoral) ? x.ZonaEleitoral.Contains(colaboradorDocumentacao.RIC) : x.ZonaEleitoral == x.ZonaEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.SecaoEleitoral) ? x.SecaoEleitoral.Contains(colaboradorDocumentacao.SecaoEleitoral) : x.SecaoEleitoral == x.SecaoEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFEleitoral) ? x.UFEleitoral.Contains(colaboradorDocumentacao.UFEleitoral) : x.UFEleitoral == x.UFEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CidadeEleitoral) ? x.CidadeEleitoral.Contains(colaboradorDocumentacao.CidadeEleitoral) : x.CidadeEleitoral == x.CidadeEleitoral)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CarteiraHabilitacao) ? x.CarteiraHabilitacao.Contains(colaboradorDocumentacao.CarteiraHabilitacao) : x.CarteiraHabilitacao == x.CarteiraHabilitacao)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.CategoriaHabilitacao) ? x.CategoriaHabilitacao.Contains(colaboradorDocumentacao.CategoriaHabilitacao) : x.CategoriaHabilitacao == x.CategoriaHabilitacao)
                            .Where(x => colaboradorDocumentacao.DataVencimentoHabilitacao != null ? x.DataVencimentoHabilitacao == colaboradorDocumentacao.DataVencimentoHabilitacao : x.DataVencimentoHabilitacao == x.DataVencimentoHabilitacao)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.NumeroCTPS) ? x.NumeroCTPS.Contains(colaboradorDocumentacao.NumeroCTPS) : x.NumeroCTPS == x.NumeroCTPS)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.SerieCTPS) ? x.SerieCTPS.Contains(colaboradorDocumentacao.SerieCTPS) : x.SerieCTPS == x.SerieCTPS)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.UFCTPS) ? x.UFCTPS.Contains(colaboradorDocumentacao.UFCTPS) : x.UFCTPS == x.UFCTPS)
                            .Where(x => colaboradorDocumentacao.DataEmissaoCTPS != null ? x.DataEmissaoCTPS == colaboradorDocumentacao.DataEmissaoCTPS : x.DataEmissaoCTPS == x.DataEmissaoCTPS)
                            .Where(x => !string.IsNullOrEmpty(colaboradorDocumentacao.PISNITNIS) ? x.PISNITNIS.Contains(colaboradorDocumentacao.PISNITNIS) : x.PISNITNIS == x.PISNITNIS)
                            .Where(x => colaboradorDocumentacao.DataEmissaoPISNITNIS != null ? x.DataEmissaoPISNITNIS == colaboradorDocumentacao.DataEmissaoPISNITNIS : x.DataEmissaoPISNITNIS == x.DataEmissaoPISNITNIS)
                            .ToList();

            return result;
        }

        public ColaboradorDocumentacaoModel GetColaboradorDocumentacaoValidation(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            var result = _db.ColaboradorDocumentacao
                            .Where(x => colaboradorDocumentacao.Id != 0 ? x.Id != colaboradorDocumentacao.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == colaboradorDocumentacao.ColaboradorId)
                            .Where(x => x.RG == colaboradorDocumentacao.RG)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorDocumentacaoModel GetColaboradorDocumentacaobyColaboradorId(int id)
        {
            var result = _db.ColaboradorDocumentacao
                            .Where(x => x.ColaboradorId == id)
                            .FirstOrDefault();

            return result;
        }
    }
}