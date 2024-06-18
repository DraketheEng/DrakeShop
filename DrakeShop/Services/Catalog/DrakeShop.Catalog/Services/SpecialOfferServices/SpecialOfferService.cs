using DrakeShop.Catalog.Entities;
using DrakeShop.Catalog.MongoDB.Repository;

namespace DrakeShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoDbServices<SpecialOffer> _specialOfferServices;

        public SpecialOfferService(IMongoDbServices<SpecialOffer> specialOffer)
        {
            _specialOfferServices = specialOffer;
        }

        public List<SpecialOffer> GetAll()
        {
            var list = _specialOfferServices.FilterBy(x => true).ToList();
            return list;
        }

        public async Task<SpecialOffer> GetById(string id)
        {
            var SpecialOffer = await _specialOfferServices.FindByIdAsync(id);
            return SpecialOffer;
        }

        public async Task<bool> Create(SpecialOffer specialOffer)
        {
            await _specialOfferServices.InsertOneAsync(specialOffer);
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await _specialOfferServices.DeleteOneAsync(x => x.Id == id);
            return true;
        }

        public async Task<bool> Update(SpecialOffer specialOffer)
        {
            await _specialOfferServices.ReplaceOneAsync(specialOffer);
            return true;
        }
    }
}
