using Alura.Adopet.Console.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        public static string uri = "http://localhost:5057";
        [Fact]
        public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            //Arrange
            var clientePet = new HttpClientPet(uri);
            //Act
            var lista = await clientePet.ListPetsAsync();
            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }

        [Fact]
        public async Task QuandoAPIForaDeveRetornarUmaExcecao()
        {
            //Arrange
            var clientePet = new HttpClientPet(uri: "http://localhost:1111");

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(() => clientePet.ListPetsAsync());
        }

    }
}
