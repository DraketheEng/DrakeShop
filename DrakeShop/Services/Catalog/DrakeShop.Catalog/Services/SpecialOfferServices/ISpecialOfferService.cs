using DrakeShop.Catalog.Entities;

namespace DrakeShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        List<SpecialOffer> GetAll();
        Task<SpecialOffer> GetById(string id);
        Task<bool> Create(SpecialOffer specialOffer);
        Task<bool> Delete(string id);
        Task<bool> Update(SpecialOffer specialOffer);
    }
}
