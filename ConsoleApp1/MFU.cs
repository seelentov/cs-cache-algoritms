using System;

namespace ConsoleApp1;

public class MFU : Store
{
    public MFU(int limit) : base(limit) { }

    protected override void CalcCache()
    {
        while (IsLimitOvercome())
        {
            var mostUsed = _cache.OrderByDescending(x => x.Value.Usage).FirstOrDefault();

            if (mostUsed.Value != null)
                _cache.Remove(mostUsed.Key);
        }
    }
}
