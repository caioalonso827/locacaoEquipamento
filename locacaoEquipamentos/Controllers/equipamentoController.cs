using locacaoEquipamentos.models;
using locacaoEquipamentos.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace locacaoEquipamentos.Controllers
{
    [ApiController]
    [Route("Equipamento")]
    public class equipamentoController :ControllerBase
    {
        private readonly equipamentoService _equipamentoService;


        public equipamentoController(equipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpGet("listarEquipamentos")]
        public List<equipamentos> listarEquipamentos()
        {
            return _equipamentoService.listarEquipamentos();
        }

        [HttpPut("AtualizarEquipamentos")]
        public equipamentos atualizarEquipamento(equipamentos equipamento)
        {
            return _equipamentoService.atualizarEquipamento(equipamento);
        }
    }
}
