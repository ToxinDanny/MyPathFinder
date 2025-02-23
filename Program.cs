using MyPathFinder;
using MyPathFinder.DataStructures;

var roma = new Vertex("Roma", 0);
List<Vertex> bolognaAdj = [new Vertex("Milano", 0.5m), new Vertex("Venezia", 1m, [new Vertex("Milano", 1m)])];

roma.AdjacentVertices.Add(new Vertex("Firenze", 1.5m, [new Vertex("Bologna", 5m, bolognaAdj)]));
roma.AdjacentVertices.Add(new Vertex("Napoli", 2m, [new Vertex("Bari", 1.5m, [new Vertex("Bologna", 0.5m, bolognaAdj)])]));

var strategy = new DijkstraStrategy() { Graph = new Graph(roma), Destination = "Bologna" };

Utils.PrintArray(strategy.Execute().BacktrackShortestPath(), "Shortest Path");
