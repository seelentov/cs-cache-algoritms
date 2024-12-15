using System;
using System.Text.Json;

namespace ConsoleApp1;

abstract public class Store
{
    protected Dictionary<int, ItemCacheData> _cache = [];
    protected int _limit { get; set; }
    private List<Item> _data = [];

    public Store(int limit)
    {
        _limit = limit;
    }

    protected abstract void CalcCache();

    protected int GetSize()
    {
        return _cache.Sum((x) => x.Value.Size);
    }
    protected bool IsLimitOvercome()
    {
        return GetSize() >= _limit;
    }

    public Item? Get(int id)
    {

        _cache.TryGetValue(id, out ItemCacheData? cacheItem);

        if (cacheItem != null)
        {
            cacheItem.Use();
            Item cacheData = JsonSerializer.Deserialize<Item>(cacheItem.Data) ?? throw new Exception($"Error deserialize {id}");
            return cacheData;
        }

        var data = _data.Where(x => x.Id == id).FirstOrDefault();

        if (data != null)
        {
            _cache[id] = new ItemCacheData(data.Size, JsonSerializer.Serialize(data));

            CalcCache();

            return data;
        }

        return null;
    }

    public void Add(Item item)
    {
        _data.Add(item);
    }

    public override string ToString()
    {
        string stat = $"Data count: {_data.Count} | Cache count: {_cache.Count} | Cache size: {GetSize()} / Cache limit:{_limit}";
        string header = $"Id | Size | Usage | LastUse";
        string[] headerParts = header.Split('|');

        string cacheList = string.Join('\n', _cache.OrderBy(x => x.Key).Select(x =>
        {
            string[] parts = { x.Key.ToString(), x.Value.Size.ToString(), x.Value.Usage.ToString(), x.Value.LastUse.ToString() };
            return string.Join("|", parts.Select((p, i) => p.PadRight(headerParts[i].Trim().Length)));
        }));

        return stat + '\n' + header + '\n' + cacheList;
    }



}
