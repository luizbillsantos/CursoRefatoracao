using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list", documentacao: "adopet list   <arquivo> comando que exibe" +
        " no terminal o conteúdo do cadastrado na base de dados.")]
    internal class List : IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await ListaDadosPetsDaApiAsync();
        }

        private async Task ListaDadosPetsDaApiAsync()
        {
            var httpListPet = new HttpClientPet();
            var pets = await httpListPet.ListPetsAsync();
            System.Console.WriteLine("-----Lista de Pets importados no sistema-----");
            foreach (var pet in pets)
                System.Console.WriteLine(pet);
        }
    }
}
