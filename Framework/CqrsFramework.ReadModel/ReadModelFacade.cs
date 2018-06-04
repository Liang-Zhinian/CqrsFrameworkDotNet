using CqrsFramework.ReadModel.Infrastructure;
using System;
using System.Collections.Generic;

namespace CqrsFramework.ReadModel
{
    public class ReadModelFacade<THeaderDto, TDetailsDto> : IReadModelFacade<THeaderDto, TDetailsDto>
    {
        public IEnumerable<THeaderDto> GetHeaders()
        {
            return InMemoryDatabase<THeaderDto, TDetailsDto>.List;
        }

        public TDetailsDto GetDetails(Guid id)
        {
            return InMemoryDatabase<THeaderDto, TDetailsDto>.Details[id];
        }
    }
}
