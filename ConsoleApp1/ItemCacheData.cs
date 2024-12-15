using System;

namespace ConsoleApp1;

public class ItemCacheData
{
    private int _usage { get; set; }
    public int Usage
    {
        get
        {
            return _usage;
        }
    }
    private DateTime _lastUse = DateTime.Now;
    public DateTime LastUse
    {
        get
        {
            return _lastUse;
        }

    }
    public int Size { get; }
    public string Data { get; } = string.Empty;

    public ItemCacheData(int size = 1, string data = "")
    {
        Size = size;
        Data = data;
    }

    public void Use()
    {
        _lastUse = DateTime.Now;
        _usage++;
    }
}
