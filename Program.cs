using MyPathFinder.DataStructures;

var ht = new HashTable<decimal>();
ht["Roma"] = 1m;
ht["Milano"] = 3.5m;
ht["Firenze"] = 2.5m;
ht["Bologna"] = 3m;
ht["Bari"] = 3m;
ht["Venezia"] = 3.5m;

Console.WriteLine($"Value of 'Roma'? Distance: {ht["Roma"]}; Hash: {HashTable<decimal>.Hash("Roma")}");
Console.WriteLine($"Value of 'Milano'? Distance: {ht["Milano"]}; Hash: {HashTable<decimal>.Hash("Milano")}");
Console.WriteLine($"Value of 'Firenze'? Distance: {ht["Firenze"]}; Hash: {HashTable<decimal>.Hash("Firenze")}");
Console.WriteLine($"Value of 'Bologna'? Distance: {ht["Bologna"]}; Hash: {HashTable<decimal>.Hash("Bologna")}");
Console.WriteLine($"Value of 'Bari'? Distance: {ht["Bari"]}; Hash: {HashTable<decimal>.Hash("Bari")}");
Console.WriteLine($"Value of 'Venezia'? Distance: {ht["Venezia"]}; Hash: {HashTable<decimal>.Hash("Venezia")}");

var queue = new MyPathFinder.DataStructures.Queue<decimal>();
queue.Enqueue(1.5m);
queue.Enqueue(2.3m);    // TODO: non aggiunge

PrintQueue(queue);

Console.WriteLine($"Dequeue value: {queue.Dequeue()}");

PrintQueue(queue);

static void PrintQueue(MyPathFinder.DataStructures.Queue<decimal> queue)
{
    Console.Write("Queue: [ ");
    for (int i = 0; i < queue.Length; i++)
        if (i == queue.Length - 1)
            Console.Write($"{queue[i]} ");
        else
            Console.Write($"{queue[i]}, ");

    Console.Write("]\n");
}