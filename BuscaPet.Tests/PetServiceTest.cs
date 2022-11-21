using BuscaPet.Domain;
using BuscaPet.Repositories.Interfaces;
using BuscaPet.Services;
using BuscaPet.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace BuscaPet.Tests
{
    public class PetServiceTest
    {

        [Fact]
        public void GetAllPets_ReturnSuccess()
        {
            Mock<IPetRepository> petRepositoryMock = new Mock<IPetRepository>();
            petRepositoryMock.Setup(p => p.FetchAllPets()).Returns(ListaPets());

            IEnumerable<Pet> pets = GetService(petRepositoryMock).GetPets();
            Assert.NotEmpty(pets);
        }

        private IPetService GetService(Mock<IPetRepository> petRepository)
        {
            return new PetService(petRepository.Object);
        }

        private IEnumerable<Pet> ListaPets()
        {
            return new List<Pet>
            {
                new Pet
                {
                    Id = 1,
                    Name = "Beto",
                    BirthDate = System.DateTime.Now.AddDays(-1111)
                },
                new Pet
                {
                    Id = 2,
                    Name = "Thor",
                    BirthDate = System.DateTime.Today
                }
            };
        }
    }
}