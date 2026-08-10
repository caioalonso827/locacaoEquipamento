using locacaoEquipamentos.models;
using locacaoEquipamentos.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace locacaoEquipamentos.Controllers
{
    [ApiController]
    [Route("Equipamento")]
    public class equipamentoController
    {
        private readonly equipamentoService _equipamentoService;


        public equipamentoController(equipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpGet]
        public List<Equipamento> listarEquipamentos()
        {
            return _equipamentoService.listarEquipamentos();
        }

        [HttpPut]
        public Equipamento atualizarEquipamento(Equipamento equipamento)
        {
            return _equipamentoService.atualizarEquipamento(equipamento);
        }
    }
}
