using locacaoEquipamentos.models;
using locacaoEquipamentos.models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace locacaoEquipamentos.Services.Service
{
   
    public class movimentacaoService
    {
        private readonly AppDbContext _appDbContext;

        public movimentacaoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public String cadastrarMovimentacao(Movimentacao movimentacao)
        {
            if (movimentacao.Tipo == Tipo.ENTRADA)
            {
                var equipamentoExistente = _appDbContext.Equipamentos.Find(movimentacao.equipamento_id);
                if (equipamentoExistente == null)
                {
                    throw new Exception("Equipamento não encontrado.");
                }
                equipamentoExistente.Quantidade += movimentacao.Quantidades;

            }
            else if (movimentacao.Tipo == Tipo.SAIDA)
            {
                var equipamentoExistente = _appDbContext.Equipamentos.Find(movimentacao.equipamento_id);
                if (equipamentoExistente == null)
                {
                    throw new Exception("Equipamento não encontrado.");
                }
                if (equipamentoExistente.Quantidade < movimentacao.Quantidades)
                {
                    throw new Exception("Quantidade insuficiente em estoque.");
                }
                equipamentoExistente.Quantidade -= movimentacao.Quantidades;
            }
            else
            {
                throw new Exception("Tipo de movimentação inválido.");
            }
            _appDbContext.Movimentacaos.Add(movimentacao);
            _appDbContext.SaveChanges();
            return "Movimentação cadastrada com sucesso!";
        }

        public List<Movimentacao> listarMovimentacoes()
        {
            var lista = _appDbContext.Movimentacaos.ToList();
            return lista;
        }
    }
}
