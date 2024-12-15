using System;
using System.Drawing;

namespace ConsoleApp1;

public class Item
{
    private static int counter = 0;
    public int Id { get; }
    public string Data { get; } = string.Empty;
    public int Size { get; }

    public Item(int size, string? data = null)
    {
        Id = counter++;

        Size = size;

        if (data != null)
            Data = data;
    }
}
