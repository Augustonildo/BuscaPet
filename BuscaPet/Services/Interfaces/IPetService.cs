using BuscaPet.Domain;

namespace BuscaPet.Services.Interfaces
{
    public interface IPetService
    {
        IEnumerable<Pet> GetPets();
        void AddPet(Pet pet);
        void UpdatePet(Pet pet);
        void RemovePet(Pet pet);
    }
}
