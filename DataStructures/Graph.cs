namespace MyPathFinder.DataStructures
{
    public class Vertex(string value, List<Vertex>? adjacentVeretices = null) : IEquatable<Vertex>
    {
        public string Value { get; set; } = value;
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
            visited[current.Value] = current;

            if(current.Value.Equals(toSearch))
                return current;

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

        public Vertex? BreadthFirstSearch(Vertex current, Queue<Vertex> visited, string toSearch)
        {
            if(current.Value.Equals(toSearch))
                return current;

            foreach(var v in current.AdjacentVertices)
            {
                if (v.Value.Equals(toSearch))
                    return v;

                visited.Enqueue(v);
            }

            while (visited.Length != 0)
            {
                var found = BreadthFirstSearch(visited.Dequeue()!, visited, toSearch);

                if(found is not null)
                    return found;
            }

            return null;
        }
    }
}
