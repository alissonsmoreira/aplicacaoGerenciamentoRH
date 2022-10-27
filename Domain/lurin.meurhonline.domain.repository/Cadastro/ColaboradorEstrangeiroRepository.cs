using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class ColaboradorEstrangeiroRepository : IColaboradorEstrangeiroRepository<ColaboradorEstrangeiroModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public ColaboradorEstrangeiroRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public ColaboradorEstrangeiroModel GetColaboradorEstrangeirobyId(int id)
        {
            var result = _db.ColaboradorEstrangeiro
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.ColaboradorEstrangeiroTipoVisto)
                            .Where(x => x.Id == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorEstrangeiroModel GetColaboradorEstrangeiroPreAdmissaobyId(int id)
        {
            var result = _db.ColaboradorEstrangeiro
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.ColaboradorEstrangeiroTipoVisto)
                            .Where(x => x.ColaboradorId == id)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .FirstOrDefault();

            return result;
        }

        public ColaboradorEstrangeiroModel GetColaboradorEstrangeiroEditarById(int id)
        {
            var result = _db.ColaboradorEstrangeiro
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.ColaboradorEstrangeiroTipoVisto)
                            .Where(x => x.Id == id)                            
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<ColaboradorEstrangeiroModel> GetColaboradorEstrangeiro(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            var result = _db.ColaboradorEstrangeiro
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.ColaboradorEstrangeiroTipoVisto)
                            .Where(x => x.Colaborador.ColaboradorStatusId != (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorEstrangeiro.ColaboradorId != 0 ? x.ColaboradorId == colaboradorEstrangeiro.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.Origem) ? x.Origem.Contains(colaboradorEstrangeiro.Origem) : x.Origem == x.Origem)
                            .Where(x => colaboradorEstrangeiro.ColaboradorEstrangeiroTipoVistoId != 0 ? x.ColaboradorEstrangeiroTipoVistoId == colaboradorEstrangeiro.ColaboradorEstrangeiroTipoVistoId : x.ColaboradorEstrangeiroTipoVistoId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.Passaporte) ? x.Passaporte.Contains(colaboradorEstrangeiro.Passaporte) : x.Passaporte == x.Passaporte)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.PaisEmissorPassaporte) ? x.PaisEmissorPassaporte.Contains(colaboradorEstrangeiro.PaisEmissorPassaporte) : x.PaisEmissorPassaporte == x.PaisEmissorPassaporte)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.UFPassaporte) ? x.UFPassaporte.Contains(colaboradorEstrangeiro.UFPassaporte) : x.UFPassaporte == x.UFPassaporte)
                            .Where(x => colaboradorEstrangeiro.DataEmissaoPassaporte != null ? x.DataEmissaoPassaporte == colaboradorEstrangeiro.DataEmissaoPassaporte : x.DataEmissaoPassaporte == x.DataEmissaoPassaporte)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.PortariaNaturalizacao) ? x.PortariaNaturalizacao.Contains(colaboradorEstrangeiro.PortariaNaturalizacao) : x.PortariaNaturalizacao == x.PortariaNaturalizacao)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.IdentidadeEstrangeira) ? x.IdentidadeEstrangeira.Contains(colaboradorEstrangeiro.IdentidadeEstrangeira) : x.IdentidadeEstrangeira == x.IdentidadeEstrangeira)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.ValidadeIdentidadeEstrangeira) ? x.ValidadeIdentidadeEstrangeira.Contains(colaboradorEstrangeiro.ValidadeIdentidadeEstrangeira) : x.ValidadeIdentidadeEstrangeira == x.ValidadeIdentidadeEstrangeira)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.AnoChegada) ? x.AnoChegada.Contains(colaboradorEstrangeiro.AnoChegada) : x.AnoChegada == x.AnoChegada)
                            .ToList();

            return result;
        }

        public IEnumerable<ColaboradorEstrangeiroModel> GetColaboradorPreAdmissaoEstrangeiro(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            var result = _db.ColaboradorEstrangeiro
                            .Include(x => x.Colaborador.Empresa)
                            .Include(x => x.ColaboradorEstrangeiroTipoVisto)
                            .Where(x => x.Colaborador.ColaboradorStatusId == (int)ColaboradorStatusEnum.PRE_ADMISSAO)
                            .Where(x => colaboradorEstrangeiro.ColaboradorId != 0 ? x.ColaboradorId == colaboradorEstrangeiro.ColaboradorId : x.ColaboradorId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.Origem) ? x.Origem.Contains(colaboradorEstrangeiro.Origem) : x.Origem != string.Empty)
                            .Where(x => colaboradorEstrangeiro.ColaboradorEstrangeiroTipoVistoId != 0 ? x.ColaboradorEstrangeiroTipoVistoId == colaboradorEstrangeiro.ColaboradorEstrangeiroTipoVistoId : x.ColaboradorEstrangeiroTipoVistoId != 0)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.Passaporte) ? x.Passaporte.Contains(colaboradorEstrangeiro.Passaporte) : x.Passaporte != string.Empty)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.PaisEmissorPassaporte) ? x.PaisEmissorPassaporte.Contains(colaboradorEstrangeiro.PaisEmissorPassaporte) : x.PaisEmissorPassaporte == x.PaisEmissorPassaporte)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.UFPassaporte) ? x.UFPassaporte.Contains(colaboradorEstrangeiro.UFPassaporte) : x.UFPassaporte == x.UFPassaporte)
                            .Where(x => colaboradorEstrangeiro.DataEmissaoPassaporte != null ? x.DataEmissaoPassaporte == colaboradorEstrangeiro.DataEmissaoPassaporte : x.DataEmissaoPassaporte == x.DataEmissaoPassaporte)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.PortariaNaturalizacao) ? x.PortariaNaturalizacao.Contains(colaboradorEstrangeiro.PortariaNaturalizacao) : x.PortariaNaturalizacao == x.PortariaNaturalizacao)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.IdentidadeEstrangeira) ? x.IdentidadeEstrangeira.Contains(colaboradorEstrangeiro.IdentidadeEstrangeira) : x.IdentidadeEstrangeira == x.IdentidadeEstrangeira)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.ValidadeIdentidadeEstrangeira) ? x.ValidadeIdentidadeEstrangeira.Contains(colaboradorEstrangeiro.ValidadeIdentidadeEstrangeira) : x.ValidadeIdentidadeEstrangeira == x.ValidadeIdentidadeEstrangeira)
                            .Where(x => !string.IsNullOrEmpty(colaboradorEstrangeiro.AnoChegada) ? x.AnoChegada.Contains(colaboradorEstrangeiro.AnoChegada) : x.AnoChegada == x.AnoChegada)
                            .ToList();

            return result;
        }

        public ColaboradorEstrangeiroModel GetColaboradorEstrangeiroValidation(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            var result = _db.ColaboradorEstrangeiro
                            .Where(x => colaboradorEstrangeiro.Id != 0 ? x.Id != colaboradorEstrangeiro.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == colaboradorEstrangeiro.ColaboradorId)
                            .FirstOrDefault();

            return result;
        }
    }
}