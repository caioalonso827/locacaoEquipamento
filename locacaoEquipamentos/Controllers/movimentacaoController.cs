using locacaoEquipamentos.models;
using locacaoEquipamentos.Services.Service;

namespace locacaoEquipamentos.Controllers
{
    public class movimentacaoController
    {
        private readonly movimentacaoService _movimentacaoService;

        public movimentacaoController(movimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        public String cadastrarMovimentacao(Movimentacao movimentacao)
        {
            return _movimentacaoService.cadastrarMovimentacao(movimentacao);
        }

        public List<Movimentacao> listarMovimentacoes()
        {
            return _movimentacaoService.listarMovimentacoes();
        }
    }
}
