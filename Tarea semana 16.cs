using System;
using System.Collections.Generic;
using System.Linq;

class CentralityCalculator
{
    static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>()
    {
        {"A", new List<string>{"B", "D"}},
        {"B", new List<string>{"A", "C", "E"}},
        {"C", new List<string>{"B", "F"}},
        {"D", new List<string>{"A"}},
        {"E", new List<string>{"B"}},
        {"F", new List<string>{"C"}}
    };

    static void Main()
    {
        Console.WriteLine("Centralidad de Grado:");
        foreach (var node in graph.Keys)
        {
            Console.WriteLine($"Nodo {node}: {DegreeCentrality(node)}");
        }

        Console.WriteLine("\nCentralidad de Cercanía:");
        foreach (var node in graph.Keys)
        {
            double closeness = ClosenessCentrality(node);
            Console.WriteLine($"Nodo {node}: {closeness:F3}");
        }

        Console.WriteLine("\nCentralidad de Intermediación:");
        var betweenness = BetweennessCentrality();
        foreach (var kv in betweenness)
        {
            Console.WriteLine($"Nodo {kv.Key}: {kv.Value:F2}");
        }
    }

    static int DegreeCentrality(string node)
    {
        return graph[node].Count;
    }

    static double ClosenessCentrality(string node)
    {
        var distances = BFS(node);
        int total = distances.Values.Sum();
        if (total == 0) return 0;
        return 1.0 / total;
    }

    static Dictionary<string, int> BFS(string start)
    {
        var distances = new Dictionary<string, int>();
        var visited = new HashSet<string>();
        var queue = new Queue<(string node, int dist)>();
        queue.Enqueue((start, 0));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (current, dist) = queue.Dequeue();
            distances[current] = dist;
            foreach (var neighbor in graph[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue((neighbor, dist + 1));
                }
            }
        }
        return distances;
    }

    static Dictionary<string, double> BetweennessCentrality()
    {
        var centrality = graph.Keys.ToDictionary(node => node, node => 0.0);

        foreach (var s in graph.Keys)
        {
            var stack = new Stack<string>();
            var paths = graph.Keys.ToDictionary(w => w, w => new List<string>());
            var sigma = graph.Keys.ToDictionary(w => w, w => 0);
            var dist = graph.Keys.ToDictionary(w => w, w => -1);

            sigma[s] = 1;
            dist[s] = 0;

            var queue = new Queue<string>();
            queue.Enqueue(s);

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                stack.Push(v);

                foreach (var w in graph[v])
                {
                    if (dist[w] < 0)
                    {
                        dist[w] = dist[v] + 1;
                        queue.Enqueue(w);
                    }

                    if (dist[w] == dist[v] + 1)
                    {
                        sigma[w] += sigma[v];
                        paths[w].Add(v);
                    }
                }
            }

            var delta = graph.Keys.ToDictionary(w => w, w => 0.0);

            while (stack.Count > 0)
            {
                var w = stack.Pop();
                foreach (var v in paths[w])
                {
                    delta[v] += ((double)sigma[v] / sigma[w]) * (1 + delta[w]);
                }

                if (w != s)
                    centrality[w] += delta[w];
            }
        }

        return centrality;
    }
}
