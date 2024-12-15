using System;

namespace ConsoleApp1;

public class LRU : Store
{
    public LRU(int limit) : base(limit) { }

    protected override void CalcCache()
    {
        while (IsLimitOvercome())
        {
            var oldestUsage = _cache.OrderBy(x => x.Value.LastUse).FirstOrDefault();

            if (oldestUsage.Value != null)
                _cache.Remove(oldestUsage.Key);
        }
    }
}
