namespace GpsBestRoute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("EntradaGPS .txt");

                List<TestCase> testCasesList = LoadTestCases(lines);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static List<TestCase> LoadTestCases(string[] lines)
        {
            try
            {
                List<TestCase> testCasesList = new List<TestCase>();

                if (int.TryParse(lines[0], out int testCaseLine))
                {
                    Console.WriteLine(testCaseLine);

                    TestCase newTestCase = new TestCase();

                    if (int.TryParse(lines[1], out int citiesQty))
                    {
                        List<string> allCities = lines[2].Split(' ').ToList();
                        newTestCase.allCities = allCities;

                        // Get quantity of roads and each road data
                        for (int i = 3; i < lines.Length; i++)
                        {
                            if (int.TryParse(lines[i], out int roadsQty))
                            {
                                for (int j = 1; j < roadsQty; j++)
                                {
                                    string roadStartCity = lines[i + j];
                                    string roadEndCity = lines[i + j + 1];
                                    if (!int.TryParse(lines[i + j + 2], out int tripTime))
                                    {
                                        Console.WriteLine($"Erro na rota: {lines[i + j + 2]}");
                                        continue;
                                    }
                                }

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
                else
                {
                    Console.WriteLine("Quantidade de casos de testes inálido");
                }

                return testCasesList;
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
        public List<RoadData>? roadData;
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