using DTOs;
using Entities;

namespace Services;

public class ProdutoService
{
    private readonly ProdutoRepository _produtoRepository;

    public ProdutoService(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResultadoServico<Produto>> CriarProduto(ProdutoRequest response)
    {
        if (string.IsNullOrWhiteSpace(response.Nome))
            return ResultadoServico<Produto>.Falha("Nome inválido", TipoErro.Validacao);

        if (response.Preco <= 0)
            return ResultadoServico<Produto>.Falha("Preço inválido", TipoErro.Validacao);

        if (response.Quantidade <= 0)
            return ResultadoServico<Produto>.Falha("Quantidade inválida", TipoErro.Validacao);

        Produto produto = await _produtoRepository.CriarAsync(response);

        return ResultadoServico<Produto>.Ok(produto);
    }

    public async Task<bool> RemoverProdutoAsync(int id)
    {
        if (id <= 0) 
            return false;

        return await _produtoRepository.RemoverAsync(id);
    }

    public async Task<ResultadoServico<Produto>> AtualizarProdutoAsync(int id, ProdutoRequest response)
    {
        if (id <= 0)
            return ResultadoServico<Produto>.Falha("Id inválido", TipoErro.Validacao);

        if (string.IsNullOrWhiteSpace(response.Nome))
            return ResultadoServico<Produto>.Falha("Nome inválido", TipoErro.Validacao);

        if (response.Quantidade <= 0)
            return ResultadoServico<Produto>.Falha("Quantidade inválida", TipoErro.Validacao);

        if (response.Preco <= 0)
            return ResultadoServico<Produto>.Falha("Preço inválido", TipoErro.Validacao);

        Produto? produto = await _produtoRepository.AtualizarProdutoAsync(id, response);

        if (produto == null)
            return ResultadoServico<Produto>.Falha("Produto não encontrado", TipoErro.NaoEncontrado);

        return ResultadoServico<Produto>.Ok(produto);
    }

    public async Task<List<Produto>> ListarTodosAsync()
    {
        return await _produtoRepository.ListarProdutosAsync();
    }

    public async Task<ResultadoServico<Produto>> BuscarProdutoAsync(int id)
    {
        if (id <= 0)
            return ResultadoServico<Produto>.Falha("Id inválido", TipoErro.Validacao);

        Produto? produto = await _produtoRepository.BuscarProdutoAsync(id);

        if (produto == null)
            return ResultadoServico<Produto>.Falha("Produto não encontrado", TipoErro.NaoEncontrado);

        return ResultadoServico<Produto>.Ok(produto);
    }
}