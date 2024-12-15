using System;

namespace ConsoleApp1;

public class LFU : Store
{
    public LFU(int limit) : base(limit) { }

    protected override void CalcCache()
    {
        while (IsLimitOvercome())
        {
            var orderedCache = _cache.OrderBy(x => x.Value.Usage);
            var lastUsage = _cache.OrderByDescending(x => x.Value.LastUse).FirstOrDefault();

            foreach (var item in orderedCache)
            {
                if (item.Key != lastUsage.Key)
                {
                    _cache.Remove(item.Key);
                    break;
                }
            }
        }
    }
}
