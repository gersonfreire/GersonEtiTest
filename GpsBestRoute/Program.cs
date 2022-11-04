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

                int testCaseCitiesQtyLineIndex = 1;

                for (int testCaseCounter = 0; testCaseCounter < testCaseQty; testCaseCounter++)
                {
                    if ((int.TryParse(lines[testCaseCitiesQtyLineIndex], out int testCaseCitiesQty)) && (testCaseCitiesQty > 0))
                    {

                        int citiesLineIndex = testCaseCitiesQtyLineIndex + 1;
                        string testCaseCitiesLine = lines[citiesLineIndex];
                        List<string>? testCaseCitiesList = testCaseCitiesLine.Split(' ').ToList();

                        int roadsQtyLineIndex = citiesLineIndex + 1;

                        if ((int.TryParse(lines[roadsQtyLineIndex], out int roadsQty)) && (roadsQty > 0))
                        {
                            int startCityLineNumber = roadsQtyLineIndex + 1;
                            int endCityLineNumber = roadsQtyLineIndex + roadsQty;

                            testCasesList.Add(new TestCase()
                            {
                                allCities = testCaseCitiesList,
                                roadsList = LoadRoadsList(lines, roadsQty, roadsQtyLineIndex),
                                startCity = lines[startCityLineNumber],
                                endCity = lines[endCityLineNumber]
                            });
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

        private static List<RoadData> LoadRoadsList(string[] lines, int roadsQty, int roadsQtyLineIndex)
        {
            try
            {
                List<RoadData> roadsList = new List<RoadData>();

                // Get each road and add it to list 
                for (int roadsCounter = 0; roadsCounter < roadsQty; roadsCounter++)
                {
                    int roadLineIndex = roadsQtyLineIndex + roadsCounter;
                    string roadLine = lines[roadLineIndex];

                    string[] roadData = roadLine.Split(' ');

                    if ((roadData.Length > 2) && (int.TryParse(roadData[2], out int tripTime)))
                    {
                        RoadData newRoad = new RoadData()
                        {
                            startCity = roadData[0],
                            endCity = roadData[0],
                            tripTime = tripTime
                        };
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