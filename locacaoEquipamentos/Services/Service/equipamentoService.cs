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
        public List<Equipamento> listarEquipamentos()
        {
            var lista = _appDbContext.Equipamentos.ToList();
            return lista;

        }

        [HttpPut]
        public Equipamento atualizarEquipamento(Equipamento equipamento)
        {
            var equipamentoExistente = _appDbContext.Equipamentos.Find(equipamento.Id);
            if (equipamentoExistente == null)
            {
                throw new Exception("Equipamento não encontrado.");
            }
            equipamentoExistente.Nome = equipamento.Nome;
            equipamentoExistente.Quantidade = equipamento.Quantidade;
            _appDbContext.SaveChanges();
            return equipamentoExistente;
        }

        [HttpDelete("{id}")]
        public void deletarEquipamento(int id)
        {
            var equipamentoExistente = _appDbContext.Equipamentos.Find(id);
            if (equipamentoExistente == null)
            {
                throw new Exception("Equipamento não encontrado.");
            }
            _appDbContext.Equipamentos.Remove(equipamentoExistente);
            _appDbContext.SaveChanges();
        }
    }
}
