using BuscaPet.Domain;

namespace BuscaPet.Repositories.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<Pet> FetchAllPets();
        int RegisterPet(Pet pet);
    }
}
