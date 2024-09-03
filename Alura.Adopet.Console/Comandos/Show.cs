using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show", documentacao: "adopet show   <arquivo> comando que exibe" +
        " no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
            return Task.CompletedTask;
        }

        private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
        {
            var leitor = new LeitorDeArquivo();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);
            foreach (var pet in listaDePet)
                System.Console.WriteLine(pet);
        }
    }
}
