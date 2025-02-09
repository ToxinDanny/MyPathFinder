using MyPathFinder;
using MyPathFinder.DataStructures;

var roma = new Vertex("Roma", 0);
var firenze = new Vertex("Firenze", 2m);
var milano = new Vertex("Milano", 3.5m);
var bari = new Vertex("Bari", 2.5m);
var bologna = new Vertex("Bologna", 3m);
var venezia = new Vertex("Venezia", 4m);

roma.AdjacentVertices.Add(firenze);
roma.AdjacentVertices.Add(bari);
bari.AdjacentVertices.Add(bologna);
bari.AdjacentVertices.Add(roma);
firenze.AdjacentVertices.Add(bologna);
bologna.AdjacentVertices.Add(milano);
bologna.AdjacentVertices.Add(venezia);
venezia.AdjacentVertices.Add(milano);

var strategy = new DijkstraStrategy() { Graph = new Graph(roma), Destination = "Milano" };

Utils.PrintArray(strategy.Execute().BacktrackShortestPath(), "Shortest Path");
