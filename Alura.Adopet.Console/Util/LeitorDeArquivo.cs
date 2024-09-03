using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivo
    {
        public IEnumerable<Pet> RealizaLeitura(string caminhodoArquivoASerLido)
        {
            var listaDePet = new List<Pet>();
            using StreamReader sr = new StreamReader(caminhodoArquivoASerLido);
            System.Console.WriteLine("----- Dados a serem importados -----");
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                propriedades[1],
                TipoPet.Cachorro
                );
                System.Console.WriteLine(pet);
                listaDePet.Add(pet);
            }
            return listaDePet;
        }
    }
}
