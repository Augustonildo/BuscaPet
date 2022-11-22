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
            bool petAlreadyExists = PetExists(pet);
            if (petAlreadyExists)
            {
                throw new InvalidRegistryException();
            }

            return _petRepository.RegisterPet(pet);
        }

        int IPetService.RemovePet(Pet pet)
        {
            bool petExists = PetExists(pet);
            if (!petExists)
            {
                throw new InvalidRegistryException();
            }

            return _petRepository.DeletePet(pet);
        }

        int IPetService.UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        private bool PetExists(Pet pet)
        {
            IEnumerable<Pet> petList = _petRepository.FetchAllPets();
            return petList.Any(p => p.Id == pet.Id);
        }
    }
}
