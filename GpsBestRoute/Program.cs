namespace GpsBestRoute
{
    internal class Program
    {
        List<TestCase> testCasesList = new List<TestCase>();
        List<string> allCitiesList = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("EntradaGPS.txt");

                if ((int.TryParse(lines[0], out int testCaseQty)) && (testCaseQty > 0))
                {
                    List<TestCase> testCasesList = LoadTestCases(lines, testCaseQty);                 
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

                int testCaseCitiesQtyLine = 1; 

                for (int testCaseNumber = 0; testCaseNumber < testCaseQty; testCaseNumber++)
                {
                    if ((int.TryParse(lines[testCaseCitiesQtyLine], out int testCaseCitiesQty)) && (testCaseCitiesQty > 0))
                    {
                        string testCaseAllCities = lines[testCaseCitiesQtyLine + 1];
                        List<string>? testCaseCitiesList = testCaseAllCities.Split(' ').ToList();

                        testCasesList.Add(new TestCase()
                        {
                            allCities = testCaseCitiesList,
                            //roadsList = LoadRoadsList(lines, testCaseCitiesQtyLine + 1)
                        }); 
                    }
                    else
                    {
                        Console.WriteLine($"Erro no arquivo de entrada: Quantidade de cidades {testCaseCitiesQty} não é um inteiro positivo!");
                        continue;
                    }
                }

                //if (int.TryParse(lines[0], out int testCaseQty))
                {
                    Console.WriteLine(testCaseQty);

                    if (int.TryParse(lines[1], out int allCitiesQty))
                    {

                        List<string> allCities = lines[2].Split(' ').ToList();

                        TestCase newTestCase = new TestCase();
                        newTestCase.allCities = allCities;

                        // Get quantity of roads and each road data
                        for (int i = 3; i < lines.Length; i++)
                        {
                            if (int.TryParse(lines[i], out int roadsQty))
                            {
                                newTestCase.roadsList = LoadRoadData(lines, roadsQty, i);

                                //for (int j = 1; j < roadsQty; j++)
                                //{
                                //    string roadStartCity = lines[i + j];
                                //    string roadEndCity = lines[i + j + 1];
                                //    if (!int.TryParse(lines[i + j + 2], out int tripTime))
                                //    {
                                //        Console.WriteLine($"Erro na rota: {lines[i + j + 2]}");
                                //        continue;
                                //    }

                                //    RoadData newRoadData = new RoadData()
                                //    {
                                //        startCity = roadStartCity,
                                //        endCity = roadEndCity,
                                //        tripTime = tripTime
                                //    };

                                //    newTestCase.roadsList?.Add(newRoadData);
                                //}

                                string tripRoute = lines[i + roadsQty + 1];
                                if (tripRoute.Split(' ').Length > 1)
                                {
                                    string tripStartCity = tripRoute.Split(' ')[0];
                                    string tripEndCity = tripRoute.Split(' ')[1];

                                    int smallestTimeTrip = CalcSmallestTimeTrip(tripRoute, tripStartCity, tripEndCity);

                                    testCasesList.Add(newTestCase);
                                }
                                else
                                {
                                    Console.WriteLine($"Erro na viagem: {tripRoute}");
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de cidades inálida");
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

        private static List<RoadData> LoadRoadData(string[] lines, int roadsQty, int i)
        {
            try
            {
                List<RoadData> roadsList = new List<RoadData>();

                for (int j = 1; j < roadsQty; j++)
                {
                    string roadStartCity = lines[i + j];
                    string roadEndCity = lines[i + j + 1];
                    if (!int.TryParse(lines[i + j + 2], out int tripTime))
                    {
                        Console.WriteLine($"Erro na rota: {lines[i + j + 2]}");
                        continue;
                    }

                    roadsList.Add(new RoadData()
                    {
                        startCity = roadStartCity,
                        endCity = roadEndCity,
                        tripTime = tripTime
                    });
                }

                return roadsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private static int CalcSmallestTimeTrip(string tripRoute, string tripStartCity, string tripEndCity)
        {
            throw new NotImplementedException();
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