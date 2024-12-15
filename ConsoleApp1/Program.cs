using ConsoleApp1;

internal class Program
{

    private static async Task Main(string[] args)
    {
        var store = new LRU(100);

        for (int i = 0; i < 10; i++)
        {
            int rand = new Random().Next(0, 30);
            store.Add(new Item(rand));
        }

        while (true)
        {
            Console.Clear();

            int rand = new Random().Next(0, 10);

            store.Get(rand);

            Console.WriteLine("Get Item. Id - " + rand);
            Console.WriteLine(store);

            await Task.Delay(TimeSpan.FromSeconds(0.5));
        }

    }
}

