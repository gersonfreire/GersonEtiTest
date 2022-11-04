using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsBestRoute
{
    //https://www.geeksforgeeks.org/single-source-shortest-path-between-two-cities/
    internal class AlgDepth
    {
        public static int findCheapestPrice(int n,
                                      int[,] flights,
                                      int src, int dst,
                                      int K)
        {
            var adjList
              = new Dictionary<int,
            List<Tuple<int, int>>>();

            // Traverse flight[][]
            for (int i = 0; i < flights.GetLength(0); i++)
            {
                // Create Adjacency Matrix
                if (!adjList.ContainsKey(flights[i, 0]))
                {
                    adjList.Add(flights[i, 0],
                                new List<Tuple<int, int>>());
                }
                adjList[flights[i, 0]].Add(
                  Tuple.Create(flights[i, 1], flights[i, 2]));
            }

            // < city, distancefromsource > []
            var q = new Queue<(int, int)>();
            q.Enqueue((src, 0));

            // Store the Result
            var srcDist = Int32.MaxValue;

            // Traversing the Matrix
            while (q.Count > 0 && K-- >= 0)
            {
                var qSize = q.Count;

                for (var i = 0; i < qSize; i++)
                {
                    var curr = q.Dequeue();

                    foreach (var next in adjList[curr.Item1])
                    {
                        // If source distance is already
                        // least the skip this iteration
                        if (srcDist < curr.Item2 + next.Item2)
                            continue;

                        q.Enqueue((next.Item1,
                                   curr.Item2 + next.Item2));
                        if (dst == next.Item1)
                        {
                            srcDist = Math.Min(
                              srcDist,
                              curr.Item2 + next.Item2);
                        }
                    }
                }
            }
            // Returning the Answer
            return srcDist == Int32.MaxValue ? -1 : srcDist;
        }

        public static int findShortestPath(int n,
                                      int[,] flights,
                                      int src, int dst,
                                      int K)
        {
            var adjList
              = new Dictionary<int,
            List<Tuple<int, int>>>();

            // Traverse flight[][]
            for (int i = 0; i < flights.GetLength(0); i++)
            {
                // Create Adjacency Matrix
                if (!adjList.ContainsKey(flights[i, 0]))
                {
                    adjList.Add(flights[i, 0],
                                new List<Tuple<int, int>>());
                }
                adjList[flights[i, 0]].Add(
                  Tuple.Create(flights[i, 1], flights[i, 2]));
            }

            // < city, distancefromsource > []
            var q = new Queue<(int, int)>();
            q.Enqueue((src, 0));

            // Store the Result
            var srcDist = Int32.MaxValue;

            // Traversing the Matrix
            while (q.Count > 0 && K-- >= 0)
            {
                var qSize = q.Count;

                for (var i = 0; i < qSize; i++)
                {
                    var curr = q.Dequeue();

                    foreach (var next in adjList[curr.Item1])
                    {
                        // If source distance is already
                        // least the skip this iteration
                        if (srcDist < curr.Item2 + next.Item2)
                            continue;

                        q.Enqueue((next.Item1,
                                   curr.Item2 + next.Item2));
                        if (dst == next.Item1)
                        {
                            srcDist = Math.Min(
                              srcDist,
                              curr.Item2 + next.Item2);
                        }
                    }
                }
            }
            // Returning the Answer
            return srcDist == Int32.MaxValue ? -1 : srcDist;
        }

        // Driver Code
        public static void Main(string[] args)
        {
            List<string> allCities = new List<string>() { "z", "a", "b", "c"};

            List<List<string>> roadsList = new List<List<string>>()
            {
                new List<string>() { "z", "a", "1"},
                new List<string>() { "z", "b", "2"},
                new List<string>() { "a", "c", "2"},
                new List<string>() { "b", "c", "1"},
            };
            int[,] roadsArray = convert(roadsList, allCities);

            // Input flight : {Source,
            // Destination, Cost}
            int[,] flights
              = new int[,] { { 4, 1, 1 }, { 1, 2, 3 },
                     { 0, 3, 2 }, { 0, 4, 10 },
                     { 3, 1, 1 }, { 1, 4, 3 } };

            flights
              = new int[,] { { 0, 1, 1 }, { 0, 2, 2 },
                     { 1, 3, 2 }, { 2, 3, 1 } };


            // vec, n, stops, src, dst
            int stops = 2;
            int totalCities = 5;

            // Given source and destination
            int sourceCity = 0;
            int destCity = 4;

            // Function Call

            sourceCity = 0;//z
            destCity = 3;//c
            totalCities = 5;
            stops = 2;
            long ans = findCheapestPrice(totalCities, roadsArray,
                                         sourceCity, destCity,
                                         stops);

            ans = findCheapestPrice(totalCities, flights,
                                         sourceCity, destCity,
                                         stops);
            Console.WriteLine(ans);
        }

        public static int[,] convert(List<List<string>> roadsList, List<string> allCities)
        {
            //string[,] roads
            //  = new string[,] { { "z", "a", "1" }, { "z", "b", "2" },
            //         { "a", "c", "2" }, { "b", "c", "1" } };

            //List<List<string>> list = new List<List<string>>()
            //{
            //    new List<string>() { "z", "a", "1"},
            //    new List<string>() { "z", "b", "2"},
            //    new List<string>() { "a", "c", "2"},
            //    new List<string>() { "b", "c", "1"},
            //};

            var array2 = roadsList.ToArray();
            int[,] roadsArray = new int[array2.Length, 3];

            //foreach (var item in roadsList)
            for (int i = 0; i < roadsList.Count; i++)
            {
                int startCityIndex = allCities.IndexOf(roadsList[i][0]);
                int endCityIndex = allCities.IndexOf(roadsList[i][1]);

                string char3 = roadsList[i][2];

                int.TryParse(char3, out int int3);

                roadsArray.SetValue(startCityIndex, i, 0);
                roadsArray.SetValue(endCityIndex, i, 1);
                roadsArray.SetValue(int3, i, 2); 
            }

            return roadsArray;
        }
    }
}
