namespace PS.Infrastructure.Interfaces
{
    public interface IOpenAiVisionService
    {
        Task<string> DetectBreedFromImageAsync(string imageUrl);
    }
}
