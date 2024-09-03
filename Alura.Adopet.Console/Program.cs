using Alura.Adopet.Console.Comandos;

// cria instância de HttpClient para consumir API Adopet
Console.ForegroundColor = ConsoleColor.Green;
try
{
    Dictionary<string, IComando> comandosDoSistema = new()
    {
        {"help", new Help() },
        {"list", new List() },
        {"import", new Import() },
        {"show", new Show() }
    };

    string comando = args[0].Trim();
    if (comandosDoSistema.ContainsKey(comando))
    {
        IComando? cmd = comandosDoSistema[comando];
        await cmd.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido");
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}