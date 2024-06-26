﻿namespace HyperX;

public interface ICache<TValue> :
    IEnumerable<TValue>
{
    void Add(TValue value);

    void Clear();

    bool Remove(TValue value);
}

public interface ICache<TKey, TValue> :
    IEnumerable<KeyValuePair<TKey, TValue>>
    where TKey :
    notnull
    where TValue : 
    notnull
{
    void Add(TKey key, 
        TValue value);

    void Clear();

    bool ContainsKey(TKey key);

    bool Remove(TKey key);

    bool TryGetValue(TKey key, out TValue? value);
}
