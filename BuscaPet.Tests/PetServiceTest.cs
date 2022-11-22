using BuscaPet.Domain;
using BuscaPet.Exceptions;
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

        [Fact]
        public void AddPet_PetAlreadyExists_InvalidRegistryException()
        {
            Mock<IPetRepository> petRepositoryMock = new Mock<IPetRepository>();
            petRepositoryMock.Setup(p => p.FetchAllPets()).Returns(ListaPets());

            Pet repeatedPet = new Pet
            {
                Id = 1
            };

            Assert.Throws<InvalidRegistryException>(() => GetService(petRepositoryMock).AddPet(repeatedPet));
        }

        [Fact]
        public void AddPet_Success()
        {
            Pet newPet = new Pet
            {
                Id = 99
            };

            Mock<IPetRepository> petRepositoryMock = new Mock<IPetRepository>();
            petRepositoryMock.Setup(p => p.FetchAllPets()).Returns(ListaPets());
            petRepositoryMock.Setup(p => p.RegisterPet(newPet)).Returns(0);


            int returnValue = GetService(petRepositoryMock).AddPet(newPet);
            Assert.Equal(0, returnValue);
        }

        [Fact]
        public void RemovePet_PetDoesNotExist_InvalidRegistryException()
        {
            Mock<IPetRepository> petRepositoryMock = new Mock<IPetRepository>();
            petRepositoryMock.Setup(p => p.FetchAllPets()).Returns(ListaPets());

            Pet nonexistentPet = new Pet
            {
                Id = 3
            };

            Assert.Throws<InvalidRegistryException>(() => GetService(petRepositoryMock).RemovePet(nonexistentPet));
        }

        [Fact]
        public void RemovePet_PetExists_Success()
        {
            Pet removedPet = new Pet
            {
                Id = 2
            };

            Mock<IPetRepository> petRepositoryMock = new Mock<IPetRepository>();
            petRepositoryMock.Setup(p => p.FetchAllPets()).Returns(ListaPets());
            petRepositoryMock.Setup(p => p.DeletePet(removedPet)).Returns(0);


            int returnValue = GetService(petRepositoryMock).RemovePet(removedPet);
            Assert.Equal(0, returnValue);
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