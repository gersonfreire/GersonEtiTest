﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsBestRoute
{
    internal class DeepFirst
    {
        // DFS memoization
        static int[][] adjMatrix;
        static Dictionary<int[], int> mp = new Dictionary<int[], int>();

        // Function to implement DFS Traversal
        static int DFSUtility(int node, int stops, int dst, int cities)
        {
            // Base Case
            if (node == dst)
            {
                return 0;
            }

            if (stops < 0)
            {
                return Int32.MaxValue;
            }

            int[] key = new int[] { node, stops };

            // Find value with key in a map
            if (mp.ContainsKey(key))
            {
                return mp[key];
            }

            int ans = Int32.MaxValue;

            // Traverse adjacency matrix of
            // source node
            for (int neighbour = 0; neighbour < cities; ++neighbour)
            {
                int weight = adjMatrix[node][neighbour];

                if (weight > 0)
                {
                    // Recursive DFS call for
                    // child node
                    int minVal = DFSUtility(neighbour, stops - 1, dst, cities);

                    if (minVal + weight > 0)
                    {
                        ans = Math.Min(ans, minVal + weight);
                    }
                }
                if (!mp.ContainsKey(key))
                {
                    mp.Add(key, 0);
                }
                mp[key] = ans;
            }
            // Return ans
            return ans;
        }

        // Function to find the cheapest price
        // from given source to destination
        static int findCheapestPrice(int cities, int[][] flights, int src, int dst, int stops)
        {
            // Resize Adjacency Matrix
            adjMatrix = new int[cities + 1][];
            for (int i = 0; i <= cities; i++)
            {
                adjMatrix[i] = new int[cities + 1];
            }

            // Traverse flight[][]
            foreach (int[] item in flights)
            {
                // Create Adjacency Matrix
                adjMatrix[item[0]][item[1]] = item[2];
            }

            // DFS Call to find shortest path
            int ans = DFSUtility(src, stops, dst, cities);

            // Return the cost
            return ans >= Int32.MaxValue ? -1 : ans;
        }

        // Driver code
        public static void Main(string[] args)
        {

            // Input flight : :Source,
            // Destination, Cost
            int[][] flights = new int[][]{
              new int[]{ 4, 1, 1 },
              new int[]{ 1, 2, 3 },
              new int[]{ 0, 3, 2 },
              new int[]{ 0, 4, 10 },
              new int[]{ 3, 1, 1 },
              new int[]{ 1, 4, 3 }
            };

            flights = new int[][]{
              new int[]{ 1, 2, 3 },
              new int[]{ 0, 3, 2 },
              new int[]{ 3, 1, 1 },
              new int[]{ 1, 3, 3 }
            };

            flights = new int[][] 
            { 
                new int[]{ 0, 1, 1 }, 
                new int[]{ 0, 2, 2 },                     
                new int[]{ 1, 3, 2 },
                new int[]{ 2, 3, 1 } 
            };

            // vec, n, stops, src, dst
            int stops = 2;
            int totalCities = 5;
            int sourceCity = 0;
            int destCity = 3;// 1;// 4;

            // Function Call
            int ans = findCheapestPrice(totalCities, flights, sourceCity, destCity, stops);

            Console.WriteLine(ans);

        }
    }
}