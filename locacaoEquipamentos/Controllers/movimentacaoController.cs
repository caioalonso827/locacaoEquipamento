using locacaoEquipamentos.models;
using locacaoEquipamentos.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace locacaoEquipamentos.Controllers
{
    [ApiController]
    [Route("Equipamento")]
    public class movimentacaoController : ControllerBase
    {
        private readonly movimentacaoService _movimentacaoService;

        public movimentacaoController(movimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost("cadastrarMovimentacao")]
        public String cadastrarMovimentacao(Movimentacao movimentacao)
        {
            return _movimentacaoService.cadastrarMovimentacao(movimentacao);
        }


        [HttpGet("listarMovimentacoes")]
        public List<Movimentacao> listarMovimentacoes()
        {
            return _movimentacaoService.listarMovimentacoes();
        }
    }
}
