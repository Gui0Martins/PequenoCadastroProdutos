using Entities;
using DTOs;

public class ProdutoRepository
{
    private static readonly List<Produto> _produtos = new();
    private static int indiceId = 1;

    public Task<Produto> CriarAsync(ProdutoRequest request)
    {
        Produto produto = new Produto
        {
            Nome = request.Nome,
            Preco = request.Preco,
            Quantidade = request.Quantidade,
            CategoriaId = request.CategoriaId,
            Id = indiceId
        };

        indiceId++;

        _produtos.Add(produto);

        return Task.FromResult(produto);
    }

    public Task<bool> RemoverAsync(int id)
    {
        Produto? produtoCadastrado = _produtos.FirstOrDefault(p => p.Id == id);

        if (produtoCadastrado != null)
        {
            _produtos.Remove(produtoCadastrado);
            return Task.FromResult(true);
        }
        else 
            return Task.FromResult(false);
    }

    public Task<Produto?> AtualizarProdutoAsync(int id, ProdutoRequest request)
    {
        Produto? produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);

        if (produtoExistente == null)
            return Task.FromResult<Produto?>(null);

        produtoExistente.Nome = request.Nome;
        produtoExistente.Preco = request.Preco;
        produtoExistente.Quantidade = request.Quantidade;
        produtoExistente.CategoriaId = request.CategoriaId;

        return Task.FromResult<Produto?>(produtoExistente);
    }

    public Task<List<Produto>> ListarProdutosAsync()
    {
        return Task.FromResult(_produtos.ToList());
    }

    public Task<Produto?> BuscarProdutoAsync(int id)
    {
        var produto = _produtos.FirstOrDefault(p =>p.Id == id);

        return Task.FromResult(produto);
    }
}