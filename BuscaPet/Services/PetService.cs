using BuscaPet.Domain;
using BuscaPet.Exceptions;
using BuscaPet.Repositories.Interfaces;
using BuscaPet.Services.Interfaces;

namespace BuscaPet.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        IEnumerable<Pet> IPetService.GetPets()
        {
            return _petRepository.FetchAllPets();
        }

        int IPetService.AddPet(Pet pet)
        {
            IEnumerable<Pet> petList = _petRepository.FetchAllPets();

            bool petAlreadyExists = petList.Any(p => p.Id == pet.Id);
            if (petAlreadyExists)
            {
                throw new InvalidRegistryException();
            }

            return _petRepository.RegisterPet(pet);
        }

        int IPetService.RemovePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        int IPetService.UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
