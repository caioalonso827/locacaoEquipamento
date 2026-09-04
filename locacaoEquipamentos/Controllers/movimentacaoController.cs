using locacaoEquipamentos.models;
using locacaoEquipamentos.Services.Service;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize]
        [HttpPost("cadastrarMovimentacao")]
        public String cadastrarMovimentacao(movimentacao movimentacao)
        {
            return _movimentacaoService.cadastrarMovimentacao(movimentacao);
        }

        [Authorize]
        [HttpGet("listarMovimentacoes")]
        public List<movimentacao> listarMovimentacoes()
        {
            return _movimentacaoService.listarMovimentacoes();
        }
    }
}
