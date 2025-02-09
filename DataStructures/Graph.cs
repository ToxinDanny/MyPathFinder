namespace MyPathFinder.DataStructures
{
    public class Vertex(string value, decimal weight, List<Vertex>? adjacentVeretices = null) : IEquatable<Vertex>
    {
        public string Value { get; set; } = value;
        public decimal Weight { get; set; } = weight;
        public List<Vertex> AdjacentVertices { get; set; } = adjacentVeretices is null ? [] : adjacentVeretices;

        public bool Equals(Vertex? other)
        {
            return Value.Equals(other?.Value);
        }
    }

    public class Graph(Vertex root)
    {
        public Vertex Root { get; set; } = root;

        public Vertex? DepthFirstSearch(Vertex current, HashTable<Vertex> visited, string toSearch) 
        {
            if(current.Value.Equals(toSearch))
                return current;

            visited[current.Value] = current;

            foreach (var v in current.AdjacentVertices)
            {
                if(v.Value.Equals(toSearch))
                    return v;

                if (visited[v.Value] is null)
                {
                    var found = DepthFirstSearch(v, visited, toSearch);
                    if (found?.Value.Equals(toSearch) ?? false)
                        return found;
                }
            }

            return null;
        }

        public Vertex? BreadthFirstSearch(Vertex current, HashTable<Vertex> visited, Queue<Vertex> adjacent, string toSearch)
        {
            if(current.Value.Equals(toSearch))
                return current;

            visited[current.Value] = current;

            foreach(var v in current.AdjacentVertices)
            {
                if (v.Value.Equals(toSearch))
                    return v;

                if (visited[v.Value] is null && adjacent[v] is null)
                    adjacent.Enqueue(v);
            }

            while (adjacent.Length != 0)
            {
                var found = BreadthFirstSearch(adjacent.Dequeue()!, visited, adjacent, toSearch);

                if(found is not null)
                    return found;
            }

            return null;
        }
    }
}
