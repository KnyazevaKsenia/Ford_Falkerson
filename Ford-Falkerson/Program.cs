using System;
using Ford_Falkerson;
using System.Timers;
using System.Diagnostics;

int[][] graph = MakeGraph(10);

/*
for (int i = 0; i < graph.Length; i++)
{
    for (int j = 0; j < graph[i].Length; j++)
    {
        if (graph[i][j].ToString().Length == 1)
        {
            Console.Write($"{graph[i][j]}  ");

        }
        else
        {
            Console.Write($"{graph[i][j]} ");
        }
    }
    Console.WriteLine();
}*/


for (int n = 100; n <= 1000; n += 100)
{
    var testgr = new Graph(n);
    Stopwatch sw = Stopwatch.StartNew();
    //
    sw.Start();
    var flow=testgr.FordFulkerson(0,n-1);
    sw.Stop();
    //
    Console.Write($"{n}  ");
    Console.Write($"{sw.Elapsed.Seconds},");
    Console.Write($"{sw.Elapsed.Microseconds}");
    Console.WriteLine();
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

