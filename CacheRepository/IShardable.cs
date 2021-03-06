﻿using System;
using System.Collections.Generic;

namespace CacheRepository
{
    public interface IShardable<TKey, TValue, TShardKey> : IRepository<TKey, TValue>
        where TValue : class, IEntity
    {
        TShardKey GetShardKey(TValue value);
        Func<TShardKey, (int index, string tag)> GetShardingRule();
        Shard<TKey, TValue, TShardKey> this[int index] { get; }
        Dictionary<int, Shard<TKey, TValue, TShardKey>> Shards { get; }
    }
}
