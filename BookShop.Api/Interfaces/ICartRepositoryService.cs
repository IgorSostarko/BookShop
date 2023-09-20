namespace BookShop.Api.Interfaces
{
    public interface ICartRepositoryService
    {
        Task<bool> CartExists(string id);
    }
}
