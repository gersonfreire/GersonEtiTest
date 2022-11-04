namespace GpsBestRoute
{
    internal class Program
    {
        List<TestCase> testCasesList = new List<TestCase>();
        List<string> allCitiesList = new List<string>();

        static int[][] adjacencyMatrix; 
        static Dictionary<int[], int> map = new Dictionary<int[], int>();

        static void MainOri(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("EntradaGPS.txt");

                if ((int.TryParse(lines[0], out int testCaseQty)) && (testCaseQty > 0))
                {
                    List<TestCase> testCasesList = LoadTestCases(lines, testCaseQty);

                    // TODO: calculare best route
                    ProcessTestCases(testCasesList);
                }
                else
                {
                    Console.WriteLine($"Erro no arquivo de entrada: Quantidade de casos de testes {testCaseQty} não é um inteiro positivo!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static List<TestCase> LoadTestCases(string[] lines, int testCaseQty)
        {
            try
            {
                List<TestCase> testCasesList = new List<TestCase>();

                int testCaseCitiesQtyLineIndex = 1;

                for (int testCaseCounter = 0; testCaseCounter < testCaseQty; testCaseCounter++)
                {
                    if ((int.TryParse(lines[testCaseCitiesQtyLineIndex], out int testCaseCitiesQty)) && (testCaseCitiesQty > 0))
                    {

                        int citiesLineIndex = testCaseCitiesQtyLineIndex + 1;
                        string testCaseCitiesLine = lines[citiesLineIndex];
                        List<string>? testCaseCitiesList = testCaseCitiesLine.Trim().Split(' ').ToList();

                        int roadsQtyLineIndex = citiesLineIndex + 1;

                        if ((int.TryParse(lines[roadsQtyLineIndex], out int roadsQty)) && (roadsQty > 0))
                        {
                            int startCityLineNumber = roadsQtyLineIndex + 1;
                            int endCityLineNumber = roadsQtyLineIndex + roadsQty;

                            int testCaseLineIndex = roadsQtyLineIndex + roadsQty + 1;
                            string testCaseLine = lines[testCaseLineIndex ];

                            string startCity = testCaseLine.Trim().Split(' ')[0];
                            string endCity = testCaseLine.Trim().Split(' ')[1];

                            int firstRoadLineIndex = roadsQtyLineIndex + 1;

                            testCasesList.Add(new TestCase()
                            {
                                allCities = testCaseCitiesList,
                                roadsList = LoadRoadsList(lines, roadsQty, firstRoadLineIndex),
                                startCity = startCity,
                                endCity = endCity
                            });

                            testCaseCitiesQtyLineIndex = firstRoadLineIndex + roadsQty + 1;
                        }
                        else
                        {
                            Console.WriteLine($"Erro no arquivo de entrada: Quantidade de estradas {testCaseCitiesQty} não é um inteiro positivo!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Erro no arquivo de entrada: Quantidade de cidades {testCaseCitiesQty} não é um inteiro positivo!");
                        continue;
                    }
                }

                return testCasesList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static List<RoadData> LoadRoadsList(string[] lines, int roadsQty, int firstRoadLineIndex)
        {
            try
            {
                List<RoadData> roadsList = new List<RoadData>();

                // Get each road and add it to list 
                for (int roadsCounter = 0; roadsCounter < roadsQty; roadsCounter++)
                {
                    int roadLineIndex = firstRoadLineIndex + roadsCounter;
                    string roadLine = lines[roadLineIndex];

                    string[] roadData = roadLine.Split(' ');

                    if ((roadData.Length > 2) && (int.TryParse(roadData[2], out int tripTime)))
                    {
                        roadsList.Add(new RoadData()
                        {
                            startCity = roadData[0],
                            endCity = roadData[1],
                            tripTime = tripTime
                        });
                    }
                }

                return roadsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static void ProcessTestCases(List<TestCase> testCaseList)
        {
            try
            {
                foreach (TestCase testCase in testCaseList)
                {
                    int smallestTime = CalculateSmallestTime(testCase);


                    // TODO : print each time result
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static int CalculateSmallestTime(TestCase testCase, int lastTripTime = 0)
        {
            try
            {
                int smallestTime = 0;

                if (testCase.roadsList != null)
                {
                    // TODO: calculate smallest trip time

                    // TODO: get all possible routes and trip times
                    foreach (RoadData road in testCase.roadsList)
                    {
                        
                    }
                }

                return smallestTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        static int FindSmallestPath(int cities, int[][] roadsArray, int startCity, int distance, int stops)
        {
            // Resize Adjacency Matrix
            adjacencyMatrix = new int[cities + 1][];
            for (int i = 0; i <= cities; i++)
            {
                adjacencyMatrix[i] = new int[cities + 1];
            }

            // Traverse flight[][]
            foreach (int[] item in roadsArray)
            {
                // Create Adjacency Matrix
                adjacencyMatrix[item[0]][item[1]] = item[2];
            }

            // Algorithm to find shortest path
            int finalResult = DeepFirstSearchAlgorithm(startCity, stops, distance, cities);

            // Return the traffic/weight
            return finalResult >= Int32.MaxValue ? -1 : finalResult;
        }

        // Implement Depth First Traversal(or Search) algorithm
        static int DeepFirstSearchAlgorithm(int currentNode, int stops, int distance, int cities)
        {
            // Best cenario cases (heuristic)
            if (currentNode == distance)
            {
                return 0;
            }

            if (stops < 0)
            {
                return Int32.MaxValue;
            }

            int[] key = new int[] { currentNode, stops };

            // Is this key already exists in memory map?
            if (map.ContainsKey(key))
            {
                return map[key];
            }

            int finalResult = Int32.MaxValue;

            // Loop though adjacency matrix (origin node)
            for (int neighbour = 0; neighbour < cities; ++neighbour)
            {
                int weight = adjacencyMatrix[currentNode][neighbour];

                if (weight > 0)
                {
                    // Recursively calls itself
                    int minVal = DeepFirstSearchAlgorithm(neighbour, stops - 1, distance, cities);

                    if (minVal + weight > 0)
                    {
                        finalResult = Math.Min(finalResult, minVal + weight);
                    }
                }
                if (!map.ContainsKey(key))
                {
                    map.Add(key, 0);
                }
                map[key] = finalResult;
            }

            // Return final result
            return finalResult;
        }

        // Covert roads list to suitable array in order to use it in algorithm
        public static int[][] ConvertRoadsList(List<RoadData> roadsList, List<string> allCities)
        {
            var array2 = roadsList.ToArray();
            int[][] roadsArray = new int[array2.Length][];

            for (int i = 0; i < roadsList.Count; i++)
            {
                int startCityIndex = allCities.IndexOf(roadsList[i].startCity);
                int endCityIndex = allCities.IndexOf(roadsList[i].endCity);
                int roadTraffic = roadsList[i].tripTime;

                roadsArray[i] = new int[3];
                roadsArray[i][0] = startCityIndex;
                roadsArray[i][1] = endCityIndex;
                roadsArray[i][2] = roadTraffic;
            }

            return roadsArray;
        }

        public static int ProcessRoad(List<RoadData> roadsList, List<string> allCities)
        {
            int[][] roadsArray = ConvertRoadsList(roadsList, allCities);

            int stops = 2;
            int totalCities = 5;
            int startCity = 0;
            int endCity = 3;

            int minimalTripTime = FindSmallestPath(totalCities, roadsArray, startCity, endCity, stops);

            return minimalTripTime;
        }

        public static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("EntradaGPS.txt");

                if ((int.TryParse(lines[0], out int testCaseQty)) && (testCaseQty > 0))
                {
                    List<TestCase> testCasesList = LoadTestCases(lines, testCaseQty);

                    foreach (TestCase testCase in testCasesList)
                    {
                        int bestPathTime = ProcessRoad(testCase.roadsList, testCase.allCities);

                        testCase.smallestTripTime = bestPathTime;

                        Console.WriteLine($"O melhor tempo de viagem entre [{testCase.startCity}] e [{testCase.endCity}] é {testCase.smallestTripTime}!\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Erro no arquivo de entrada: Quantidade de casos de testes {testCaseQty} não é um inteiro positivo!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class RoadData
    {
        public string? startCity;
        public string? endCity;
        public int tripTime;
    }

    public class TestCase
    {
        public List<string>? allCities;
        public List<RoadData>? roadsList;
        public string? startCity;
        public string? endCity;
        public int smallestTripTime;
    }
}


#region Data structure
/*Entrada
 A entrada começa com uma linha contendo um inteiro T indicando o número de casos de teste. Para cada caso de teste, a entrada acontecerá da seguinte forma:

•	uma linha contendo um inteiro C, indicando o número de cidades; 
•	uma linha contendo os nomes de todas as cidades, que são nomeadas com uma letra minúscula, separadas por um espaço; 

•	uma linha contendo um inteiro R, indicando o número de estradas; 
•	R linhas, cada uma contendo os seguintes dados, separados por um espaço: 
o	uma letra minúscula representando uma cidade, em uma das pontas da estrada; uma letra minúscula representando a cidade do outro lado da estrada; 
o	um número inteiro t representando o tempo, em horas, necessário para percorrer toda a estrada (independentemente de a direção do tráfego); 
•	Finalmente, a última linha de um caso de teste conterá duas letras minúsculas, separadas por um espaço, indicando uma cidade de partida e uma cidade de destino.
Resultado 
Um inteiro M indicando o tempo mínimo necessário para viajar da cidade de partida à cidade de destino.
*/
#endregion