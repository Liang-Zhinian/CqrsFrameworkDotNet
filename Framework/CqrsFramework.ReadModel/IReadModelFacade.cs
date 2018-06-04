using System;
using System.Collections.Generic;

namespace CqrsFramework.ReadModel
{
    public interface IReadModelFacade<THeaderDto, TDetailsDto>
    {
        IEnumerable<THeaderDto> GetHeaders();
        TDetailsDto GetDetails(Guid id);
    }
}
