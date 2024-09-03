using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class PetAPartirDoCsvTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            var conversor = new PetAPartirDoCsv();
            //Act
            Pet pet = linha.ConverteDoTexto();
            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoGuidInvalidoDeveLancarArgumentException()
        {
            // arrange
            string? linha = "adkajhd; Lima Limão;1";

            // act + assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoInvalidoDeveLancarArgumentException()
        {
            // arrange
            string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41; Lima Limão; 2";

            // act + assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}
