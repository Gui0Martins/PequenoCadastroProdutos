namespace Services;

public class ResultadoServico<T>
{
    public bool Sucesso { get; private set; }
    public T? Dados { get; private set; }
    public string? MensagemErro { get; private set; }
    public TipoErro? TipoErro { get; private set; }

    private ResultadoServico(bool sucesso, T? dados, string? mensagemErro, TipoErro? tipoErro)
    {
        Sucesso = sucesso;
        Dados = dados;
        MensagemErro = mensagemErro;
        TipoErro = tipoErro;
    }

    public static ResultadoServico<T> Ok(T dados)
    {
        return new ResultadoServico<T>(true, dados, null, null);
    }

    public static ResultadoServico<T> Falha(string mensagemErro, TipoErro tipoErro)
    {
        return new ResultadoServico<T>(false, default, mensagemErro, tipoErro);
    }
}
