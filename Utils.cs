using MyPathFinder.DataStructures;

namespace MyPathFinder
{
    public static class Utils
    {
        public static void PrintQueue<T>(DataStructures.Queue<T> queue)
            where T : IEquatable<T>
        {
            Console.Write("Queue: [ ");
            for (int i = 0; i < queue.Length; i++)
                if (i == queue.Length - 1)
                    Console.Write($"{queue[i]} ");
                else
                    Console.Write($"{queue[i]}, ");

            Console.Write("]\n");
        }

        public static void PrintArray<T>(T[] array, string title)
        {
            Console.Write($"{title}: [ ");
            for (int i = 0; i < array.Length; i++)
                if (i == array.Length - 1)
                    Console.Write($"{array[i]} ");
                else
                    Console.Write($"{array[i]}, ");

            Console.Write("]\n");
        }

        public static void TestGraphSearch(Graph graph)
        {
            var visited = new HashTable<Vertex>();
            var queue = new MyPathFinder.DataStructures.Queue<Vertex>();
            var toSearch = "Palermo";
            //var vertexFound = graph.DepthFirstSearch(graph.Root, visited, toSearch);
            var vertexFound = graph.BreadthFirstSearch(graph.Root, visited, queue, toSearch);

            Console.WriteLine(vertexFound is null ?
                $"Vertex '{toSearch}' not found" :
                $"Vertex '{toSearch}' found");
        }

        public static void TestDataStructure()
        {
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
            queue.Enqueue(2.3m);

            PrintQueue(queue);

            Console.WriteLine($"Dequeue value: {queue.Dequeue()}");

            PrintQueue(queue);
        }
    }
}
