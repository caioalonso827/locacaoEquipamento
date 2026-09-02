using locacaoEquipamentos.models;
using Microsoft.AspNetCore.Mvc;

namespace locacaoEquipamentos.Services.Service
{
    [ApiController]
    [Route("Equipamento")]
    public class equipamentoService
    {
        private readonly AppDbContext _appDbContext;

        public equipamentoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public List<equipamentos> listarEquipamentos()
        {
            var lista = _appDbContext.equipamentos.ToList();
            return lista;

        }

        [HttpPut]
        public equipamentos atualizarEquipamento(equipamentos equipamento)
        {
            var equipamentoExistente = _appDbContext.equipamentos.Find(equipamento.id);
            if (equipamentoExistente == null)
            {
                throw new Exception("Equipamento não encontrado.");
            }
            equipamentoExistente.nome = equipamento.nome;
            equipamentoExistente.quantidade = equipamento.quantidade;
            _appDbContext.SaveChanges();
            return equipamentoExistente;
        }

        [HttpDelete("{id}")]
        public void deletarEquipamento(int id)
        {
            var equipamentoExistente = _appDbContext.equipamentos.Find(id);
            if (equipamentoExistente == null)
            {
                throw new Exception("Equipamento não encontrado.");
            }
            _appDbContext.equipamentos.Remove(equipamentoExistente);
            _appDbContext.SaveChanges();
        }
    }
}
