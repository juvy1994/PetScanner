namespace PS.Infrastructure.Interfaces
{
    public interface IChatService
    {
        Task<PetBreedInfoDto?> GetPetDescriptionAsync(string breed);

    }
}
