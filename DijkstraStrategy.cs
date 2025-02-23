using MyPathFinder.DataStructures;

namespace MyPathFinder
{
    public class DijkstraStrategy
    {
		private Dictionary<string, decimal> _minWeights = [];
		private Dictionary<string, string> _minWeightsVisited = [];
		private Dictionary<string, bool> _visited = [];

		private Graph? _graph;

		public Graph Graph 
		{
			get => _graph is not null ? _graph : throw new Exception("Graph is null...");
			set
			{
				_graph = value;
				_minWeights[_graph.Root.Value] = 0m;
			} 
		}

		public string Destination { get; set; } = null!;

		public DijkstraStrategy Execute() 
		{ 
			FindShortestPath(Graph.Root);
			return this;
		}

        /*
            Implementazione dell'algoritmo di Dijkstra per la ricerca della minima distanza.
            Passaggi:
            1) Visitiamo il primo nodo rendendolo il nodo corrente
            2) Controlliamo i pesi dei nodi adiacenti
            3) Aggiorniamo le tabelle di appoggio con gli eventuali nuovi valori minimi:
                3.1) tabella dei pesi minimi
                3.2) tabella dei nodi visitati con peso minimo
            4) Spostiamoci sul nodo con peso minimo e rendiamolo corrente.
            5) Ripeti 2-4 per tutti i nodi
        */
        private void FindShortestPath(Vertex current)
        {
			if(!_visited.TryAdd(current.Value, true)) 
				return;

            if(current.AdjacentVertices.Count == 0)
				return;

			foreach(Vertex v in current.AdjacentVertices)
			{
				if (!_minWeights.TryGetValue(v.Value, out var weight) || weight > v.Weight)
				{
					_minWeights[v.Value] = _minWeights.TryGetValue(current.Value, out var totalWeight) ?
                        totalWeight + v.Weight :
						v.Weight;
					_minWeightsVisited[v.Value] = current.Value;
				}

				var adjacentVisited = _minWeightsVisited.Where(w => w.Value.Equals(current.Value))
					.Select(w => w.Key)
					.Where(k => !_minWeightsVisited.ContainsValue(k));

				if (!adjacentVisited.Any())
					return;

				var toSearch = _minWeights.Where(w => adjacentVisited.Contains(w.Key)).MinBy(w => w.Value).Key;
				var next = _graph!.DepthFirstSearch(current, new(), toSearch);
			
				if (next is null)
					return;

				FindShortestPath(next);
			}
        }
		
		public string[] BacktrackShortestPath()
		{
			return BacktrackShortestPath([Destination], Destination);
		}

		public string[] BacktrackShortestPath(string[] path, string current)
		{
			if(current.Equals(_graph!.Root.Value))
				return path.Reverse().ToArray();

			var previous = _minWeightsVisited[current];
			path = [.. path, previous];

			return BacktrackShortestPath(path, previous);
		}

		public decimal CalculateDistance()
		{
			return 0m;
		}
    }
}
