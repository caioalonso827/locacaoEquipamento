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

        public String cadastrarMovimentacao(movimentacao movimentacao)
        {
            if (movimentacao.tipo == Tipo.ENTRADA)
            {
                var equipamentoExistente = _appDbContext.equipamentos.Find(movimentacao.equipamento_id);
                if (equipamentoExistente == null)
                {
                    throw new Exception("Equipamento não encontrado.");
                }
                equipamentoExistente.quantidade += movimentacao.quantidade;

            }
            else if (movimentacao.tipo == Tipo.SAIDA)
            {
                var equipamentoExistente = _appDbContext.equipamentos.Find(movimentacao.equipamento_id);
                if (equipamentoExistente == null)
                {
                    throw new Exception("Equipamento não encontrado.");
                }
                if (equipamentoExistente.quantidade < movimentacao.quantidade)
                {
                    throw new Exception("Quantidade insuficiente em estoque.");
                }
                equipamentoExistente.quantidade -= movimentacao.quantidade;
            }
            else
            {
                throw new Exception("Tipo de movimentação inválido.");
            }
            _appDbContext.movimentacao.Add(movimentacao);
            _appDbContext.SaveChanges();
            return "Movimentação cadastrada com sucesso!";
        }

        public List<movimentacao> listarMovimentacoes()
        {
            var lista = _appDbContext.movimentacao.ToList();
            return lista;
        }
    }
}
