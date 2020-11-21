using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Services.PostalCodes
{
    interface IPostalCodeService
    {
        IEnumerable<PostalCode> GetAllPostalCodes();
    }
}
