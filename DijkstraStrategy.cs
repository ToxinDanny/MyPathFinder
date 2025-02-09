using System.Reflection.Metadata.Ecma335;
using MyPathFinder.DataStructures;

namespace MyPathFinder
{
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

    public class DijkstraStrategy
    {
		private Dictionary<string, bool> _visited = new();
		private Dictionary<string, decimal> _minWeights = new();
		private Dictionary<string, string> _minWeightsVisited = new();

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

        private void FindShortestPath(Vertex current)
        {
			_visited[current.Value] = true;

			if(Destination.Equals(current.Value))
				return;	

			foreach (var v in current.AdjacentVertices)
			{
				if (_visited.TryGetValue(v.Value, out var _))
					continue;

				if (!_minWeights.TryGetValue(current.Value, out var weight) || 
					weight == 0 ||
					weight > v.Weight)
				{
                    _minWeights[current.Value] = v.Weight;
					_minWeightsVisited[current.Value] = v.Value;
				}
			}

			var minWeightNode = _graph!.DepthFirstSearch(current, new HashTable<Vertex>(), _minWeightsVisited[current.Value])!;

			FindShortestPath(minWeightNode);
        }

		public string[] BacktrackShortestPath()
		{
			return BacktrackShortestPath([Destination], Destination);
		}

		public string[] BacktrackShortestPath(string[] path, string current)
		{
			if(current.Equals(_graph!.Root.Value))
				return path.Reverse().ToArray();

			var previous = _minWeightsVisited.First(kv => kv.Value.Equals(current)).Key;
			path = [.. path, previous];

			return BacktrackShortestPath(path, previous);
		}

		public decimal CalculateDistance()
		{
			return 0m;
		}
    }
}
