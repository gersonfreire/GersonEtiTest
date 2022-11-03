namespace GpsBestRoute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("EntradaGPS .txt");

                if(int.TryParse(lines[0], out int testCases))
                {
                    Console.WriteLine(testCases);

                    if (int.TryParse(lines[1], out int citiesQty))  
                    {
                        List<string> cities = lines[2].Split(' ').ToList();

                        // TODO: Get roads data
                        for (int i = 3; i < lines.Length; i++)
                        {

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
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