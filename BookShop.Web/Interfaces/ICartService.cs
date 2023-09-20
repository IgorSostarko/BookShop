namespace BookShop.Web.Interfaces
{
    public interface ICartService
    {
        Task<bool> SetUpName(string name);
    }
}
