namespace MyPathFinder.DataStructures
{
    public class Vertex
    {
        public string Value { get; set; } = default!;
        public List<Vertex> AdjacentVertices { get; set; } = [];
    }

    public class Graph(Vertex root)
    {
        public Vertex Root { get; set; } = root;

        // TODO: implementare
        public Vertex DepthFirstSearch(Vertex toSearch, Dictionary<string, Vertex> visited) 
        {
            return Root;
        }

        public Vertex BreadthFirstSearch(Vertex toSearch)
        {
            return Root;
        }
    }
}
