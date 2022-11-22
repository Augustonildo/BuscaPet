using BuscaPet.Domain;

namespace BuscaPet.Services.Interfaces
{
    public interface IPetService
    {
        IEnumerable<Pet> GetPets();
        int AddPet(Pet pet);
        int UpdatePet(Pet pet);
        int RemovePet(Pet pet);
    }
}
