using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TesteVagaBackEnd.Api.Controllers
{
    [ApiController] // identifica a classe como um Controller
    [Route("api/produto")] // Rota base desse controller -> [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoRequest request)
        {
            var resultado = await _produtoService.CriarProduto(request);

            if (!resultado.Sucesso)
                return BadRequest(resultado.MensagemErro);

            return Ok(resultado.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            bool removido = await _produtoService.RemoverProdutoAsync(id);

            if (!removido)
            {
                return NotFound("Produto não encontrado");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, ProdutoRequest request)
        {
            var resultado = await _produtoService.AtualizarProdutoAsync(id, request);

            if (!resultado.Sucesso)
            {
                if (resultado.TipoErro == TipoErro.Validacao)
                return BadRequest(resultado.MensagemErro);

                if (resultado.TipoErro == TipoErro.NaoEncontrado)
                    return NotFound(resultado.MensagemErro);
            }

            return Ok(resultado.Dados);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            List<Produto> produtos = await _produtoService.ListarTodosAsync();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProduto(int id)
        {
            var resultado = await _produtoService.BuscarProdutoAsync(id);

            if (!resultado.Sucesso)
            {
                if (resultado.TipoErro == TipoErro.Validacao)
                    return BadRequest(resultado.MensagemErro);

                if (resultado.TipoErro == TipoErro.NaoEncontrado)
                    return NotFound(resultado.MensagemErro);
            }

            return Ok(resultado.Dados);
        }
    }
}
