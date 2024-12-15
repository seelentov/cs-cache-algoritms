using System;

namespace ConsoleApp1;

public class LFU : Store
{
    public LFU(int limit) : base(limit) { }

    protected override void CalcCache()
    {
        while (IsLimitOvercome())
        {
            var leastUsed = _cache.OrderBy(x => x.Value.Usage).FirstOrDefault();

            if (leastUsed.Value != null)
                _cache.Remove(leastUsed.Key);
        }
    }
}
