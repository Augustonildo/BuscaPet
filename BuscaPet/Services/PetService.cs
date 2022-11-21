using BuscaPet.Domain;
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

        void IPetService.AddPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        void IPetService.RemovePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        void IPetService.UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
