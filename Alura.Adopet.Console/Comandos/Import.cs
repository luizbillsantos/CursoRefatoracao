using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando " +
        "que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        HttpClientPet petClient = new HttpClientPet(uri: "http://localhost:5057");
        HttpClient client;

        public Import()
        {
            client = petClient.ConfiguraHttpClient("http://localhost:5057");
        }

        public async Task ExecutarAsync(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoDoArquivo: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivo)
        {
            var leitor = new LeitorDeArquivo();
            var listaDePet = leitor.RealizaLeitura(caminhoDoArquivo);

            foreach (var pet in listaDePet)
            {
                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }

        Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
        }
    }
}
