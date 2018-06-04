using System;
using System.Collections.Generic;

namespace CqrsFramework.ReadModel.Infrastructure
{
    public static class InMemoryDatabase<THeaderDto, TDetailsDto>
    {
        public static readonly Dictionary<Guid, TDetailsDto> Details = new Dictionary<Guid, TDetailsDto>();
        public static readonly List<THeaderDto> List = new List<THeaderDto>();
    }
}
