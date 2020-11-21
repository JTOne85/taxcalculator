using TaxCalculator.Core.Context;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.PostalCodes
{
    public class PostalCodeRepository : Repository<PostalCode>, IPostalCodeRepository
    {
        public PostalCodeRepository(TaxManContext taxManContext) : base(taxManContext) { }
    }
}
