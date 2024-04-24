using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ford_Falkerson
{
    public class Graph
    {
        int[][] graph;
        int row;
        public Graph(int n)
        {
            graph=MakeGraph(n);
            this.row = graph.Length;
        }

        public bool SearchingAlgo(int s, int t, int[] parents)
        {
            bool[] visited = new bool[graph.Length];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();

                for (int ind = 0; ind < graph[u].Length; ind++)
                {
                    if (!visited[ind] && graph[u][ind] > 0)
                    {
                        queue.Enqueue(ind);
                        visited[ind] = true;
                        parents[ind] = u;
                    }
                }
            }
            return visited[t];
        }

        public int FordFulkerson(int source, int sink)
        {
            int[] parent = new int[row];
            int maxFlow = 0;

            while (SearchingAlgo(source, sink, parent))
            {
                int pathFlow = int.MaxValue;
                int s = sink;

                while (s != source) //идем в обратном направленни к истоку и ищем минимальный поток
                {
                    pathFlow = Math.Min(pathFlow, graph[parent[s]][s]);
                    s = parent[s];
                }

                maxFlow += pathFlow;

                int v = sink;
                while (v != source)
                {
                    int u = parent[v];
                    graph[u][v] -= pathFlow;
                    graph[v][u] += pathFlow;
                    v = parent[v];
                }
            }
            return maxFlow;
        }

        int[][] MakeGraph(int n)
        {
            Random rnd = new Random();
            var graph = new int[n][];
            for (int stroka = 0; stroka < graph.Length; stroka++)
            {
                graph[stroka] = new int[n];
                for (int versh = 0; versh < graph[stroka].Length; versh++)
                {
                    if (versh != stroka && stroka != (graph.Length - 1))
                    {
                        var weight = rnd.Next(0, 30);

                        if (weight > 15)
                        {
                            graph[stroka][versh] = weight;
                        }
                        else
                        {
                            graph[stroka][versh] = 0;
                        }
                    }
                    else
                    {
                        graph[stroka][versh] = 0;
                    }
                }
            }
            return graph;
        }
    }
    
}
