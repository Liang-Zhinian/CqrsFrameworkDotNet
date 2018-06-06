using CqrsFramework.Domain;
using CqrsFramework.Events;
using System;
using System.Collections.Concurrent;
using System.Linq;
#if NET461
using System.Runtime.Caching;
#else
using Microsoft.Extensions.Caching.Memory;
#endif

namespace CqrsFramework.Cache
{
    public class CacheRepository : IRepository
    {
        private readonly IRepository _repository;
        private readonly IEventStore _eventStore;
#if NET461
        private readonly System.Runtime.Caching.MemoryCache _cache;
        private Func<CacheItemPolicy> _policyFactory;
#else
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IMemoryCache _cache;
#endif
        private static readonly ConcurrentDictionary<string, object> _locks =
            new ConcurrentDictionary<string, object>();

        public CacheRepository(IRepository repository, IEventStore eventStore)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            if (eventStore == null)
                throw new ArgumentNullException("eventStore");

#if NET461
            _cache = System.Runtime.Caching.MemoryCache.Default;
            _policyFactory = () => new CacheItemPolicy
            {
                SlidingExpiration = new TimeSpan(0, 0, 15, 0),
                RemovedCallback = x =>
                {
                    object o;
                    _locks.TryRemove(x.CacheItem.Key, out o);
                }
            };
#else
            _cacheOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(15)
            };
            _cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());
#endif

            _repository = repository;
            _eventStore = eventStore;
            
        }

        public void Save<T>(T aggregate, int? expectedVersion = null)
            where T : AggregateRoot
        {
            var idstring = aggregate.Id.ToString();
            try
            {
                lock (_locks.GetOrAdd(idstring, _ => new object()))
                {
                    if (aggregate.Id != Guid.Empty && !IsTracked(aggregate.Id))
                        Set(aggregate.Id, aggregate);
                    _repository.Save(aggregate, expectedVersion);
                }
            }
            catch (Exception e)
            {
                Remove(aggregate.Id);
                throw e;
            }
        }

        public T Get<T>(Guid aggregateId) where T : AggregateRoot
        {
            var idstring = aggregateId.ToString();
            try
            {
                lock (_locks.GetOrAdd(idstring, _ => new object()))
                {
                    T aggregate;
                    if (IsTracked(aggregateId))
                    {
                        aggregate = (T)_cache.Get(idstring);
                        var events = _eventStore.Get(aggregateId, aggregate.Version);
                        if (events.Any() && events.First().Version != aggregate.Version + 1)
                        {
                            Remove(aggregateId);
                        }
                        else
                        {
                            aggregate.LoadFromHistory(events);
                            return aggregate;
                        }
                    }

                    aggregate = _repository.Get<T>(aggregateId);
                    Set(aggregateId, aggregate);
                    return aggregate;
                }
            }
            catch (Exception)
            {
                Remove(aggregateId);
                throw;
            }
        }
        
        private bool IsTracked(Guid id)
        {
#if NET461
            return _cache.Contains(id.ToString());
#else
            return _cache.TryGetValue(id, out var o) && o != null;
#endif
        }

        private void Set(Guid id, AggregateRoot aggregate)
        {
#if NET461
            _cache.Add(id.ToString(), aggregate, _policyFactory.Invoke());
#else
            _cache.Set(id, aggregate, _cacheOptions);
#endif
        }

        private AggregateRoot Get(Guid id)
        {
#if NET461
            return (AggregateRoot)_cache.Get(id.ToString());
#else
            return (AggregateRoot) _cache.Get(id);
#endif
        }

        private void Remove(Guid id)
        {
#if NET461
            _cache.Remove(id.ToString());
#else
            _cache.Remove(id);
#endif
        }

        private void RegisterEvictionCallback(Action<Guid> action)
        {
#if NET461
            _policyFactory = () => new CacheItemPolicy
            {
                RemovedCallback = x =>
                {
                    action.Invoke(Guid.Parse(x.CacheItem.Key));
                }
            };
#else
            _cacheOptions.RegisterPostEvictionCallback((key, value, reason, state) =>
            {
                action.Invoke((Guid) key);
            });
#endif
        }
    }
}
