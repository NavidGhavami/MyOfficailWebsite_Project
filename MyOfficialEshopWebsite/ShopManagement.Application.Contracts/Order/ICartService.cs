namespace ShopManagement.Application.Contract.Order
{
    public interface ICartService
    {
        void Set(Cart cart);
        Cart Get();
    }
}
